using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GreyCodes
{
    class Program
    {
        static void Main()
        {
            int n = 3;
            var codes = GrayCodes(10);
            foreach (var code in codes)
            {
                Console.WriteLine(code);
            }
        }

        static List<string> GrayCodes(int n)
        {
            if (n == 0)
            {
                return new List<string>();
            }

            if (n == 1)
            {
                    return new List<string>() { "0", "1" };
            }

            var firstHalf = GrayCodes(n - 1);
            var secondHalf = firstHalf.ToList(); // makes copy
            secondHalf.Reverse();

            firstHalf = firstHalf
                .Select(code => "0" + code)
                .ToList();

            secondHalf = secondHalf
                .Select(code => "1" + code)
                .ToList();

            firstHalf.AddRange(secondHalf);

            return firstHalf;
        }
    }
}
