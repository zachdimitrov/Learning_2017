using System;

namespace RecursionHw
{
    public static class CombinationsNoDuplicates
    {
        public static void Execute<T>(T[] set, int k)
        {
            T[] comb = new T[k];
            bool[] used = new bool[set.Length];
            int index = 0;
            Execute(index, set, k, comb, used);
        }

        private static void Execute<T>(int index, T[] set, int k, T[] comb, bool[] used)
        {
            if (index == k)
            {
                Console.WriteLine(string.Join(", ", comb));
                used = new bool[set.Length];
                return;
            }

            for (int i = 0; i < set.Length; i++)
            {
                if (used[i] == true)
                {
                    continue;
                }

                comb[index] = set[i];
                used[i] = true;
                Execute(index + 1, set, k, comb, used);
            }
        }
    }
}
