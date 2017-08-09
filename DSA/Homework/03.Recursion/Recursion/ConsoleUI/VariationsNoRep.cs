using System;

namespace RecursionHw
{
    internal class VariationsNoRep
    {
        internal static void Execute(string[] set, int k)
        {
            bool[] used = new bool[set.Length];
            string[] variation = new string[k];
            GenerateVariations(0, set, k, used, variation);
        }

        private static void GenerateVariations(int index, string[] set, int k, bool[] used, string[] variation)
        {
            if (index == k)
            {
                Console.WriteLine(string.Join(", ", variation));
                return;
            }

            for (int i = 0; i < set.Length; i++)
            {
                if (used[i] == true)
                {
                    continue;
                }

                variation[index] = set[i];
                used[i] = true;
                GenerateVariations(index + 1, set, k, used, variation);
                used[i] = false;
            }
        }
    }
}