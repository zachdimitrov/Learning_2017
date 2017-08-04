using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DijkstraAlgorithm
{
    class Program
    {
        // input - nodes, edges, weight
        private static string input = @"5
8
1 2 2
1 3 3
1 4 11
2 3 3
2 5 15
3 4 2
3 5 6
4 5 3";

        static void FakeInput()
        {
            Console.SetIn(new StringReader(input));
        }

        static void Main()
        {
            FakeInput();
            var vertices = ReadWeightedGraph();
            var dist = Dijkstra(vertices, 1 - 1);
            Console.WriteLine(string.Join(", ", dist));
        }

        private static int[] Dijkstra(List<Node>[] vertices, int start)
        {
            // regular for is better (3 cycles here)
            //var d = Enumerable.Range(1, vertices.Length).Select(_ => int.MaxValue).ToArray();

            const int INFINITY = int.MaxValue;

            var d = new int[vertices.Length];
            for (int i = 0; i < d.Length; i++)
            {
                d[i] = INFINITY;
            }

            d[start] = 0;

            var used = new HashSet<int>();
            var queue = new PriorityQueue<Node>();
            queue.Enqueue(new Node(start, 0));

            // repeat
            while (queue.IsEmpty == false)
            {
                // find new best
                var node = queue.Dequeue();
                while (queue.IsEmpty == false && used.Contains(node.Vertex))
                {
                    node = queue.Dequeue();
                }

                used.Add(node.Vertex);

                // update distances of best
                foreach (var next in vertices[node.Vertex])
                {
                    var currentDist = d[next.Vertex];
                    var newDist = d[node.Vertex] + next.Distance;

                    if (currentDist <= newDist)
                    {
                        continue;
                    }

                    d[next.Vertex] = newDist;
                    queue.Enqueue(new Node(next.Vertex, newDist));
                }
            }

            return d;
        }

        private static List<Node>[] ReadWeightedGraph()
        {
            var n = int.Parse(Console.ReadLine());
            var m = int.Parse(Console.ReadLine());

            var vertices = new List<Node>[n];

            for (int i = 0; i < m; i++)
            {
                var edge = Console.ReadLine()
                    .Split(' ')
                    .Select(int.Parse)
                    .ToArray();

                AddEdge(vertices, edge[0] - 1, edge[1] - 1, edge[2]);
                AddEdge(vertices, edge[1] - 1, edge[0] - 1, edge[2]);
            }

            return vertices;
        }

        private static void AddEdge(List<Node>[] vertices, int from, int to, int dist)
        {
            if (vertices[from] == null)
            {
                vertices[from] = new List<Node>();
            }

            vertices[from].Add(new Node(to, dist));
        }
    }
}
