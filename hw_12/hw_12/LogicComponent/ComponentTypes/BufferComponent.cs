using System;
using System.Collections.Generic;
using System.Linq;
using Avalonia;
using Avalonia.Media;
using Avalonia.Media.Imaging;
using Avalonia.Platform;
using hw_12.LogicComponent.Shared;

namespace hw_12.LogicComponent.ComponentTypes;

public class BufferComponent : BaseComponent
{
    public override string Name { get; } = "Буффер";
    public override int Width { get; } = 100;
    public override int Height { get; } = 100;

    private bool _lastValue = false;

    private const int InputCount = 1;
    private const int OutputCount = 1;

    private const double ConnectorRadius = 4;


    public override void Render(DrawingContext context, VisualizationTypes visualizationType)
    {
        if (visualizationType == VisualizationTypes.ANSI)
        {
            DrawAnsi(context);
        }
        else
        {
            DrawGost(context);
        }
    }

    private void DrawGost(DrawingContext context)
    {
        var asset = new Bitmap(AssetLoader.Open(new Uri("avares://hw_12/Assets/buf_gost.png")));

        context.DrawImage(asset, new Rect(0, 0, Width, Height));

        var centerX = Width / 2;
        var centerY = Height / 2;
        var inputSpacing = Height / (InputCount + 1);
        var outputSpacing = Height / (OutputCount + 1);

        // Отрисовка точек входов
        for (var i = 0; i < InputCount; i++)
        {
            var y = inputSpacing * (i + 1);
            context.DrawEllipse(Brushes.Red, null, new Avalonia.Point(35, y - 6), ConnectorRadius, ConnectorRadius);
        }

        // Отрисовка точки выхода
        context.DrawEllipse(Brushes.Blue, null, new Avalonia.Point(Width - 41, centerY - 6), ConnectorRadius, ConnectorRadius);
    }

    private void DrawAnsi(DrawingContext context)
    {
        var asset = new Bitmap(AssetLoader.Open(new Uri("avares://hw_12/Assets/buf_ansi.png")));

        context.DrawImage(asset, new Rect(0, 0, Width, Height));

        var centerX = Width / 2;
        var centerY = Height / 2;
        var inputSpacing = Height / (InputCount + 1);
        var outputSpacing = Height / (OutputCount + 1);

        // Отрисовка точек входов
        for (var i = 0; i < InputCount; i++)
        {
            var y = inputSpacing * (i + 1);
            context.DrawEllipse(Brushes.Red, null, new Avalonia.Point(38, y - 9), ConnectorRadius, ConnectorRadius);
        }

        // Отрисовка точки выхода
        context.DrawEllipse(Brushes.Blue, null, new Avalonia.Point(Width - 29, centerY - 9), ConnectorRadius, ConnectorRadius);
    }
}