using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sorting
{
    public class BubleSorter<T> : ISorter<T> where T : IComparable<T>
    {
        public void Sort(IList<T> collection)
        {
            bool swapped = true;

            while (swapped)
            {
                swapped = false;
                for (int i = 1; i < collection.Count; i++)
                {
                    if (collection[i - 1].CompareTo(collection[i]) > 0)
                    {
                        var utils = new Utils<T>();
                        utils.Swap(collection, i - 1, i);
                        swapped = true;
                    }
                }
            }
        }
    }
}
