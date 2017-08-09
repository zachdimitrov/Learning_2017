using System;

namespace RecursionHw
{
    internal class Variations
    {
        internal static void Execute(string[] set, int k)
        {
            string[] variation = new string[k];
            GenerateVariations(0, set, k, variation);
        }

        private static void GenerateVariations(int index, string[] set, int k, string[] variation)
        {
            if (index == k)
            {
                Console.WriteLine(string.Join(", ", variation));
                return;
            }

            for (int i = 0; i < set.Length; i++)
            {
                variation[index] = set[i];
                GenerateVariations(index + 1, set, k, variation);
            }
        }
    }
}