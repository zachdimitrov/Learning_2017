using System;

namespace RabinKarpAlgorithm
{
    public class Program
    {
        public static void Main(string[] args)
        {
            // SimpleSolution();
            // RabinKarp();
            Kmp();
        }

        // simple solution - square complexity
        static void PrintMatch(int index, string pattern)
        {
            for (int i = 0; i < index; i++)
            {
                Console.Write(" ");
            }
            
            Console.ForegroundColor = ConsoleColor.Green;
            System.Console.WriteLine(pattern);
            Console.ForegroundColor = ConsoleColor.Gray;            
        }

        static void SimpleSolution()
        {
            string pattern = "pesho";
            string text = "gosho e po-malak ot pesho,pesho";

            for (int i = 0; i + pattern.Length - 1 < text.Length; i++)
            {
                bool match = true;
                for (int j = 0; j < pattern.Length; j++)
                {
                    if (pattern[j] != text[i + j])
                    {
                        match = false;
                        break;
                    }
                }

                if (match)
                {
                    // Console.WriteLine($"Found at: {i}");
                    Console.WriteLine(text);
                    PrintMatch(i, pattern);
                }
            }
        }

        // Rabin-Karp algorithm
        static void RabinKarp()
        {
            var pattern = "alabala";
            var text = "xalabaalabalaxabalalabala";

            Console.WriteLine(text);
            var patternHash = new Hash(pattern);
            var windowHash = new Hash(text, pattern.Length);

            // Console.WriteLine($"Hash of {pattern}: {patternHash}");
            // Console.WriteLine($"Hash of {text.Substring(0, pattern.Length)}: {windowHash}");

            if (patternHash.Equals(windowHash))
            {
                PrintMatch(0, pattern);
            }

            for (int i = 0; i < text.Length - pattern.Length; i++)
            {
                windowHash.Roll(text[i + pattern.Length], text[i]);

                // Console.WriteLine($"Hash of {text.Substring(i + 1, pattern.Length)}: {windowHash}");

                if (patternHash.Equals(windowHash))
                {
                    PrintMatch(i + 1, pattern);
                }
            }
        }

        // Knuth Morris Pratt
        static void Kmp()
        {
            var pattern = "alabala";
            var text = "xabajslaalabalaskjdlalabalasjdoalabala";
            Console.WriteLine(text);
            var failLink = PreComputeKMP(pattern);

           // Console.WriteLine(" " + string.Join(" ", pattern.ToCharArray()));
           // Console.WriteLine(string.Join(" ", failLink));

            int j = 0;
            for (int i = 0; i < text.Length; i++)
            {
                while (j >=0 && pattern[j] != text[i])
                {
                    j = failLink[j];
                }

                ++j;
                if(j == pattern.Length)
                {
                    Console.WriteLine($"{i} - {j}");
                    PrintMatch(i - j + 1, pattern);
                    j = failLink[j];
                }
            }
        }

        static int[] PreComputeKMP(string str)
        {
            var failLink = new int[str.Length + 1];
            failLink[0] = -1;
            failLink[1] = 0;

            for (int i = 2; i < str.Length; i++)
            {
                int j = failLink[i];
                while (j >= 0 && str[i] != str[j])
                {
                    j = failLink[j];
                }

                failLink[i + 1] = j + 1;
            }

            return failLink;
        }
    }
}

// 2:12:55