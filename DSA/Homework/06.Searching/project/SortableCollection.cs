namespace SearchingHomework
{
    using System;
    using System.Collections.Generic;

    public class SortableCollection<T> where T : IComparable<T>
    {
        private readonly IList<T> items;

        public SortableCollection()
        {
            this.items = new List<T>();
        }

        public SortableCollection(IEnumerable<T> items)
        {
            this.items = new List<T>(items);
        }

        public IList<T> Items
        {
            get
            {
                return this.items;
            }
        }

        public void Sort(ISorter<T> sorter)
        {
            sorter.Sort(this.items);
        }

        public bool LinearSearch(T item)
        {
            return this.Items.Contains(item);
        }

        public int BinarySearch(T item)
        {
            return this.items.BinarySearchFindWhatever(item);
        }

        public void Shuffle()
        {
            int n = this.items.Count;
            var utils = new Utils<T>();
            for (int i = 0; i < n; i++)
            {
                int r = i + RandomProvider.Instance.Next(0, n - i);
                utils.Swap(this.items, i, r);
            }
        }

        public void PrintAllItemsOnConsole()
        {
            for (int i = 0; i < this.items.Count; i++)
            {
                if (i == 0)
                {
                    Console.Write(this.items[i]);
                }
                else
                {
                    Console.Write(" " + this.items[i]);
                }
            }

            Console.WriteLine();
        }
    }

    public static class RandomProvider
    {
        public static Random Instance = new Random();
    }
}
