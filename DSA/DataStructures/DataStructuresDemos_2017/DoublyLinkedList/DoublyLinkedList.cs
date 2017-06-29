using System;

namespace DoublyLinkedList
{
    public class DoublyLinkedList<T>
    {
        private ListNode<T> first;
        private ListNode<T> last;

        public DoublyLinkedList()
        {
            this.first = null;
            this.last = null;
            Size = 0;
        }

        public int Size { get; set; }

        public ListNode<T> First
        {
            get { return first; }
            private set { first = value; }
        }

        public ListNode<T> Last
        {
            get { return last; }
            private set { last = value; }
        }

        public void InsetBefore(ListNode<T> node, T value)
        {
            ++this.Size;
            var newNode = new ListNode<T>(value);
            newNode.Next = node;
            newNode.Prev = node.Prev;

            newNode.Next.Prev = newNode;
            if (newNode.Prev != null)
            {
                newNode.Prev.Next = newNode;
            }
            else
            {
                this.First = newNode;
            }
        }

        public void InsertAfter(ListNode<T> node, T value)
        {
            ++this.Size;
            var newNode = new ListNode<T>(value);
            newNode.Prev = node;
            newNode.Next = node.Next;

            newNode.Prev.Next = newNode;
            if (newNode.Next != null)
            {
                newNode.Next.Prev = newNode;
            }
            else
            {
                this.Last = newNode;
            }
        }

        public void PushFront(T value)
        {
            var newNode = new ListNode<T>(value);
            ++this.Size;
            if (First == null)
            {
                First = newNode;
                Last = newNode;
                return;
            }

            newNode.Next = First;
            First.Prev = newNode;
            First = newNode;
        }

        public void PushBack(T value)
        {
            var newNode = new ListNode<T>(value);
            ++this.Size;
            if (Last == null)
            {
                Last = newNode;
                First = newNode;
                return;
            }

            newNode.Prev = Last;
            Last.Next = newNode;
            Last = newNode;
        }

        public T PopFront()
        {
            return Remove(First);
        }

        public T PopBack()
        {
            return Remove(Last);
        }

        public T Remove(ListNode<T> node)
        {
            if (node == null)
            {
                return default(T);
            }

            if (node.Prev != null)
            {
                if (node.Next != null)
                {
                    node.Prev.Next = node.Next;
                }
                else
                {
                    node.Prev.Next = null;
                }
            }
            else
            {
                First = node.Next;
            }

            if (node.Next != null)
            {
                if (node.Prev != null)
                {
                    node.Next.Prev = node.Prev;
                }
                else
                {
                    node.Next.Prev = null;
                }
            }
            else
            {
                Last = node.Prev;
            }

            --this.Size;
            return node.Val;
        }
    }
}
