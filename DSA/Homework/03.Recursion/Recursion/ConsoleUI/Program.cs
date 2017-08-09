using ConsoleUI.Utils;
using System;

namespace RecursionHw
{
    class Program
    {
        static void Main()
        {
            // simple set with 5 elements
            int n = 5;
            var set = new string[n];
            set[0] = "b";
            set[1] = "o";
            set[2] = "r";
            set[3] = "i";
            set[4] = "s";

            Console.WriteLine("[ " + string.Join(", ", set) + " ]" + "\n");

            // simple matrix
            char[,] matrix = new char[,]
            {

                {' ', ' ', ' ', '*', ' ', ' ', ' '},

                {'*', '*', ' ', '*', ' ', '*', ' '},

                {' ', ' ', ' ', ' ', ' ', ' ', ' '},

                {' ', '*', '*', '*', '*', '*', ' '},

                {' ', ' ', ' ', ' ', ' ', ' ', 'e'},

            };

            Matrix.Print(matrix);
            Console.WriteLine();

            // big matrix
            int num = 3;
            char[,] bigMatrix = new char[num, num];
            for (int i = 0; i < num; i++)
            {
                for (int j = 0; j < num; j++)
                {
                    bigMatrix[i, j] = ' ';
                }
            }

            bigMatrix[num - 1, num - 1] = 'e';
            Matrix.Print(bigMatrix);

            // 01. N Nested Loops with recursion
            // NNestedLoops.Execute(3);

            // 02. Combinations with repetition
            // CombinationsWithDuplicates.Execute(set, 5);

            // 03. Combinations without repetitions
            // CombinationsNoDuplicates.Execute(set, 5);

            // 04. Permutations of numbers 1..n
            // Permutations.Execute();

            // 05. Variations from n elements to k subsets
            // Variations.Execute(set, 3);

            // 06. Variations from n elements to k subsets
            // VariationsNoRep.Execute(set, 3);

            // 07. All paths between cells
            // AllPathsInMatrix.Execute(matrix);

            // 08. Find if path exists between cells
            FindPathInMatrix.Execute(bigMatrix);
        }
    }
}
