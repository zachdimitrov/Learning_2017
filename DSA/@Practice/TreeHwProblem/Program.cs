using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TreeHwProblem
{
    class Program
    {
        static Node<int> FindRoot(Node<int>[] tree)
        {
            var hasParent = new bool[tree.Length];

            foreach(var node in tree)
            {
                foreach (var child in node.Children)
                {
                    hasParent[child.Value] = true;
                }
            }

            for (int i = 0; i < hasParent.Length; i++)
            {
                if (!hasParent[i])
                {
                    return tree[i];
                }
            }

            return null;
        }

        static List<Node<int>> FindLeaves(Node<int>[] tree)
        {
            var leaves = new List<Node<int>>();

            foreach (var node in tree)
            {
                if (node.Children.Count == 0)
                {
                    leaves.Add(node);
                }
            }

            return leaves;
        }

        static List<Node<int>> MiddleNodes(Node<int>[] tree)
        {
            var nodes = new List<Node<int>>();

            foreach (var node in tree)
            {
                if (node.Children.Count > 0 && node.HasParent)
                {
                    nodes.Add(node);
                }
            }

            return nodes;
        }

        private static int FindLongestPath(Node<int> root)
        {
            if (root.Children.Count == 0)
            {
                return 0;
            }

            int maxPath = 0;

            foreach (var node in root.Children)
            {
                maxPath = Math.Max(maxPath, FindLongestPath(node));
            }

            return maxPath + 1;
        }

        static Node<int>[] CreeateTree(int n)
        {
            // create array of nodes
            var nodes = new Node<int>[n];

            for (int i = 0; i < n; i++)
            {
                nodes[i] = new Node<int>(i);
            }

            // construct tree
            for (int j = 0; j < n - 1; j++)
            {
                string edgeStr = Console.ReadLine();
                var edgeParts = edgeStr.Split(' ');

                int parent = int.Parse(edgeParts[0]);
                int child = int.Parse(edgeParts[1]);

                nodes[parent].Children.Add(nodes[child]);
                nodes[child].HasParent = true;
            }

            return nodes;
        }

        static void Main(string[] args)
        {
            // get number of nodes
            int n = int.Parse(Console.ReadLine());

            // construct tree as Node<T>[] with linked nodes
            var tree = CreeateTree(n);

            // 1. Root
            Node<int> root = FindRoot(tree);
            if (root != null)
            {
                Console.WriteLine($"1. The root is: {root.Value}");
            }
            else
            {
                Console.WriteLine("1. Tree does not have a root!");
            }

            // 2. Find leaves
            var leaves = FindLeaves(tree);
            Console.WriteLine($"2. Leaves in the tree: {string.Join(", ", leaves.Select(x => x.Value).ToList())}");

            // 3. Find middle nodes
            var midNodes = MiddleNodes(tree);
            Console.WriteLine($"3. All middle nodes: {string.Join(", ", midNodes.Select(x => x.Value).ToList())}");

            // 4. Find longest path
            var path = FindLongestPath(root);
            Console.WriteLine($"4. The longest path is: {path}");
        }
    }
}

/*
Input: 

7
2 4
3 2
5 0
3 5
5 6
5 1

*/
