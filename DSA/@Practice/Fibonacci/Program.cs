using System;

namespace Fibonacci
{
    public class IterativeFibonacci
    {
        public const int M = 1000000007;
        private static long[] memo;

        public static void Main()
        {
            var n = long.Parse(Console.ReadLine());
            memo = new long[n + 1];
            //var result = FibRec(n);
            //var result = Fib(n);
            var result = FibDin(n);
            Console.WriteLine(result);
            //Console.WriteLine(FastPower(2, 20));
        }

        public static long FibDin(long n)
        {
            Matrix a = Matrix.Single;
            return Matrix.Power(a, n).Table[0,1];
        }

        public static long FibRec(long n)
        {
            if (memo[n] != 0)
            {
                return memo[n];
            }

            if (n == 1 || n == 2)
            {
                return 1;
            }

            var number = FibRec(n - 1) + FibRec(n - 2);
            number %= M;
            memo[n] = number;
            return number;
        }

        public static long Fib(long n)
        {
            long fn = 0;
            long fnMinus1 = 1;
            long fnMinus2 = 1;

            if (n == 1 || n == 2)
            {
                return 1;
            }

            for (long i = 2; i < n; i++)
            {
                fn = fnMinus1 + fnMinus2;
                fnMinus2 = fnMinus1 % M;
                fnMinus1 = fn % M;
            }

            return fn % M;
        }

        public static long FastPower(long a, long p)
        {
            if (p == 0)
            {
                return 1;
            }

            if (p % 2 == 1)
            {
                return FastPower(a, p - 1) * a % M;
            }

            a = FastPower(a, p / 2);
            return a * a % M;
        }
    }

    public class Matrix
    {
        public const int M = 1000000007;

        public long[,] Table { get; set; }

        public Matrix()
        {
            Table = new long[2, 2];
        }

        public Matrix(int a, int b, int c, int d)
        {
            Table = new long[2, 2];
            Table[0, 0] = a;
            Table[0, 1] = b;
            Table[1, 0] = c;
            Table[1, 1] = d;
        }

        public Matrix(Matrix A, Matrix B)
        {
            Table = new long[2, 2];
            Table[0, 0] = A.Table[0, 0] * B.Table[0, 0] + A.Table[0, 1] * B.Table[1, 0];
            Table[0, 1] = A.Table[0, 0] * B.Table[0, 1] + A.Table[0, 1] * B.Table[1, 1];
            Table[1, 0] = A.Table[1, 0] * B.Table[0, 0] + A.Table[1, 1] * B.Table[1, 0];
            Table[1, 1] = A.Table[1, 0] * B.Table[0, 1] + A.Table[1, 1] * B.Table[1, 1];

            Table[0, 0] %= M;
            Table[0, 1] %= M;
            Table[1, 0] %= M;
            Table[1, 1] %= M;
        }

        public static Matrix Power(Matrix a, long p)
        {
            if (p == 1)
            {
                return a;
            }

            if (p % 2 == 1)
            {
                return new Matrix(Power(a, p - 1), a);
            }

            a = Power(a, p / 2);
            return new Matrix(a, a);
        }

        public static Matrix Single
        {
            get
            {
                return new Matrix(1, 1, 1, 0);
            }
        }
    }
}
