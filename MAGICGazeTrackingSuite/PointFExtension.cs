using System;
using System.Drawing;

namespace MAGICGazeTrackingSuite
{
    public static class PointFExtension
    {
        public static PointF Add(this PointF p1, PointF p2)
        {
            return new PointF(p1.X + p2.X, p1.Y + p2.Y);
        }
        public static PointF Subtract(this PointF p1, PointF p2)
        {
            return new PointF(p1.X - p2.X, p1.Y - p2.Y);
        }
        public static PointF Multiply(this PointF p, float s)
        {
            return Multiply(p, s, s);
        }
        public static PointF Multiply(this PointF p, float sx, float sy)
        {
            return new PointF(p.X * sx, p.Y * sy);
        }
        public static PointF Divide(this PointF p, float s)
        {
            return Divide(p, s, s);
        }
        public static PointF Divide(this PointF p, float sX, float sY)
        {
            return new PointF(p.X / sX, p.Y / sY);
        }
        public static float Dot(this PointF p1, PointF p2)
        {
            return p1.X * p2.X + p1.Y * p2.Y;
        }
        public static float Norm(this PointF p)
        {
            return (float)Math.Sqrt(Dot(p, p));
        }
        public static float NormSqr(this PointF p)
        {
            return Dot(p, p);
        }
        public static float DistSqr(this PointF p1, PointF p2)
        {
            return PointFExtension.NormSqr(PointFExtension.Subtract(p1, p2));
        }
        public static float Dist(this PointF p1, PointF p2)
        {
            return (float)Math.Sqrt(PointFExtension.DistSqr(p1, p2));
        }
        public static PointF Normalize(this PointF p)
        {
            float normP = Norm(p);
            p.X = p.X / normP;
            p.Y = p.Y / normP;
            return p;
        }
        public static float Angle(this PointF v1, PointF v2)
        {
            return (float) (Math.Acos(v1.Normalize().Dot(v2.Normalize())) * 180 / Math.PI);
        }
    }
}
