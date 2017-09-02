using System;
using System.Collections.Generic;
using System.Linq;

namespace AcademyTasks
{
    class Program
    {
        static List<int> tasks = new List<int>();
        static int variety;
        // static int best = int.MaxValue;
        // static int maxIndex;

        static void Main()
        {
            tasks = Console.ReadLine()
                .Split(new char[] { ',', ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList();

            variety = int.Parse(Console.ReadLine());

            Console.WriteLine(SolveWithDP()); 

            //int currentMin = tasks[0];
            //int currentMax = tasks[0];
            //maxIndex = -1;

            //for (int i = 0; i < tasks.Count; i++)
            //{
            //    currentMin = Math.Min(currentMin, tasks[i]);
            //    currentMax = Math.Max(currentMax, tasks[i]);
            //    if (currentMax - currentMin >= variety)
            //    {
            //        maxIndex = i;
            //        break;
            //    }
            //}

            //if (maxIndex == -1)
            //{
            //    Console.WriteLine(tasks.Count);
            //    return;
            //}

            //best = tasks.Count;
            //Solve(0, 1, tasks[0], tasks[0]);
            //Console.WriteLine(best);
        }

        private static int SolveWithDP()
        {
            int min = tasks.Count;
            for (int i = 0; i < tasks.Count - 1; i++)
            {
                for (int j = i + 1; j < tasks.Count; j++)
                {
                    if (Math.Abs(tasks[i] - tasks[j]) >= variety)
                    {
                        int count = 0;

                        count += (i + 1) / 2;
                        count += (j - i + 1) / 2 + 1;

                        min = Math.Min(min, count);
                    }
                }
            }

            return min;
        }

        //static void Solve(int index, int taskSolved, int min, int max)
        //{
        //    if (max - min >= variety)
        //    {
        //        best = Math.Min(best, taskSolved);
        //        return;
        //    }

        //    if (index >= maxIndex)
        //    {
        //        return;
        //    }

        //    for (int i = 2; i >= 1; i--)
        //    {
        //        if (index + i < tasks.Count)
        //        {
        //            Solve(index + i,
        //                taskSolved + 1,
        //                Math.Min(min, tasks[index + i]),
        //                Math.Max(max, tasks[index + i]));

        //            if (best != tasks.Count)
        //            {
        //                return;
        //            }
        //        }
        //    }
        //}
    }
}
