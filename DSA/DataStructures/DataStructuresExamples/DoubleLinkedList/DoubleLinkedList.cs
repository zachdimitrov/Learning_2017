namespace DoubleLinkedList
{
    public class DoubleLinkedList<T>
    {
        private Node<T> start;
        private Node<T> end;

        public void AddStart(T value)
        {
            Node<T> newElem = new Node<T>(value);
            var oldStart = this.start;
            this.start = newElem;
            newElem.Next = oldStart;
        }
        public void AddEnd(T value)
        {
            Node<T> newElem = new Node<T>(value);
            var oldEnd = this.end;
            this.end = newElem;
            newElem.Prev = oldEnd;
        }
    }
}
