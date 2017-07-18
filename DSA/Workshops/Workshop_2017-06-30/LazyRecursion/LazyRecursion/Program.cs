using LazyTypes;
using System;

namespace LazyRecursion
{
    #region example implementation of Lazy (available in System)
    /*
    public class Lazy<T> where T : struct
    {
        private T? value;
        private Func<T> func;

        public Lazy(Func<T> f)
        {
            value = null;
            func = f;
        }

        public T Value
        {
            get
            {
                if (!value.HasValue)
                {
                    value = func();
                }

                return (T)value;
            }
        }
    }
    */
    #endregion

    class Program
    {
        static Optional<int> Divide(Lazy<int> x, Lazy<int> y)
        {
            if (y.Value == 0)
            {
                return new Optional<int>();
            }
            return new Optional<int>(new Lazy<int>(() => x.Value / y.Value));
        }
        static void Main(string[] args)
        {
            var x = new Lazy<int>(() => int.Parse(Console.ReadLine()));
            var y = new Lazy<int>(() => int.Parse(Console.ReadLine()));
            var z = new Lazy<int>(() => 3);

            var p = Pair.Make(x, y); // var p = new Pair<int, int>(x, y);
            p.WithPair((v1, v2) =>
            {
                Console.WriteLine($"{v1.Value} + {v2.Value} = {v1.Value + v2.Value}");
                return new Lazy<int>(() => 0);
            });


            var a = new Lazy<int>(() => 18);
            var b = new Lazy<int>(() => 2);
            var c = new Lazy<int>(() => 3);

            var result = new Optional<int>(a)
            .Bind(v => Divide(v, b))
            .Bind(v => Divide(v, c))
            .WithOptional(
                new Lazy<int>(() =>
                {
                    Console.WriteLine("Cannot divide by zero!");
                    return 0;
                }),
                (value => new Lazy<int>(() =>
                {
                    Console.WriteLine("Result is " + value.Value);
                    return 0;
                })));

            var ignore = result.Value;
        }
    }
}
