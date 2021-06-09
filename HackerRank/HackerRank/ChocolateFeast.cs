using NUnit.Framework;

namespace HackerRank
{
    [TestFixture]
    public class ChocolateFeast
    {
        [Test]
        public void canReturnNoOfChocolatesEaten()
        {
            Assert.That(chocolateFeast(0, 1, 1), Is.EqualTo(0), "1");
            Assert.That(chocolateFeast(1, 2, 1), Is.EqualTo(0), "2");
            Assert.That(chocolateFeast(2, 1, 2), Is.EqualTo(3), "3");
            Assert.That(chocolateFeast(3, 1, 2), Is.EqualTo(5), "4");
            Assert.That(chocolateFeast(3, 2, 2), Is.EqualTo(1), "5");
            Assert.That(chocolateFeast(6, 2, 2), Is.EqualTo(5), "6");
            Assert.That(chocolateFeast(15, 3, 2), Is.EqualTo(9), "7");

        }

        private int chocolateFeast(int n, int c, int m)
        {
            if(n == 0 || n < c)
                return 0;

            
            int ateBars = n / c;
            int wrappers = ateBars;

            while(wrappers >= m)
            {
                ateBars = ateBars + (wrappers / m);
                wrappers = (wrappers % m) + (wrappers / m);
            }


            return ateBars;
        }
    }
}
