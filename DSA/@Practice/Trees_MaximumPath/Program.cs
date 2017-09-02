using System;
using System.Collections.Generic;
using System.Linq;

namespace Trees_MaximumPath
{
    public class Node
    {
        public Node(int value)
        {
            this.Value = value;
            this.Children = new List<Node>();
        }

        public int Value { get; set; }
        public List<Node> Children { get; set; }
        public bool HasParent { get; set; }

        public int NumberOfChildren
        {
            get
            {
                return this.Children.Count;
            }
        }

        public void AddChild(Node child)
        {
            child.HasParent = true;
            this.Children.Add(child);
        }

        public Node GetNode(int index)
        {
            return this.Children[index];
        }
    }

    class Program
    {
        static long maxSum = 0;
        static HashSet<Node> used = new HashSet<Node>();

        static void DFS(Node node, long currentSum)
        {
            currentSum += node.Value;
            used.Add(node);

            for (int i = 0; i < node.NumberOfChildren; i++)
            {
                if (used.Contains(node.GetNode(i)))
                {
                    continue;
                }

                DFS(node.GetNode(i), currentSum);
            }

            if (node.NumberOfChildren == 1 && currentSum > maxSum)
            {
                maxSum = currentSum;
            }
        }

        static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            var tree = new Dictionary<int, Node>();

            for (int i = 0; i < n - 1; i++)
            {
                var line = Console.ReadLine()
                    .Split(new Char[] { '(', ')', '<', '-' }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();

                int parent = line[0];
                int child = line[1];

                Node parentNode = new Trees_MaximumPath.Node(parent);
                Node childNode = new Trees_MaximumPath.Node(child);

                if (tree.ContainsKey(parent))
                {
                    parentNode = tree[parent];
                }
                else
                {
                    parentNode = new Node(parent);
                    tree.Add(parent, parentNode);
                }

                if (tree.ContainsKey(child))
                {
                    childNode = tree[child];
                }
                else
                {
                    childNode = new Node(child);
                    tree.Add(child, childNode);

                }

                parentNode.AddChild(childNode);
                childNode.AddChild(parentNode);  // ?
            }

            foreach (var node in tree)
            {
                if (node.Value.NumberOfChildren == 1)
                {
                    used.Clear();
                    DFS(node.Value, 0);
                }
            }

            Console.WriteLine(maxSum);
        }
    }
}
