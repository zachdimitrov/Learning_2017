using System;

namespace SticksVektors1
{
    public class Point
    {
        public Point(double x, double y)
        {
            X = x;
            Y = y;
        }

        public double X { get; set; }
        public double Y { get; set; }

        public double DistanceToSquared(Point other)
        {
            double dx = other.X = this.X;
            double dy = other.Y - this.Y;

            return dx * dx + dy * dy;
        }

        public double DistanceTo(Point other)
        {
            return Math.Sqrt(DistanceToSquared(other));
        }
    }

}
