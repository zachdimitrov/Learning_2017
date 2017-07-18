using System;

namespace Numerology
{
    class Program
    {
        static void Main()
        {
            string bd = Console.ReadLine();
            CalcResult(bd);
            Console.WriteLine(string.Join(" ", results));
        }

        static int[] results = new int[10];

        static void CalcResult(string bd)
        {
            if (bd.Length == 1)
            {
                int index = int.Parse(bd);
                ++results[index];
            }

            for (int j = 0; j < bd.Length - 1; j++)
            {
                string numbers = bd.Substring(j, 2);
                int a = numbers[0] - '0';
                int b = numbers[1] - '0';
                int result = (a + b) * (a ^ b) % 10;

                var newbd = bd.Remove(j, 2);
                newbd = newbd.Insert(j, result.ToString());

                CalcResult(newbd);
            }
        }
    }
}
