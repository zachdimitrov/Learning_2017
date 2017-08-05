using System;
using System.Linq;

namespace Heights
{
    class Program
    {
        static void Main(string[] args)
        {
            double[] x = Console.ReadLine()
                .Split(' ')
                .Select(double.Parse)
                .ToArray();

            double[] y = Console.ReadLine()
                .Split(' ')
                .Select(double.Parse)
                .ToArray();

            double[] z = Console.ReadLine()
                .Split(' ')
                .Select(double.Parse)
                .ToArray();

            double area = (x[0] * (y[1] - z[1]) + y[0] * (z[1] - x[1]) + z[0] * (x[1] - y[1])) * 0.5;

            double yz = GetLength(y, z);
            Console.WriteLine("{1:F}", 2, Math.Abs((2 * area) / yz));

            double zx = GetLength(z, x);
            Console.WriteLine("{1:F}", 2, Math.Abs((2 * area) / zx));

            double xy = GetLength(x, y);
            Console.WriteLine("{1:F}", 2, Math.Abs((2 * area) / xy));
        }

        private static double GetLength(double[] x, double[] y)
        {
            return Math.Sqrt((x[0] - y[0]) * (x[0] - y[0]) + (x[1] - y[1]) * (x[1] - y[1]));
        }
    }
}
