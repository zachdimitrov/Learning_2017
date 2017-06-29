using System;

namespace CyclicQueue
{
    public class CyclicQueue<T>
    {
        private const int InitialLength = 8;
        private T[] queue;
        private int head;
        private int tail;
        private int count;

        public CyclicQueue()
        {
            this.queue = new T[InitialLength];
            this.head = 0;
            this.tail = 0;
            this.count = 0;
        }

        public int Count
        {
            get
            {
                return this.count;
            }

            private set
            {
                this.count = value;
            }
        }

        public void Enqueue(T value)
        {
            this.queue[this.tail] = value;
            this.Count++;
            this.tail++;
            if (this.tail >= this.queue.Length && this.head > 0)
            {
                this.tail = 0;
            }

            if (this.tail == this.head )
            {
                this.IncreaseCapacity();
            }
        }

        private void IncreaseCapacity()
        {
            throw new NotImplementedException();
        }

        public T Dequeue()
        {
            var result = this.queue[this.head];
            this.count--;
            this.head++;

            if (this.head >= this.queue.Length)
            {
                this.head = 0;
            }

            if (this.Count == 0)
            {
                // no elements
            }

            return result;
        }
    }
}
