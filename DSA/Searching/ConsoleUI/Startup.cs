using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleUI
{
    public class Startup
    {
        public static void Main()
        {
            int n = 100;
            var array = new int[n];
            var rand = new Random();
            for (int i = 0; i < array.Length; i++)
            {
                array[i] = rand.Next() % 1000;
            }
            
            Console.WriteLine("Not Sorted: " + string.Join(" ", array));
            Console.WriteLine(array.FindFirst(684));
            Console.WriteLine(array.FindFirst(x => x > 800));
            BinarySearch.BinarySearchSort(array);
            Console.WriteLine("Sorted: " + string.Join(" ", array));
            Console.WriteLine(array.BinarySearchBadExample(684));
            var arr = Shuffle.GenShuffled(10);
            Console.WriteLine("Random shuffled: " + string.Join(" ", arr));

            Console.WriteLine("-------- Solve Equasion --------");

            Console.WriteLine("Solve: x ^ 2 - 5 * x + 6 = 0");
            var roots = PolinomialSolver.Solve(new List<double>() { 6, 5, 1 });
            Console.WriteLine(String.Join(", ", roots));

            Console.WriteLine("Solve: 3 * x ^ 7 - 12 * x ^ 6 + 4 * x ^ 5 + 3 * x ^ 4 + 8 * x ^ 2 + 5 * x + 6 = 0");
            var roots2 = PolinomialSolver.Solve(new List<double>() { 6, 5, 8, 3, 4, -12, 3 });
            Console.WriteLine(String.Join(", ", roots2));

            Console.WriteLine("Solve: x^6 - 2*x^5 - 2.75*x^4 - 1.25*x3 + 1*x^2 + 1.75*x - 0.75");
            var roots3 = PolinomialSolver.Solve(new List<double>() { -0.75, 1.75, 1, -1.25, -2.75, -2, 1 });
            Console.WriteLine(String.Join(", ", roots3));
        }
    }
}
