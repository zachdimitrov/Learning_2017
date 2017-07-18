using System;
using System.Collections.Generic;

namespace JediMeditation
{
    class Program
    {
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            string[] jedi = Console.ReadLine().Split(' ');

            var masters = new List<string>();
            var knights = new List<string>();
            var paduans = new List<string>();

            for(int i = 0; i < n; ++i)
            {
                if (jedi[i][0] == 'M') 
                {
                    masters.Add(jedi[i]);
                }

                if (jedi[i][0] == 'K')
                {
                    knights.Add(jedi[i]);
                }

                if (jedi[i][0] == 'P')
                {
                    paduans.Add(jedi[i]);
                }
            }

            Console.WriteLine(String.Join(" ", masters.ToArray()) + " " + String.Join(" ", knights.ToArray()) + " " + String.Join(" ", paduans.ToArray()));
        }
    }
}
