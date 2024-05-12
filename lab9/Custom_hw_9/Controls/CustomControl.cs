using System;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.Primitives;
using Avalonia.Input;

namespace Custom_hw_9.Controls
{
    public class CustomControl: TemplatedControl
    {
        public static readonly StyledProperty<bool> IsOpenProperty =
     AvaloniaProperty.Register<CustomControl, bool>(nameof(IsOpen));

        public bool IsOpen
        {
            get => GetValue(IsOpenProperty);
            set => SetValue(IsOpenProperty, value);
        }

        protected override void OnApplyTemplate(TemplateAppliedEventArgs e)
        {
            var btn = e.NameScope.Find<Button>("ClickableButton");
            btn.Tapped += Button_Tapped;
        }

        private void Button_Tapped(object? sender, TappedEventArgs e)
        {
            IsOpen = !IsOpen;
        }
    }
}
