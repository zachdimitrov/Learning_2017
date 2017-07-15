using BinaryTree;
using System;
using System.Collections;

namespace ConsoleUI
{
    using BinaryHeap;
    using System.Collections.Generic;
    using Node = Tree<int>;

    class Program
    {
        static void Main()
        {
            var tree = new Node(4,
                new Node(2,
                    new Node(1), new Node(3)),
                new Node(5,
                    null,
                    new Node(8,
                        new Node(7),
                        null)));

            Console.WriteLine("\nDFS traverse");
            Dfs(tree);

            Console.WriteLine("\nIterative DFS traverse");
            DfsIter(tree);

            Console.WriteLine("\nBFS traverse");
            Bfs(tree);

            Console.WriteLine("\nBinary heap");
            var array = new int[17];
            var rnd = new Random();
            for (int i = 0; i < array.Length; i++)
            {
                array[i] = rnd.Next() % 100;
            }

            Console.WriteLine(string.Join(", ", array));

            var heap = new Heap<int>((a, b) => a < b);

            Console.WriteLine("\nStart Inserting!");
            foreach (var x in array)
            {
                heap.Insert(x);
                Console.Write(heap.Top + " - ");
            }
            Console.WriteLine("\nAll inserted!");

            Console.WriteLine("\nStart Removing!");
            for (int i = 0; !heap.Empty; i++)
            {
                array[i] = heap.Top;
                Console.WriteLine(i + " - " + array[i]);
                heap.RemoveTop();
            }
            
            Console.WriteLine(string.Join(", ", array));
            Console.WriteLine("\nAll removed!");
        }

        static void Dfs<T>(Tree<T> root)
        {
            if (root == null)
            {
                return;
            }

            Console.WriteLine("Enter: " + root.Value); // preorder
            Dfs(root.Left);
            //Console.WriteLine("In between: " + root.Value); // in order
            Dfs(root.Right);
            //Console.WriteLine("Leaving: " + root.Value); // postorder
        }

        static void Bfs<T>(Tree<T> root)
        {
            var q = new Queue<Tree<T>>();
            q.Enqueue(root);

            while (q.Count > 0)
            {
                var x = q.Dequeue();
                Console.WriteLine(x.Value);
                if (x.Left != null)
                {
                    q.Enqueue(x.Left);
                }
                if (x.Right != null)
                {
                    q.Enqueue(x.Right);
                }
            }
        }

        static void DfsIter<T>(Tree<T> root)
        {
            var s = new Stack<Tree<T>>();
            s.Push(root);

            while (s.Count > 0)
            {
                var x = s.Pop();
                Console.WriteLine(x.Value);
                if (x.Left != null)
                {
                    s.Push(x.Left);
                }
                if (x.Right != null)
                {
                    s.Push(x.Right);
                }
            }
        }
    }
}
