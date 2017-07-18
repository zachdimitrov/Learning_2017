using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;

namespace Recursion
{
    class Program
    {
        static void Main()
        {
            //Console.WriteLine("------ Simple ------");
            //Rec(10);
            //Console.WriteLine($"Back in main");

            //Console.WriteLine(FastPower(545, 100000));

            //Console.WriteLine("------ Factorial ------");
            //long fact = Factorial(5);
            //Console.WriteLine(fact);

            //Console.WriteLine("------ Factorial witn Memo ------");
            //FactorialMemo(1000);
            //FactorialMemo(3000);
            //FactorialMemo(5000);
            //FactorialMemo(8000);
            //FactorialMemo(11000);
            //Console.WriteLine(FactorialMemo(14000));

            //Console.WriteLine("------ Without Recursion ------");
            //BitsWithoutRec();

            //Console.WriteLine("------ With Recursion ------");
            //Bits(4, "");

            //Console.WriteLine("------ Decimals With Recursion ------");
            //Decimals(1, "");

            //Console.WriteLine("------ Fibonacci With Recursion ------");
            //Fibonacci(1000);
            //Fibonacci(2000);
            //Fibonacci(3000);
            //Fibonacci(4000);
            //Fibonacci(5000);
            //Fibonacci(6000);
            //Fibonacci(7000);
            //Fibonacci(8000);
            //Fibonacci(9000);
            //Fibonacci(10000);
            //Console.WriteLine(Math.Exp(BigInteger.Log(Fibonacci(11001)) - BigInteger.Log(Fibonacci(11000))));

            //Console.WriteLine("------ Expression Brackets With Recursion ------");
            //string exp = "((s + 2) - ((d + s*(d - s) - 3) * (3 + 1)))";
            //ExtractRec(exp, 0);
        }

        // 8-th queen

        // sudoku

        // fast power
        static BigInteger FastPower(int n, int p)
        {
            if (p == 0)
            {
                return 1;
            }

            if (p % 2 == 1)
            {
                return n * FastPower(n, p - 1);
            }

            BigInteger half = FastPower(n, p / 2);
            return half * half;
        }

        // fibonacci
        private static BigInteger[] memo = new BigInteger[100001];
        static BigInteger Fibonacci(int n)
        {
            if (memo[n] == 0)
            {
                if (n == 1 || n == 2)
                {
                    memo[n] = 1;
                }
                else
                {
                    memo[n] = Fibonacci(n - 1) + Fibonacci(n - 2);
                }
            }

            return memo[n];
        }

        // labirinth

        // bits without recursion
        static void BitsWithoutRec()
        {
            for (int b1 = 0; b1 < 2; b1++)
            {
                for (int b2 = 0; b2 < 2; b2++)
                {
                    for (int b3 = 0; b3 < 2; b3++)
                    {
                        for (int b4 = 0; b4 < 2; b4++)
                        {
                            Console.WriteLine($"{b1}{b2}{b3}{b4}");
                        }
                    }
                }
            }
        }

        // bits with recursion
        static void Bits(int n, string bits)
        {
            if (n == 0)
            {
                Console.WriteLine(bits);
                return;
            }

            Bits(n - 1, bits + "0");
            Bits(n - 1, bits + "1");
        }

        // decimals with recursion
        static void Decimals(int n, string decs)
        {
            if (n == 0)
            {
                Console.WriteLine(decs);
                return;
            }

            for(int d = 0; d < 10; ++d)
            {
                Decimals(n - 1, decs + d);
            }
        }

        // factorial
        static long Factorial(int n)
        {
            if(n == 0)
            {
                return 1;
            }

            return n * Factorial(n - 1);
        }

        // factorial with memo
        private static readonly BigInteger[] factMemo = new BigInteger[1000000];
        private static BigInteger FactorialMemo(int n)
        {
            if (n == 0)
            {
                return 1;
            }

            if (factMemo[n] == 0)
            {
                factMemo[n] = n * FactorialMemo(n - 1);
            }

            return factMemo[n];
        }

        // simple reqursion
        static void Rec(int steps)
        {
            Console.WriteLine($"Called at {steps}");
            if (steps <= 0)
            {
                Console.WriteLine($"Returns at {steps}");
                return;
            }
            
            Rec(steps - 1);
            Console.WriteLine($"Returns at {steps}");
        }

        // extract from expression
        static void extract(string exp)
        {
            var stack = new Stack<int>();
            for (int i = 0; i < exp.Length; i++)
            {
                if (exp[i] == '(')
                {
                    stack.Push(i);
                }
                else if (exp[i] == ')')
                {
                    var start = stack.Peek();
                    var length = i - start + 1;
                    Console.WriteLine(exp.Substring(start, length));
                    stack.Pop();
                }
            }
        }

        // extract from expression with recursion
        static int ExtractRec(string exp, int i)
        {
            if (i >= exp.Length)
            {
                return 0;
            }

            if (exp[i] == '(')
            {
                var result = ExtractRec(exp, i + 1);
                var length = result + 1 - i;
                Console.WriteLine(exp.Substring(i, length));
                return ExtractRec(exp, result + 1);
            }
            else if (exp[i] == ')')
            {
                return i;
            }
            return ExtractRec(exp, i + 1);
        }
    }
}
