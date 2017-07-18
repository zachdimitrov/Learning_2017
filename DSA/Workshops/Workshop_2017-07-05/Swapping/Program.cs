using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Swapping
{
    class Program
    {
        static void Main()
        {
            var n = int.Parse(Console.ReadLine());

            /*
            // 01. 48 points in BG Coder

            var numbers = Enumerable.Range(1, n).ToList();
            var swapNumbers = Console.ReadLine()
                .Split(' ')
                .Select(int.Parse)
                .ToArray();

            foreach (var num in swapNumbers)
            {
                int index = numbers.IndexOf(num);
                numbers.Insert(0, num);
                numbers.InsertRange(0, numbers.GetRange(index + 2, numbers.Count - index - 2));
                numbers.RemoveRange(n, numbers.Count - n);
            }

            Console.WriteLine(string.Join(" ", numbers));
            */

            /*
            // 02. Swapping queues

            var q = new Queue<int>(Enumerable.Range(1, n).ToList());

            Console.ReadLine()
                .Split(' ')
                .Select(int.Parse)
                .ToList()
                .ForEach(num =>
                {
                    q.Enqueue(num);
                    int X;
                    while ((X = q.Dequeue()) != num)
                    {
                        q.Enqueue(X);
                    }
                });

            Console.WriteLine(string.Join(" ", q));
            */

            // 03. Linked list


        }
    }
}
