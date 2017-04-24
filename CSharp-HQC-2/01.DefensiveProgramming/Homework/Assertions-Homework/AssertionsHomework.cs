using System;
using System.Linq;
using System.Diagnostics;

class AssertionsHomework
{
    public static void SelectionSort<T>(T[] arr) where T : IComparable<T>
    {
        // assert that provided array is valid with valid elements
        Debug.Assert(arr.Length != 0, "Provided array must not be empty!");
        Debug.Assert(arr != null, "Provided array must exist!");
        Debug.Assert(arr.All(x => x != null), "Elements in the array cannot be null!");

        for (int index = 0; index < arr.Length-1; index++)
        {
            int minElementIndex = FindMinElementIndex(arr, index, arr.Length - 1);
            Swap(ref arr[index], ref arr[minElementIndex]);
        }

        // assert that array is not sorted already
        Debug.Assert(!IsArraySorted(arr), "Array is already sorted!");
    }

    /// <summary>
    /// Helper method for testing if array is not already sorted
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="arr"></param>
    /// <returns>bool</returns>
    private static bool IsArraySorted<T>(T[] arr) where T : IComparable<T>
    {
        for (int i = 0; i < arr.Length - 1; i++)
        {
            if (arr[i].CompareTo(arr[i + 1]) > 0)
            {
                return false; // array is not sorted!
            }
        }
        return true; // array is sorted!
    }

    private static int FindMinElementIndex<T>(T[] arr, int startIndex, int endIndex) 
        where T : IComparable<T>
    {
        // assert that provided array is valid
        Debug.Assert(arr != null, "Provided array must exist!");
        // assert that startIndex and endIndex are valid
        Debug.Assert(startIndex >= 0, "Start index should be positive!");
        Debug.Assert(endIndex >= 0, "End index should be positive!");
        Debug.Assert(endIndex <= arr.Length - 1, "End index should be smaller than the length of the array!");
        Debug.Assert(startIndex <= endIndex, "Start index should be smaller than or equal to end index!");

        int minElementIndex = startIndex;
        for (int i = startIndex + 1; i <= endIndex; i++)
        {
            if (arr[i].CompareTo(arr[minElementIndex]) < 0)
            {
                minElementIndex = i;
            }
        }

        // assert that result is correct
        for (int i = startIndex + 1; i < endIndex; i++)
        {
            Debug.Assert(arr[minElementIndex].CompareTo(arr[i]) <= 0, "The method did not return the smallest element!");
        }

        return minElementIndex;
    }

    private static void Swap<T>(ref T x, ref T y)
    {
        T oldX = x;
        x = y;
        y = oldX;
    }

    public static int BinarySearch<T>(T[] arr, T value) where T : IComparable<T>
    {
        // assert that provided array is valid
        Debug.Assert(arr != null, "Provided array must exist!");
        // assert that array is sorted so Binary Search is usable
        Debug.Assert(IsArraySorted(arr), "The array must be sorted for Binary Search!");

        return BinarySearch(arr, value, 0, arr.Length - 1);
    }

    private static int BinarySearch<T>(T[] arr, T value, int startIndex, int endIndex) 
        where T : IComparable<T>
    {
        // assert that provided array is valid
        Debug.Assert(arr != null, "Provided array must exist!");
        // assert that startIndex and endIndex are valid
        Debug.Assert(startIndex >= 0, "Start index should be positive!");
        Debug.Assert(endIndex >= 0, "End index should be positive!");
        Debug.Assert(endIndex <= arr.Length - 1, "End index should be smaller than the length of the array!");
        Debug.Assert(startIndex <= endIndex, "Start index should be smaller than or equal to end index!");

        while (startIndex <= endIndex)
        {
            int midIndex = (startIndex + endIndex) / 2;
            if (arr[midIndex].Equals(value))
            {
                return midIndex;
            }
            if (arr[midIndex].CompareTo(value) < 0)
            {
                // Search on the right half
                startIndex = midIndex + 1;
            }
            else 
            {
                // Search on the right half
                endIndex = midIndex - 1;
            }
        }

        // Searched value not found
        return -1;
    }

    static void Main()
    {
        int[] arr = new int[] { 3, -1, 15, 4, 17, 2, 33, 0 };
        Console.WriteLine("arr = [{0}]", string.Join(", ", arr));
        SelectionSort(arr);
        Console.WriteLine("sorted = [{0}]", string.Join(", ", arr));

        SelectionSort(new int[0]); // Test sorting empty array
        SelectionSort(new int[1]); // Test sorting single element array

        Console.WriteLine(BinarySearch(arr, -1000));
        Console.WriteLine(BinarySearch(arr, 0));
        Console.WriteLine(BinarySearch(arr, 17));
        Console.WriteLine(BinarySearch(arr, 10));
        Console.WriteLine(BinarySearch(arr, 1000));
    }
}
