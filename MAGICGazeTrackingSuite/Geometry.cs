using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MAGICGazeTrackingSuite
{
    class Geometry
    {
        public static PointF ClosestPointInLine(PointF p, Line2D line)
        {
            float a = line.A;
            float b = line.B;
            float c = line.C;
            float div = a * a + b * b;
            return new PointF((b * (b * p.X - a * p.Y) - a * c) / div, (a * (-b * p.X + a * p.Y) - b * c) / div);
        }

        public static bool PointInBox(PointF p, PointF topLeft, PointF botRight)
        {
            double minX = topLeft.X;
            double maxX = botRight.X;
            double minY = topLeft.Y;
            double maxY = botRight.Y;
            return minX <= p.X && maxX >= p.X && minY <= p.Y && maxY >= p.Y;
        }

        public static PointF IntersectLineAndCircle(PointF startP, PointF endP, PointF center, float rad)
        {
            // See http://stackoverflow.com/questions/1073336/circle-line-collision-detection for more details
            PointF d = endP.Subtract(startP);
            PointF f = startP.Subtract(center);
            float a = d.Dot(d);
            float b = 2 * d.Dot(f);
            float c = f.Dot(f) - rad * rad;
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
                return startP.Add(d.Multiply(t2));
            }
            return startP.Add(d.Multiply(t1));
        }

        public static PointF ClosestPointToRayInCircle(PointF center, float radius, PointF rayStart, PointF otherPointInRay)
        {
            // Return intersection of direction with the circle around gaze position
            // If there is no intersection return the closest point to the direction line in the circle
            PointF p = ClosestPointInLine(center, new Line2D(rayStart, otherPointInRay));
            float distSqr = p.Subtract(center).NormSqr();
            if (distSqr < radius * radius)
            {
                return IntersectLineAndCircle(rayStart, otherPointInRay, center, radius);
            }
            return IntersectLineAndCircle(center, p, center, radius);
        }
    }
}
