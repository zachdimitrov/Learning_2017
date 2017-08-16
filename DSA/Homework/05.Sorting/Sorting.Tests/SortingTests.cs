using System;
using NUnit.Framework;
using System.Collections.Generic;

namespace Sorting.Tests
{
    [TestFixture]
    public class SortingTests
    {
        // Swapper tests
        [Test]
        public void Utls_Swap_ShouldSwapCorrectly_Integers()
        {
            var list = new List<int> { 5, 2, 3, 1 };

            var utils = new Utils<int>();
            utils.Swap(list, 0, 2);

            Assert.AreEqual(list[0], 3);
            Assert.AreEqual(list[2], 5);
        }

        [Test]
        public void Utils_Swap_ShouldSwapCorrectly_Strings()
        {
            var list = new List<string> { "a", "l", "v", "k" };

            var utils = new Utils<string>();
            utils.Swap(list, 0, 2);

            Assert.AreEqual("vlak", string.Join("", list));
        }

        // selection sort tests
        [Test]
        public void SelectionSorter_ShouldSortCorrectly_Integers()
        {
            var list = new List<int> { 5, 2, 8, 3, 1, 9, 4, 7, 6 };
            var sorted = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9 };

            var sorter = new SelectionSorter<int>();
            sorter.Sort(list);


            Assert.AreEqual(sorted, list);
        }

        [Test]
        public void SelectionSorter_ShouldSortCorrectly_Strings()
        {
            var list = new List<string> { "a", "l", "v", "k" };

            var sorter = new SelectionSorter<string>();
            sorter.Sort(list);

            Assert.AreEqual("aklv", string.Join("", list));
        }

        // buble sort tests
        [Test]
        public void BubleSorter_ShouldSortCorrectly_Integers()
        {
            var list = new List<int> { 5, 2, 8, 3, 1, 9, 4, 7, 6 };
            var sorted = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9 };

            var sorter = new BubleSorter<int>();
            sorter.Sort(list);

            Assert.AreEqual(sorted, list);
        }

        [Test]
        public void BubleSorter_ShouldSortCorrectly_Strings()
        {
            var list = new List<string> { "a", "l", "v", "k" };

            var sorter = new BubleSorter<string>();
            sorter.Sort(list);

            Assert.AreEqual("aklv", string.Join("", list));
        }

        // insertion sort tests
        [Test]
        public void InsertionSorter_ShouldSortCorrectly_Integers()
        {
            var list = new List<int> { 5, 2, 8, 3, 1, 9, 4, 7, 6 };
            var sorted = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9 };

            var sorter = new InsertionSorter<int>();
            sorter.Sort(list);

            Assert.AreEqual(sorted, list);
        }

        [Test]
        public void InsertionSorter_ShouldSortCorrectly_Strings()
        {
            var list = new List<string> { "a", "l", "v", "k" };

            var sorter = new InsertionSorter<string>();
            sorter.Sort(list);

            Assert.AreEqual("aklv", string.Join("", list));
        }

        // quick sort tests
        [Test]
        public void QuickSorter_ShouldSortCorrectly_Integers()
        {
            var list = new List<int> { 5, 2, 8, 3, 1, 9, 4, 7, 6 };
            var sorted = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9 };

            var sorter = new QuickSorter<int>();
            sorter.Sort(list);

            Assert.AreEqual(sorted, list);
        }

        [Test]
        public void QuickSorter_ShouldSortCorrectly_Strings()
        {
            var list = new List<string> { "a", "l", "v", "k" };

            var sorter = new QuickSorter<string>();
            sorter.Sort(list);

            Assert.AreEqual("aklv", string.Join("", list));
        }

        // merge sort tests
        [Test]
        public void MergeSorter_ShouldSortCorrectly_Integers()
        {
            var list = new List<int> { 5, 2, 8, 3, 1, 9, 4, 7, 6 };
            var sorted = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9 };

            var sorter = new MergeSorter<int>();
            sorter.Sort(list);

            Assert.AreEqual(sorted, list);
        }

        [Test]
        public void MergeSorter_ShouldSortCorrectly_Strings()
        {
            var list = new List<string> { "a", "l", "v", "k" };

            var sorter = new MergeSorter<string>();
            sorter.Sort(list);

            Assert.AreEqual("aklv", string.Join("", list));
        }
    }
}
