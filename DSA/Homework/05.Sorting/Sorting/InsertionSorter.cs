using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sorting
{
    public class InsertionSorter<T> : ISorter<T> where T : IComparable<T>
    {
        public void Sort(IList<T> list)
        {
            for (int i = 1; i < list.Count; i++)
            {
                T inserted = list[i];
                int j = i;
                while (j > 0 && inserted.CompareTo(list[j - 1]) < 0)
                {
                    list[j] = list[j - 1];
                    j--;
                }

                list[j] = inserted;
            }
        }
    }
}
