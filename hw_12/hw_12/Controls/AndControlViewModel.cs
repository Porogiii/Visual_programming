using Avalonia;
using Avalonia.Controls;
using Avalonia.Media;
using System.Globalization;

namespace hw_12.Controls
{
    public class AndControlViewModel : Control
    {
        private readonly double _radius = 3;
        private readonly double _defaultInterval = 6;

        public IBrush? Stroke { get; set; } = Brushes.Black;
        public double StrokeThickness { get; set; }
        public string SetFonts { get; set; } = "Arial";
        public int CountInput { get; set; } = 2; 
        public int SizeHeader { get; set; } = 20;
        public int SizeLabel { get; set; } = 18;
        public string HeaderValve { get; set; } = "&";
        public string LabelValve { get; set; } = "AND";
        public string TypeValve { get; set; } = "GOST"; 
        public bool IsSelected { get; set; }

        private static Typeface CreateTypeface(string font) => new Typeface(font);

        public override void Render(DrawingContext context)
        {
            var strokeColor = IsSelected ? Brushes.Green : Stroke;
            var renderSize = Bounds.Size;

            var typeface = CreateTypeface(SetFonts);

            if (TypeValve == "ANSI")
            {
                DrawAnsiStyle(context, strokeColor, typeface, renderSize);
            }
            else
            {
                DrawGostStyle(context, strokeColor, typeface, renderSize);
            }
        }

        private void DrawAnsiStyle(DrawingContext context, IBrush strokeColor, Typeface typeface, Size renderSize)
        {
            var startX = new Point(35, 10);
            var endY = new Point(35, 80);
            var lineX = new Point(0, 10);
            var lineY = new Point(0, 80);

            var pathGeometry = new PathGeometry
            {
                Figures = new PathFigures
                {
                    new PathFigure
                    {
                        StartPoint = startX,
                        IsClosed = false,
                        IsFilled = true,
                        Segments = new PathSegments
                        {
                            new ArcSegment
                            {
                                Point = endY,
                                Size = new Size(1, 1),
                            }
                        }
                    }
                }
            };
            context.DrawGeometry(null, new Pen(strokeColor, StrokeThickness), pathGeometry);

            context.DrawLine(new Pen(strokeColor, StrokeThickness), lineX, startX);
            context.DrawLine(new Pen(strokeColor, StrokeThickness), lineY, endY);
            context.DrawLine(new Pen(strokeColor, StrokeThickness), lineX, lineY);

            var x1 = 0;
            var y1 = 42;
            var interval = _defaultInterval;
            DrawInputs(context, x1, y1, interval);

            var x2 = 70;
            var y2 = 44;
            context.DrawEllipse(Brushes.Red, new Pen(strokeColor, StrokeThickness),
                new Rect(x2 - _radius, y2 - _radius, _radius * 2, _radius * 2));

            var labelPositionY = renderSize.Height - 15;
            DrawText(context, typeface, LabelValve, SizeLabel, new Point(0, labelPositionY));
        }

        private void DrawGostStyle(DrawingContext context, IBrush strokeColor, Typeface typeface, Size renderSize)
        {
            var rect = new Rect(renderSize);
            context.DrawRectangle(null, new Pen(strokeColor, StrokeThickness), rect);

            var headerPosition = new Point(renderSize.Width / 3, 4);
            DrawText(context, typeface, HeaderValve, SizeHeader, headerPosition);

            var x1 = 0;
            var y1 = renderSize.Height / 2;
            var interval = _defaultInterval;
            DrawInputs(context, x1, y1, interval);

            var x2 = renderSize.Width;
            var y2 = renderSize.Height / 2;
            context.DrawEllipse(Brushes.Red, new Pen(strokeColor, StrokeThickness),
                new Rect(x2 - _radius, y2 - _radius, _radius * 2, _radius * 2));

            var labelPositionY = renderSize.Height + 5;
            DrawText(context, typeface, LabelValve, SizeLabel, new Point(0, labelPositionY));
        }

        private void DrawInputs(DrawingContext context, double x, double y, double interval)
        {
            for (int i = 0; i < CountInput; i++)
            {
                context.DrawEllipse(Brushes.Blue, new Pen(Stroke, StrokeThickness),
                    i % 2 == 0
                        ? new Rect(x - _radius, y - interval - _radius, _radius * 2, _radius * 2)
                        : new Rect(x - _radius, y + interval - _radius, _radius * 2, _radius * 2));
                interval += _defaultInterval;
            }
        }

        private void DrawText(DrawingContext context, Typeface typeface, string text, double fontSize, Point position)
        {
            var formattedText = new FormattedText(
                text,
                CultureInfo.GetCultureInfo("en-us"),
                FlowDirection.LeftToRight,
                typeface,
                fontSize,
                Brushes.Black);
            context.DrawText(formattedText, position);
        }
    }
}
