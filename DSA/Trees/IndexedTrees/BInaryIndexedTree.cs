using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IndexedTrees
{
    public class BInaryIndexedTree<T>
    {
        private Func<T, T, T> combineFunc;
        private T[] tree;
        private int realN;

        public BInaryIndexedTree(int n, Func<T, T, T> func)
        {
            
            realN = 1;
            while(realN < n)
            {
                realN *= 2;
            }

            tree = new T[realN * 2];
            combineFunc = func;
        }

        public BInaryIndexedTree(T[] initial, Func<T, T, T> func)
            : this(initial.Length, func)
        {
            int i = realN;
            foreach (var val in initial)
            {
                tree[i] = val;
                ++i;
            }

            for (int j = realN - 1; j > 1; --j)
            {
                Update(j);
            }
        }

        public BInaryIndexedTree(ICollection<T> initial, Func<T, T, T> func)
            :this(initial.Count, func)
        {
            int i = realN;
            foreach(var val in initial)
            {
                tree[i] = val;
                ++i;
            }

            for (int j = realN - 1; j > 1; --j)
            {
                Update(j);
            }
        }

        public T this[int index]
        {
            get
            {
                return tree[realN + index];
            }

            set
            {
                int indexToUpdate = realN + index;

                tree[indexToUpdate] = value; // update to new value

                while(indexToUpdate > 1)
                {
                    Update(indexToUpdate);
                    indexToUpdate /= 2;
                }
            }
        }

        public T GetInterval(int left, int right)
        {
            return GetInterval(left, right, 1, 0, realN);
        }

        private T GetInterval(int leftQuery, int rightQuery, int index, int leftNode, int rightNode)
        {
            // cql podinterval - dyno
            if (leftQuery == leftNode && rightQuery == rightNode)
            {
                return tree[index];
            }

            int middleNode = (leftNode + rightNode) / 2;

            // ako e samo v podinterval lqv
            if(rightQuery <= middleNode)
            {
                return GetInterval(leftQuery, rightQuery, index * 2, leftNode, middleNode);
            }

            // ako e samo v podinterval desen
            if (leftQuery >= middleNode)
            {
                return GetInterval(leftQuery, rightQuery, index * 2 + 1, middleNode, rightNode);
            }

            // v sluchai che e v 2-ta podintervala
            return combineFunc(
                GetInterval(leftQuery, middleNode, index * 2, leftNode, middleNode),
                GetInterval(middleNode, rightQuery, index * 2 + 1, middleNode, rightNode)
                );

            /*
             index * 2
             [leftNode, middleNode)
             index * 2 = 1
             [middleNode, rightNode)
            */
        }

        private void Update(int index)
        {
            tree[index / 2] = combineFunc(tree[index], tree[index ^ 1]);

            // num ^ 1 -> moves to next child (adds or removes 1)
            // tree[1 - indexToUpdate % 2 * 2 + indexToUpdate]
        }
    }
}
