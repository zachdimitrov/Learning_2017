using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphsAlgorithms
{
    class Program
    {
        // input - nodes, edges, weight
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

        private static LinkedList<int>[] ReadGraph()
        {
            FakeInput();
            int n = int.Parse(Console.ReadLine());
            int m = int.Parse(Console.ReadLine());

            var vertices = new LinkedList<int>[n];

            for (int i = 0; i < m; i++)
            {
                var edge = Console.ReadLine()
                    .Split(' ')
                    .Select(int.Parse)
                    .ToArray();

                var x = edge[0] - 1;
                var y = edge[1] - 1;

                if (vertices[x] == null)
                {
                    vertices[x] = new LinkedList<int>();
                }

                if (vertices[y] == null)
                {
                    vertices[y] = new LinkedList<int>();
                }

                vertices[x].AddLast(y);
                vertices[y].AddLast(x);
            }

            return vertices;
        }

        static void Main()
        {
            var vertices = ReadGraph();
            PrintPathWithDfs(vertices);
            PrintPathWithBfs(vertices);
        }

        private static void PrintPathWithBfs(LinkedList<int>[] vertices)
        {
            var vertex = 0;
            var used = new bool[vertices.Length];

            Queue<int> queue = new Queue<int>();
            queue.Enqueue(3 - 1);
            while (queue.Count > 0)
            {

            }
        }

        private static void PrintPathWithDfs(LinkedList<int>[] vertices)
        {
            var vertex = 0;
            var used = new bool[vertices.Length];
            var path = new int[vertices.Length];
            path[0] = -1;

            Dfs(vertex, vertices, used, path, "");

            Console.WriteLine("\npath values:");
            Console.WriteLine(string.Join(" ", path));
            Console.WriteLine("\npath nexts:");
            for (int i = 0; i < vertices.Length; i++)
            {
                Console.WriteLine($"{path[i] + 1} -> {i + 1}");
            }
            Console.WriteLine("\nother path examples");

            var current = 5 - 1;
            while (current != -1)
            {
                Console.WriteLine(current);
                current = path[current];
            }
        }

        private static void Dfs(int vertex, LinkedList<int>[] vertices, bool[] used, int[] path, string sep)
        {
            used[vertex] = true;

            var nexts = vertices[vertex].OrderBy(x => x);

            Console.WriteLine(sep + " " + (vertex + 1));

            foreach (var next in nexts)
            {
                if (used[next])
                {
                    continue;
                }

                path[next] = vertex;
                Dfs(next, vertices, used, path, sep + "--");
            }
        }
    }
}

// 1:03