using System;
namespace DoublyLinkedList
{
    public class ListNode<T>
    {
        private T val;

        internal ListNode(T value)
        {
            this.Val = value;
            this.Prev = null;
            this.Next = null;
        }

        public T Val
        {
            get { return this.val; }
            set
            {
                if(value == null)
                {
                    throw new ArgumentNullException("Value cannot be null!");
                } 

                this.val = value;
            }
        }

        public ListNode<T> Prev { get; internal set; }
        public ListNode<T> Next { get; internal set; }
    }
}
