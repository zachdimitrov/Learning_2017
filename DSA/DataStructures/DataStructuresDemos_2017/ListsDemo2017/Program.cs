using System;
using System.Diagnostics;
using System.Text;
using LinearDataStructures;
using DoublyLinkedList;

namespace ListsDemo2017
{
    class Program
    {
        static void TimeCode(Action func)
        {
            var watch = new Stopwatch();

            watch.Start();
            func();
            watch.Stop();

            Console.WriteLine($"Elapsed: { watch.Elapsed }");
        }

        static void Main(string[] args)
        {
            //Console.WriteLine("----------- Standard List ------------");
            //var list = new List<int>();
            //TimeCode(() =>
            //{

            //});

            //while (true)
            //{
            //    var strs = Console.ReadLine().Split(' ');
            //    var index = int.Parse(strs[0]);
            //    var value = int.Parse(strs[1]);

            //    list.InsertAt(index, value);

            //    var line = new StringBuilder();
            //    for (int i = 0; i < list.Size; i++)
            //    {
            //        line.Append($" {list[i]}");
            //    }
            //}

            //Console.WriteLine(list.Capacity);

            Console.WriteLine("----------- Doubly Linked List ------------");
            Console.WriteLine(@" Use these commands:
 f [number] - Push to front
 b [number] - Push to back
 r r        - Pop from front
 l l        - Pop from back
 d [index]  - Delete by Index
");
            var x = new DoublyLinkedList<int>();
            string result = "";
            ShowResult(x);

            while (true)
            {
                var str = Console.ReadLine().Split(' ');
                if (str.Length < 2)
                {
                    ShowResult(x);
                    continue;
                }

                if (str[0][0] == 'f')
                {
                    int value = int.Parse(str[1]);
                    x.PushFront(value);
                    ShowAdded(value);
                    ShowResult(x);
                }
                else if (str[0][0] == 'b')
                {
                    int value = int.Parse(str[1]);
                    x.PushBack(value);
                    ShowAdded(value);
                    ShowResult(x);
                }
                else if (str[0][0] == 'r')
                {
                    var t = x.PopFront();
                    ShowRemoved(t);
                    ShowResult(x);
                }
                else if (str[0][0] == 'l')
                {
                    var t = x.PopBack();
                    ShowRemoved(t);
                    ShowResult(x);
                }
                else if (str[0][0] == 'd')
                {
                    var node = x.First;
                    var index = int.Parse(str[1]);
                    for (int i = 0; i < index; ++i)
                    {
                        node = node.Next;
                    }
                    var t = x.Remove(node);
                    ShowRemoved(t);
                    ShowResult(x);
                }
                else if (str[0] == "end")
                {
                    break;
                }
            }
        }

        private static void ShowRemoved(int t)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.SetCursorPosition(1, 9);
            ClearLine();
            Console.WriteLine($"Removed value: {t}");
        }

        private static void ShowAdded(int t)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.SetCursorPosition(1, 9);
            ClearLine();
            Console.WriteLine($"Added value: {t}");
        }

        private static void ShowResult(DoublyLinkedList<int> x)
        {
            // show result list
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.SetCursorPosition(0, 8);
            ClearLine();
            var line = new StringBuilder();
            if (x.First == null && x.Last == null)
            {
                line.Append("No items!");
            }
            else
            {
                for (var node = x.First; node != null; node = node.Next)
                {
                    line.Append($" {node.Val}");
                }
            }

            Console.WriteLine(line.ToString());
            Console.ForegroundColor = ConsoleColor.White;
            Console.SetCursorPosition(1, 10);
            ClearLine();
        }

        public static void ClearLine()
        {
            int currentLineCursor = Console.CursorTop;
            Console.SetCursorPosition(1, Console.CursorTop);
            Console.Write(new string(' ', Console.WindowWidth));
            Console.SetCursorPosition(1, currentLineCursor);
        }
    }
}
