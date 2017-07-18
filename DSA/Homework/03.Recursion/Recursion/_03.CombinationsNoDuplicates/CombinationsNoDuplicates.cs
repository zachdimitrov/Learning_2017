﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03.CombinationsNoDuplicates
{
    public static class CombinationsNoDuplicates
    {
        public static void Execute<T>(T[] set, int k)
        {
            T[] comb = new T[k];
            bool[] used = new bool[n];
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
                used[i] = true;
                Execute(s + 1, set, k, comb);
            }
        }
    }
}
