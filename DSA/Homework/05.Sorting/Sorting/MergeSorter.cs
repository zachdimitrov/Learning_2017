using System;
using System.Collections.Generic;
using System.Text;

namespace Sorting
{
    public class MergeSorter<T> : ISorter<T> where T : IComparable<T>
    {
        public void Sort(IList<T> list)
        {
            MergeSort(list, 0, list.Count);
        }

        private void MergeSort(IList<T> list, int left, int right)
        {
            if (right - left < 2)
            {
                return;
            }

            int mid = (left + right) / 2;

            MergeSort(list, left, mid);
            MergeSort(list, mid, right);

            MergeSort(list, left, mid, right);
        }

        private void MergeSort(IList<T> list, int left, int mid, int right)
        {
            var aux = new T[right - left];
            int i = left;
            int j = mid;
                    
            for (int k = 0; k < aux.Length; k++)
            {
                if (i < mid && j < right)
                {
                    if (list[i].CompareTo(list[j]) <= 0)
                    {
                        aux[k] = list[i];
                        i++;
                    }
                    else
                    {
                        aux[k] = list[j];
                        j++;
                    }
                }
                else if(i < mid)
                {
                    aux[k] = list[i];
                    i++;
                }
                else if(j < right)
                {
                    aux[k] = list[j];
                    j++;
                }
                else
                {
                    break;
                }
            }

            for (int p = 0; p < aux.Length; p++)
            {
                list[left + p] = aux[p];
            }
        }
    }
}
