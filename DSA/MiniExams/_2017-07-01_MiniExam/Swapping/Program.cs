using System;
using System.Collections.Generic;
using System.Linq;

namespace Swapping
{
    class Link
    {
        public int Value { get; private set; }
        public Link Left { get; private set; }
        public Link Right { get; private set; }

        public Link(Link end, int x)
        {
            this.Value = x;
            this.Left = end;
            this.Right = null;

            if (end != null)
            {
                end.Right = this;
            }
        }

        public static void Detach(Link x)
        {
            if(x.Left != null)
            {
                x.Left.Right = null;
            }
            if (x.Right != null)
            {
                x.Right.Left = null;
            }
            x.Left = null;
            x.Right = null;
        }

        public static void Attach(Link l, Link r)
        {
            if(l == r)
            {
                return;
            }
            l.Right = r;
            r.Left = l;
        }
    }

    class Program
    {
        public static int[] SubArray(int[] data, int index, int length)
        {
            int[] result = new int[length];
            Array.Copy(data, index, result, 0, length);
            return result;
        }

        static void Main()
        {
            #region not working sollutions calls
            //Solution1();
            //Solution2();
            //Solution3();
            //Solution4();
            //Solution5();
            //Solution6();
            //Solution7();
            //Solution8();
            #endregion

            AuthorSolution();
        }

        static void AuthorSolution()
        {
            int n = int.Parse(Console.ReadLine());
            int[] numbers = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();

            Link[] links = new Link[n + 1];
            for(int i = 1; i <= n; ++i)
            {
                links[i] = new Link(links[i - 1], i);
            }

            var leftEnd = links[1];
            var rightEnd = links[n];

            foreach (int x in numbers)
            {
                var mid = links[x];
                var newRight = mid.Left;
                var newLeft = mid.Right;

                Link.Detach(mid);
                Link.Attach(rightEnd, mid);
                Link.Attach(mid, leftEnd);

                if (newLeft == null)
                {
                    leftEnd = mid;
                }
                else
                {
                    leftEnd = newLeft;
                }

                if (newRight == null)
                {
                    rightEnd = mid;
                }
                else
                {
                    rightEnd = newRight;
                }
            }

            var num = new int[n];
            for (int i = 0; i < n; i++)
            {
                num[i] = leftEnd.Value;
                leftEnd = leftEnd.Right;
            }

            Console.WriteLine(string.Join(" ", num));
        }

        #region not working solutions
        static void Solution1()
        {
            int n = int.Parse(Console.ReadLine());
            int[] numbers = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            int[] sequence = new int[n];

            for (int j = 1; j <= n; j++)
            {
                sequence[j - 1] = j;
            }

            for (int i = 0; i < numbers.Length; i++)
            {
                List<int> left = new List<int>();
                List<int> right = new List<int>();
                int mid = numbers[i];
                int index = Array.IndexOf(sequence, mid);

                for (int k = 0; k < sequence.Length; k++)
                {
                    if (k < index)
                    {
                        left.Add(sequence[k]);
                    }
                    if (k > index)
                    {
                        right.Add(sequence[k]);
                    }
                }

                right.Add(mid);

                if (left.Count == 0)
                {
                    sequence = right.ToArray();
                }
                else
                {
                    sequence = right.Concat(left).ToArray();
                }
            }

            Console.WriteLine(string.Join(" ", sequence));
        }

        static void Solution2()
        {
            int n = int.Parse(Console.ReadLine());
            int[] numbers = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            int[] sequence = new int[n];

            for (int j = 1; j <= n; j++)
            {
                sequence[j - 1] = j;
            }

            for (int i = 0; i < numbers.Length; i++)
            {
                int mid = numbers[i];
                int index = Array.IndexOf(sequence, mid);
                int[] left = sequence.Take(index).ToArray();
                int[] right = sequence.Skip(index).ToArray();

                int length = right.Length;

                for (int j = 0; j < length - 1; j++)
                {
                    if (length == 1)
                    {
                        break;
                    }
                    else
                    {
                        right[j] = right[j + 1];
                    }
                }

                right[right.Length - 1] = mid;

                sequence = right.Concat(left).ToArray();
            }

            Console.WriteLine(string.Join(" ", sequence));
        }

        static void Solution3()
        {
            int n = int.Parse(Console.ReadLine());
            int[] numbers = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            List<int> sequence = new List<int>();

            for (int j = 1; j <= n; j++)
            {
                sequence.Add(j);
            }

            for (int i = 0; i < numbers.Length; i++)
            {
                int index = sequence.IndexOf(numbers[i]);

                sequence.Add(numbers[i]);
                sequence.Remove(sequence[index]);

                for (int j = 0; j < index; j++)
                {
                    sequence.Add(sequence[0]);
                    sequence.Remove(sequence[0]);
                }
            }

            Console.WriteLine(string.Join(" ", sequence));
        }

        static void Solution4()
        {
            int n = int.Parse(Console.ReadLine());
            int[] numbers = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            List<int> sequence = Enumerable.Range(1, n).ToList();

            for (int i = 0; i < numbers.Length; i++)
            {
                int index = sequence.IndexOf(numbers[i]);

                sequence.Add(numbers[i]);
                sequence.Remove(sequence[index]);

                for (int j = 0; j < index; j++)
                {
                    sequence.Add(sequence[0]);
                    sequence.Remove(sequence[0]);
                }
            }

            Console.WriteLine(string.Join(" ", sequence));
        }

        static void Solution5()
        {
            int n = int.Parse(Console.ReadLine());
            int[] numbers = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            List<int> sequence = Enumerable.Range(1, n).ToList();

            for (int i = 0; i < numbers.Length; i++)
            {
                List<int> left = new List<int>();
                List<int> right = new List<int>();
                int mid = numbers[i];
                int index = sequence.IndexOf(numbers[i]);

                for (int k = 0; k < sequence.Count; k++)
                {
                    if (k < index)
                    {
                        left.Add(sequence[k]);
                    }
                    if (k > index)
                    {
                        right.Add(sequence[k]);
                    }
                }

                right.Add(mid);

                if (left.Count == 0)
                {
                    sequence = right;
                }
                else
                {
                    sequence = right.Concat(left).ToList();
                }
            }

            Console.WriteLine(string.Join(" ", sequence));
        }

        static void Solution6()
        {
            int n = int.Parse(Console.ReadLine());
            int[] numbers = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            LinkedList<int> list = new LinkedList<int>(Enumerable.Range(1, n));

            foreach (int t in numbers)
            {
                var call = list.Find(t);
                var newCall = new LinkedListNode<int>(call.Value);

                Console.WriteLine(string.Join(" ", list));

                var sep = call.Previous;
                list.Remove(call);
                list.AddFirst(newCall);

                while (list.Last.Value != sep.Value)
                {
                    var lastElem = list.Last.Value;
                    list.RemoveLast();
                    list.AddFirst(new LinkedListNode<int>(lastElem));
                }
            }

            Console.WriteLine(string.Join(" ", list));
        }

        static void Solution7()
        {

            int n = int.Parse(Console.ReadLine());
            int[] numbers = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            LinkedList<int> list = new LinkedList<int>(Enumerable.Range(1, n));

            for (int i = 0; i < numbers.Length; i++)
            {
                int t = numbers[i];
                var call = list.Find(t);

                if (call.Value != list.First.Value && call.Value != list.Last.Value)
                {
                    var val = call.Previous.Value;
                    list.Remove(call);
                    list.AddFirst(call);

                    while (list.Last.Value != val)
                    {
                        var lastElem = list.Last;
                        list.RemoveLast();
                        list.AddFirst(lastElem);
                    }
                }
                else if (call.Value == list.First.Value)
                {
                    var node = list.First();
                    list.RemoveFirst();
                    list.AddLast(node);
                }
                else if (call.Value == list.Last.Value)
                {
                    var node = list.Last();
                    list.RemoveLast();
                    list.AddFirst(node);
                }
            }

            Console.WriteLine(string.Join(" ", list));
        }

        static void Solution8()
        {

            int n = int.Parse(Console.ReadLine());
            int[] numbers = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            LinkedList<int> list = new LinkedList<int>(Enumerable.Range(1, n));

            for (int i = 0; i < numbers.Length; i++)
            {
                int t = numbers[i];
                var call = list.Find(t);

                if (call.Value != list.First.Value && call.Value != list.Last.Value)
                {

                }
                else if (call.Value == list.First.Value)
                {

                }
                else if (call.Value == list.Last.Value)
                {

                }
            }

            Console.WriteLine(string.Join(" ", list));
        }
        #endregion
    }
}
