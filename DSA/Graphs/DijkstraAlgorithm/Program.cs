using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DijkstraAlgorithm
{
    class Program
    {
        // input - nodes, edges, weight
        private static string input = @"5
8
1 2 2
1 3 3
1 4 11
2 3 3
2 5 15
3 4 2
3 5 6
4 5 3";

        static void FakeInput()
        {
            Console.SetIn(new StringReader(input));
        }

        static void Main()
        {
            FakeInput();
            ReadWeightedGraph();
        }

        private static List<Node>[] ReadWeightedGraph()
        {
            var n = int.Parse(Console.ReadLine());
            var m = int.Parse(Console.ReadLine());

            var vertices = new List<Node>[n];
            for (int i = 0; i < m; i++)
            {
                var edge = conso
            }
        }
    }
}
