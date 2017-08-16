using System;
using System.Collections.Generic;

namespace Dividers
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            string[] list = new string[n];
            List<int> numbers = new List<int>();

            for (int i = 0; i < n; i++)
            {
                list[i] = Console.ReadLine();
            }

            Array.Sort(list);
            GenerateNumbers(list, numbers, 0, n);
            //numbers.ForEach(x => Console.WriteLine(x));
            int minDiv = int.MaxValue;
            int minNum = int.MaxValue;

            foreach (var num in numbers)
            {
                int localMin = 0;
                for (int i = 2; i <= Math.Sqrt(num); i++)
                {
                    if (num % i == 0)
                    {
                        localMin++;
                    }
                }

                if (localMin == minDiv)
                {
                    if (minNum > num)
                    {
                        minNum = num;
                    }
                }

                if (localMin < minDiv)
                {
                    minDiv = localMin;
                    minNum = num;
                }
            }

            Console.WriteLine(minNum);
        }

        private static void GenerateNumbers(string[] list, List<int> numbers, int start, int length)
        {
            var number = int.Parse(string.Join("", list).TrimStart(new Char[] { '0' }));
            //Console.WriteLine(number);
            numbers.Add(number);

            if (start < length)
            {
                for (int i = length - 2; i >= start; i--)
                {
                    for (int j = i + 1; j < length; j++)
                    {
                        if (list[i] != list[j])
                        {
                            var temp = list[i];
                            list[i] = list[j];
                            list[j] = temp;
                            GenerateNumbers(list, numbers, i + 1, length);
                        }
                    }

                    var tmp = list[i];
                    for (int k = i; k < length - 1;)
                    {
                        list[k] = list[++k];
                    }

                    list[length - 1] = tmp;
                }
            }
        }
    }
}
