using System;

namespace LinearDataStructures.Tasks.CustomDataStructures
{
    public class CustomLinkedListNode<T> where T : IComparable<T>
    {
        private T value;
        private CustomLinkedListNode<T> next;

        public T Value
        {
            get { return this.value; }
            set { this.value = value; }
        }

        public CustomLinkedListNode<T> Next
        {
            get { return this.next; }
            set { this.next = value; }
        }

        public CustomLinkedListNode()
        : this(default(T), null)
        { }

        public CustomLinkedListNode(T value, CustomLinkedListNode<T> next)
        {
            this.value = value;
            this.next = next;
        }

        public CustomLinkedListNode(T value)
        {
            this.value = value;
            this.next = null;
        }
    }

    public class CustomLinkedList<T> where T : IComparable<T>
    {
        private CustomLinkedListNode<T> tailNode;
        private int count;

        public int Count
        {
            get { return this.count; }
        }

        public CustomLinkedList()
        {
            this.tailNode = null;
            this.count = 0;
        }

        public CustomLinkedList(CustomLinkedListNode<T> Node)
        {
            this.tailNode = Node;
            this.count++;
        }

        public CustomLinkedList(T value)
        {
            CustomLinkedListNode<T> tempNode = new CustomLinkedListNode<T>(value);
            this.tailNode = tempNode;
            this.count++;
        }

        public void AddItem(T value)
        {
            if (this.tailNode == null)
            {
                this.tailNode = new CustomLinkedListNode<T>(value);
            }
            else
            {
                CustomLinkedListNode<T> newNode = new CustomLinkedListNode<T>(value, this.tailNode);
                this.tailNode = newNode;
            }
            this.count++;
        }

        public void AddItemAt(T value, int index)
        {
            if (index < 0 || index > this.count)
            {
                throw new IndexOutOfRangeException(String.Format("Invalid index: {0}.", index));
            }
            else
            {
                if (index == this.count)
                {
                    CustomLinkedListNode<T> newNode = new CustomLinkedListNode<T>(value, this.tailNode);
                    this.tailNode = newNode;
                }
                else
                {
                    CustomLinkedListNode<T> currentElement = this.tailNode;
                    CustomLinkedListNode<T> newNode = new CustomLinkedListNode<T>(value);
                    for (int i = 0; i < this.count - index - 1; i++)
                    {
                        currentElement = currentElement.Next;
                    }
                    newNode.Next = currentElement.Next;
                    currentElement.Next = newNode;
                }
                this.count++;
            }
        }

        public void RemoveLast()
        {
            CustomLinkedListNode<T> currentElement = this.tailNode.Next;
            this.tailNode = currentElement;
            this.count--;
        }

        public void RemoveAt(int index)
        {
            if (index < 0 || index >= this.count)
            {
                throw new IndexOutOfRangeException(String.Format("Invalid index: {0}.", index));
            }
            else
            {
                if (this.count - 1 == index)
                {
                    this.RemoveLast();
                }
                else
                {
                    CustomLinkedListNode<T> currentElement = this.tailNode;
                    for (int i = 0; i < this.count - index - 2; i++)
                    {
                        currentElement = currentElement.Next;
                    }
                    currentElement.Next = currentElement.Next.Next;
                    this.count--;
                }
            }
        }

        public void Remove(T value)
        {
            CustomLinkedListNode<T> currentElement = this.tailNode;
            int position = this.count - 1;
            while (currentElement.Next != null)
            {
                if (currentElement.Value.Equals(value))
                {
                    this.RemoveAt(position);
                    break;
                }
                else
                {
                    currentElement = currentElement.Next;
                    position--;
                }
            }
        }

        public void Clear()
        {
            this.tailNode = null;
        }

        public bool Contains(T value)
        {
            CustomLinkedListNode<T> currentElement = this.tailNode;
            while (currentElement.Next != null)
            {
                if (currentElement.Value.Equals(value))
                {
                    return true;
                }
                currentElement = currentElement.Next;
            }
            return false;
        }

        public T this[int index]
        {
            get
            {
                if (index >= this.count)
                {
                    throw new IndexOutOfRangeException(String.Format("Invalid index: {0}.", index));
                }
                else
                {
                    CustomLinkedListNode<T> currentElement = this.tailNode;
                    int position = this.count - 1;
                    for (int i = 0; i < this.count - index - 1; i++)
                    {
                        currentElement = currentElement.Next;
                    }
                    return currentElement.Value;
                }
            }
        }
    }
}
