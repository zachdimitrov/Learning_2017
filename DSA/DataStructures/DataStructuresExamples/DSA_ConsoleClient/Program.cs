using System;
using System.Collections.Generic;

namespace _ConsoleClient
{
    class Program
    {
        static void Main(string[] args)
        {
            // stack example
            Sep("Stacks");
            StackTest();
            Sep("Queues");
            SequenceN();
        }

        private static void Sep(string p)
        {
            Console.WriteLine($"------------------ {p} -------------------");
        }

        // union arrays
        int[] Union(int[] first, int[] second)
        {
            List<int> union = new List<int>();
            union.AddRange(first);
            foreach (int item in second)
            {
                if (!union.Contains(item))
                {
                    union.Add(item);
                    return union.ToArray();
                }
            }
            return union.ToArray();
        }

        // intersect arrays
        int[] Intersect(int[] first, int[] second)
        {
            List<int> intersect = new List<int>();
            foreach (int item in first)
            {
                if (Array.IndexOf(second, item) != -1)
                {
                    intersect.Add(item);
                }
            }
            return intersect.ToArray();
        }

        // stack example
        static void StackTest()
        {
            string exp = "1 + (2 - (2 + 3) * 4 / (3 + 1)) * 5";

            Stack<int> stack = new Stack<int>();
            for (int i = 0; i < exp.Length; i++)
            {
                if (exp[i] == '(')
                {
                    stack.Push(i);
                }
                else if (exp[i] == ')')
                {
                    int openInd = stack.Pop();
                    string subExp = exp.Substring(openInd - 1, (i - openInd + 2));
                    Console.WriteLine(subExp); 
                }
            }
        }

        // queue example
        static void SequenceN()
        {
            int n = 3;
            int p = 16;

            Queue<int> queue = new Queue<int>();

            queue.Enqueue(n);

            for(int i = 1; queue.Count != 0; i++)
            {
                int num = queue.Dequeue();
                if (i == p)
                {
                    Console.WriteLine(num);
                    break;
                }

                queue.Enqueue(num + 1);
                queue.Enqueue(num * 2);
            }
        }
    }
}
