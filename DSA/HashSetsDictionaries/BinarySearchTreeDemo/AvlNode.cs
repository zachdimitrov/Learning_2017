using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinarySearchTreeDemo
{
    internal class AvlNode<T> where T : IComparable<T>
    {
        private int size;
        private int height;

        public AvlNode(T value)
        {
            this.Value = value;
            this.Neighbours = new AvlNode<T>[3];
        }

        public T Value { get; private set; }

        public AvlNode<T>[] Neighbours { get; set; }

        public AvlNode<T> Parent {
            get
            {
                return Neighbours[2];
            }
            set
            {
                this.Neighbours[2] = value;
            }
        }

        public AvlNode<T> Left
        {
            get
            {
                return Neighbours[0];
            }
            set
            {
                this.Neighbours[0] = value;
            }
        }

        public AvlNode<T> Right
        {
            get
            {
                return Neighbours[1];
            }
            set
            {
                this.Neighbours[1] = value;
            }
        }



        public static int GetSize(AvlNode<T> node)
        {
            return node == null ? 0 : node.size;
        }

        public static int GetHeight(AvlNode<T> node)
        {
            return node == null ? 0 : node.height;
        }

        public int Ballance => GetHeight(Left) - GetHeight(Right);

        public void RotateRight()
        {
            this.Rotate(0, 1);
        }

        public void RotateLeft()
        {
            this.Rotate(1, 0);
        }

        private void Rotate(int left, int right)
        {
            throw new NotImplementedException();
        }
    }
}
