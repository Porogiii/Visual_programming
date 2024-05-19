using System;
using System.Collections.ObjectModel;
using System.Dynamic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;

namespace hw_12.ViewModels;

public partial class MainViewModel : ObservableObject
{
    public ObservableCollection<bool> InputValues { get; set; } = new ObservableCollection<bool>()
    {
    };

    [ObservableProperty]
    public bool? _output = false;

    public MainViewModel()
    {
    }
}
