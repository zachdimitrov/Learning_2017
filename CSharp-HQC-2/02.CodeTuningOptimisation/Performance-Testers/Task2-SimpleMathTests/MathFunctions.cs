using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2_SimpleMathTests
{
    public static class MathFunctions
    {
        static MathFunctions()
        {
        }

        public static void TestMathOperation(string operation)
        {
            Console.WriteLine(operation);

            int small = 2;
            int large = 1000000;

            var stopwatch = new Stopwatch();

            stopwatch.Start();

            for (int i = 0; i < 100000; i++)
            {
                switch (operation)
                {
                    case "addition":
                        small = small + 1;
                        break;
                    case "substract":
                        large = large - 1;
                        break;
                    case "increment":
                        small += 1;
                        break;
                    case "multiply":
                        small = small*2;
                        break;
                    case "deletion":
                        double result = large/2;
                        break;
                }
            }

            stopwatch.Stop();

            Console.WriteLine("{0} took - {1} ms", operation, stopwatch.Elapsed);
        }
    }
}
