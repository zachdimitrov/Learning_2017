using System.Collections.Generic;

namespace ReadTree
{
    public class Tree<T>
    {
        public Tree()
        {
            this.Children = new List<Tree<T>>();
        }

        public Tree(T value) : this()
        {
            this.Value = value;
        }

        public Tree(T value, List<Tree<T>> children)
        {
            this.Value = value;
            this.Children = children;
        }

        public T Value { get; set; }
        public List<Tree<T>> Children { get; set; }
        public bool HasParent { get; set; }

        public bool IsLeaf => Children == null;
    }
}
