using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Combinations
{
    class Program
    {
        static void Main()
        {
            // COMBINATIONS - select number of elements no matter the order
            // N!/(N - K)! * K!
            PrintCombinations(49, 6);

            // PERMUTATIONS - different orders of all elements
            // order N elements -> N! permutations N!/(N - K)!*K!
            PrintPermutations(5);

            // PERMUTATIONS with repetiton
            // N repeatong elements from N posssoble

            // VARIATIONS (without repetition) - select number of elements in specific order
            // select K elements from N -> N!/(N - K)!
            PrintVariations(5, 3);

            // VARIATIONS (with repetition)
            // select repeating K elements from N -> N^K
        }

        static void PrintPermutations(int n)
        {
            PrintVariations(n, n);
        }

        static void PrintVariations(int n, int k)
        {
            var variations = new int[k];
            var used = new bool[n];
            PrintVariations(0, variations, used);
        }

        static void PrintPermutations(int i, int[] permutation, bool[] used)
        {
            int n = permutation.Length;
            if (i == n)
            {
                Console.WriteLine(string.Join(" ", permutation));
                return;
            }

            for (int j = 0; j < n; ++j)
            {
                if (used[j])
                {
                    continue;
                }

                permutation[i] = j + 1;
                used[j] = true;
                PrintPermutations(i + 1, permutation, used);
                used[j] = false; // important
            }
        }

        static void PrintVariations(int i, int[] permutation, bool[] used)
        {
            int n = used.Length;
            int k = permutation.Length;

            if (i == n)
            {
                Console.WriteLine(string.Join(" ", permutation));
                return;
            }

            for (int j = 0; j < n; ++j)
            {
                if (used[j])
                {
                    continue;
                }

                permutation[i] = j + 1;
                used[j] = true;
                PrintPermutations(i + 1, permutation, used);
                used[j] = false; // important
            }
        }

        static void PrintCombinations(int n, int k)
        {
            var combination = new int[k];
            PrintCombinations(0, n, combination);
        }

        static void PrintCombinations(int i, int n, int[] combination)
        {
            int k = combination.Length;

            if (i == k)
            {
                Console.WriteLine(string.Join(" ", combination));
                return;
            }

            var start = i == 0 ? 1 : combination[i - 1] + 1;
            for (int j = start; j <= n; ++j)
            {
                combination[i] = j;
                PrintCombinations(i + 1, n, combination);
            }
        }
    }
}
