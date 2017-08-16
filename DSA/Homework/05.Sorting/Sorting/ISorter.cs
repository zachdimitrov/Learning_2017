using System;
using System.Collections.Generic;
using System.Text;

namespace Sorting
{
    public interface ISorter<T> where T : IComparable<T>
        {
            void Sort(IList<T> collection);
        }
}
