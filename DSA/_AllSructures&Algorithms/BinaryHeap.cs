
using System;
using System.Collections.Generic;

namespace BinaryHeap
{
    public class BinaryHeap<T>
    //where T : IComparable<T>
    {
        private List<T> heap;
        private Func<T, T, bool> compareFunc;

        public BinaryHeap(Func<T, T, bool> cmpFunc)
        {
            heap = new List<T>();
            heap.Add(default(T));
            compareFunc = cmpFunc;
        }

        public T Top => heap[1];
        public int Count => heap.Count - 1;
        public bool Empty => Count == 0;

        public void Insert(T value)
        {
            int index = heap.Count; // index where inserted
            heap.Add(value);

            while (index > 1 && compareFunc(value, heap[index / 2]))
            {
                heap[index] = heap[index / 2];
                //var temp = heap[index / 2];
                //heap[index / 2] = heap[index];
                //heap[index] = temp;
                index /= 2;
            }

            heap[index] = value;
        }

        public void RemoveTop()
        {
            var value = heap[heap.Count - 1];
            heap.RemoveAt(heap.Count - 1);

            if (!Empty)
            {
                HeapifyDown(1, value);
            }
        }

        private void HeapifyDown(int index, T value)
        {
            while (index * 2 + 1 < heap.Count)
            {
                int smallerKidIndex = compareFunc(heap[index * 2], heap[index * 2 + 1])
                    ? index * 2
                    : index * 2 + 1;
                if (compareFunc(heap[smallerKidIndex], value))
                {
                    heap[index] = heap[smallerKidIndex];
                    index = smallerKidIndex;
                }
                else
                {
                    break;
                }
            }

            if(index * 2 < heap.Count)
            {
                int smallerKidIndex = index * 2;
                if (compareFunc(heap[smallerKidIndex], value))
                {
                    heap[index] = heap[smallerKidIndex];
                    index = smallerKidIndex;
                }
            }

            heap[index] = value;
        }
    }

    public static class BinaryHeapSort
    {
        public static void HeapSort<T>(this T[] array)
            where T: IComparable<T>
        {
            array.HeapSort((x, y) => x.CompareTo(y) > 0);
        }

        public static void HeapSort<T>(this T[] array, Func<T, T, bool> cmpFunc)
        {
            for (int i = array.Length / 2 - 1; i >= 0; --i)
            {
                array.HeapifyDown(cmpFunc, i, array[i], array.Length);
            }

            for (int i = array.Length - 1; i >= 0; --i)
            {
                var value = array[i];
                array[i] = array[0];
                array.HeapifyDown(cmpFunc, 0, value, i);
            }
        }
        private static void HeapifyDown<T>(this T[] heap, Func<T, T, bool> cmpFunc, int index, T value, int length)
        {
            while (index * 2 + 2 < length)
            {
                int smallerKidIndex = cmpFunc(heap[index * 2 + 1], heap[index * 2 + 2])
                    ? index * 2 + 1
                    : index * 2 + 2;
                if (cmpFunc(heap[smallerKidIndex], value))
                {
                    heap[index] = heap[smallerKidIndex];
                    index = smallerKidIndex;
                }
                else
                {
                    break;
                }
            }

            if (index * 2 + 1 < length)
            {
                int smallerKidIndex = index * 2 + 1;
                if (cmpFunc(heap[smallerKidIndex], value))
                {
                    heap[index] = heap[smallerKidIndex];
                    index = smallerKidIndex;
                }
            }

            heap[index] = value;
        }
    }
}
