namespace LinkedList
{
    public class LinkedList<T>
    {
        private Node<T> head;

        public void Add(T value)
        {
            var oldHead = this.head;
            this.head = new Node<T>(value);
            this.head.Next = oldHead;
        }
    }
}
