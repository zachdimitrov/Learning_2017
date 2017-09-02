using System;
using System.Collections.Generic;
using System.Text;

namespace Graphs_RiskWins
{
    class Program
    {
        static void Main()
        {
            string startComb = Console.ReadLine();
            string endComb = Console.ReadLine();
            HashSet<string> visited = new HashSet<string>();
            // List<string> forbidden = new List<string>();

            int forbiddenCount = int.Parse(Console.ReadLine());

            for (int i = 0; i < forbiddenCount; i++)
            {
                // forbidden.Add(Console.ReadLine());
                visited.Add(Console.ReadLine());
            }

            #region stupid solution - 84 points
            //int count = 0;
            //for (int i = 0; i < startComb.Length; i++)
            //{
            //    int startDigit = startComb[i] - '0';
            //    int endDigit = endComb[i] - '0';

            //    count += Math.Min(Math.Abs(startDigit - endDigit), 10 - Math.Abs(startDigit - endDigit));
            //}

            //Console.WriteLine(count);
            #endregion

            Queue<Tuple<string, int>> queue = new Queue<Tuple<string, int>>();
            queue.Enqueue(new Tuple<string, int>(startComb, 0));
            visited.Add(startComb);

            while (queue.Count > 0)
            {
                var current = queue.Dequeue();
                if (current.Item1 == endComb)
                {
                    Console.WriteLine(current.Item2);
                    return;
                }

                // Press up
                for (int i = 0; i < 5; i++)
                {
                    int digit = current.Item1[i] - '0';
                    digit++;
                    if (digit == 10)
                    {
                        digit = 0;
                    }

                    var sb = new StringBuilder(current.Item1);
                    sb[i] = (char)(digit + '0');
                    string newNode = sb.ToString();

                    if (!visited.Contains(newNode))
                    {
                        visited.Add(newNode);
                        queue.Enqueue(new Tuple<string, int>(newNode, current.Item2 + 1));
                    }
                }

                // Press down
                for (int i = 0; i < 5; i++)
                {
                    int digit = current.Item1[i] - '0';
                    digit--;
                    if (digit == -1)
                    {
                        digit = 9;
                    }

                    var sb = new StringBuilder(current.Item1);
                    sb[i] = (char)(digit + '0');
                    string newNode = sb.ToString();

                    if (!visited.Contains(newNode))
                    {
                        visited.Add(newNode);
                        queue.Enqueue(new Tuple<string, int>(newNode, current.Item2 + 1));
                    }
                }
            }

            Console.WriteLine("-1");
        }
    }
}
