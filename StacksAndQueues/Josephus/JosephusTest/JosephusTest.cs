using GenericQueue;
using Josephus;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Josephus.JosephusSolver;

namespace JosephusTest
{
    [TestFixture]
    public class JosephusTest
    {
        JosephusSolver j;

        [SetUp]
        public void Setup()
        {
            j = new JosephusSolver(new LinkedQueue<int>());
        }

        [Test]
        public void canEnumerateEliminatedOnes()
        {
            Assert.AreEqual("0", j.printEliminated(1, 1), "first test");
            Assert.AreEqual("0 1", j.printEliminated(1, 2), "second test");
            Assert.AreEqual("1 0 2", j.printEliminated(2, 3), "third test");
            Assert.AreEqual("1 3 5 0 4 2 6", j.printEliminated(2, 7), "fourth test");
        }
    }
}
