using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Squares
{
    class Program
    {
        static int n;
        static int m;
        static long result;
        static bool[,] used;

        static void Main()
        {
            n = int.Parse(Console.ReadLine());
            m = int.Parse(Console.ReadLine());

            var matrix = new bool[n, m];
            used = new bool[n, m];

            GenerateAll(0, 0);

            Console.WriteLine(result);
        }

        static void GenerateAll(int i, int j)
        {
            if (i == n && j == m)
            {
                for (int w = 0; w < used.GetLength(0); w++)
                {
                    for (int h = 0; h < used.GetLength(1); h++)
                    {
                        Console.Write((used[w, h] ? 1 : 0) + " | ");
                    }

                    Console.WriteLine();
                }
                Console.WriteLine("------ next iteration ------");

                return;
            }

            for (int row = i; row < n; row++)
            {
                for (int col = j; col < m; col++)
                {
                    used[row, col] = true;

                    if (noOtherBlacks(row, col, used))
                    {
                        result++;
                    }

                    GenerateAll(i + 1, j + 1);

                    used[row, col] = false;
                }
            }
        }

        private static bool noOtherBlacks(int row, int col, bool[,] m)
        {
            if (row - 1 < 0 && col - 1 < 0)
            {
                return (!m[row + 1, col] && !m[row, col + 1]);
            }

             if (row - 1 < 0 && col - 1 > 0)
            {
                if (col >= m.GetLength(1) - 1)
                {
                    return (!m[row, col - 1] && !m[row + 1, col]);
                }

                return (!m[row, col - 1] && !m[row + 1, col] && !m[row, col + 1]);
            }

            if (col - 1 < 0 && row - 1 > 0)
            {
                if (row >= m.GetLength(0) - 1)
                {
                    return (!m[row - 1, col] && !m[row, col + 1]);
                }

                return (!m[row - 1, col] && !m[row + 1, col] && !m[row, col + 1]);
            }

            if (row < m.GetLength(0) - 1 && col < m.GetLength(1) - 1)
            {
                return (!m[row, col + 1] && !m[row, col + 1]);
            }

            if (row >= m.GetLength(0) - 1 && col < m.GetLength(1) - 1)
            {
                return (!m[row - 1, col] && !m[row, col - 1] && !m[row, col + 1]);
            }

            if (col >= m.GetLength(1) - 1 && row < m.GetLength(0) - 1)
            {
                return (!m[row - 1, col] && !m[row, col - 1] && !m[row + 1, col]);
            }

            return (!m[row - 1, col] && !m[row, col - 1] && !m[row + 1, col] && !m[row, col + 1]);
        }
    }
}
