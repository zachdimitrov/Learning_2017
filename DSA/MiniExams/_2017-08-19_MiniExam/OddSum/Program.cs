using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OddSum
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine()
                .Split(' ')
                .Select(int.Parse)
                .ToArray();
            int sum = int.MinValue;
            int localSum = 0;
            int result = 0;

            Array.Sort(numbers);

            for (int j = numbers.Length - 1; j >= 0; j--)
            {
                localSum += numbers[j];

                if (sum < localSum)
                {
                    sum = localSum;
                    if (sum % 2 != 0)
                    {
                        result = sum;
                    }
                }
            }

            Console.WriteLine(result);
        }
    }
}