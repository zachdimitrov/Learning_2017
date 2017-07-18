using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;

namespace SortAlgorithms
{
    static class Startup
    {
        static void Main()
        {
            const int n = 30;
            int[] set = new int[n] { 23, 56, 74, 23, 59, 45, 26, 5, 3, 4, 2, 1, 8, 11, 55, 33, 87, 99, 21, 37, 6, 7, 9, 83, 71, 19, 98, 17, 16, 14 };
            Console.WriteLine("Unsorted: " + string.Join(", ", set));
            Console.WriteLine("-------------------------------------");

            // search for smallest and move it to first position (or largest to last)
            var watch1 = new Stopwatch();
            int[] selectionSet = new int[n];
            Array.Copy(set, selectionSet, n);
            watch1.Start();
            SelectionSort(selectionSet);
            watch1.Stop();
            Console.WriteLine("Selection sort: " + string.Join(", ", selectionSet) + " for " + watch1.Elapsed);

            // buble sort
            var watch2 = new Stopwatch();
            int[] bubleSet = new int[n];
            Array.Copy(set, bubleSet, n);
            watch2.Start();
            BubleSort(bubleSet);
            watch2.Stop();
            Console.WriteLine("Buble sort:     " + string.Join(", ", bubleSet) + " for " + watch2.Elapsed);

            // insertion sort
            var watch3 = new Stopwatch();
            int[] insertSet = new int[n];
            Array.Copy(set, insertSet, n);
            watch3.Start();
            InsertionSort(insertSet);
            watch3.Stop();
            Console.WriteLine("Insertion sort: " + string.Join(", ", insertSet) + " for " + watch3.Elapsed);

            // quick sort
            var watch4 = new Stopwatch();
            int[] quickSet = new int[n];
            Array.Copy(set, quickSet, n);
            watch4.Start();
            var newQuickSet = QuickSort(quickSet);
            watch4.Stop();
            Console.WriteLine("Quick sort:     " + string.Join(", ", newQuickSet) + " for " + watch4.Elapsed);

            // quick sort in place
            var watch5 = new Stopwatch();
            int[] quickInPlaceSet = new int[n];
            Array.Copy(set, quickInPlaceSet, n);
            watch5.Start();
            quickInPlaceSet.QuickInPlace();
            watch5.Stop();
            Console.WriteLine("Quick sort in place:     " + string.Join(", ", quickInPlaceSet) + " for " + watch5.Elapsed);

            // merge sort
            var watch6 = new Stopwatch();
            int[] mergeSet = new int[n];
            Array.Copy(set, mergeSet, n);
            watch6.Start();
            mergeSet.MergeSort();
            watch6.Stop();
            Console.WriteLine("Merge sort:     " + string.Join(", ", mergeSet) + " for " + watch6.Elapsed);

            // merge sort iterative
            var watch7 = new Stopwatch();
            int[] mergeSetIt = new int[n];
            Array.Copy(set, mergeSetIt, n);
            watch7.Start();
            mergeSetIt.MergeSort();
            watch7.Stop();
            Console.WriteLine("Merge sort iterative:     " + string.Join(", ", mergeSetIt) + " for " + watch7.Elapsed);

            // merge sort multi threaded
            var watch8 = new Stopwatch();
            int[] mergeSetMT = new int[n];
            Array.Copy(set, mergeSetMT, n);
            watch8.Start();
            mergeSetMT.MergeSortMuliThreaded();
            watch8.Stop();
            Console.WriteLine("Merge sort multi threaded:     " + string.Join(", ", mergeSetMT) + " for " + watch8.Elapsed);

            // merge sort multi threaded
            var watch9 = new Stopwatch();
            int[] countSorded = new int[n];
            Array.Copy(set, countSorded, n);
            watch9.Start();
            countSorded.CountingSort(0, 100);
            watch9.Stop();
            Console.WriteLine("Counting sort:     " + string.Join(", ", countSorded) + " for " + watch9.Elapsed);

            // radix left to right
            var watch10 = new Stopwatch();
            int[] radixSorded = new int[8] { 15, 302, 104, 452, 192, 983, 704, 367 };
            watch10.Start();
            radixSorded.RadixLeftToRight(3, 10);
            watch10.Stop();
            Console.WriteLine("Radix LR sort:     " + string.Join(", ", radixSorded) + " for " + watch10.Elapsed);

            // radix rught to left
            var watch11 = new Stopwatch();
            int[] radixRLSorded = new int[8] { 18, 608, 404, 232, 162, 993, 504, 163 };
            watch11.Start();
            radixRLSorded.RadixRightToLeft(3, 10);
            watch11.Stop();
            Console.WriteLine("Radix RL sort:     " + string.Join(", ", radixRLSorded) + " for " + watch11.Elapsed);

        }

        private static T[] QuickSort<T>(this T[] array) where T : IComparable<T>
        {
            // x < y -> x.CompareTo(y) < 0
            // x >= y -> x.CompareTo(y) >= 0;

            if (array.Length < 2)
            {
                var sortedArray = new T[array.Length];
                Array.Copy(array, sortedArray, array.Length);
                return sortedArray;
            }

            T pivot = array[0];
            var left = new List<T>();
            var right = new List<T>();
            for (int i = 1; i < array.Length; i++)
            {
                if (array[i].CompareTo(pivot) < 0)
                {
                    left.Add(array[i]);
                }
                else
                {
                    right.Add(array[i]);
                }
            }

            var leftSorted = left.ToArray().QuickSort();
            var rightSorted = right.ToArray().QuickSort();

            var sortedArr = new T[array.Length];

            for (int j = 0; j < leftSorted.Length; j++)
            {
                sortedArr[j] = leftSorted[j];
            }

            sortedArr[leftSorted.Length] = pivot;

            for (int k = 0; k < rightSorted.Length; k++)
            {
                sortedArr[leftSorted.Length + 1 + k] = rightSorted[k];
            }

            //Console.WriteLine(string.Join("-", sortedArr));
            return sortedArr;
        }

        private static void QuickInPlace<T>(this T[] array) where T : IComparable<T>
        {
            array.QuickInPlace(0, array.Length);
        }

        private static void QuickInPlace<T>(this T[] array, int left, int right) where T : IComparable<T>
        {
            if (right - left < 2)
            {
                return;
            }

            var pivot = array[left];

            int leftIndex = left + 1;
            int rightIndex = right - 1;

            --rightIndex;

            while (leftIndex < rightIndex)
            {
                if (array[leftIndex].CompareTo(pivot) < 0)
                {
                    ++leftIndex;
                    continue;
                }

                if (array[rightIndex].CompareTo(pivot) >= 0)
                {
                    --rightIndex;
                    continue;
                }

                var tmp = array[leftIndex];
                array[leftIndex] = array[rightIndex];
                array[rightIndex] = tmp;
            }

            int middle = leftIndex;
            if (array[middle].CompareTo(pivot) >= 0)
            {
                --middle;
            }

            if (middle != left)
            {
                array[left] = array[middle];
                array[middle] = pivot;
            }

            array.QuickInPlace(left, middle);
            array.QuickInPlace(middle + 1, right);
        }

        private static void InsertionSort(int[] set)
        {
            var sortedArr = new int[set.Length];

            for (int i = 0; i < set.Length; i++)
            {
                int j;
                for (j = 0; j < i; j++)
                {
                    if (sortedArr[j] > set[i])
                    {
                        break;
                    }
                }

                for (int k = i; k > j; k--)
                {
                    sortedArr[k] = sortedArr[k - 1];
                }

                sortedArr[j] = set[i];
                //Console.WriteLine($"Sort step {i}: " + string.Join(", ", sortedArr));
            }

            // just recreate the array
            for (int i = 0; i < set.Length; i++)
            {
                set[i] = sortedArr[i];
            }
        }

        private static void BubleSort(int[] set)
        {
            for (int i = 0; i < set.Length; i++)
            {
                for (int j = 0; j < set.Length - 1; j++)
                {
                    if (set[j] > set[j + 1])
                    {
                        int temp = set[j + 1];
                        set[j + 1] = set[j];
                        set[j] = temp;
                    }
                }
            }
        }

        private static void SelectionSort(int[] set)
        {
            for (int i = 0; i < set.Length; i++)
            {
                for (int j = 0; j < set.Length; j++)
                {
                    if (set[j] > set[i])
                    {
                        int temp = set[i];
                        set[i] = set[j];
                        set[j] = temp;
                    }
                }
            }
        }

        private static void MergeSort<T>(this T[] array) where T : IComparable<T>
        {
            array.MergeSort(0, array.Length);
        }

        private static void Merge<T>(this T[] array, int left, int middle, int right) where T : IComparable<T>
        {
            int i = left;
            int j = middle;
            int k = 0;
            T[] mergeArray = new T[right - left];

            while (true)
            {
                if (i < middle && j < right)
                {
                    if (array[i].CompareTo(array[j]) <= 0)
                    {
                        mergeArray[k] = array[i];
                        ++i;
                    }
                    else
                    {
                        mergeArray[k] = array[j];
                        ++j;
                    }
                }
                else if (i < middle)
                {
                    mergeArray[k] = array[i];
                    ++i;
                }
                else if (j < right)
                {
                    mergeArray[k] = array[j];
                    ++j;
                }
                else
                {
                    break;
                }

                ++k;
            }

            for (int t = 0; t < mergeArray.Length; ++t)
            {
                array[left + t] = mergeArray[t];
            }
        }

        private static void MergeSort<T>(this T[] array, int left, int right) where T : IComparable<T>
        {
            if (right - left < 2)
            {
                return;
            }

            int middle = (left + right) / 2;

            array.MergeSort(left, middle);
            array.MergeSort(middle, right);
            array.Merge(left, middle, right);
        }

        public static void MergeSortIterative<T>(this T[] array) where T : IComparable<T>
        {
            for (int half = 1; half <= array.Length; half *= 2)
            {
                for (int left = 0; left < array.Length; left += half * 2)
                {
                    int middle = left + half;
                    if (middle >= array.Length)
                    {
                        break;
                    }

                    int right = left + half * 2;

                    if (right > array.Length)
                    {
                        right = array.Length;
                    }

                    array.Merge(left, middle, right);
                }
            }
        }

        private static void MergeSortMuliThreaded<T>(this T[] array) where T : IComparable<T>
        {
            array.MergeSortMuliThreaded(0, array.Length);
        }

        private static void MergeSortMuliThreaded<T>(this T[] array, int left, int right) where T : IComparable<T>
        {
            if (right - left < 2)
            {
                return;
            }

            int middle = (left + right) / 2;

            ThreadStart leftSortTask = () => array.MergeSortMuliThreaded(left, middle);
            var leftSortThread = new Thread(leftSortTask);
            leftSortThread.Start();

            ThreadStart rightSortTask = () => array.MergeSortMuliThreaded(middle, right);
            var rightSortThread = new Thread(rightSortTask);
            rightSortThread.Start();

            leftSortThread.Join();
            rightSortThread.Join();

            //array.MergeSort(left, middle);
            //array.MergeSort(middle, right);
            array.Merge(left, middle, right);
        }

        public static void CountingSort(this int[] array, int minNumber, int maxNumber)
        {
            var counts = new int[maxNumber + 1 - minNumber];
            foreach (int x in array)
            {
                ++counts[x - minNumber];
            }

            int index = 0;

            for (int n = 0; n < counts.Length; ++n)
            {
                for (int i = 0; i < counts[n]; ++i)
                {
                    array[index] = n + minNumber;
                    ++index;
                }
            }
        }

        public static void RadixLeftToRight(this int[] array, int digits, int baza)
        {
            int basePower = 1;
            for (int i = 1; i < digits; i++)
            {
                basePower *= baza;
            }

            var buckets = new List<int>[baza];
            for (int b = 0; b < buckets.Length; b++)
            {
                buckets[b] = new List<int>();
            }

            //var bckets = Enumerable.Range(0, baza)
            //    .Select(x => new List<int>())
            //    .ToArray();

            for (int d = digits - 1; d >= 0; --d)
            {
                for (int j = 0; j < array.Length; j++)
                {
                    int digit = array[j] / basePower % baza;
                    buckets[digit].Add(array[j]);
                }

                foreach (var bucket in buckets)
                {
                    bucket.Sort();
                }

                buckets.Aggregate((x, y) =>
                    {
                        x.AddRange(y);
                        return x;
                    })
                    .CopyTo(array);

                break;

                basePower /= baza;
            }
        }

        public static void RadixRightToLeft(this int[] array, int digits, int baza)
        {
            int basePower = 1;
            var buckets = new List<int>[baza];
            for (int b = 0; b < buckets.Length; b++)
            {
                buckets[b] = new List<int>();
            }

            for (int digit = 0; digit < digits; digit++)
            {
                foreach(var j in array)
                {
                    int currentDigit = (j / basePower) % baza;
                    buckets[currentDigit].Add(j);
                }

                int index = 0;
                foreach (var bucket in buckets)
                {
                    foreach (var x in bucket)
                    {
                        array[index] = x;
                        ++index;
                    }
                    bucket.Clear();
                }

                basePower *= baza;
            }
        }
    }
}
