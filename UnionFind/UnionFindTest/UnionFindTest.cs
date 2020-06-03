using NUnit.Framework;
using UnionFindApp;

namespace UnionFindTest
{
    [TestFixture]
    public class UnionFindTest
    {
        UnionFind qf;

        [SetUp]
        public void SetUp()
        {
            qf = new QuickUnion(10);
        }

        [Test]
        public void WhenTwoSameNumbers_IsConnectedReturnsTrue()
        {
            assertIsConnected(0, 0);
        }

        [Test]
        public void WhenTwoDifferentNumbers_IsConnectedReturnsFalse()
        {
            assertNotConnected(0, 1);
        }

        [Test]
        public void GivenInputExceedsLimit_WhenUnion_ThenThrowNumberExceedsLimitException()
        {
            Assert.Throws<UnionFind.NumberExceedsLimitException>(() => qf.Union(11, 0));
            Assert.Throws<UnionFind.NumberExceedsLimitException>(() => qf.Union(0, 11));
        }

        [Test]
        public void GivenInputExceedsLimit_WhenConnected_ThenThrowNumberExceedsLimitException()
        {
            Assert.Throws<UnionFind.NumberExceedsLimitException>(() => qf.Connected(11, 0));
            Assert.Throws<UnionFind.NumberExceedsLimitException>(() => qf.Connected(0, 11));
        }

        [Test]
        public void WhenUnionTwoDifferentNumbers_ThenTheyAreConnected()
        {
            qf.Union(0, 1);
            qf.Union(2, 3);

            assertIsConnected(0, 1);
            assertIsConnected(2, 3);
            assertNotConnected(0, 2);
        }

        [Test]
        public void UnionTransitivity()
        {
            qf.Union(0, 1);
            qf.Union(0, 2);

            assertIsConnected(1, 2);
        }

        [Test]
        public void IntegrationTest()
        {
            qf.Union(4, 3);
            qf.Union(3, 8);
            qf.Union(6, 5);

            assertIsConnected(4, 8);
            assertNotConnected(6, 3);

            qf.Union(9, 4);
            qf.Union(2, 1);

            assertIsConnected(8, 9);
            assertNotConnected(5, 4);

            qf.Union(5, 0);
            qf.Union(7, 2);

            assertIsConnected(7, 1);
            assertNotConnected(7, 0);

            qf.Union(6, 1);
            qf.Union(7, 3);

            assertIsConnected(7, 0);
            assertIsConnected(4, 5);
            assertIsConnected(6, 3);
        }

        private void assertIsConnected(int num1, int num2)
        {
            Assert.IsTrue(qf.Connected(num1, num2));
        }

        private void assertNotConnected(int num1, int num2)
        {
            Assert.IsFalse(qf.Connected(num1, num2));
        }

    }
}
