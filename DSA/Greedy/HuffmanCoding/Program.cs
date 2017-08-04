using GraphsAlgorithms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HuffmanCoding
{
    class Program
    {
        static void Main()
        {
            var line = Console.ReadLine();
            var freq = new Dictionary<char, int>();
            var queue = new PriorityQueue<Tuple<int, HuffmanTree>>((x, y) => x.Item1 < y.Item1);

            foreach (char c in line)
            {
                if (freq.ContainsKey(c))
                {
                    freq[c]++;
                }
                else
                {
                    freq[c] = 1;
                }
            }

            foreach (var x in freq)
            {
                queue.Enqueue(new Tuple<int, HuffmanTree>(x.Value, new HuffmanTree(x.Key)));
            }

            while (queue.Count > 1)
            {
                var x = queue.Dequeue();
                var y = queue.Dequeue();

                queue.Enqueue(new Tuple<int, HuffmanTree>(
                    x.Item1 + y.Item1,
                    new HuffmanTree(x.Item2, y.Item2)));
            }

            var root = queue.Dequeue().Item2;
            root.Dfs();
        }
    }
}
