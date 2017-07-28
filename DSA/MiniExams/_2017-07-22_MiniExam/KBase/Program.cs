using System;

namespace KBase
{
    class Program
    {
        static long[,] dp = new long[16, 2];
        static int k = 0;
        static int n = 0;

        static void Main()
        {
            n = int.Parse(Console.ReadLine());
            k = int.Parse(Console.ReadLine());

            long amount = (k - 1) * count(n - 1, 0);

            Console.WriteLine(amount);
        }

        static long count(int n, int zeros)
        {
            if (zeros == 2)
            {
                return 0;
            }

            if (n == 1)
            {
                if (zeros == 1)
                {
                    return k - 1;
                }
                else
                {
                    return k;
                }
            }

            long result = dp[n, zeros];

            if (result == 0)
            {
                result = zeros == 1 ? 0 : count(n - 1, 1);
                result += (k - 1) * count(n - 1, 0);
            }

            return result;
        }
    }
}
