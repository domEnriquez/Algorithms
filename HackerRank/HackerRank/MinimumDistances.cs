using NUnit.Framework;
using System;

namespace HackerRank
{
    [TestFixture]
    public class MinimumDistances
    {
        private int[] array(params int[] n)
        {
            return n;
        }

        [Test]
        [TestCase(null, ExpectedResult = -1)]
        [TestCase(new int[] { }, ExpectedResult = -1)]
        [TestCase(new int[] { 1 }, ExpectedResult = -1)]
        [TestCase(new int[] { 1, 2 }, ExpectedResult = -1)]
        [TestCase(new int[] { 1, 1 }, ExpectedResult = 1)]
        [TestCase(new int[] { 1, 2 , 1}, ExpectedResult = 2)]
        [TestCase(new int[] { 7, 1, 3, 4, 1, 7}, ExpectedResult = 3)]
        public int canDetermineMinDistance(int[] input)
        {
            return minimumDistances(input);

        }

        private int minimumDistances(int[] a)
        {
            if(a == null)
                return -1;

            int size = a.Length;

            if (size == 0 || size == 1)
                return -1;

            int minDistance = Int32.MaxValue;
            bool found = false;

            for(int i = 0; i < size - 1; i++)
            {
                for(int j = i+1; j < size; j++)
                {
                    if (a[i] == a[j] && Math.Abs(j - i) < minDistance)
                    {
                        found = true;
                        minDistance = j - i;
                    }
                }
            }

            if (!found)
                return -1;
            else
                return minDistance;
        }
    }
}
