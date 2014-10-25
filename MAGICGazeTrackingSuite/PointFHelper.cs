using System;
using System.Drawing;

namespace MAGICGazeTrackingSuite
{
    class PointFHelper
    {
        public static PointF Sum(PointF p1, PointF p2)
        {
            return new PointF(p1.X + p2.X, p1.Y + p2.Y);
        }
        public static PointF Subtract(PointF p1, PointF p2)
        {
            return new PointF(p1.X - p2.X, p1.Y - p2.Y);
        }
        public static PointF Multiply(PointF p, float s)
        {
            return Multiply(p, s, s);
        }
        public static PointF Multiply(PointF p, float sx, float sy)
        {
            return new PointF(p.X * sx, p.Y * sy);
        }
        public static PointF Divide(PointF p, float s)
        {
            return Divide(p, s, s);
        }
        public static PointF Divide(PointF p, float sX, float sY)
        {
            return new PointF(p.X / sX, p.Y / sY);
        }
        public static double Dot(PointF p1, PointF p2)
        {
            return p1.X * p2.X + p1.Y * p2.Y;
        }
        public static double Norm(PointF p)
        {
            return Math.Sqrt(Dot(p, p));
        }
        public static double NormSqr(PointF p)
        {
            return Dot(p, p);
        }
        public static PointF Normalize(PointF p)
        {
            double normP = Norm(p);
            p.X = p.X / (float)normP;
            p.Y = p.Y / (float)normP;
            return p;
        }
    }
}
