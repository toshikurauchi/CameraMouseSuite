using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace MAGICGazeTrackingSuite
{
    public class Line2D // Line defined by eq: ax + by + c = 0
    {
        public Line2D(float a, float b, float c)
        {
            A = a;
            B = b;
            C = c;
        }

        public Line2D(PointF p1, PointF p2)
        {
            if (p1.Equals(p2))
            {
                throw new ArgumentException("Points are equal");
            }
            if (p1.X == p2.X)
            {
                A = 1;
                B = 0;
                C = -p1.X;
            }
            else
            {
                A = (p2.Y - p1.Y) / (p2.X - p1.X);
                B = -1;
                C = p1.Y - A * p1.X;
            }
        }

        public static Line2D HorizontalLine(PointF p)
        {
            return new Line2D(0, 1, -p.Y);
        }

        public static Line2D VerticalLine(PointF p)
        {
            return new Line2D(1, 0, -p.X);
        }

        public PointF Intersect(Line2D other)
        {
            float x = B * other.C - other.B * C;
            float y = other.A * C - A * other.C;
            float w = A * other.B - other.A * B;
            if (w == 0)
            {
                return PointF.Empty;
            }
            return new PointF(x/w, y/w);
        }

        public float A { get; set; }
        public float B { get; set; }
        public float C { get; set; }
    }
}
