using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleUI
{
    public static class Shuffle
    {
        public static int[] GenShuffled(int n)
        {
            var array = new int[n];
            for (int i = 0; i < n; i++)
            {
                array[i] = i;
            }

            var rnd = new Random();
            int indexLimit = n;

            for (int i = n - 1; i > 0; --i)
            {
                var j = rnd.Next() % (i + 1);
                if (j != i)
                {
                    var k = array[j];
                    array[j] = array[i];
                    array[i] = k;
                }
            }

            return array;
        }
    }
}
