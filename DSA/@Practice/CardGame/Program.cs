using System;
using System.Linq;

namespace CardGame
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int[] numbers = Console.ReadLine()
                .Split(' ')
                .Select(int.Parse)
                .ToArray();

            int[,] dp = new int[n, n];

            for (int lenght = 3; lenght <= n; lenght++)
            {
                for (int i = 0; i <= n - lenght; i++)
                {
                    // [i, i+ lenght - 1]
                    for (int j = i + 1; j < i + lenght - 1; j++)
                    {
                        int current = dp[i, j] + dp[j, i + lenght - 1] + numbers[j] * (numbers[i] + numbers[i + lenght - 1]);

                        if (dp[i, i + lenght - 1] < current)
                        {
                            dp[i, i + lenght - 1] = current;
                        }
                    }
                }
            }

            Console.WriteLine(dp[0, n - 1]);
        }
    }
}
