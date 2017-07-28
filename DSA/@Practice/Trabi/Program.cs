using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trabi
{
    class Program
    {
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            int m = int.Parse(Console.ReadLine());
            int[] pipes = new int[n];
            int fullLength = 0;
            for (int i = 0; i < n; i++)
            {
                pipes[i] = int.Parse(Console.ReadLine());
                fullLength += pipes[i];
            }

            int proposed = fullLength / m;
            int count = 0;

            while (proposed > 0)
            {
                for (int j = 0; j < n; j++)
                {
                    count += pipes[j] / proposed;
                }

                if (count == m)
                {
                    Console.WriteLine(proposed);
                    return;
                }

                count = 0;
                proposed--;
            }

            Console.WriteLine(-1);
        }
    }
}
