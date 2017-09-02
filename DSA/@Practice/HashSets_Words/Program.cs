using System;
using System.Collections.Generic;
using System.Text;

namespace HashSets_Words
{
    class Program
    {
        static Dictionary<char, HashSet<string>> words = new Dictionary<char, HashSet<string>>();

        static void InitDict()
        {
            for (int a = 'a'; a <= 'z'; a++)
            {
                words[(char)a] = new HashSet<string>();
            }
        }

        static void AddWord(string word)
        {
            for (int i = 0; i < word.Length; i++)
            {
                words[word[i]].Add(word);
            }
        }

        static void ReadWords()
        {
            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                StringBuilder word = new StringBuilder();
                string line = Console.ReadLine().ToLower();

                for (int j = 0; j < line.Length; j++)
                {
                    if (line[j] >= 'a' && line[j] <= 'z')
                    {
                        word.Append(line[j]);
                    }
                    else if (word.Length > 0)
                    {
                        AddWord(word.ToString());
                        word.Clear();
                    }
                }

                if (word.Length > 0)
                {
                    AddWord(word.ToString());
                }
            }
        }

        static void ProcessWords()
        {
            int m = int.Parse(Console.ReadLine());
            for (int i = 0; i < m; i++)
            {
                string word = Console.ReadLine();
                string lowered = word.ToLower();

                HashSet<string> current = new HashSet<string>(words[lowered[0]]);

                for (int j = 1; j < lowered.Length; j++)
                {
                    current.IntersectWith(words[lowered[j]]);
                }

                Console.WriteLine(word + " -> " + current.Count);
            }
        }

        static void Main()
        {
            InitDict();
            ReadWords();
            ProcessWords();
        }
    }
}
