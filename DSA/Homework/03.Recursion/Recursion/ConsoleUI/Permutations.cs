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

        internal static void Execute(string[] set)
        {
            Array.Sort(set);
            int n = set.Length;
            GeneratePermutationsFromSet(0, set, n);
        }

        private static void GeneratePermutationsFromSet(int index, string[] perm, int n)
        {
            var tmp = "";
            Console.WriteLine(string.Join(", ", perm));

            if (index < n)
            {
                for (int i = n - 2; i >= index; i--)
                {
                    for (int j = i + 1; j < n; j++)
                    {
                        if (perm[i] != perm[j])
                        {
                            tmp = perm[i];
                            perm[i] = perm[j];
                            perm[j] = tmp;

                            GeneratePermutationsFromSet(i + 1, perm, n);
                        }
                    }

                    tmp = perm[i];
                    for (int k = i; k < n - 1; k++)
                    {
                        perm[k] = perm[++k];
                    }

                    perm[n - 1] = tmp;
                }
            }
        }
    }
}