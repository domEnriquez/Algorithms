using NUnit.Framework;

namespace HackerRank
{
    [TestFixture]
    public class HalloweenSale
    {
        [Test]
        public void canCountGames()
        {
            Assert.That(howManyGames(2, 1, 1, 1), Is.EqualTo(0));
            Assert.That(howManyGames(2, 1, 1, 2), Is.EqualTo(1));
            Assert.That(howManyGames(2, 1, 1, 3), Is.EqualTo(2));
            Assert.That(howManyGames(2, 1, 1, 4), Is.EqualTo(3));
            Assert.That(howManyGames(20, 3, 6, 70), Is.EqualTo(5));
            Assert.That(howManyGames(20, 3, 6, 80), Is.EqualTo(6));
            Assert.That(howManyGames(20, 3, 6, 85), Is.EqualTo(7));
            Assert.That(howManyGames(1, 100, 1, 9777), Is.EqualTo(9777));

        }

        private int howManyGames(int p, int d, int m, int s)
        {
            if(s < p)
                return 0;

            int gamesCount = 1;
            int currentCost = p - d;

            if (currentCost < m)
                currentCost = m;

            int totalCost = p + currentCost;
            
            while (totalCost <= s)
            {
                if (currentCost > m)
                    currentCost -= d;

                if (currentCost < m)
                    currentCost = m;

                gamesCount++;
                totalCost += currentCost;
            }

            return gamesCount;
        }
    }
}
