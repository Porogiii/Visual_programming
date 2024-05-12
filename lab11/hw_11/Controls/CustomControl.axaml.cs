using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.Primitives;
using Avalonia.Data;
using hw_11.Struct;
using static Avalonia.AvaloniaProperty;

namespace hw_11.Controls
{
    public class CustomControl : TemplatedControl
    {
        public static readonly StyledProperty<object> UserElementProperty =
            AvaloniaProperty.Register<CustomControl, object>(nameof(UserElement), defaultBindingMode: BindingMode.TwoWay);

        public object UserElement
        {
            get => GetValue(UserElementProperty);
            set => SetValue(UserElementProperty, value);
        }

        protected override void OnApplyTemplate(TemplateAppliedEventArgs e)
        {
            base.OnApplyTemplate(e);
            var viewModel = new CustomControlViewModel(UserElement);
            DataContext = viewModel;
        }
    }
}
