using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleUI
{
    class Edge
    {
        public Edge(int from, int to, int weight)
        {
            From = from;
            To = to;
            Weight = weight;
        }

        public int From { get; set; }
        public int To { get; set; }
        public int Weight { get; set; }

        public override string ToString()
        {
            return $"{this.From} -> {this.To} - {this.Weight}";
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var r = int.Parse(Console.ReadLine());
            var c = int.Parse(Console.ReadLine());

            var edges = new List<Edge>();

            for (int i = 0; i < r; i++)
            {

                var edge = Console.ReadLine()
                    .Split(' ')
                    .Select(int.Parse)
                    .ToArray();

                for (int j = 0; j < 3; j++)
                {
                    int from = i * 3 + j;
                    int to = i * 3 + j + 1;
                    int weight = edge[j];

                    // edges list
                    var e1 = new Edge(from, to, weight);
                    edges.Add(e1);
                    var e2 = new Edge(to, from, weight);
                    edges.Add(e2);
                }
            }

            PrintEdgeList(edges);
        }

        private static void PrintEdgeList(List<Edge> edges)
        {
            edges
                .OrderBy(e => e.From)
                .ThenBy(e => e.To)
                .ToList();

            edges.ForEach(edge => Console.WriteLine(edge));
            Console.WriteLine();
        }
    }
}
