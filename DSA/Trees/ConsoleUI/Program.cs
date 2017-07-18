using BinaryTree;
using System;
using System.Collections;

namespace ConsoleUI
{
    using BinaryHeap;
    using UnionFind;
    using System.Collections.Generic;
    using Node = Tree<int>;
    using System.Numerics;

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

            Console.WriteLine("Union find");

            var uf = new UnionFInd(10);

            Console.WriteLine("Ackermann");
            for (int i = 1; i <= 7; i++)
            {
                for (int j = 1; j <= 3; j++)
                {
                    Console.WriteLine(Ackermann(j , i));
                }
            }

            while(true)
            {
                var strs = Console.ReadLine().Split(' ');
                if (strs[0] == "f") 
                {
                    int x = int.Parse(strs[1]);
                    Console.WriteLine(uf.Find(x));
                }
                else if(strs[0] == "u")
                {
                    int x = int.Parse(strs[1]);
                    int y = int.Parse(strs[2]);
                    Console.WriteLine(uf.Union(x, y));
                }

                uf.Print();
            }
        }

        static BigInteger Ackermann(int m, BigInteger n)
        {
            if (m == 0)
            {
                return n + 1;
            }
            if (n == 0)
            {
                return Ackermann(m - 1, 1);
            }

            return Ackermann(m - 1, Ackermann(m, n - 1));
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
