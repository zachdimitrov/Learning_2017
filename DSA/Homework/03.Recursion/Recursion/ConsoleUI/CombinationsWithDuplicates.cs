using System;

namespace RecursionHw
{
    public static class CombinationsWithDuplicates
    {
        public static void Execute<T>(T[] set, int k)
        {
            T[] comb = new T[k];
            int index = 0;
            Execute(index, set, k, comb);
        }

        private static void Execute<T>(int index, T[] set, int k, T[] comb)
        {
            if (index == k)
            {
                Console.WriteLine(string.Join(", ", comb));
                return;
            }

            for (int i = 0; i < set.Length; i++)
            {
                comb[index] = set[i];
                Execute(index + 1, set, k, comb);
            }
        }
    }
}
