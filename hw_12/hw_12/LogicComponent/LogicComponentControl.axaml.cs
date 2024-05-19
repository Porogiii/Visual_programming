using Avalonia;
using Avalonia.Controls;
using Avalonia.Data;
using Avalonia.Interactivity;
using Avalonia.Media;
using hw_12.LogicComponent.ComponentTypes;
using hw_12.LogicComponent.Shared;
using System;
using System.Collections.ObjectModel;
using System.Collections.Specialized;

namespace hw_12.LogicComponent
{
    public partial class LogicComponentControl : Control
    {
        public static readonly StyledProperty<BaseComponent> LogicComponentProperty =
            AvaloniaProperty.Register<LogicComponentControl, BaseComponent>(nameof(LogicComponent));

        public static readonly StyledProperty<VisualizationTypes> VisualizationTypeProperty =
            AvaloniaProperty.Register<LogicComponentControl, VisualizationTypes>(nameof(VisualizationType), defaultValue: VisualizationTypes.ANSI);

        public static readonly StyledProperty<ObservableCollection<bool>> InputValuesProperty =
            AvaloniaProperty.Register<LogicComponentControl, ObservableCollection<bool>>(nameof(InputValues), defaultBindingMode: BindingMode.TwoWay);

        public static readonly StyledProperty<bool> OutputValueProperty =
            AvaloniaProperty.Register<LogicComponentControl, bool>(nameof(OutputValue), defaultBindingMode: BindingMode.TwoWay);

        public static readonly StyledProperty<bool> IsSelectedProperty =
            AvaloniaProperty.Register<LogicComponentControl, bool>(nameof(IsSelected), false, defaultBindingMode: BindingMode.TwoWay);

        public BaseComponent LogicComponent
        {
            get => GetValue(LogicComponentProperty);
            set => SetValue(LogicComponentProperty, value);
        }

        public VisualizationTypes VisualizationType
        {
            get => GetValue(VisualizationTypeProperty);
            set => SetValue(VisualizationTypeProperty, value);
        }

        public ObservableCollection<bool> InputValues
        {
            get => GetValue(InputValuesProperty);
            set => SetValue(InputValuesProperty, value);
        }

        public bool OutputValue
        {
            get => GetValue(OutputValueProperty);
            set => SetValue(OutputValueProperty, value);
        }

        public bool IsSelected
        {
            get => GetValue(IsSelectedProperty);
            set => SetValue(IsSelectedProperty, value);
        }

        public LogicComponentControl()
        {
            Loaded += (sender, e) =>
            {
                MinWidth = MinHeight = 100;
                Margin = new Thickness(5);
                Width = LogicComponent.Width;
                Height = LogicComponent.Height;
                Tapped += (s, ev) => { IsSelected = !IsSelected; InvalidateVisual(); };
                InputValues.CollectionChanged += (s, ev) => InvalidateVisual();
            };
        }

        public override void Render(DrawingContext context)
        {
            base.Render(context);
            LogicComponent.Render(context, VisualizationType);
            if (IsSelected)
                context.DrawRectangle(new Pen(Brushes.Black, 2), new Rect(0, 0, 100, 100));
        }
    }
}
