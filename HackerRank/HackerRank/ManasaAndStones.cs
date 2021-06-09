using NUnit.Framework;
using System.Collections.Generic;

namespace HackerRank
{
    [TestFixture]
    public class ManasaAndStones
    {
        [Test]
        public void canDetermineLastStones()
        {
            Assert.That(stones(1, 1, 2), Is.EqualTo(new List<int> { 1, 2 }));
            Assert.That(stones(1, 2, 3), Is.EqualTo(new List<int> { 2, 3 }));
            Assert.That(stones(2, 2, 3), Is.EqualTo(new List<int> { 4, 5, 6 }));
            Assert.That(stones(2, 1, 2), Is.EqualTo(new List<int> { 2, 3, 4 }));

        }

        private List<int> stones(int n, int a, int b)
        {
            if(n == 1)
                return new List<int> { a, b };

            List<int> lastNums = new List<int>();


            int firstSum = a + a;
            int secSum = a + b;
            int thirdSum = b + b;


            lastNums.Add(firstSum);
            lastNums.Add(secSum);
            lastNums.Add(thirdSum);

            return lastNums;
        }
    }
}
