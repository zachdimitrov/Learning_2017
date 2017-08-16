using System;
using System.Collections.Generic;

namespace ColorRabbits
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            var ans = new Dictionary<int, int>();
            int result = 0;

            for (int i = 0; i < n; i++)
            {
                int a = int.Parse(Console.ReadLine());
                if (ans.ContainsKey(a + 1))
                {
                    ans[a + 1]++;
                }
                else
                {
                    ans[a + 1] = 1;
                }
            }

            foreach(var elm in ans)
            {
                if (elm.Value <= elm.Key)
                {
                    result += elm.Key;
                }
                else
                {
                    result += (int)Math.Ceiling((double)elm.Value / elm.Key) * elm.Key;
                }
            }

            Console.WriteLine(result);
        }
    }
}
