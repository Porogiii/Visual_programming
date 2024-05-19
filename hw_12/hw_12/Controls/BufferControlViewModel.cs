using Avalonia;
using Avalonia.Controls;
using Avalonia.Media;
using System.Globalization;

namespace hw_12.Controls
{
    public class BufferControlViewModel : Control
    {
        private const double DefaultRadius = 3;
        private const double DefaultStrokeThickness = 1;
        private const double DefaultBoxLength = 100;

        public IBrush? Stroke { get; set; } = Brushes.Black;
        public double StrokeThickness { get; set; } = DefaultStrokeThickness;
        public string SetFonts { get; set; } = "Arial";
        public int CountInput { get; set; } = 1;
        public int SizeHeader { get; set; } = 20;
        public string HeaderValve { get; set; } = "1";
        public int SizeLabel { get; set; } = 18;
        public string LabelValve { get; set; } = "Buffer";
        public string TypeValve { get; set; } = "GOST";
        public BufferControlViewModel() { }

        public override void Render(DrawingContext context)
        {
            var renderSize = Bounds.Size;
            var typeface = new Typeface(SetFonts);

            if (TypeValve == "ANSI")
            {
                RenderAnsi(context, renderSize, typeface);
            }
            else
            {
                RenderGost(context, renderSize, typeface);
            }

            base.Render(context);
        }

        private void RenderAnsi(DrawingContext context, Size renderSize, Typeface typeface)
        {
            var centerX = renderSize.Width / 2;
            var centerY = renderSize.Height / 2;

            var point1 = new Point(0, 0);
            var point2 = new Point(0, DefaultBoxLength);
            var point3 = new Point(centerX + DefaultBoxLength / 2, centerY);

            context.DrawLine(new Pen(Stroke, StrokeThickness), point1, point2);
            context.DrawLine(new Pen(Stroke, StrokeThickness), point1, point3);
            context.DrawLine(new Pen(Stroke, StrokeThickness), point2, point3);

            DrawCircle(context, Brushes.Blue, new Point(0, renderSize.Height / 2), DefaultRadius);
            DrawCircle(context, Brushes.Red, new Point(centerX + DefaultBoxLength / 2, centerY), DefaultRadius);

            DrawLabel(context, typeface, LabelValve, SizeLabel, new Point(0, renderSize.Height + 5));
        }

        private void RenderGost(DrawingContext context, Size renderSize, Typeface typeface)
        {
            var rect = new Rect(renderSize);
            context.DrawRectangle(null, new Pen(Stroke, StrokeThickness), rect);

            DrawText(context, typeface, HeaderValve, SizeHeader, new Point(renderSize.Width / 3, 4));

            DrawLabel(context, typeface, LabelValve, SizeLabel, new Point(0, renderSize.Height + 5));

            var circlePosition = new Point(renderSize.Width / 2 + 25, renderSize.Height / 2);
            DrawCircle(context, Brushes.Red, circlePosition, DefaultRadius);

            DrawCircle(context, Brushes.Blue, new Point(0, renderSize.Height / 2), DefaultRadius);
        }

        private void DrawText(DrawingContext context, Typeface typeface, string text, int size, Point position)
        {
            var formattedText = new FormattedText(
                text,
                CultureInfo.GetCultureInfo("en-us"),
                FlowDirection.LeftToRight,
                typeface,
                size,
                Brushes.Black);
            context.DrawText(formattedText, position);
        }

        private void DrawLabel(DrawingContext context, Typeface typeface, string text, int size, Point position)
        {
            var formattedText = new FormattedText(
                text,
                CultureInfo.GetCultureInfo("en-us"),
                FlowDirection.LeftToRight,
                typeface,
                size,
                Brushes.Black);
            context.DrawText(formattedText, position);
        }

        private void DrawCircle(DrawingContext context, IBrush brush, Point center, double radius)
        {
            context.DrawEllipse(brush, new Pen(Stroke, StrokeThickness),
                new Rect(center.X - radius, center.Y - radius, radius * 2, radius * 2));
        }
    }
}
