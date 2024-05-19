using Avalonia;
using Avalonia.Controls;
using Avalonia.Media;
using System;
using System.Globalization;

namespace hw_12.Controls
{
    public class AndNotControlViewModel : Control
    {
        private const double DefaultRadius = 3;
        private const double DefaultStrokeThickness = 1;
        private const double DefaultInterval = 6;

        public IBrush? Stroke { get; set; } = Brushes.Black;
        public double StrokeThickness { get; set; } = DefaultStrokeThickness;
        public string SetFonts { get; set; } = "Arial";
        public int CountInput { get; set; } = 2;
        public int SizeHeader { get; set; } = 20;
        public int SizeLabel { get; set; } = 18;
        public string HeaderValve { get; set; } = "&";
        public string LabelValve { get; set; } = "AND-NOT";
        public string TypeValve { get; set; } = "GOST";
        public AndNotControlViewModel() { }

        public override void Render(DrawingContext context)
        {
            var renderSize = Bounds.Size;
            var typeface = new Typeface(SetFonts);

            if (TypeValve == "ANSI")
            {
                DrawAnsi(context, renderSize, typeface);
            }
            else
            {
                DrawGost(context, renderSize, typeface);
            }

            base.Render(context);
        }

        private void DrawAnsi(DrawingContext context, Size renderSize, Typeface typeface)
        {
            var startPoint = new Point(35, 10);
            var endPoint = new Point(35, 80);

            var pathGeometry = new PathGeometry
            {
                Figures = new PathFigures
                {
                    new PathFigure
                    {
                        StartPoint = startPoint,
                        IsClosed = false,
                        IsFilled = true,
                        Segments = new PathSegments
                        {
                            new ArcSegment
                            {
                                Point = endPoint,
                                Size = new Size(1, 1),
                            }
                        }
                    }
                }
            };

            context.DrawGeometry(null, new Pen(Stroke, StrokeThickness), pathGeometry);

            DrawAnsiLines(context, Stroke, StrokeThickness);
            DrawLabel(context, typeface, LabelValve, SizeLabel, new Point(0, renderSize.Height - 15));

            DrawInputPoints(context, 0, 42, DefaultInterval, DefaultRadius, CountInput);
            DrawOutputPoint(context, new Point(70, 44), DefaultRadius, Brushes.Red);
        }

        private void DrawAnsiLines(DrawingContext context, IBrush stroke, double thickness)
        {
            var lineX = new Point(0, 10);
            var lineY = new Point(0, 80);

            context.DrawLine(new Pen(stroke, thickness), lineX, new Point(35, 10));
            context.DrawLine(new Pen(stroke, thickness), lineY, new Point(35, 80));
            context.DrawLine(new Pen(stroke, thickness), lineX, lineY);
        }

        private void DrawGost(DrawingContext context, Size renderSize, Typeface typeface)
        {
            var rect = new Rect(renderSize);
            context.DrawRectangle(null, new Pen(Stroke, StrokeThickness), rect);

            var headerPosition = new Point(renderSize.Width / 3, 4);
            DrawText(context, typeface, HeaderValve, SizeHeader, headerPosition);

            var labelPositionY = renderSize.Height + 5;
            DrawText(context, typeface, LabelValve, SizeLabel, new Point(0, labelPositionY));

            DrawOutputPoint(context, new Point(renderSize.Width / 2 + 25, renderSize.Height / 2), DefaultRadius, Brushes.Red);

            DrawInputPoints(context, 0, renderSize.Height / 2, 10, DefaultRadius, CountInput);
        }

        private void DrawInputPoints(DrawingContext context, double x, double y, double interval, double radius, int count)
        {
            for (int i = 0; i < count; i++)
            {
                var position = i % 2 == 0
                    ? new Rect(x - radius, y - interval - radius, radius * 2, radius * 2)
                    : new Rect(x - radius, y + interval - radius, radius * 2, radius * 2);

                context.DrawEllipse(Brushes.Blue, new Pen(Stroke, StrokeThickness), position);
                interval += DefaultInterval;
            }
        }

        private void DrawOutputPoint(DrawingContext context, Point position, double radius, IBrush color)
        {
            context.DrawEllipse(null, new Pen(Stroke, StrokeThickness),
                new Rect(position.X - radius - 2, position.Y - radius - 2, (radius + 2) * 2, (radius + 2) * 2));
            context.DrawEllipse(color, new Pen(Stroke, StrokeThickness),
                new Rect(position.X - radius, position.Y - radius, radius * 2, radius * 2));
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

        private void DrawLabel(DrawingContext context, Typeface typeface, string text, double fontSize, Point position)
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
