// recursive
class RecursiveFibonacciMemoization {
    static long[] numbers;
    static void Main () {
        Console.Write ("n = ");
        int n = int.Parse (Console.ReadLine ());
        numbers = new long[n + 2];
        numbers[1] = 1;
        numbers[2] = 1;
        long result = Fib (n);
        Console.WriteLine ("fib({0}) = {1}", n, result);
    }

    static long Fib (int n) {
        if (0 == numbers[n]) {
            numbers[n] = Fib (n - 1) + Fib (n - 2);
        }
        return numbers[n];
    }
}

// iterative
class IterativeFibonacci
{
    static void Main ()
    {
        Console.Write ("n = ");
        int n = int.Parse (Console.ReadLine ());
        long result = Fib (n);
        Console.WriteLine ("fib({0}) = {1}", n, result);
    }
	
    static long Fib (int n)
    {
        long fn = 0;
        long fnMinus1 = 1;
        long fnMinus2 = 1;

        for (int i = 2; i < n; i++)
        {
            fn = fnMinus1 + fnMinus2;
            fnMinus2 = fnMinus1;
            fnMinus1 = fn;
        }
        return fn;
    }
}