using System;

namespace ConsoleUI.Utils
{
    public static class Matrix
    {
        public static void Print(char[,] matrix)
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    Console.Write("|" + matrix[i, j]);
                }
                Console.Write("|");
                Console.WriteLine();
            }
            Console.WriteLine();
        }
    }
}
