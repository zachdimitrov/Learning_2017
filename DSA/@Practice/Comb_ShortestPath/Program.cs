using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Comb_ShortestPath
{
    class Program
    {
        static char[] path;

        static HashSet<string> combs = new HashSet<string>();

        static void FindPaths(int i)
        {

            if (i == path.Length)
            {
                combs.Add(new string(path));
                return;
            }

            if (path[i] == '*')
            {
                path[i] = 'L';
                FindPaths(i + 1);
                path[i] = 'R';
                FindPaths(i + 1);
                path[i] = 'S';
                FindPaths(i + 1);
                path[i] = '*';
            }
            else
            {
                FindPaths(i + 1);
            }
        }

        static void Main(string[] args)
        {
            path = Console.ReadLine().ToCharArray();

            FindPaths(0);

            Console.WriteLine(combs.Count);
            foreach (var comb in combs)
            {
                Console.WriteLine(comb);
            }
        }
    }
}
