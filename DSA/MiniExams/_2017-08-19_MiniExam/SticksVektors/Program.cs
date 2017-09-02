using System;
using System.Linq;

namespace SticksVektors
{
    public class Line
    {
        public Line(Point p1, Point p2)
        {
            P1 = p1;
            P2 = p2;
        }

        public Point P1 { get; set; }
        public Point P2 { get; set; }

        public double A
        {
            get
            {
                double aa = 0;
                double dx = P2.X - P1.X;
                double dy = P2.Y - P1.Y;
                if (dx != 0)
                {
                    aa = dy / dx;
                }

                return aa;
            }
        }

        public double B
        {
            get
            {
                return P1.Y - this.A * P1.X;
            }
        }

        public Point Intersection(Line other)
        {
            double x = 0;
            double y = 0;

            if ((other.P1.Y == other.P2.Y && this.P1.Y == this.P2.Y) ||
                (other.P1.X == other.P2.X && this.P1.X == this.P2.X))
            {
                throw new Exception("No triangle.");
            }

            if (other.P1.Y == other.P2.Y && this.P1.Y != this.P2.Y)
            {
                y = other.P1.Y;
                x = (y - this.B) / this.A;
                return new Point(x, y);
            }

            if (other.P1.X == other.P2.X && this.P1.X != this.P2.X)
            {
                x = other.P1.X;
                y = this.A * x + this.B;
                return new Point(x, y);
            }

            if (this.P1.Y == this.P2.Y && other.P1.Y != other.P2.Y)
            {
                y = this.P1.Y;
                x = (y - other.B) / other.A;
                return new Point(x, y);
            }

            if (this.P1.X == this.P2.X && other.P1.X != other.P2.X)
            {
                x = this.P1.X;
                y = other.A * x + other.B;
                return new Point(x, y);
            }

            if (this.A != other.A)
            {
                x = (other.B - this.B) / (this.A - other.A);
            }

            y = this.A * x + this.B;

            return new Point(x, y);
        }
    }

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

    class Program
    {
        static void Main(string[] args)
        {
            Line l1 = GenerateLine();
            Line l2 = GenerateLine();
            Line l3 = GenerateLine();

            Point p1;
            Point p2;
            Point p3;

            try
            {
                p1 = l1.Intersection(l2);
                p2 = l2.Intersection(l3);
                p3 = l3.Intersection(l1);
            }
            catch(Exception ex)
            {
                if (ex.Message == "No triangle.")
                {
                    Console.WriteLine(ex.Message);
                }

                return;
            }

            double area = Math.Abs(0.5 * (p1.X * (p2.Y - p3.Y) + p2.X * (p3.Y - p1.Y) + p3.X * (p1.Y - p2.Y)));

            if (double.IsNaN(area) || double.IsInfinity(area))
            {

                Console.WriteLine("No triangle.");
            }
            else
            {
                Console.WriteLine("{0:F3}", area);
            }
        }

        private static Line GenerateLine()
        {
            double[] p = Console.ReadLine()
                .Split(' ')
                .Select(double.Parse)
                .ToArray();

            Line A = new Line(new Point(p[0], p[1]), new Point(p[2], p[3]));
            return A;
        }
    }
}
