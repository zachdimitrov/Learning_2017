using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sticks
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] a = Console.ReadLine()
                .Split(' ')
                .Select(int.Parse)
                .ToArray();

            double l1 = Math.Sqrt((a[0] - a[2]) * (a[0] - a[2]) + (a[1] - a[3]) * (a[1] - a[3]));

            int[] b = Console.ReadLine()
                .Split(' ')
                .Select(int.Parse)
                .ToArray();

            double l2 = Math.Sqrt((b[0] - b[2]) * (b[0] - b[2]) + (b[1] - b[3]) * (b[1] - b[3]));

            int[] c = Console.ReadLine()
                .Split(' ')
                .Select(int.Parse)
                .ToArray();

            double l3 = Math.Sqrt((c[0] - c[2]) * (c[0] - c[2]) + (c[1] - c[3]) * (c[1] - c[3]));

            //Console.WriteLine(l1);
            //Console.WriteLine(l2);
            //Console.WriteLine(l3);

            if (l1 + l2 > l3 && l1 + l3 > l2 && l2 + l3 > l1)
            {
                double p = (l1 + l2 + l3) / 2;
                double area = Math.Sqrt(p * (p - l1) * (p - l2) * (p - l3));
                Console.WriteLine("{0:F3}", area);
            }
            else
            {
                Console.WriteLine("No triangle.");
            }
        }
    }
}
