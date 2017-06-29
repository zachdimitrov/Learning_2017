using LinearDataStructures.Utilities;
using System.Collections.Generic;
using System.Text;
using System;
using System.Linq;

namespace LinearDataStructures.Tasks
{
    class FastestWayFromNtoM
    {
        private const string ErrorMessage = "Write a number or press enter!";
        private const string Title = "  10. GO FROM N TO M";
        private const string Header = @"  Write number N on first line and number M (larger number) on second.
  Press enter on third line to finish and see result.";

        public static void Start()
        {
            var queue = new Queue<List<int>>();
            int[] par = new int[2];
            ConsoleRunner e = new ConsoleRunner(Title, Header, ErrorMessage);
            int count = 0;
            e.AddTitle();

            while (true)
            {
                try
                {
                    var input = e.GetInput(count);

                    if (count == 2)
                    {
                        int n = par[0];
                        int m = par[1];

                        var firstTry = new List<int>();
                        firstTry.Add(n);
                        queue.Enqueue(firstTry);

                        var result = GoFromNtoM(queue, m);

                        e.PrintResult(string.Join(" -> ", result.ToArray().Select(x => x.ToString()).ToArray()));
                        break;
                    }

                    par[count] = int.Parse(input);
                    count++;
                }
                catch
                {
                    e.GetErrorMessage();
                }
            }
        }

        private static List<int> GoFromNtoM(Queue<List<int>> queue, int m)
        {
            while (true)
            {
                // get last list of operations
                var currentList = queue.Dequeue();
                // get last item in list
                var currentLastelem = currentList.Last();

                // 1. calculate next value using N = N+1 operation
                int firstNextValue = currentLastelem + 1;

                // 2. add to copy of last list of operations
                List<int> firstNextList = new List<int>(currentList);
                firstNextList.Add(firstNextValue);

                // 3. check if M is reached and return last successfull list of operations
                if (firstNextValue < m)
                {
                    queue.Enqueue(firstNextList);
                }
                else if (firstNextValue == m)
                {
                    return firstNextList;
                }

                // 1.
                int secondNextValue = currentLastelem + 2;

                // 2.
                List<int> secondNextList = new List<int>(currentList);
                secondNextList.Add(secondNextValue);

                // 3.
                if (secondNextValue < m)
                {
                    queue.Enqueue(secondNextList);
                }
                else if (secondNextValue == m)
                {
                    return secondNextList;
                }

                // 1.
                int thirdNextValue = currentLastelem * 2;

                // 2.
                List<int> thirdNextList = new List<int>(currentList);

                // 3.
                thirdNextList.Add(thirdNextValue);
                if (thirdNextValue < m)
                {
                    queue.Enqueue(thirdNextList);
                }
                else if (thirdNextValue == m)
                {
                    return thirdNextList;
                }
            }
        }
    }
}
