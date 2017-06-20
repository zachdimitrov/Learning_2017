namespace DoubleLinkedList
{
    public class DoubleLinkedList<T>
    {
        public Node<T> AddFirst(T value)
        {
            Node<T> newElem = new Node<T>(value);
            if (this.First == null)
            {
                this.First = newElem;
                this.Last = newElem;
            }

            var oldStart = this.First;
            this.First = newElem;
            newElem.Next = oldStart;
            oldStart.Prev = newElem;

            return newElem;
        }

        public Node<T> AddLast(T value)
        {
            Node<T> newElem = new Node<T>(value);

            if (this.First == null)
            {
                this.First = newElem;
                this.Last = newElem;
            }

            var oldEnd = this.Last;
            this.Last = newElem;
            newElem.Prev = oldEnd;
            oldEnd.Prev.Next = newElem;

            return newElem;
        }


        public Node<T> First { get; private set; }

        public Node<T> Last { get; private set; }
    }
}
