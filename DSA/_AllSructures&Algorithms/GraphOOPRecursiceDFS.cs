namespace DFSRecursiveOOPGraph
{
    using System;
    using System.Collections.Generic;

    public class RecursiveDfs
    {
        public static void Main()
        {
            var graph = new Graph(
                new[]
                    {
                        new[] { 3, 6 }, // successors of vertice 0
                        new[] { 2, 3, 4, 5, 6 }, // successors of vertice 1
                        new[] { 1, 4, 5 }, // successors of vertice 2
                        new[] { 0, 1, 5 }, // successors of vertice 3
                        new[] { 1, 2, 6 }, // successors of vertice 4
                        new[] { 1, 2, 3 }, // successors of vertice 5
                        new[] { 0, 1, 4 } // successors of vertice 6
                    });

            graph.DfsRecursive(0);
        }
    }

    public class Graph
    {
        private readonly HashSet<int> visited;
        private readonly int[][] childNodes;

        public Graph(int[][] nodes)
        {
            this.childNodes = nodes;
            this.visited = new HashSet<int>();
        }

        public void DfsRecursive(int node)
        {
            if (!this.visited.Contains(node))
            {
                this.visited.Add(node);
                Console.WriteLine(node);

                for (int i = 0; i < this.childNodes[node].Length; i++)
                {
                    this.DfsRecursive(this.childNodes[node][i]);
                }
            }
        }
    }
}
