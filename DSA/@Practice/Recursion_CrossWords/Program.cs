
using System;
using System.Collections.Generic;
using System.Text;

namespace Recursion_CrossWords
{
    class Program
    {
        static HashSet<string> allWords = new HashSet<string>();
        static string[] words;
        static string[] crossword;

        static bool CheckVerticals()
        {
            StringBuilder current = new StringBuilder();

            for (int i = 0; i < crossword.Length; i++)
            {
                current.Clear();

                for (int j = 0; j < crossword.Length; j++)
                {
                    current.Append(crossword[j][i]);
                }

                if (!allWords.Contains(current.ToString()))
                {
                    return false;
                }
            }

            return true;
        }

        static void Solve(int index)
        {
            if (index >= crossword.Length)
            {
                if (CheckVerticals())
                {
                    Printer();
                    Environment.Exit(0);
                }

                return;
            }

            for (int i = 0; i < words.Length; i++)
            {
                crossword[index] = words[i];
                Solve(index + 1);
                crossword[index] = null;
            }
        }

        static void Printer()
        {
            for (int i = 0; i < crossword.Length; i++)
            {
                Console.WriteLine(crossword[i]);
            }
        }

        static void Main(string[] args)
        {
            int N = int.Parse(Console.ReadLine());

            words = new string[2 * N];
            crossword = new string[N];

            for (int i = 0; i < 2 * N; i++)
            {
                words[i] = Console.ReadLine();
                allWords.Add(words[i]);
            }

            Array.Sort(words);

            Solve(0);

            Console.WriteLine("NO SOLUTION!");
        }
    }
}
