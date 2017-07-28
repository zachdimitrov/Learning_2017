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
            this.size = 1;
            this.height = 1;
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

        public void Update()
        {
            this.size = GetSize(this.Left) + GetSize(this.Right) + 1;
            this.height = Math.Max(GetHeight(this.Left), GetHeight(this.Right)) + 1;

            if (this.Ballance < -1)
            {
                this.RotateLeft();
            }
            else if(this.Ballance > 1)
            {
                this.RotateRight();
            }

            if (this.Parent != null)
            {
                this.Parent.Update();
            }
        }


        public AvlNode<T> RotateRight()
        {
            return this.Rotate(0, 1);
        }

        public AvlNode<T> RotateLeft()
        {
            return this.Rotate(1, 0);
        }

        private AvlNode<T> Rotate(int left, int right)
        {
            var newRoot = this.Neighbours[left];

            if (newRoot.Neighbours[right] != null)
            {
                newRoot.Neighbours[right].Parent = this;
            }

            if (this.Parent != null)
            {
                if (this == this.Parent.Neighbours[left])
                {
                    this.Parent.Neighbours[left] = newRoot;
                }
                else
                {
                    this.Parent.Neighbours[right] = newRoot;
                }
            }

            newRoot.Parent = this.Parent;
            this.Parent = newRoot;

            this.Neighbours[left] = newRoot.Right;
            newRoot.Neighbours[right] = this;
            return newRoot;
        }
    }
}
