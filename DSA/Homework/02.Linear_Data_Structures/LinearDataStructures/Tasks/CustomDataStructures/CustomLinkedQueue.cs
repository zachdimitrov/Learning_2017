using System;

namespace LinearDataStructures.Tasks.CustomDataStructures
{
    public class CustomLinkedQueueNode<T> where T : IComparable<T>
    {
        private T value;
        private CustomLinkedQueueNode<T> next;
        private CustomLinkedQueueNode<T> previous;

        public T Value
        {
            get { return this.value; }
            set { this.value = value; }
        }

        public CustomLinkedQueueNode<T> Next
        {
            get { return this.next; }
            set { this.next = value; }
        }

        public CustomLinkedQueueNode<T> Previous
        {
            get { return this.previous; }
            set { this.previous = value; }
        }

        public CustomLinkedQueueNode()
        : this(default(T), null, null)
        { }

        public CustomLinkedQueueNode(T value)
        {
            this.value = value;
            this.next = null;
            this.previous = null;
        }

        public CustomLinkedQueueNode(T value, CustomLinkedQueueNode<T> nextValue, CustomLinkedQueueNode<T> prevValue)
        {
            this.value = value;
            this.next = nextValue;
            this.previous = prevValue;
        }
    }
    public class CustomLinkedQueue<T> where T : IComparable<T>
    {
        private CustomLinkedQueueNode<T> head;
        private CustomLinkedQueueNode<T> tail;
        private int count;

        public int Count
        {
            get { return this.count; }
        }

        public CustomLinkedQueue()
        {
            this.head = null;
            this.tail = null;
            this.count = 0;
        }

        public void Enqueue(T value)
        {
            if (this.tail == null)
            {
                this.tail = new CustomLinkedQueueNode<T>(value);
                this.head = tail;
            }
            else
            {
                CustomLinkedQueueNode<T> newNode = new CustomLinkedQueueNode<T>(value, null, this.tail);
                this.tail.Next = newNode;
                this.tail = newNode;
            }
            this.count++;
        }

        public T Dequeue()
        {
            if (this.count > 0)
            {
                T topElement = head.Value;
                if (this.head.Next == null)
                {
                    this.head = null;
                    this.tail = null;
                }
                else
                {
                    this.head = head.Next;
                    this.head.Previous = null;
                }
                this.count--;
                return topElement;
            }
            else
            {
                throw new NullReferenceException("No elements in the queue!");
            }
        }

        public T Peek()
        {
            if (this.count > 0)
            {
                T topElement = this.head.Value;
                return topElement;
            }
            else
            {
                throw new NullReferenceException("No elements in the queue!");
            }
        }

        public bool Contains(T value)
        {
            CustomLinkedQueueNode<T> currentNode = head;
            while (currentNode != null)
            {
                if (currentNode.Value.Equals(value))
                {
                    return true;
                }
                currentNode = currentNode.Next;
            }
            return false;
        }

        public void Clear()
        {
            this.count = 0;
            this.head = null;
            this.tail = null;
        }
    }
}
