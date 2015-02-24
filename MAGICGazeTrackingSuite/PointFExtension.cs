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
        public static PointF LineTo(this PointF p1, PointF p2) // y = ax + b. Returns (a,b)
        {
            float a = (p2.Y-p1.Y)/(p2.X-p1.X);
            return new PointF(a, p1.Y - a * p1.X);
        }
        public static PointF HorizontalLine(this PointF p)
        {
            return p.LineTo(p.Add(new Point(1,0)));
        }
        public static PointF IntersectLine(this PointF line1, PointF line2)
        {
            if (line1.X - line2.X == 0) // Parallel
            {
                return PointF.Empty;
            }
            float x = (line2.Y - line1.Y) / (line1.X - line2.X);
            float y = line1.X * x + line1.Y;
            return new PointF(x, y);
        }
        public static PointF VerticalLine(this PointF p)
        {
            return p.LineTo(p.Add(new Point(0,1)));
        }
        public static float Angle(this PointF v1, PointF v2)
        {
            return (float) (Math.Acos(v1.Normalize().Dot(v2.Normalize())) * 180 / Math.PI);
        }
        public static PointF ClosestPointInLine(this PointF p, PointF l1, PointF l2)
        {
            PointF line = l1.LineTo(l2);
            float a = line.X;
            float b = -1;
            float c = line.Y;
            float div = a * a + b * b;
            return new PointF((b*(b*p.X-a*p.Y)-a*c)/div, (a*(-b*p.X + a*p.Y)-b*c)/div);
        }
        public static bool InBox(this PointF p, PointF topLeft, PointF botRight)
        {
            double minX = topLeft.X;
            double maxX = botRight.X;
            double minY = topLeft.Y;
            double maxY = botRight.Y;
            return minX <= p.X && maxX >= p.X && minY <= p.Y && maxY >= p.Y;
        }
        public static PointF IntersectLineAndCircle(this PointF startP, PointF endP, PointF center, float rad)
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
                return Add(startP, Multiply(d, t2));
            }
            return Add(startP, Multiply(d, t1));
        }
        public static PointF ClosestPointToRayInCircle(this PointF center, float radius, PointF rayStart, PointF otherPointInRay)
        {
            // Return intersection of direction with the circle around gaze position
            // If there is no intersection return the closest point to the direction line in the circle
            PointF p = PointFExtension.ClosestPointInLine(center, rayStart, otherPointInRay);
            float distSqr = PointFExtension.NormSqr(PointFExtension.Subtract(p, center));
            if (distSqr < radius * radius)
            {
                return PointFExtension.IntersectLineAndCircle(rayStart, otherPointInRay, center, radius);
            }
            return PointFExtension.IntersectLineAndCircle(center, p, center, radius);
        }
    }
}
