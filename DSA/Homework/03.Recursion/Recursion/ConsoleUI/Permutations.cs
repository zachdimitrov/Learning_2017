using System;

namespace RecursionHw
{
    internal class Permutations
    {
        internal static void Execute()
        {
            Console.Write("04. Enter number n: ");
            int n = int.Parse(Console.ReadLine());
            bool[] used = new bool[n];
            int[] perm = new int[n];
            GeneratePermutations(0, n, used, perm);
        }

        private static void GeneratePermutations(int index, int n, bool[] used, int[] perm)
        {
            if (index == n)
            {
                Console.WriteLine(string.Join(", ", perm));
                return;
            }

            for (int i = 0; i < n; i++)
            {
                if (used[i] == true)
                {
                    continue;
                }

                perm[index] = i + 1;
                used[i] = true;
                GeneratePermutations(index + 1, n, used, perm);
                used[i] = false;
            }
        }
    }
}