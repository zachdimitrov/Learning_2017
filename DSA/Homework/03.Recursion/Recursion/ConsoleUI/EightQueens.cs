using ConsoleUI.Utils;
using System;
using System.Collections.Generic;

namespace RecursionHw
{
    internal class EightQueens
    {
        static int n = 8;
        static char[,] board = new char[n, n];
        internal static void Execute()
        {
            for (int i = 0; i < board.GetLength(0); i++)
            {
                for (int j = 0; j < board.GetLength(1); j++)
                {
                    board[i, j] = ' ';
                }
            }

            GetSolution(n);
        }

        private static void GetSolution(int count)
        {
            if (count == 0)
            {
                Matrix.PrintToFile(@"C:\Users\Zahari\Projects\Learning_2017\DSA\Homework\03.Recursion\Recursion\result.txt", board);
            }
            else
            {
                int j = count - 1;
                for (int i = 0; i < n; i++)
                {
                    if (CanPlaceQueen(j, i))
                    {
                        board[j, i] = 'Q';
                        GetSolution(count - 1);
                        board[j, i] = ' ';
                    }
                }
            }
        }

        private static bool CanPlaceQueen(int row, int col)
        {
            int x = row;
            int y = col;
            int[] dx = { 1, 1, 1 };
            int[] dy = { 0, 1, -1 };
            bool res = true;

            for (int i = 0; i < 3; i++)
            {
                while (x >= 0 && y >= 0 && x < n && y < n)
                {
                    if (board[x, y] == 'Q')
                    {
                        res = false;
                    }

                    x += dx[i];
                    y += dy[i];
                }

                x = row;
                y = col;
            }

            return res;
        }
    }
}