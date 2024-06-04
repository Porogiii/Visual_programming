using MathDrawer.Models;
using System.Collections.Generic;
using Avalonia;
using Avalonia.Media;
using System.Collections.ObjectModel;
namespace MathDrawer.ViewModels;

public class MainWindowViewModel : ViewModelBase
{
    public ObservableCollection<GraphData> Graphs { get; set; }
    public ObservableCollection<LegendItem> LegendItems { get; set; }

    public MainWindowViewModel()
    {
        Graphs = [];
        LegendItems = [];

        InitializeGraphData();
    }

    private void InitializeGraphData()
    {
        var graphData1 = new GraphData(
            [new Point(100, 50), new Point(150, 65)],
            Colors.Blue,
            "Line 1"
        );

        var graphData2 = new GraphData(
            [new Point(100, 120), new Point(300, 120)],
            Colors.Red,
            "Line 2"
        );

        var graphData3 = new GraphData(
            [new Point(500, 120), new Point(800, 400)],
            Colors.Yellow,
            "Line 3"
        );

        var label1Data = new LegendItem(
            Colors.Blue,
            "Line 1"
        );

        var label2Data = new LegendItem(
            Colors.Red,
            "Line 2"
        );

        var label3Data = new LegendItem(
            Colors.Yellow,
            "Line 3"
        );

        Graphs.Add(graphData1);
        Graphs.Add(graphData2);
        Graphs.Add(graphData3);

        LegendItems.Add(label1Data);
        LegendItems.Add(label2Data);
        LegendItems.Add(label3Data);
    }

    private void AddData(Point first, Point second, Colors color, string label)
    {

    }

}
