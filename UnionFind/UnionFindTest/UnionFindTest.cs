using NUnit.Framework;
using UnionFindApp;

namespace UnionFindTest
{
    [TestFixture]
    public class UnionFindTest
    {
        UnionFind uf;

        [SetUp]
        public void SetUp()
        {
            uf = new UnionFind(10);
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
            Assert.Throws<UnionFind.NumberExceedsLimitException>(() => uf.Union(11, 0));
            Assert.Throws<UnionFind.NumberExceedsLimitException>(() => uf.Union(0, 11));
        }

        [Test]
        public void GivenInputExceedsLimit_WhenConnected_ThenThrowNumberExceedsLimitException()
        {
            Assert.Throws<UnionFind.NumberExceedsLimitException>(() => uf.Connected(11, 0));
            Assert.Throws<UnionFind.NumberExceedsLimitException>(() => uf.Connected(0, 11));
        }

        [Test]
        public void WhenUnionTwoDifferentNumbers_ThenTheyAreConnected()
        {
            uf.Union(0, 1);
            uf.Union(2, 3);

            assertIsConnected(0, 1);
            assertIsConnected(2, 3);
            assertNotConnected(0, 2);
        }

        [Test]
        public void UnionTransitivity()
        {
            uf.Union(0, 1);
            uf.Union(0, 2);

            assertIsConnected(1, 2);
        }

        [Test]
        public void IntegrationTest()
        {
            uf.Union(4, 3);
            uf.Union(3, 8);
            uf.Union(6, 5);
            uf.Union(9, 4);
            uf.Union(2, 1);

            assertIsConnected(8, 9);
            assertNotConnected(0, 5);

            uf.Union(0, 5);
            uf.Union(2, 7);
            uf.Union(6, 1);

            assertIsConnected(0, 5);
            assertIsConnected(3, 4);
            assertNotConnected(4, 5);
        }

        private void assertIsConnected(int num1, int num2)
        {
            Assert.IsTrue(uf.Connected(num1, num2));
        }

        private void assertNotConnected(int num1, int num2)
        {
            Assert.IsFalse(uf.Connected(num1, num2));
        }

    }
}
