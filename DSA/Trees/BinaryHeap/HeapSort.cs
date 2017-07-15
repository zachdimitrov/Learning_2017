using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinaryHeap
{
    static class BinaryHeapSort
    {
        public static void HeapSort<T>(this T[] array, Func<T, T, bool> compFunc)
        {
            for (int i = array.Length / 2 - 1; i >= 0; --i)
            {
                array.HeapifyDown(compFunc, i, array[i], array.Length);
            }

            for (int i = array.Length - 1; i >= 0; --i)
            {
                var value = array[i];
                array[i] = array[0];
                array.HeapifyDown(compFunc, 0, value, i);
            }
        }

        // 2:27:36
        public static void HeapifyDown<T>(this T[] heap, Func<T, T, bool> compare, int index, T value, int length)
        {
            while (index * 2 + 2 < length)
            {
                int smallerIndex = compare(heap[index * 2 + 1], heap[index * 2 + 2])
                    ? index * 2 + 1
                    : index * 2 + 2;
                // Console.WriteLine("DEBUG" + index + " " + smallerIndex + " " + heap[index] + " " + heap[smallerIndex] + " " + value);
                if (compare(heap[smallerIndex], value))
                {
                    heap[index] = heap[smallerIndex];
                    index = smallerIndex;
                }
                else
                {
                    break;
                }
            }

            if (index * 2 + 1 < length)
            {
                var smallerIndex = index * 2 + 1;

                if (compare(heap[smallerIndex], value))
                {
                    heap[index] = heap[smallerIndex];
                    index = smallerIndex;
                }
            }

            heap[index] = value;
        }
    }
}
