using Avalonia;
using Avalonia.Controls;
using Avalonia.Input;
using Домашнее_задание__5.Class;

namespace Домашнее_задание__5.Views;

public partial class MainView : UserControl
{
    public MainView()
    {
        InitializeComponent();
    }

    private void TappedListBox(object? sender, TappedEventArgs e)
    {
        if (e.Source is not IDataContextProvider provider) return;
        if (provider.DataContext is not Directoryies directory) return;
        if (DataContext is not ViewModels.MainViewModel viewModel) return;

        viewModel.HandleItemClick(directory);
    }

    private void TappedImage(object? sender, TappedEventArgs e)
    {
        if (e.Source is not IDataContextProvider provider) return;
        if (provider.DataContext is not FileImage image) return;
        if (DataContext is not ViewModels.MainViewModel viewModel) return;

        viewModel.HandleImageClick(image);
    }
}
