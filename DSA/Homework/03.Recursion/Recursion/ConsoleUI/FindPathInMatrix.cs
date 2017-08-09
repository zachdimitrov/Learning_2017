using System;
using System.Collections.Generic;

namespace RecursionHw
{
    internal class FindPathInMatrix
    {
        static List<char> path = new List<char>();

        internal static void Execute(char[,] matrix)
        {
            FindExit(matrix, 0, 0, 'S');
        }

        private static void FindExit(char[,] matrix, int row, int col, char dir)
        {
            if (row < 0 || col < 0 || row >= matrix.GetLength(0) || col >= matrix.GetLength(1))
            {
                return;
            }

            if (matrix[row, col] == 'e')
            {
                path.Add(dir);
                Console.WriteLine("Found path to exit: " + string.Join("", path));
                return;
            }

            if (matrix[row, col] != ' ')
            {
                return;
            }

            path.Add(dir);
            matrix[row, col] = 's';

            FindExit(matrix, row, col - 1, 'L'); // left
            FindExit(matrix, row - 1, col, 'U'); // up
            FindExit(matrix, row, col + 1, 'R'); // right
            FindExit(matrix, row + 1, col, 'D'); // down

            path.RemoveAt(path.Count - 1);
        }
    }
}