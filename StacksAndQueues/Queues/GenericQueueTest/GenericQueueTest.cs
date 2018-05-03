using GenericQueue;
using NUnit.Framework;
using System.Collections.Generic;

namespace GenericQueueTest
{
    [TestFixture]
    public class GenericQueueTest
    {
        private List<AbstractQueue<int>> queues;

        [SetUp]
        public void GivenAListOfQueueTypes()
        {
            queues = new List<AbstractQueue<int>>() { /*new LinkedQueue<int>(), new ResizingArrayQueue<int>(),*/ new QueueViaTwoStacks<int>() };
        }

        [Test]
        public void whenEnqueueOne_thenIncreaseQueueSize()
        {
            foreach (AbstractQueue<int> queue in queues)
            {
                queue.Enqueue(1);
                Assert.IsFalse(queue.IsEmpty());
                Assert.AreEqual(1, queue.Size());
            }
        }

        [Test]
        public void whenEnquequeOneDequeueOne_thenDecreaseQueueSize()
        {
            foreach (AbstractQueue<int> queue in queues)
            {
                queue.Enqueue(1);
                queue.Dequeue();
                Assert.IsTrue(queue.IsEmpty());
            }
        }

        [Test]
        public void whenEnqueueOne_thenReturnOneWhenDequeue()
        {
            foreach(AbstractQueue<int> queue in queues)
            {
                queue.Enqueue(1);
                Assert.AreEqual(1, queue.Dequeue());
            }
        }

        [Test]
        public void whenEqueueOneEnqueueTwo_theReturnOneWhenDequeue()
        {
            foreach(AbstractQueue<int> queue in queues)
            {
                queue.Enqueue(1);
                queue.Enqueue(2);
                Assert.AreEqual(1, queue.Dequeue());
                Assert.AreEqual(1, queue.Size());
            }
        }

        [Test]
        public void enqueueDequeueCombination()
        {
            foreach (AbstractQueue<int> queue in queues)
            {
                queue.Enqueue(1);
                Assert.AreEqual(1, queue.Dequeue());
                queue.Enqueue(2);
                queue.Enqueue(3);
                Assert.AreEqual(2, queue.Dequeue());
                queue.Enqueue(4);
                Assert.AreEqual(2, queue.Size());
            }
        }

        [Test]
        public void enqueue20Items_dequeue15Items()
        {
            foreach (AbstractQueue<int> queue in queues)
            {
                for (int i = 0; i < 20; i++)
                    queue.Enqueue(i);

                Assert.AreEqual(20, queue.Size());

                for (int i = 0; i < 15; i++)
                {
                    Assert.AreEqual(i, queue.Dequeue());
                }

                Assert.AreEqual(5, queue.Size());
            }

        }

        [Test]
        public void whenDequeueOfEmptyQueue_thenThrowQueueUnderflowException()
        {
            foreach (AbstractQueue<int> queue in queues)
                Assert.Throws<AbstractQueue<int>.QueueUnderFlowException>(() => queue.Dequeue());
        }
    }
}
