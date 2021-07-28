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
            Assert.That(stones(3, 10, 100), Is.EqualTo(new List<int> { 30, 120, 210, 300 }));

        }

        private List<int> stones(int n, int a, int b)
        {
            if(n == 1)
                return new List<int> { a, b };

            List<int> lastNums = new List<int>();


            int firstSum = a + a;
            int secSum = a + b;
            int thirdSum = b + b;

            if(n == 2)
            {
                lastNums.Add(firstSum);
                lastNums.Add(secSum);
                lastNums.Add(thirdSum);

                return lastNums;
            }

            int temp1 = firstSum;
            int temp2 = secSum;
            int temp3 = thirdSum;
            int temp4 = firstSum;
            int temp5 = secSum;
            int temp6 = thirdSum;


            for (int j = 3; j <= n; j++)
            {
                temp1 += a;
                temp2 += a;
                temp3 += a;
                temp4 += b;
                temp5 += b;
                temp6 += b;
            }

            if (!lastNums.Contains(temp1)) lastNums.Add(temp1);
            if (!lastNums.Contains(temp2)) lastNums.Add(temp2);
            if (!lastNums.Contains(temp3)) lastNums.Add(temp3);
            if (!lastNums.Contains(temp4)) lastNums.Add(temp4);
            if (!lastNums.Contains(temp5)) lastNums.Add(temp5);
            if (!lastNums.Contains(temp6)) lastNums.Add(temp6);

            return lastNums;

        }
    }
}
