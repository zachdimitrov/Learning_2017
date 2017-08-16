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

        internal static void Execute(int[] set)
        {
            Array.Sort(set);
            int n = set.Length;
            PermuteRep(set, 0, n);
        }

        private static void PermuteRep(int[] set, int start, int length)
        {
            Console.WriteLine(string.Join(" ", set));

            if (start < length)
            {
                for (int i = length - 2; i >= start; i--)
                {
                    for (int j = i + 1; j < length; j++)
                    {
                        if (set[i] != set[j])
                        {
                            Swap(ref set[i], ref set[j]);
                            PermuteRep(set, i + 1, length);
                        }
                    }

                    var tmp = set[i];
                    for (int k = i; k < length - 1;)
                    {
                        set[k] = set[++k];
                    }

                    set[length - 1] = tmp;


                }
            }
        }

        private static void Swap(ref int v1, ref int v2)
        {
            var temp = v1;
            v1 = v2;
            v2 = temp;
        }
    }
}