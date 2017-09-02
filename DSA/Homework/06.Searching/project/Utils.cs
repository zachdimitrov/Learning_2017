using System.Collections.Generic;

namespace SearchingHomework
{
    public class Utils<T>
    {
        public void Swap(IList<T> list, int a, int b)
        {
            T temp = list[a];
            list[a] = list[b];
            list[b] = temp;
        }
    }
}
