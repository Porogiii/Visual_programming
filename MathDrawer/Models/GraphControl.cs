using Avalonia;
using Avalonia.Controls;
using Avalonia.Media;
using Avalonia.Rendering.SceneGraph;
using System;
using System.Collections.ObjectModel;
using System.Globalization;

namespace MathDrawer.Models;

public class GraphControl : Control
{
    public string? XAxisLabel { get; set; }
    public string? YAxisLabel { get; set; }
    public static readonly StyledProperty<ObservableCollection<GraphData>> GraphsProperty =
        AvaloniaProperty.Register<GraphControl, ObservableCollection<GraphData>>(nameof(Graphs));

    public ObservableCollection<GraphData> Graphs
    {
        get => GetValue(GraphsProperty);
        set => SetValue(GraphsProperty, value);
    }

    public static readonly StyledProperty<ObservableCollection<LegendItem>> LegendItemsProperty =
        AvaloniaProperty.Register<GraphControl, ObservableCollection<LegendItem>>(nameof(LegendItems));

    public ObservableCollection<LegendItem> LegendItems
    {
        get => GetValue(LegendItemsProperty);
        set => SetValue(LegendItemsProperty, value);
    }

    public GraphControl()
    {
        Graphs = [];
        LegendItems = [];
    }

    public override void Render(DrawingContext context)
    {
        base.Render(context);
        DrawGraphs(context);
        DrawLegend(context);
        DrawAxisLabels(context);
    }

    private void DrawGraphs(DrawingContext context)
    {
        if (Graphs == null) return;

            foreach (var graph in Graphs)
            {
                if (graph.Points == null) continue; 

                var pen = new Pen(graph.Color.ToUInt32(), 2);
                for (int i = 0; i < graph.Points.Count - 1; i++)
                {
                    var startPoint = graph.Points[i];
                    var endPoint = graph.Points[i + 1];
                    context.DrawLine(pen, startPoint, endPoint);
                }
            }
    }

    private void DrawLegend(DrawingContext context)
    {
        if (LegendItems == null) return;
        var legendItems = LegendItems;
        if (legendItems == null || legendItems.Count == 0) return;

        var legendStartX = 0;
        var legendStartY = 0;
        var legendItemHeight = 20;
        var legendItemSpacing = 10;

        for (int i = 0; i < legendItems.Count; i++)
        {
            var item = legendItems[i];
            var rect = new Rect(legendStartX, legendStartY + i * (legendItemHeight + legendItemSpacing), 10, 10);
            context.DrawRectangle(new SolidColorBrush(item.Color), null, rect);
            
            var fontColor = new SolidColorBrush(Colors.White);
            
            var formattedText = new FormattedText(
                item.Label,
                CultureInfo.CurrentCulture,
                FlowDirection.LeftToRight,
                new Typeface("Arial"),
                12, 
                fontColor
            );
            context.DrawText(formattedText, new Point(legendStartX + 20, legendStartY + i * (legendItemHeight + legendItemSpacing)));
        }
    }
    private void DrawAxisLabels(DrawingContext context)
    {
        // Отрисовка названия оси X
        if (!string.IsNullOrEmpty(XAxisLabel))
        {
            var xAxisLabelText = new FormattedText(
                XAxisLabel,
                CultureInfo.CurrentCulture,
                FlowDirection.LeftToRight,
                new Typeface("Arial"),
                12,
                Brushes.Yellow
            );
            var xAxisLabelPosition = new Point(Bounds.Width / 2 - xAxisLabelText.Width / 2, Bounds.Height - 15);
            context.DrawText(xAxisLabelText, xAxisLabelPosition);
        }

        // Отрисовка названия оси Y
        if (!string.IsNullOrEmpty(YAxisLabel))
        {
            var yAxisLabelText = new FormattedText(
                YAxisLabel,
                CultureInfo.CurrentCulture,
                FlowDirection.LeftToRight,
                new Typeface("Arial"),
                12,
                Brushes.Yellow
            );
            var yAxisLabelPosition = new Point(10, Bounds.Height / 2 - yAxisLabelText.Height / 2);
            context.DrawText(yAxisLabelText, yAxisLabelPosition);
        }
    }
}

public class GraphData
{
    public ObservableCollection<Point> Points { get; set; }
    public Color Color { get; set; }
    public string? Label { get; set; }

    public GraphData()
    {
        Points = [];
    }

    public GraphData(ObservableCollection<Point> points, Color color, string label)
    {
        Points = points;
        Color = color;
        Label = label;
    }
}

public class LegendItem
{
    public Color Color { get; set; }
    public string Label { get; set; }

    public LegendItem(Color color, string label)
    {
        Color = color;
        Label = label;
    }
}