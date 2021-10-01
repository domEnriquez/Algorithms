using NUnit.Framework;
using System.Linq;

namespace CrackingCodeInterview.RecursionAndDynamicProgramming
{
    public class TripleStep
    {
        public int CountWays(int n)
        {
            if (n < 0)
                return 0;
            else if (n == 0)
                return 1;
            else
                return CountWays(n - 1) + CountWays(n - 2) + CountWays(n - 3);

        }

        public int CountWaysWithMemoization(int n)
        {
            int[] memo = Enumerable.Repeat(-1, n + 1).ToArray();
            return countWaysWithMemoization(n, memo);
        }

        private int countWaysWithMemoization(int n, int[] memo)
        {
            if (n < 0)
                return 0;
            else if (n == 0)
                return 1;
            else if (memo[n] > -1)
                return memo[n];
            else
            {
                memo[n] = countWaysWithMemoization(n - 1, memo) 
                    + countWaysWithMemoization(n - 2, memo) 
                    + countWaysWithMemoization(n - 3, memo);

                return memo[n];
            }
        }
    }

    [TestFixture]
    public class TripleStepTests
    {
        [Test]
        public void canCountNumberOfWaysToClimbStairs()
        {
            TripleStep tripleStep = new TripleStep();

            Assert.That(tripleStep.CountWays(1), Is.EqualTo(1));
            Assert.That(tripleStep.CountWays(2), Is.EqualTo(2));
            Assert.That(tripleStep.CountWays(3), Is.EqualTo(4));
        }
    }
}
