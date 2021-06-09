using NUnit.Framework;
using System;

namespace HackerRank
{
    [TestFixture]
    public class SherlockAndSquares
    {
        [Test]
        public void canCountSquares()
        {
            Assert.AreEqual(1, squares(1, 1));
            Assert.AreEqual(1, squares(1, 2));
            Assert.AreEqual(2, squares(1, 4));
        }

        private int squares(int a, int b)
        {
            int count = 0;

            for(int i = a; i <= b; i++)
            {
                if (Math.Sqrt(i) % 1 == 0)
                    count++;
            }

            return count;
        }
    }
}
