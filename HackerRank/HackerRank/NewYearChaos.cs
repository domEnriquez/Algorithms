using NUnit.Framework;

namespace HackerRank
{
    [TestFixture]
    public class NewYearChaos
    {
        private int[] array(params int[] n)
        {
            return n;
        }

        private void assertMinBribes(int[] q, int expected)
        {
            Assert.AreEqual(expected, minimumBribes(q));
        }

        [Test]
        public void canCountMinBribes()
        {
            assertMinBribes(null, 0);
            assertMinBribes(array(), 0);
            assertMinBribes(array(1), 0);
            assertMinBribes(array(1, 2), 0);
            assertMinBribes(array(2, 1), 1);
            assertMinBribes(array(1, 2, 3), 0);
            assertMinBribes(array(2, 1, 5, 3, 4), 3);
            assertMinBribes(array(2, 5, 1, 3, 4), -1);
            assertMinBribes(array(3, 2, 1), 3);
            assertMinBribes(array(1, 2, 5, 3, 7, 8, 6, 4), 7);
        }

        private int minimumBribes(int[] q)
        {
            if(q == null)
                return 0;

            int size = q.Length;

            if (size == 0 || size == 1)
                return 0;

            int noOfBribes = 0;

            for (int i = 0; i < size; i++)
            {
                if ((q[i] - (i + 1)) > 2)
                    return -1;

                if (i == 0)
                    continue;

                for(int j = i - 1; j >= 0; j--)
                {
                    if (q[j] > q[i])
                        noOfBribes++;                        
                }
            }

            return noOfBribes;
        }
    }
}
