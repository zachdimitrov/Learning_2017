using System;
using System.Linq;

namespace RecursionHw
{
    internal class LargestConnectedArea
    {
        internal static void Execute(char[,] matrix)
        {
            int best = 0;

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (matrix[i, j] == ' ')
                    {
                        int currentBest = 0;
                        FindLargest(i, j, matrix, ref currentBest);
                        Console.WriteLine(currentBest);
                        if (currentBest > best)
                        {
                            best = currentBest;
                        }
                    }
                }
            }

            Console.WriteLine($"The largest connected area is {best} cells.");
        }

        private static void FindLargest(int row, int col, char[,] matrix, ref int best)
        {
            if (row < 0 || col < 0 || row >= matrix.GetLength(0) || col >= matrix.GetLength(1))
            {
                return;
            }

            if (matrix[row, col] != ' ')
            {
                return;
            }

            best++;
            matrix[row, col] = 's';
            
            FindLargest(row + 1, col, matrix, ref best);
            FindLargest(row - 1, col, matrix, ref best);
            FindLargest(row, col + 1, matrix, ref best);
            FindLargest(row, col - 1, matrix, ref best);
        }
    }
}