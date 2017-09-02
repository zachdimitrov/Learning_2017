using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SearchingHomework
{
    class Program
    {
        static void Main()
        {

            var collection = new SortableCollection<int>(new[] { 22, 11, 101, 33, 0, 101, 5, 23, 1, 4, 5, 7, 32, 6, 88, 2 });
            Console.WriteLine("Quicksorter result:");
            collection.Sort(new QuickSorter<int>());
            collection.PrintAllItemsOnConsole();
            Console.WriteLine();

            int n = 101;
            Console.WriteLine($"Number {n} is found on index: {collection.BinarySearch(n)}");
        }
    }
}
