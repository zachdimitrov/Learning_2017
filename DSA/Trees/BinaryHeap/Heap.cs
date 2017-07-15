using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinaryHeap
{
    public class Heap<T>
    {
        private readonly Func<T, T, bool> compare;
        private List<T> heap;

        public Heap(Func<T, T, bool> compFunc)
        {
            this.compare = compFunc;
            this.heap = new List<T>();
            heap.Add(default(T));
        }

        public T Top => heap[1];
        public int Count => heap.Count - 1;
        public bool Empty => Count == 0;

        public void Insert(T value)
        {
            var index = heap.Count;
            heap.Add(value);

            while (index > 1 && compare(value, heap[index / 2]))
            {
                heap[index] = heap[index / 2];
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

        public void HeapifyDown(int index, T value)
        {
            while (index * 2 + 1 < heap.Count)
            {
                int smallerIndex = compare(heap[index * 2], heap[index * 2 + 1])
                    ? index * 2
                    : index * 2 + 1;
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

            if (index * 2 < heap.Count)
            {
                var smallerIndex = index * 2;

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
