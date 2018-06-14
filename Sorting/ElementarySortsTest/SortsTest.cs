using ElementarySorts;
using NUnit.Framework;
using System.Collections.Generic;

namespace ElementarySortsTest
{
    [TestFixture]
    public class SortsTest
    {
        private List<AbstractSort<int>> sorts;

        [SetUp]
        public void SetUp()
        {
            populateElemSorts();
        }

        private void populateElemSorts()
        {
            sorts = new List<AbstractSort<int>>();
            sorts.Add(new InsertionSort<int>());
            sorts.Add(new InsertionSortWithoutExchanges<int>());
            sorts.Add(new InsertionSortWithSentinel<int>());
            sorts.Add(new SelectionSort<int>());
            sorts.Add(new ShellSort<int>());
            sorts.Add(new MergeSort<int>());
            sorts.Add(new BottomUpMergeSort<int>());
            sorts.Add(new MergeSortWithFasterMerge<int>());
            sorts.Add(new MergeWithInsertionSort<int>());
            sorts.Add(new MergeSortWithSortedArrayTest<int>());
            sorts.Add(new QuickSort<int>());
            sorts.Add(new ThreeWayQuickSort<int>());
            sorts.Add(new HeapSort<int>());
        }

        [Test]
        public void canSort()
        {
            foreach(var elemSort in sorts)
            {
                Assert.AreEqual(new int[] { 1, 2, 5, 10, 12, 45, 78 }, elemSort.Sort(new int[] { 2, 5, 1, 45, 10, 12, 78 }), elemSort.GetSortName());
                Assert.AreEqual(new int[] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 }, elemSort.Sort(new int[] { 9, 8, 7, 6, 5, 4, 3, 2, 1, 0 }), elemSort.GetSortName());
                Assert.AreEqual(new int[] { 1, 2, 2, 2, 2, 5 }, elemSort.Sort(new int[] { 2, 1, 2, 2, 2, 5 }), elemSort.GetSortName());
                Assert.AreEqual(new int[] { 1, 3, 3, 3, 5, 8 }, elemSort.Sort(new int[] { 3, 1, 5, 3, 3, 8 }), elemSort.GetSortName());
            }
        }
    }
}
