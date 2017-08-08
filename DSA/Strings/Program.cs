using System;
using System.Collections.Generic;

namespace RabinKarpAlgorithm
{
    public class Program
    {
        public static void Main(string[] args)
        {
            // SimpleSolution();
            // RabinKarp();
            // Kmp();
            AhoCorasickTest();
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
                while (j >= 0 && pattern[j] != text[i])
                {
                    j = failLink[j];
                }

                ++j;
                if (j == pattern.Length)
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

        // Aho - Corasick
        static void AhoCorasickTest()
        {
            var trie = new Trie();
            var strings = new string[]
            {
                "Cuki",
                "Doncho",
                "Cala",
                "Xala",
                "bala"
            };

            for (int i = 0; i < strings.Length; i++)
            {
                trie.AddString(strings[i]);
            }

            var text = "odhdkawkdasoskdaosdopaosdjjjdooddonchosmnsdbalasidspodCukisiajdo";
            trie.Precompute();
            trie.Dfs();

            Console.WriteLine(text);
            trie.AhoCorasick(text);
        }
    }

    class Trie
    {
        private Dictionary<char, Trie> children;
        private string pattern;
        private Trie failLink;
        private Trie succesLink;

        public Trie()
        {
            this.children = new Dictionary<char, Trie>();
            this.pattern = null;
            this.failLink = null;
            this.succesLink = null;
        }

        public void AddString(string str)
        {
            var currentNode = this;
            foreach (var c in str)
            {
                if (!currentNode.children.ContainsKey(c))
                {
                    currentNode.children[c] = new Trie();
                }

                currentNode = currentNode.children[c];
            }

            currentNode.pattern = str;
        }

        public void Dfs()
        {
            this.Dfs("");
        }

        private void Dfs(string str)
        {
            if (this.failLink == null)
            {
                Console.WriteLine("root -> null");
            }
            else
            {
                Console.WriteLine($"{str} -> {this.failLink.PrintMe()}");
            }
            foreach (var child in children)
            {
                child.Value.Dfs(str + child.Key);
            }
        }

        private string PrintMe(int count = 0)
        {
            if (this.pattern != null)
            {
                return this.pattern.Substring(0, this.pattern.Length - count);
            }

            var enumerator = this.children.GetEnumerator();
            enumerator.MoveNext();
            return enumerator.Current.Value.PrintMe(count + 1);
        }

        public void Precompute()
        {
            var q = new Queue<Trie>();
            q.Enqueue(this);

            while (q.Count > 0)
            {
                var node = q.Dequeue();

                var successNode = node.failLink;
                while (successNode != null && successNode.pattern == null)
                {
                    successNode = successNode.failLink;
                }
                node.succesLink = successNode;

                foreach (var child in node.children)
                {
                    var failNode = node.failLink;
                    while (failNode != null && !failNode.children.ContainsKey(child.Key))
                    {
                        failNode = failNode.failLink;
                    }

                    child.Value.failLink = failNode == null
                        ? this
                        : failNode.children[child.Key];

                    q.Enqueue(child.Value);
                }
            }
        }

        public void AhoCorasick(string text)
        {
            var currentNode = this;
            for (int i = 0; i < text.Length; i++)
            {
                while (currentNode != null && !currentNode.children.ContainsKey(text[i]))
                {
                    currentNode = currentNode.failLink;
                }

                currentNode = currentNode == null
                    ? this
                    : currentNode.children[text[i]];

                if (currentNode.pattern != null)
                {
                    PrintMatch(i + 1 - currentNode.pattern.Length, currentNode.pattern);
                }
                var successNode = currentNode.succesLink;
                while (successNode != null)
                {
                    PrintMatch(i + 1 - successNode.pattern.Length, successNode.pattern);
                    successNode = successNode.succesLink;
                }
            }
        }

        private static void PrintMatch(int index, string pattern)
        {
            for (int i = 0; i < index; ++i)
            {
                Console.Write(" ");
            }

            Console.ForegroundColor = ConsoleColor.Green;
            System.Console.WriteLine(pattern);
            Console.ForegroundColor = ConsoleColor.Gray;
        }
    }
}