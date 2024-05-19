using Avalonia.Controls;
using Avalonia.Media;
using Avalonia;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hw_12.Controls
{
    public class InverterConrolViewModel : Control
    {
        private double _radius = 3;
        public IBrush? Stroke { get; set; }
        public double StrokeThickness { get; set; }
        public string SetFonts { get; set; }
        public int CountInput { get; set; }
        public int SizeHeader { get; set; }
        public string HeaderValve { get; set; }
        public int SizeLabel { get; set; }
        public string LabelValve { get; set; }
        public string TypeValve { get; set; }
        public InverterConrolViewModel()
        {
            SizeHeader = 20;
            SizeLabel = 18;
            HeaderValve = "1";
            LabelValve = "Inverter";
            SetFonts = "Arial";
            TypeValve = "GOST";
            CountInput = 1;
        }

        public sealed override void Render(DrawingContext context)
        {
            var renderSize = Bounds.Size;

            var typeface = new Typeface(SetFonts);

            if (TypeValve == "ANSI")
            {
                var centerX = renderSize.Width / 2;
                var centerY = renderSize.Height / 2;
                double sideLength = 100;
                var point1 = new Point(0, 0); var point2 = new Point(0, sideLength); var point3 = new Point(centerX + sideLength / 2, centerY);
                context.DrawLine(new Pen(Stroke, StrokeThickness), point1, point2);
                context.DrawLine(new Pen(Stroke, StrokeThickness), point1, point3);
                context.DrawLine(new Pen(Stroke, StrokeThickness), point2, point3);

                context.DrawEllipse(null, new Pen(Stroke, StrokeThickness), new Rect(centerX + sideLength / 2 - _radius - 2, centerY - _radius - 2, (_radius + 2) * 2, (_radius + 2) * 2));
                context.DrawEllipse(Brushes.Red, new Pen(Stroke, StrokeThickness), new Rect(centerX + sideLength / 2 - _radius, centerY - _radius, _radius * 2, _radius * 2));

                var x1 = 0;
                var y1 = renderSize.Height / 2;
                context.DrawEllipse(Brushes.Blue, new Pen(Stroke, StrokeThickness), new Rect(x1 - _radius, y1 - _radius, _radius * 2, _radius * 2));

                var posLabelX = 0; var posLabelY = renderSize.Height + 5;
                var labelText = new FormattedText(
                    LabelValve,
                    CultureInfo.GetCultureInfo("en-us"),
                    FlowDirection.LeftToRight,
                    typeface,
                    SizeLabel,
                    Brushes.Black);

                string labelSize = LabelValve;
                int lsize = labelSize.Length;

                context.DrawText(labelText,
                    lsize <= 4 ? new Point(lsize, posLabelY) : new Point(posLabelX - lsize * 2, posLabelY));
            }
            else
            {
                var rect = new Rect(renderSize);
                context.DrawRectangle(null, new Pen(Stroke, StrokeThickness), rect);

                var posHeaderX = renderSize.Width / 3;
                var posHeaderY = 4; var headerText = new FormattedText(
                    HeaderValve,
                    CultureInfo.GetCultureInfo("en-us"),
                    FlowDirection.LeftToRight,
                    typeface,
                    SizeHeader,
                    Brushes.Black);
                context.DrawText(headerText, new Point(posHeaderX, posHeaderY));

                var posLabelX = 0; var posLabelY = renderSize.Height + 5;
                var labelText = new FormattedText(
                    LabelValve,
                    CultureInfo.GetCultureInfo("en-us"),
                    FlowDirection.LeftToRight,
                    typeface,
                    SizeLabel,
                    Brushes.Black);

                string labelSize = LabelValve;
                int lsize = labelSize.Length;

                context.DrawText(labelText,
                    lsize <= 4 ? new Point(lsize, posLabelY) : new Point(posLabelX - lsize * 2, posLabelY));

                var x2 = renderSize.Width;
                var y2 = renderSize.Height / 2;
                context.DrawEllipse(null, new Pen(Stroke, StrokeThickness), new Rect(x2 - _radius - 2, y2 - _radius - 2, (_radius + 2) * 2, (_radius + 2) * 2));
                context.DrawEllipse(Brushes.Red, new Pen(Stroke, StrokeThickness), new Rect(x2 - _radius, y2 - _radius, _radius * 2, _radius * 2));

                var x1 = 0;
                var y1 = renderSize.Height / 2;
                context.DrawEllipse(Brushes.Blue, new Pen(Stroke, StrokeThickness), new Rect(x1 - _radius, y1 - _radius, _radius * 2, _radius * 2));
            }

            base.Render(context);
        }
    }
}
