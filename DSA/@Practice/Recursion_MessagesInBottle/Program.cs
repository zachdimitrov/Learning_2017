using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recursion_MessagesInBottle
{
    class Program
    {
        static List<KeyValuePair<char, string>> chiphers = new List<KeyValuePair<char, string>>();
        static string message;
        static List<string> solutions = new List<string>();

        static void Main(string[] args)
        {
            message = Console.ReadLine();
            var chipher = Console.ReadLine();

            char key = char.MinValue;
            var value = new StringBuilder();

            for (int i = 0; i < chipher.Length; i++)
            {
                if (chipher[i] >= 'A' && chipher[i] <= 'Z') // (char.IsLetter(chipher[i]))
                {
                    if (key != char.MinValue)
                    {
                        chiphers.Add(new KeyValuePair<char, string>(key, value.ToString()));
                        value.Clear();
                    }

                    key = chipher[i];
                }
                else
                {
                    value.Append(chipher[i]);
                }
            }

            if (key != char.MinValue)
            {
                chiphers.Add(new KeyValuePair<char, string>(key, value.ToString()));
                value.Clear();
            }

            Solve(0, new StringBuilder());

            Console.WriteLine(solutions.Count);
            solutions.Sort();
            Console.WriteLine(string.Join(Environment.NewLine, solutions));
        }

        static void Solve(int index, StringBuilder sb)
        {
            if (index == message.Length)
            {
                solutions.Add(sb.ToString());
                return;
            }

            foreach (var chip in chiphers)
            {
                if (message.Substring(index).StartsWith(chip.Value))
                {
                    sb.Append(chip.Key);
                    Solve(index + chip.Value.Length, sb);
                    sb.Length--;
                }
            }
        }
    }
}
