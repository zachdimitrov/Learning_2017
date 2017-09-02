using System;
using System.Collections.Generic;

namespace SearchingHomework
{
    public static class BinarySearch
    {
        /// <summary>
        /// Iterative Binary Search
        /// </summary>
        public static int BinarySearchFindWhateverIterative<T>(this IList<T> array, T value)
            where T : IComparable<T>
        {
            int left = 0;
            int right = array.Count;

            while (left < right)
            {
                int middle = (left + right) / 2;
                int cmp = array[middle].CompareTo(value);
                if (cmp < 0)
                {
                    left = middle + 1;
                }
                else if (cmp > 0)
                {
                    right = middle;
                }
                else
                {
                    return middle;
                }
            }

            return -1;
        }

        /// <summary>
        /// Recursive Binary Search
        /// </summary>
        public static int BinarySearchFindWhatever<T>(this IList<T> array, T value)
            where T: IComparable<T>
        {
            return array.BinarySearchFindWhatever(value, 0, array.Count);
        }

        private static int BinarySearchFindWhatever<T>(this IList<T> array, T value, int left, int right)
            where T : IComparable<T>
        {
            int middle = (left + right) / 2;
            int cmp = array[middle].CompareTo(value);
            if (cmp < 0)
            {
                return array.BinarySearchFindWhatever(value, middle + 1, right);
            }

            if (cmp > 0)
            {
                return array.BinarySearchFindWhatever(value, left, middle);
            }

            return middle;
        }

        /// <summary>
        /// Finds first value in collection
        /// </summary>
        public static int LowerBound<T>(this IList<T> array, T value)
                where T : IComparable<T>
        {
            return array.Bound(mid => mid.CompareTo(value) < 0);
        }

        /// <summary>
        /// Finds last value in collection
        /// </summary>
        public static int UpperBound<T>(this IList<T> array, T value)
                where T : IComparable<T>
        {
            return array.Bound(mid => mid.CompareTo(value) <= 0);
        }


        /// <summary>
        /// find bound based on compare function
        /// </summary>
        public static int Bound<T>(this IList<T> array, Func<T, bool> f)
                where T : IComparable<T>
        {
            int left = 0;
            int right = array.Count;

            while (left < right)
            {
                int middle = (left + right) / 2;
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

        /// <summary>
        /// Binary Search Sort
        /// </summary>
        public static void BinarySearchSort<T>(this IList<T> array, T value)
                where T : IComparable<T>
        {
            var sorted = new List<T>();

            foreach (var x in array)
            {
                int index = sorted.ToArray().LowerBound(value);
                sorted.Insert(index, value);
            }

            for (int i = 0; i < array.Count; i++)
            {
                array[i] = sorted[i];
            }
        }
    }
}
