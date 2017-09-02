using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bridges
{
    public struct Edge : IComparable<Edge>
    {
        public int StartNode { get; set; }
        public int EndNode { get; set; }
        public int Weight { get; set; }

        public Edge(int startVertex, int endVertex, int weight)
            : this()
        {
            this.StartNode = startVertex;
            this.EndNode = endVertex;
            this.Weight = weight;
        }

        public int CompareTo(Edge other)
        {
            int weightCompared = this.Weight.CompareTo(other.Weight);

            if (weightCompared == 0)
            {
                return this.StartNode.CompareTo(other.StartNode);
            }
            return weightCompared;
        }

        public override string ToString()
        {
            return string.Format("({0} {1}) -> {2}", this.StartNode, this.EndNode, this.Weight);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            int[] nm = Console.ReadLine()
                .Split(' ')
                .Select(int.Parse)
                .ToArray();

            var priority = new SortedSet<Edge>();
            int numberOfNodes = nm[0];
            var used = new bool[numberOfNodes + 1];
            var mpdNodes = new List<Edge>();
            var edges = new List<Edge>();
            InitializeGraph(edges, nm[1]);

            foreach (Edge edge in edges)
            {
                if (edge.StartNode == edges[0].StartNode)
                {
                    priority.Add(edge);
                }
            }

            used[edges[0].StartNode] = true;

            FindMinimumSpanningTree(used, priority, mpdNodes, edges);
            PrintMinimumSpanningTree(mpdNodes);
        }

        private static void PrintMinimumSpanningTree(IEnumerable<Edge> mpdNodes)
        {
            int steve = int.Parse(Console.ReadLine());

            int br = 0;

            foreach (Edge edge in mpdNodes)
            {
                Console.WriteLine("{0}", edge);

                if (edge.Weight < steve)
                {
                    br++;
                }
            }

            Console.WriteLine(br);
        }

        private static void FindMinimumSpanningTree(bool[] used, SortedSet<Edge> priority, List<Edge> mpdEdges, List<Edge> edges)
        {
            while (priority.Count > 0)
            {
                Edge edge = priority.Max;
                priority.Remove(edge);

                if (!used[edge.EndNode])
                {
                    used[edge.EndNode] = true; // we "visit" this node
                    mpdEdges.Add(edge);
                    AddEdges(edge, edges, mpdEdges, priority, used);
                }
            }
        }

        private static void AddEdges(Edge edge, List<Edge> edges, List<Edge> mpd, SortedSet<Edge> priority, bool[] used)
        {
            for (int i = 0; i < edges.Count; i++)
            {
                if (!mpd.Contains(edges[i]))
                {
                    if (edge.EndNode == edges[i].StartNode && !used[edges[i].EndNode])
                    {
                        priority.Add(edges[i]);
                    }
                }
            }
        }

        private static void InitializeGraph(List<Edge> edges, int n)
        {
            for (int i = 0; i < n; i++)
            {
                int[] e = Console.ReadLine()
                    .Split(' ')
                    .Select(int.Parse)
                    .ToArray();

                edges.Add(new Edge(e[0], e[1], e[2]));
            }
        }
    }
}
