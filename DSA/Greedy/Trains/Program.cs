using System;
using Wintellect.PowerCollections;

namespace Trains
{
    class Program
    {
        static void Main()
        {
            var numbers = Console.ReadLine().Split(' ');
            int n = int.Parse(numbers[0]);
            int m = int.Parse(numbers[1]);
            // int l = int.Parse(numbers[2]);

            var tickets = new Tuple<int, int>[n];

            for (int i = 0; i < n; i++)
            {
                var strs = Console.ReadLine().Split();
                tickets[i] = new Tuple<int, int>(int.Parse(strs[0]), int.Parse(strs[1]));
            }

            Array.Sort(tickets);

            var selectedTickets = new OrderedBag<int>();
            var result = 0;

            foreach (var ticket in tickets)
            {
                while (selectedTickets.Count > 0 && selectedTickets.GetFirst() <= ticket.Item1)
                {
                    ++result;
                    selectedTickets.RemoveFirst();
                }

                selectedTickets.Add(ticket.Item2);

                if (selectedTickets.Count > m)
                {
                    selectedTickets.RemoveLast();
                }
            }

            result += selectedTickets.Count;
            Console.WriteLine(result);
        }
    }
}
