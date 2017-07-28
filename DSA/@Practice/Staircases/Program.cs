using System;

namespace Staircases
{
    class Program
    {
        static long[,] count;

        static void Main()
        {
            int n = int.Parse(Console.ReadLine());

            count = new long[n + 1, n + 1];

            count[0, 0] = 1;
            count[1, 1] = 1;
            count[2, 2] = 1;

            for (int i = 3; i <= n; i++)
            {
                for (int j = 0; j <= i; j++)
                {
                    for (int k = 0; k < j && i - j >= k; k++)
                    {
                        count[i, j] += count[i - j, k];
                    }
                }
            }

            long answer = 0;
            for (int i = 1; i < n; i++)
            {
                answer += count[n, i];
            }

            Console.WriteLine(answer);

            // Recursive(n);
        }

        static void Recursive(int n)
        {
            count = new long[n + 1, n + 1];

            long result = 0;
            for (int i = 1; i < n; i++)
            {
                result += Stairs(n, i);
            }

            Console.WriteLine(result);
        }

        static long Stairs(int n, int k)
        {
            //Console.WriteLine($"{n}, {k}");

            // floor
            if (n < 3 && n == k)
            {
                return 1;
            }

            // memoisation
            if (count[n, k] > 0)
            {
                return count[n, k];
            }

            // recursion
            for (int i = 0; i < k && i <= n - k; i++)
            {
                count[n, k] += Stairs(n - k, i);
            }

            return count[n, k];
        }
    }
}
