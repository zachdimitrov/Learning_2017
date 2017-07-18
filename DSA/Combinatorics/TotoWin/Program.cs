using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TotoWin
{
    class Program
    {
        static void Main(string[] args)
        {
            var result = CheckCombinations(49, 6);
            var winning = result.Item1;
            var total = result.Item2;
            var chance = 100.0 * winning / total; 
            Console.WriteLine($"{winning}/{total} = {chance}%");
        }

        static Tuple<long, long> CheckCombinations(int n, int k)
        {
            var combination = new int[k];
            return CheckCombinations(0, n, combination);
        }

        static Tuple<long, long> CheckCombinations(int i, int n, int[] combination)
        {
            int k = combination.Length;

            if (i == k)
            {
                //Console.WriteLine(string.Join(" ", combination));
                var wins = combination[2] <= 6 ? 1 : 0;
                return new Tuple<long, long>(wins, 1);
            }

            var start = i == 0 ? 1 : combination[i - 1] + 1;
            var result = new Tuple<long, long>(0, 0);

            for (int j = start; j <= n; ++j)
            {
                combination[i] = j;
                result = AddPairs(result, CheckCombinations(i + 1, n, combination));
            }
            return result;
        }

        static Tuple<long, long> AddPairs(Tuple<long, long> a, Tuple<long, long> b)
        {
            // please no nulls!!!
            return new Tuple<long, long>(a.Item1 + b.Item1, a.Item2 + b.Item2);
        }
    }
}
