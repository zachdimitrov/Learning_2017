using System;
using System.Collections.Generic;
using System.Linq;

namespace _02.CombinationsWithDuplicates
{
    public static class CombinationsWithDuplicates
    {
        public static void Execute<T>(T[] set, int k)
        {
            T[] comb = new T[k];
            int s = 0;
            Execute(s, set, k, comb);
        }

        private static void Execute<T>(int s, T[] set, int k, T[] comb)
        {
            if (s == k)
            {
                Console.WriteLine(string.Join(", ", comb));
                return;
            }

            for (int i = 0; i < set.Length; i++)
            {
                comb[s] = set[i];
                Execute(s + 1, set, k, comb);
            }
        }
    }
}
