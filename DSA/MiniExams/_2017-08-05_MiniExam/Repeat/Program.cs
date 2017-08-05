using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Repeat
{
    class Program
    {
        static void Main()
        {
            int[] numbers = Console.ReadLine()
                .Split(' ')
                .Select(int.Parse)
                .ToArray();

            int[] failLink = new int[numbers.Length + 1];
            failLink[0] = -1;
            failLink[1] = 0;

            int j;

            for (int i = 1; i < numbers.Length; i++)
            {
                j = failLink[i];
                while (j >= 0 && numbers[i] != numbers[j])
                {
                    j = failLink[j];
                }

                failLink[i + 1] = j + 1;
            }

            j = 0;
            for (int i = 1; ; i++)
            {
                if (i == numbers.Length)
                {
                    i = 0;
                }

                while (j >= 0 && numbers[i] != numbers[j])
                {
                    j = failLink[j];
                }

                j++;

                if (j == numbers.Length)
                {
                    j = i + 1;
                    break;
                }
            }

            Console.WriteLine(String.Join(" ", numbers.Take(j)));
        }
    }
}
