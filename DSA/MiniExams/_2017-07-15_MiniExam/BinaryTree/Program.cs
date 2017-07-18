using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;

namespace BinaryTree
{
    public class Tree
    {
        private int p;
        private ulong value;

        public Tree(int p, ulong value)
        {
            this.p = p;
            this.Value = value;
        }

        public ulong Value
        {
            get
            {
                return this.value;
            }
            set
            {
                this.value = value;
            }
        }

        public Tree Left
        {
            get
            {
                return new Tree(p, this.value * (ulong)p);
            }
        }

        public Tree Right
        {
            get
            {
                return new Tree(p, this.value * (ulong)p + 1);
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            MySolution();
            //BinaryTree();
        }

        public static void MySolution()
        {
            var p = int.Parse(Console.ReadLine());
            var test = Console.ReadLine()
                .Split(' ')
                .Select(ulong.Parse)
                .ToArray();

            var tree = new Tree(p, 1);
            var len = test.Length;
            var result = new int[len];

            var nodes = new List<ulong>();

            var s = new Queue<Tree>();
            s.Enqueue(tree);

            while (true)
            {
                var x = s.Dequeue();

                if (x.Value > test.Max())
                {
                    break;
                }
                else
                {
                    nodes.Add(x.Value);
                }

                //Console.WriteLine(x.Value + " - " + x.Left.Value + " - " + x.Right.Value);
                s.Enqueue(x.Left);
                s.Enqueue(x.Right);
            }

            for (int i = 0; i < len; i++)
            {
                int finalRes = 0;
                int numFound = 0;

                foreach (var node in nodes)
                {
                    int res = Dfs(tree, node, test[i]);
                    //Console.WriteLine($" - dfs - {node.Value} - {test[i]} - {res}");
                    if (res == 1)
                    {
                        finalRes = 1;
                        numFound++;
                        if (numFound > 2)
                        {
                            break;
                        }
                    }
                }

                if (finalRes == 1 && numFound > 2)
                {
                    finalRes = 0;
                }

                result[i] = finalRes;
            }

            Console.WriteLine(string.Join(" ", result));
        }

        static int Dfs(Tree root, ulong sumNumber, ulong test)
        {
            var s = new Queue<Tree>();
            s.Enqueue(root);

            while (true)
            {
                var x = s.Dequeue();
                if (x.Value > test )
                {
                    break;
                }

                if (sumNumber != x.Value && sumNumber + x.Value == test)
                {
                    //Console.WriteLine(sumNumber + " + " + x.Value + " = " + test);
                    return 1;
                }

                s.Enqueue(x.Left);
                s.Enqueue(x.Right);
            }

            return 0;
        }

        #region Other People Solution
        /*
        public static void BinaryTree()
        {
            int p = int.Parse(Console.ReadLine());
            List<ulong> listSums = Console.ReadLine()
                                .Split(' ')
                                .Select(ulong.Parse)
                                .ToList();

            var results = new List<int>();

            foreach (var sum in listSums)
            {
                results.Add(FindPretty(sum, p, 1));
            }
            Console.WriteLine(string.Join(" ", results));
        }

        public static int FindPretty(ulong sum, int p, int rootNumber)
        {
            var sq = new Queue<ulong>();

            sq.Enqueue(rootNumber);

            var listTree = new List<ulong>();

            while (sq.Peek() < sum)
            {
                sq.Enqueue(sq.Peek() * p);
                sq.Enqueue(sq.Peek() * p + 1);
                listTree.Add(sq.Dequeue());
            }
            var counter = 0;
            var first = listTree[0];

            var compliments = new HashSet<ulong>();

            compliments.Add(sum - first);

            for (int i = 1; i < listTree.Count; i++)
            {
                if (compliments.Contains(listTree[i]))
                {
                    counter++;
                }
                else
                {
                    compliments.Add(sum - listTree[i]);
                }
            }

            if (counter == 1)
            {
                return counter;
            }

            return 0;
        }
        */
        #endregion
    }
}

