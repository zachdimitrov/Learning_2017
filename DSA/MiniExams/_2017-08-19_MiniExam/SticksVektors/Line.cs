using System;

namespace SticksVektors1
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
}
