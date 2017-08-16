using System;
using System.Collections.Generic;
using System.Text;

namespace Sorting
{
    public class QuickSorter<T> : ISorter<T> where T : IComparable<T>
    {
        public void Sort(IList<T> list)
        {
            QuickSort(list, 0, list.Count);
        }

        private void QuickSort(IList<T> list, int left, int right)
        {
            var utils = new Utils<T>();
            if (right - left < 2)
            {
                return;
            }

            int mid = (left + right) / 2;

            int pivotIndex = 0;

            if (list[left].CompareTo(list[right - 1]) < 0 ^ list[left].CompareTo(list[mid]) < 0)
            {
                pivotIndex = left;
            }
            else if(list[right - 1].CompareTo(list[left]) < 0 ^ list[right - 1].CompareTo(list[mid]) < 0)
            {
                pivotIndex = right - 1;
            }
            else
            {
                pivotIndex = mid;
            }

            if (pivotIndex != left)
            {
                utils.Swap(list, pivotIndex, left);
            }

            var pivot = list[left];

            int leftIndex = left + 1;
            int rightIndex = right - 1;

            while (leftIndex < rightIndex)
            {
                if (list[leftIndex].CompareTo(pivot) < 0)
                {
                    ++leftIndex;
                    continue;
                }

                if (list[rightIndex].CompareTo(pivot) >= 0)
                {
                    --rightIndex;
                    continue;
                }

                utils.Swap(list, leftIndex, rightIndex);
            }

            mid = leftIndex;

            if (list[mid].CompareTo(pivot) >= 0)
            {
                --mid;
            }

            if (mid != left)
            {
                list[left] = list[mid];
                list[mid] = pivot;
            }

            QuickSort(list, left, mid);
            QuickSort(list, mid + 1, right);
        }
    }
}
