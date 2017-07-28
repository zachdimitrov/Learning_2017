using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinarySearchTreeDemo
{
    public class AvlTreeIterator<T> where T : IComparable<T>
    {
        internal AvlNode<T> Node { get; private set; }

        internal AvlTreeIterator(AvlNode<T> node)
        {
            this.Node = node;
        }

        public T Value => Node.Value;

        public void MoveRight()
        {
            this.Move(0, 1);
        }

        public void MoveLeft()
        {
            this.Move(1, 0);
        }

        private void Move(int left, int right)
        {
            if (Node.Neighbours[right] != null)
            {
                this.Node = Node.Neighbours[right];
                while (Node.Neighbours[left] != null)
                {
                    this.Node = Node.Neighbours[left];
                }
            }
            else
            {
                while(Node.Parent != null && Node.Parent.Neighbours[right] == Node)
                {
                    this.Node = Node.Parent;
                }

                if (this.Node.Parent == null)
                {
                    this.Node = null;
                    return;
                }

                this.Node = Node.Parent;
            }
        }
    }
}
