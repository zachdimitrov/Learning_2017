using System;

namespace LinearDataStructures.Tasks.CustomDataStructures
{
    public class CustomStack<T> where T : IComparable
    {
        private const int defaultCapacity = 16;
        private int count;
        private int currentCapacity;
        private T[] elements;

        public int Count
        {
            get { return this.count; }
        }

        public int Capacity
        {
            get { return this.currentCapacity; }
        }

        public CustomStack()
        {
            this.elements = new T[defaultCapacity];
            this.currentCapacity = defaultCapacity;
            this.count = 0;
        }

        public CustomStack(int capacity)
        {
            this.elements = new T[capacity];
            this.currentCapacity = capacity;
            this.count = 0;
        }

        public void Push(T newElement)
        {
            if (this.count < this.currentCapacity)
            {
                this.elements[this.count] = newElement;
            }
            else
            {
                AutoGrow();
                this.elements[this.count] = newElement;
            }
            this.count++;
        }

        public T Pop()
        {
            if (this.count <= 0)
            {
                throw new Exception("The stack is empty can not peek!");
            }
            T result = this.elements[this.count - 1];
            this.elements[this.count - 1] = default(T);
            this.count--;
            return result;
        }

        public T Peek()
        {
            if (this.count <= 0)
            {
                throw new Exception("The stack is empty can not peek!");
            }
            return this.elements[this.count - 1];
        }

        public bool Contains(T value)
        {
            for (int i = 0; i < this.count; i++)
            {
                if (elements[i].Equals(value))
                {
                    return true;
                }
            }
            return false;
        }

        private void AutoGrow()
        {
            int newCapacity = currentCapacity * 2;
            T[] newElements = new T[newCapacity];
            for (int i = 0; i < currentCapacity; i++)
            {
                newElements[i] = this.elements[i];
            }
            this.currentCapacity = newCapacity;
            this.elements = newElements;
        }
    }
}
