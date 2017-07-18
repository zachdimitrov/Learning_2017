using System;
using System.Collections.Generic;

namespace ConsoleUI
{
    public static class BinarySearch
    {
        public static int BinarySearchBadExample<T>(this T[] array, T value) where T : IComparable
        {
            // return array.BinarySearchBadExample(value, 0, array.Length);
            int left = 0;
            int right = array.Length;

            while (left < right)
            {
                int mid = (left + right) / 2;
                int comp = array[mid].CompareTo(value);
                if (comp < 0)
                {
                    left = mid + 1;
                }
                else if (comp < 0)
                {
                    right = mid;
                }
                else
                {
                    return mid;
                }
            }

            return -1;
        }

        private static int BinarySearchBadExample<T>(this T[] array, T value, int left, int right) where T : IComparable
        {
            if (left >= right)
            {
                return -1;
            }

            int mid = (left + right) / 2;
            int comp = array[mid].CompareTo(value);
            if (comp < 0)
            {
                return array.BinarySearchBadExample(value, mid + 1, right);
            }

            if (comp < 0)
            {
                return array.BinarySearchBadExample(value, left, mid);
            }

            return mid;
        }

        // bound binary search
        public static int LowerBound<T>(this T[] array, T value) where T : IComparable
        {
            return array.Bound(mid => mid.CompareTo(value) < 0);
        }

        public static int UpperBound<T>(this T[] array, T value) where T : IComparable
        {
            return array.Bound(mid => mid.CompareTo(value) <= 0);
        }

        private static int Bound<T>(this T[] array, Func<T, bool> f)
        {
            int left = 0;
            int right = array.Length;

            while (left < right)
            {
                int middle = (left + right) / 2;
                // if(array[middle].CompareTo(value) < 0) // lower bound
                // if(array[middle].CompareTo(value) <= 0) // upper bound
                if (f(array[middle]))
                {
                    left = middle + 1;
                }
                else
                {
                    right = middle;
                }
            }

            return left;
        }

        // sort using bound
        public static void BinarySearchSort<T>(this T[] array) where T : IComparable
        {
            var sorted = new List<T>();

            foreach (var value in array)
            {
                int index = sorted.ToArray().UpperBound(value);
                sorted.Insert(index, value);
            }

            sorted.CopyTo(array);
        }

        // not good for RAINBOW tables
    }
}
