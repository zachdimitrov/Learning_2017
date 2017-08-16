using System;

namespace BinaryPasswords
{
    class Program
    {
        static void Main(string[] args)
        {
            string pattern = Console.ReadLine();
            long n = 1;
            for (int i = 0; i < pattern.Length; i++)
            {
                if (pattern[i] == '*')
                {
                    n *= 2;
                }
            }

            Console.WriteLine(n);
        }
    }
}
