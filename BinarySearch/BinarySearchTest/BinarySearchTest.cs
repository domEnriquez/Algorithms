using BinarySearch;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinarySearchTest
{
    [TestFixture]
    public class BinarySearchTest
    {
        private BinarySearchAlgorithm bs;

        [SetUp]
        public void Setup()
        {
            int[] sortedArray = new int[] { 10, 22, 31, 43, 56, 68, 79, 81, 92, 100 };
            bs = new BinarySearchAlgorithm(sortedArray);
        }

        [Test]
        public void canSearh()
        {
            Assert.AreEqual(0, bs.Search(10));
            Assert.AreEqual(1, bs.Search(22));
            Assert.AreEqual(2, bs.Search(31));
            Assert.AreEqual(3, bs.Search(43));
            Assert.AreEqual(4, bs.Search(56));
            Assert.AreEqual(5, bs.Search(68));
            Assert.AreEqual(6, bs.Search(79));
            Assert.AreEqual(7, bs.Search(81));
            Assert.AreEqual(8, bs.Search(92));
            Assert.AreEqual(9, bs.Search(100));
            Assert.AreEqual(2, bs.Search(31));
            Assert.AreEqual(-1, bs.Search(78));
        }
    }
}
