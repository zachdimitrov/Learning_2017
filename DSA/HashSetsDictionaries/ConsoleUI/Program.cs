using HashSetDemo;
using System;
//using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            var set = new HashSet<int>();
            Console.WriteLine(set.Add(5));
            Console.WriteLine(set.Add(5));
            Console.WriteLine(set.Add(5));
            Console.WriteLine(set.Add(8));
            Console.WriteLine(set.Add(6));
            Console.WriteLine(set.Count);
            Console.WriteLine(set.Contains(5));
            Console.WriteLine(set.Contains(3));

            var set2 = new HashSet<int>();
            var rnd = new Random();
            var sw = new Stopwatch();
            sw.Start();
            for (int i = 0; i < 100000; i++)
            {
                set2.Add(rnd.Next() % 100000);
            }

            sw.Stop();
            Console.WriteLine(sw.Elapsed);
            Console.WriteLine(set2.Count);
            Console.WriteLine("===");
            // Console.WriteLine(string.Join(" ", set2));
            Console.WriteLine("===");

            Console.WriteLine("---- HashCode demo ----");
            Console.WriteLine(12.GetHashCode());
            Console.WriteLine('b'.GetHashCode());
            Console.WriteLine("Pesho e Gosho".GetHashCode());
            Console.WriteLine(new Chushka("blue", 5).GetHashCode());
            Console.WriteLine(new Chushka("blue", 5).GetHashCode());
        }
    }

    class Chushka
    {
        public Chushka(string color, int seeds)
        {
            this.Color = color;
            this.Seeds = seeds;
        }

        public string Color { get; set; }

        public int Seeds { get; set; }

        public override bool Equals(object obj)
        {
            var other = obj as Chushka;
            return this.Color == other.Color && this.Seeds == other.Seeds;
        }

        public override int GetHashCode()
        {
            return this.Color.GetHashCode() ^ this.Seeds.GetHashCode();
        }
    }
}
