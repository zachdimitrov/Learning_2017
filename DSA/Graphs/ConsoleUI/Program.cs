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

    class Node
    {
        public Node(int to, int weight)
        {
            To = to;
            Weight = weight;
        }

        public int To { get; set; }
        public int Weight { get; set; }

        public override string ToString()
        {
            return $"{this.To} - {this.Weight}";
        }
    }

    class Program
    {
        // input - nodes, edges
        private static string input = @"7
8
1 4 3
1 7 5
2 6 1
2 7 7
3 5 0
3 6 2
3 7 9
5 6 2";

        static void FakeInput()
        {
            Console.SetIn(new StringReader(input));
        }

        static void Main(string[] args)
        {
            FakeInput();

            var n = int.Parse(Console.ReadLine());
            var m = int.Parse(Console.ReadLine());
            int?[,] matrix = new int?[n + 1, n + 1]; // bool[,] if no weights
            var vertices = new LinkedList<Node>[n + 1];
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

                // adjustency list
                CreateList(from, vertices);
                CreateList(to, vertices);

                vertices[from].AddLast(new Node(from, weight));
                vertices[to].AddLast(new Node(to, weight));

                // matrix
                matrix[from, to] = weight;
                matrix[to, from] = weight;
            }

            PrintEdgeList(edges); // with edges list
            PrintVertices(vertices); // with adjustency list (списък на съседите)
            PrintMatrix(matrix); // with 
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

        private static void PrintVertices(LinkedList<Node>[] vertices)
        {
            for (int i = 1; i < vertices.Length; i++)
            {
                var edges = vertices[i];
                Console.WriteLine($"{i} -> " + string.Join(", ", edges));
            }
            Console.WriteLine();
        }

        private static void CreateList(int x, LinkedList<Node>[] y)
        {
            if (y[x] == null)
            {
                y[x] = new LinkedList<Node>();
            }
        }

        private static void PrintMatrix(int?[,] matrix)
        {
            Console.WriteLine("  0 1 2 3 4 5 6 7");
            Console.WriteLine("  | | | | | | | |");
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                Console.Write(i + "—");
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    string toPrint = matrix[i, j] == null ? "*" :  matrix[i, j] + "";
                    Console.Write(toPrint + " ");
                }

                Console.WriteLine();
            }
        }
    }
}
