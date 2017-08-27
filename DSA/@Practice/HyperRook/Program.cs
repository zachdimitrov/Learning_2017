using System;
using System.Linq;

namespace HyperRook
{
    class Program
    {
        static void Main(string[] args)
        {
            var line1 = Console.ReadLine()
                .Split(' ');
            int n = int.Parse(line1[0]);
            int k = int.Parse(line1[1]);

            var line2 = Console.ReadLine()
                .Split(' ')
                .Select(int.Parse)
                .ToArray();

            if (k > n)
            {
                Console.WriteLine(0);
                return;
            }

            int[] cells = new int[n + 1];
            cells[1] = line2[0];
            for (int i = 2; i < n + 1; i++)
            {
                cells[i] = (cells[i - 1] * line2[1] + line2[2]) % line2[3];
            }

            //Console.WriteLine(string.Join(" ", cells));
            Console.WriteLine(Jump(0, cells, 0, k));
        }

        static long Jump(int index, int[] cells, long result, int k)
        {
            if (index >= cells.Length)
            {
                return result; 
            }

            long res = long.MaxValue;

            for (int i = 1; i <= k; i++)
            {
                long r = Jump(index + i, cells, result + cells[index], k);
                if (r < res)
                {
                    res = r;
                }
            }

            return res;
        }
    }
}
