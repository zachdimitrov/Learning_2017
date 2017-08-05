using System;

using System.Linq;

namespace Beach
{
    class Program
    {
        static void Main(string[] args)
        {
            var steve = Console.ReadLine()
                .Split(' ')
                .Select(double.Parse)
                .ToArray();

            var ellen = Console.ReadLine()
                .Split(' ')
                .Select(double.Parse)
                .ToArray();

            double sx = steve[0];
            double sy = steve[1];
            double sv = steve[2];

            double ex = ellen[0];
            double ey = ellen[1];
            double ev = ellen[2];

            double time = double.MaxValue;
            double bestTime = 0;

            for (int i = 0; i <= Math.Abs(sx - ex); i++)
            {
                double steveDist = Math.Sqrt((Math.Abs(sx - ex) - i) * (Math.Abs(sx - ex) - i) + (sy * sy));
                double ellenDist = Math.Sqrt((i*i) + (ey * ey));

                bestTime = steveDist / sv + ellenDist / ev;

                if (time > bestTime)
                {
                    time = bestTime;
                }
            }
            Console.WriteLine("{1:F}", 2, time);
        }
    }
}
