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

        public static void PrintToFile(string link, char[,] matrix)
        {
            using (System.IO.StreamWriter file =
    new System.IO.StreamWriter(link, true))
            {
                for (int i = 0; i < matrix.GetLength(0); i++)
                {
                    for (int j = 0; j < matrix.GetLength(1); j++)
                    {
                        file.Write("|" + matrix[i, j]);
                    }
                    file.Write("|");
                    file.WriteLine();
                }
                file.WriteLine();
            }
        }
    }
}
