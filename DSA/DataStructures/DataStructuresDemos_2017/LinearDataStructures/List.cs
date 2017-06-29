using System;

namespace LinearDataStructures
{
    public class List<T>
    {
        private const int MinCapacity = 4;
        private T[] buffer;
        private int size;

        public List()
        {
            this.buffer = null;
            this.size = 0;
        }

        public int Capacity { get { return buffer.Length; } }
        public int Size { get { return this.size; } }

        public T Last
        {
            get { return buffer[Size - 1]; }

            set { buffer[size - 1] = value; }
        }

        public void InsertAt(int index, T value)
        {
            if (index == size)
            {
                PushBack(value);
                return;
            }

            PushBack(Last);

            for (int i = size - 2; i > index; --i)
            {
                buffer[i] = buffer[i - 1];
            }

            buffer[index] = value;
        }

        public void PushBack(T value)
        {
            if (this.buffer == null)
            {
                buffer = new T[MinCapacity];
            }
            else if (size == buffer.Length)
            {
                Reserve(size * 2);
            }

            buffer[size] = value;
            ++size;
        }

        public void PopBack()
        {
            if (size < 0)
            {
                throw new IndexOutOfRangeException("Popping is impossible");   
            }
            --size;
        }

        public void RemoveAt(int index)
        {
            for (int i = index; i < size - 1; i++)
            {
                buffer[i] = buffer[i + 1];
            }

            PopBack();
        }

        public void RemoveRange(int begin, int end)
        {
            // validate
            int rangeSize = end - begin;
            for (int i = begin; i < size - rangeSize; i++)
            {
                //  i + rangeSize <= size - 1
                // i + rangeSize < size
                // i < size - rangeSize
                buffer[i] = buffer[i + rangeSize];
            }

            for (int i = 0; i < rangeSize; i++)
            {
                PopBack();
            }
        }

        public void Reserve(int newSize)
        {
            if (newSize < size)
            {
                return;
            }

            var newBuffer = new T[newSize];
            for (int i = 0; i < size; i++)
            {
                newBuffer[i] = buffer[i];
            }

            buffer = newBuffer;
        }

        public void ShrinkToFit()
        {
            Reserve(size);
        }

        public void Clear()
        {
            size = 0;
            buffer = new T[MinCapacity]; // optional
        }

        // Indexer
        public T this[int index]
        {
            get { return buffer[index]; }

            set { buffer[index] = value; }
        }
    }
}
