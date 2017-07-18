using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HashSetDemo
{
    public class HashSet<T> : IEnumerable<T>
    {
        private const int MIN_BUFFER_SIZE = 16;
        private const int RESIZE_FACTOR = 2;
        private const double FULL_PROP = 0.7;

        private SinglyLinkedList<T>[] buffer;
        private SinglyLinkedList<uint> used;

        public HashSet()
        {
            this.buffer = new SinglyLinkedList<T>[100];
            this.used = null;
            this.Count = 0;
        }

        public int Count { get; private set; }

        public bool Add(T value)
        {
            var hash = (uint)value.GetHashCode();
            var index = (uint)(hash % buffer.Length);
            var existed = buffer[index] != null && buffer[index].Contains(value);
            if (existed)
            {
                return false;
            }

            ++Count;
            if ((double)this.Count / buffer.Length > FULL_PROP)
            {
                this.Resize(buffer.Length * RESIZE_FACTOR);
                index = (uint)(hash % buffer.Length);
            }

            if (buffer[index] == null)
            {
                this.used = new SinglyLinkedList<uint>(index, this.used);
            }
            buffer[index] = new SinglyLinkedList<T>(value, buffer[index]);

            return true;
        }

        public T Find(T value)
        {
            var hash = (uint)value.GetHashCode();
            var index = (uint)(hash % buffer.Length);

            foreach (var x in this.buffer[index])
            {
                if (x.Equals(value))
                {
                    return x;
                }
            }

            return default(T);
        }

        public bool Contains(T value)
        {
            var hash = (uint)value.GetHashCode();
            var index = (uint)(hash % buffer.Length);

            return buffer[index] != null && buffer[index].Contains(value);
        }

        public bool Remove(T value)
        {
            var hash = (uint)value.GetHashCode();
            var index = (uint)(hash % buffer.Length);

            if (buffer[index] == null)
            {
                return false;
            }

            bool removed;
            buffer[index].Remove(value, out removed);
            if(removed)
            {
                --this.Count;
                return true;
            }

            return false;
        }

        public IEnumerator<T> GetEnumerator()
        {
            foreach (var index in this.used)
            {
                foreach (var x in this.buffer[index])
                {
                    yield return x;
                }
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }

        private void Resize(int newSize)
        {
            var newBuffer = new SinglyLinkedList<T>[newSize];
            SinglyLinkedList<uint> newIndeces = null;
            foreach(var x in this)
            {
                var hash = (uint)x.GetHashCode();
                var index = (uint)(hash % newSize);

                if (newBuffer[index] == null)
                {
                    newIndeces = new SinglyLinkedList<uint>(index, newIndeces);
                }

                newBuffer[index] = new SinglyLinkedList<T>(x, newBuffer[index]);
            }

            this.buffer = newBuffer;
            this.used = newIndeces;
        }
    }
}
