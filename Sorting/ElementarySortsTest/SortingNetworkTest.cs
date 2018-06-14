using ElementarySorts;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElementarySortsTest
{
    [TestFixture]
    public class SortingNetworkTest
    {
        private AbstractSort<int> elemSort;

        [SetUp]
        public void SetUp()
        {
            elemSort = new SortingNetwork<int>();
        }

        [Test]
        public void sortingNetworkSort()
        {
            Assert.AreEqual(new int[] { 1, 2, 3 }, elemSort.Sort(new int[] { 3, 2, 1 }));
            Assert.AreEqual(new int[] { 1, 2, 3 }, elemSort.Sort(new int[] { 2, 1, 3 }));
            Assert.AreEqual(new int[] { 1, 2, 3 }, elemSort.Sort(new int[] { 1, 3, 2 }));
            Assert.AreEqual(new int[] { 1, 2, 3 }, elemSort.Sort(new int[] { 3, 1, 2 }));
            Assert.AreEqual(new int[] { 1, 2, 3 }, elemSort.Sort(new int[] { 1, 2, 3 }));
        }
    }
}
