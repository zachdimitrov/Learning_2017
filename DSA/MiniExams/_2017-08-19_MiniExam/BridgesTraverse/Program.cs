using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bridges
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
        private static List<Edge> ReadGraph()
        {
            int[] nm = Console.ReadLine()
                    .Split(' ')
                    .Select(int.Parse)
                    .ToArray();

            int n = nm[0];
            int m = nm[1];

            int?[,] matrix = new int?[n + 1, n + 1]; // bool[,] if no weights
            var edges = new List<Edge>();

            for (int i = 0; i < m; i++)
            {
                var edge = Console.ReadLine()
                    .Split(' ')
                    .Select(int.Parse)
                    .ToArray();

                var from = edge[0];
                var to = edge[1];
                var weight = edge[2];

                // edges list
                var e1 = new Edge(from, to, weight);
                edges.Add(e1);
                var e2 = new Edge(to, from, weight);
                edges.Add(e2);
            }

            return edges;
        }

        static void Main()
        {
            var edges = ReadGraph();
            PrintPathWithBfs(edges);
        }

        private static void PrintPathWithBfs(List<Edge> edges)
        {

            int steve = int.Parse(Console.ReadLine());
            int br = 0;

            for (int i = 0; i < edges.Count; i++)
            {
                Console.WriteLine($"{i + 1}: {edges[i].Weight}");
                if (edges[i].Weight < steve)
                {
                    br++;
                }
            }

            Console.WriteLine(br);
        }
    }
}