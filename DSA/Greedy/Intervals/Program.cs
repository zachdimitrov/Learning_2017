using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Intervals
{
    class Interval
    {
        public int Start { get; set; }
        public int End { get; set; }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());
            var intervals = new Interval[n];
            for (int i = 0; i < n; i++)
            {
                var current = Console.ReadLine()
                    .Split(' ');

                intervals[i] = new Interval
                {
                    Start = int.Parse(current[0]),
                    End = int.Parse(current[1])
                };
            }

            Array.Sort(intervals, (x, y) => x.Start.CompareTo(y.Start));

            var intervalCt = 0;
            var result = new List<Interval>();
            var currentEnd = intervals[0].End;
            var last = 0;

            for (int i = 1; i < n; i++)
            {
                if (currentEnd <= intervals[i].Start)
                {
                    result.Add(intervals[last]);
                    ++intervalCt;
                    currentEnd = intervals[i].End;
                    last = i;
                }
                else if(intervals[i].End < currentEnd)
                {
                    currentEnd = intervals[i].End;
                    last = i;
                }
            }

            result.Add(intervals[last]);
            intervalCt++;

            foreach(var interval in intervals)
            {
                Console.WriteLine(interval.Start + " -> " + interval.End);
            }

            string[] iResult = result.Select((i) => ($"({i.Start} : {i.End})")).ToArray();

            Console.WriteLine($"Result: {intervalCt} intervals!" );
            Console.WriteLine("Intervals: " + string.Join(" -> ", iResult));
        }
    }
}
