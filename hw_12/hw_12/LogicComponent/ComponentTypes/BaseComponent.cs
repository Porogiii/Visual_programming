using System.Collections.Generic;
using Avalonia.Media;
using hw_12.LogicComponent.Shared;

namespace hw_12.LogicComponent.ComponentTypes;

public abstract class BaseComponent
{
    public abstract string Name { get; }
    
    public abstract int Width { get; }
    public abstract int Height { get; }

    private const double ConnectorRadius = 4;
    public abstract void Render(DrawingContext context,  VisualizationTypes visualizationType);
}