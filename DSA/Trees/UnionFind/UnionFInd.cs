using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnionFind
{
    public class UnionFInd
    {
        private int[] array;

        UnionFInd(int n)
        {
            array = new int[n];
            for (int i = 0; i < n; i++)
            {
                array[i] = -1;
            }
        }

        public int FindIterative(int x)
        {
            while (array[x] >= 0)
            {
                x = array[x];
            }

            return x;
        }

        public int FInd(int x)
        {
            if (array[x] < 0)
            {
                return x;
            }

            return FInd(array[x]);
        }

        public bool Union(int x, int y)
        {
            x = FInd(x);
            y = FInd(y);

            if (x == y)
            {
                return false;
            }

            array[x] = y;
            return true;
        }
    }
}
