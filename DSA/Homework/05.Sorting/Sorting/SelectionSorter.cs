using System;
using System.Collections.Generic;
using System.Text;

namespace Sorting
{
    public class SelectionSorter<T> : ISorter<T> where T : IComparable<T>
    {
        public void Sort(IList<T> collection)
        {
            for (int i = 0; i < collection.Count - 1; i++)
            {
                var min = i;

                for (int j = i + 1; j < collection.Count; j++)
                {
                    if (collection[j].CompareTo(collection[min]) < 0)
                    {
                        min = j;
                    }
                }

                if (min != i)
                {
                    new Utils<T>().Swap(collection, min, i);
                }
            }
        }
    }
}
