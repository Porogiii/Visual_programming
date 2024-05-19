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
    public class OrNotControlViewModel : Control
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
        public OrNotControlViewModel()
        {
            SizeHeader = 20;
            SizeLabel = 18;
            HeaderValve = "1";
            LabelValve = "NOR";
            SetFonts = "Arial";
            TypeValve = "GOST";
            CountInput = 2;

        }

        public sealed override void Render(DrawingContext context)
        {
            var renderSize = Bounds.Size;

            var typeface = new Typeface(SetFonts);

            if (TypeValve == "ANSI")
            {
                var startX = new Point(35, 10);
                var endY = new Point(35, 80);
                var lineX = new Point(0, 10);
                var lineY = new Point(0, 80);

                var pathGeometry = new PathGeometry();
                var pathFigure = new PathFigure
                {
                    StartPoint = startX,
                    IsClosed = false,
                    IsFilled = true
                };
                pathFigure.Segments?.Add(new ArcSegment
                {
                    Point = endY,
                    Size = new Size(1, 1),
                });
                pathGeometry.Figures?.Add(pathFigure);
                context.DrawGeometry(null, new Pen(Stroke, StrokeThickness), pathGeometry);

                context.DrawLine(new Pen(Stroke, StrokeThickness), lineX, startX);
                context.DrawLine(new Pen(Stroke, StrokeThickness), lineY, endY);

                var pathGeometry2 = new PathGeometry();
                var pathFigure2 = new PathFigure
                {
                    StartPoint = new Point(0, 10),
                    IsClosed = false,
                    IsFilled = true
                };
                pathFigure2.Segments?.Add(new ArcSegment
                {
                    Point = new Point(0, 80),
                    Size = new Size(50, 50),
                });
                pathGeometry2.Figures?.Add(pathFigure2);
                context.DrawGeometry(null, new Pen(Stroke, StrokeThickness), pathGeometry2);

                var posLabelX = 0; var posLabelY = renderSize.Height - 15;
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

                var x1 = 14;
                var y1 = 42;
                double interval = 6;
                for (int i = 0; i < CountInput; i++)
                {
                    if (CountInput <= 1)
                    {
                        CountInput = 2;
                        i = 0;
                        continue;
                    }

                    context.DrawEllipse(Brushes.Blue, new Pen(Stroke, StrokeThickness),
                        i % 2 == 0
                            ? new Rect(x1 - _radius, y1 - interval - _radius, _radius * 2, _radius * 2)
                            : new Rect(x1 - _radius, y1 + interval - _radius, _radius * 2, _radius * 2));

                    interval += 8;
                }

                var x2 = 70;
                var y2 = 44;
                context.DrawEllipse(null, new Pen(Stroke, StrokeThickness), new Rect(x2 - _radius - 2, y2 - _radius - 2, (_radius + 2) * 2, (_radius + 2) * 2));
                context.DrawEllipse(Brushes.Red, new Pen(Stroke, StrokeThickness), new Rect(x2 - _radius, y2 - _radius, _radius * 2, _radius * 2));
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
                double interval = 10;
                for (int i = 0; i < CountInput; i++)
                {
                    if (CountInput <= 1)
                    {
                        CountInput = 2;
                        i = 0;
                        continue;
                    }

                    context.DrawEllipse(Brushes.Blue, new Pen(Stroke, StrokeThickness),
                        i % 2 == 0
                            ? new Rect(x1 - _radius, y1 - interval - _radius, _radius * 2, _radius * 2)
                            : new Rect(x1 - _radius, y1 + interval - _radius, _radius * 2, _radius * 2));

                    interval += 9;
                }
            }

            base.Render(context);
        }
    }
}
