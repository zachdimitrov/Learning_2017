using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinarySearchTreeDemo
{
    public class AvlTree<T> : IEnumerable<T> where T: IComparable<T>
    {
        // var set = new SortedSet<int>();
        // var dict = new SortedDictionary<string, int>();

        private AvlNode<T> root;

        public int Count => AvlNode<T>.GetSize(root);
        public int Height => AvlNode<T>.GetHeight(root);

        public AvlTreeIterator<T> Begin
        {
            get
            {
                if (this.root == null)
                {
                    return new AvlTreeIterator<T>(null);
                }

                var node = this.root;
                while(node.Left != null)
                {
                    node = node.Left;
                }

                return new AvlTreeIterator<T>(node);
            }
        }

        public AvlTree()
        {
            this.root = null;
        }

        public Tuple<AvlTreeIterator<T>, bool> Add(T value)
        {
            var it = this.LowerBound(value);
            if (it.Node.Value.CompareTo(value) == 0)
            {
                return new Tuple<AvlTreeIterator<T>, bool>(it, false);
            }

            var newNode = new AvlNode<T>(value);

            if (it.Node.Left == null)
            {
                it.Node.Left = newNode;
                it.Node.Left.Parent = it.Node;
            }
            else
            {
                it.MoveLeftt();
                it.Node.Right = newNode;
                it.Node.Right.Parent = it.Node;
            }

            var newIt = new AvlTreeIterator<T>(newNode);
            return new Tuple<AvlTreeIterator<T>, bool>(newIt, true);
        }

        public void Remove(T value)
        {
            throw new NotImplementedException();
        }

        public void Remove(AvlTreeIterator<T> iterator)
        {
            throw new NotImplementedException();
        }

        public bool Contains(T value)
        {
            var it = this.LowerBound(value);
            if (it.Node.Value.CompareTo(value) == 0)
            {
                return true;
            }

            return false;
        }

        public AvlTreeIterator<T> Find(T value)
        {
            var it = this.LowerBound(value);
            if (it.Node.Value.CompareTo(value) == 0)
            {
                return it;
            }

            return null;
        }

        public AvlTreeIterator<T> LowerBound(T value)
        {
            var node = this.root;

            while (true)
            {
                var cmp = value.CompareTo(node.Value);
                if (cmp < 0)
                {
                    if (node.Left == null)
                    {
                        return new AvlTreeIterator<T>(node);
                    }

                    node = node.Left;
                }
                else if (cmp > 0)
                {
                    if (node.Right == null)
                    {
                        var it = new AvlTreeIterator<T>(node);
                        it.MoveRight();
                        return it;
                    }

                    node = node.Right;
                }
                else
                {
                    return new AvlTreeIterator<T>(node);
                }
            }
        }

        public IEnumerator<T> GetEnumerator()
        {
            var it = this.Begin;

            while (it.Node != null)
            {
                yield return it.Value;
                it.MoveRight();
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}

// 3:46