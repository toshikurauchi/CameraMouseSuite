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
        public static float Dot(PointF p1, PointF p2)
        {
            return p1.X * p2.X + p1.Y * p2.Y;
        }
        public static float Norm(PointF p)
        {
            return (float)Math.Sqrt(Dot(p, p));
        }
        public static float NormSqr(PointF p)
        {
            return Dot(p, p);
        }
        public static PointF Normalize(PointF p)
        {
            float normP = Norm(p);
            p.X = p.X / normP;
            p.Y = p.Y / normP;
            return p;
        }
        private static PointF LineFromPts(PointF p1, PointF p2) // y = ax + b. Returns (a,b)
        {
            float a = (p2.Y-p1.Y)/(p2.X-p1.X);
            return new PointF(a, p1.Y - a * p1.X);
        }
        public static PointF ClosestPointInLine(PointF p, PointF l1, PointF l2)
        {
            PointF line = LineFromPts(l1, l2);
            float a = line.X;
            float b = -1;
            float c = line.Y;
            float div = a * a + b * b;
            return new PointF((b*(b*p.X-a*p.Y)-a*c)/div, (a*(-b*p.X + a*p.Y)-b*c)/div);
        }
        public static PointF IntersectLineAndCircle(PointF startP, PointF endP, PointF center, float rad)
        {
            // See http://stackoverflow.com/questions/1073336/circle-line-collision-detection for more details
            PointF d = Subtract(endP, startP);
            PointF f = Subtract(startP, center);
            float a = Dot(d, d);
            float b = 2 * Dot(d, f);
            float c = Dot(f, f) - rad * rad;
            float discriminant = b * b - 4 * a * c;
            if (discriminant < 0)
            {
                return PointF.Empty;
            }
            discriminant = (float)Math.Sqrt(discriminant);
            float t1 = (-b - discriminant) / (2 * a);
            float t2 = (-b + discriminant) / (2 * a);
            if (t1 > t2)
            {
                float aux = t1;
                t1 = t2;
                t2 = aux;
            }
            if (t1 < 0)
            {
                return Sum(startP, Multiply(d, t2));
            }
            return Sum(startP, Multiply(d, t1));
        }
        public static PointF ClosestPointToRayInCircle(PointF center, float radius, PointF rayStart, PointF otherPointInRay)
        {
            // Return intersection of direction with the circle around gaze position
            // If there is no intersection return the closest point to the direction line in the circle
            PointF p = PointFHelper.ClosestPointInLine(center, rayStart, otherPointInRay);
            float distSqr = PointFHelper.NormSqr(PointFHelper.Subtract(p, center));
            if (distSqr < radius * radius)
            {
                return PointFHelper.IntersectLineAndCircle(rayStart, otherPointInRay, center, radius);
            }
            return PointFHelper.IntersectLineAndCircle(center, p, center, radius);
        }
    }
}
