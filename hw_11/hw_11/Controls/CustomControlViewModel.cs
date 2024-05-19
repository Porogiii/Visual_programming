using Avalonia.Controls;
using Avalonia.Layout;
using CommunityToolkit.Mvvm.ComponentModel;
using hw_11.Struct;
using System;
using System.Collections.ObjectModel;
using System.Linq;

namespace hw_11.Controls
{
    public partial class CustomControlViewModel : ObservableObject
    {
        private readonly object _userElement;

        public ObservableCollection<object> Items { get; } = new();

        [ObservableProperty] private object _content;

        public CustomControlViewModel(object userElement)
        {
            _userElement = userElement;
            ParseUserObject(userElement);

            var topLevelExpander = CreateExpander(Items);
            _content = topLevelExpander;
        }

        private void ParseUserObject(object obj)
        {
            Items.Add(obj.GetType().Name);
            AddProperties(obj, Items);
        }

        private void AddProperties(object obj, ObservableCollection<object> items)
        {
            var properties = obj.GetType().GetProperties();
            foreach (var property in properties)
            {
                var propertyValue = property.GetValue(obj);
                var propertyName = property.Name;
                var nodeTitle = $"{propertyName}";
                var displayAttribute = (DisplayAttribute)Attribute.GetCustomAttribute(property, typeof(DisplayAttribute));

                if (displayAttribute != null)
                {
                    if (propertyValue != null)
                    {
                        if (propertyValue.GetType().IsClass && propertyValue.GetType() != typeof(string))
                        {
                            var subItems = new ObservableCollection<object>();
                            subItems.Add(nodeTitle);
                            AddProperties(propertyValue, subItems);
                            items.Add(subItems);
                        }
                        else
                        {
                            items.Add($"{nodeTitle} - {propertyValue}");
                        }
                    }
                }
            }
        }

        private void FormContent(Expander? parent, ObservableCollection<object> items)
        {
            var itemsControl = new ItemsControl();

            foreach (var item in items)
            {
                var content = item is ObservableCollection<object> subItems
                    ? (object)CreateExpander(subItems)
                    : new TextBlock { Text = item.ToString(), HorizontalAlignment = HorizontalAlignment.Stretch };

                itemsControl.Items.Add(content);
            }

            if (parent == null)
            {
                _content = itemsControl;
            }
            else
            {
                if (parent is Expander expander)
                {
                    expander.Content = itemsControl;
                }
            }
        }

        private Expander CreateExpander(ObservableCollection<object> items)
        {
            var expander = new Expander
            {
                Header = items[0].ToString(),
                Margin = new Avalonia.Thickness(10),
                HorizontalAlignment = HorizontalAlignment.Center
            };

            FormContent(expander, new ObservableCollection<object>(items.Skip(1)));

            return expander;
        }
    }
}
