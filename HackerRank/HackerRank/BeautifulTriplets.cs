using NUnit.Framework;

namespace HackerRank
{
    [TestFixture]
    public class BeautifulTriplets
    {
        private int[] array(params int[] n)
        {
            return n;
        }

        [Test]
        public void canFindBeautifulTriplets()
        {
            Assert.That(beautifulTriplets(0, null), Is.EqualTo(0), "1");
            Assert.That(beautifulTriplets(0, array()), Is.EqualTo(0), "2");
            Assert.That(beautifulTriplets(0, array(1)), Is.EqualTo(0), "3");
            Assert.That(beautifulTriplets(1, array(1, 2, 3)), Is.EqualTo(1), "4");
            Assert.That(beautifulTriplets(1, array(1, 3, 2)), Is.EqualTo(0), "5");
            Assert.That(beautifulTriplets(1, array(1, 2, 3, 4)), Is.EqualTo(2), "6");
            Assert.That(beautifulTriplets(3, array(1, 2, 4, 5, 7, 8, 10)), Is.EqualTo(3), "7");
        }

        private int beautifulTriplets(int d, int[] arr)
        {
            if (arr == null || arr.Length < 3)
                return 0;

            int numOfTriplets = 0;

            for(int firstInTriplet = 0; firstInTriplet < arr.Length - 2; firstInTriplet++)
            {
                for (int secInTriplet = firstInTriplet+1; secInTriplet < arr.Length - 1; secInTriplet++)
                {
                    if (arr[secInTriplet] - arr[firstInTriplet] == d)
                    {
                        for (int thirdInTriplet = secInTriplet + 1; thirdInTriplet < arr.Length; thirdInTriplet++)
                        {
                            if (arr[thirdInTriplet] - arr[secInTriplet] == d)
                            {
                                numOfTriplets++;
                            }
                        }
                    }
                }

            }

            return numOfTriplets;
        }
    }
}
