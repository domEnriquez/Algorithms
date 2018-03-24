using NUnit.Framework;
using PriorityQueues;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PriorityQueuesTest
{
    public class PriorityQueueTest
    {
        private BinaryHeapPriorityQueue<int> pq;

        public class BinaryHeapMaxPQTests : PriorityQueueTest
        {
            [SetUp]
            public void GivenANewEmptyBinaryHeapMaxPQ()
            {
                pq = new BinaryHeapMaxPQ<int>();
            }

            [TestFixture]
            public class EmptyBinaryHeapMaxPQExceptions : BinaryHeapMaxPQTests
            {
                [Test]
                public void WhenDeleteTop_ThenThrowHeapUnderflowException()
                {
                    Assert.Throws<BinaryHeapPriorityQueue<int>.HeapUnderflowException>(() => pq.DeleteTop());
                }

                [Test]
                public void WhenPeekTop_ThenThrowHeapUnderflowException()
                {
                    Assert.Throws<BinaryHeapPriorityQueue<int>.HeapUnderflowException>(() => pq.PeekTop());
                }
            }

            [TestFixture]
            public class BinaryHeapMaxPQWithElementsOperations : BinaryHeapMaxPQTests
            {
                [SetUp]
                public void GivenABinaryHeapMaxPqWithElements()
                {
                    pq.Insert(1);
                    pq.Insert(3);
                    pq.Insert(2);
                }

                [Test]
                public void WhenDeleteTop_ThenDeleteLargestElement()
                {
                    Assert.AreEqual(3, pq.DeleteTop());
                    Assert.AreEqual(2, pq.Size());
                }

                [Test]
                public void WhenPeekTop_ThenDeleteLargestElement()
                {
                    Assert.AreEqual(3, pq.PeekTop());
                    Assert.AreEqual(3, pq.Size());
                }
            }
        }

        public class BinaryHeapMinPQTests : PriorityQueueTest
        {
            [SetUp]
            public void GivenANewEmptyBinaryHeapMinPQ()
            {
                pq = new BinaryHeapMinPQ<int>();
            }

            [TestFixture]
            public class EmptyBinaryHeapMinPQExceptions : BinaryHeapMinPQTests
            {
                [Test]
                public void WhenDeleteTop_ThenThrowHeapUnderflowException()
                {
                    Assert.Throws<BinaryHeapPriorityQueue<int>.HeapUnderflowException>(() => pq.DeleteTop());
                }

                [Test]
                public void WhenPeekTop_ThenThrowHeapUnderflowException()
                {
                    Assert.Throws<BinaryHeapPriorityQueue<int>.HeapUnderflowException>(() => pq.PeekTop());
                }
            }

            [TestFixture]
            public class BinaryHeapMinPQWithElementsOperations : BinaryHeapMinPQTests
            {
                [SetUp]
                public void GivenABinaryHeapMinPqWithElements()
                {
                    pq.Insert(1);
                    pq.Insert(3);
                    pq.Insert(2);
                }

                [Test]
                public void WhenDeleteTop_ThenDeleteSmallestElement()
                {
                    Assert.AreEqual(1, pq.DeleteTop());
                    Assert.AreEqual(2, pq.Size());
                }

                [Test]
                public void WhenPeek_ThenReturnSmallestElement()
                {
                    Assert.AreEqual(1, pq.PeekTop());
                    Assert.AreEqual(3, pq.Size());
                }
            }
        }
    }
}
