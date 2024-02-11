using Avalonia.Controls;
using Avalonia.Interactivity;

namespace AvaloniaApplication1.Views;

public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
    }
    public void Button_Click(object sender, RoutedEventArgs args)
    {
        if (sender is Button button)
        {
            Canvas.Background = button.Background;
        }
    }
}
