using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HackerRank
{
    [TestFixture]
    public class BetweenTwoSets
    {
        [Test]
        public void determineIntegersBetweenTwoSets()
        {
            assertBetweenTwoSets(arr(1), arr(1), arr(1));
            assertBetweenTwoSets(arr(1), arr(2), arr(1, 2));
            assertBetweenTwoSets(arr(2), arr(4), arr(2, 4));
            assertBetweenTwoSets(arr(2), arr(1), arr());
            assertBetweenTwoSets(arr(1, 2), arr(2, 4), arr(2));
            assertBetweenTwoSets(arr(2, 4), arr(16, 32, 96), arr(4, 8, 16));
            assertBetweenTwoSets(arr(3, 6, 9), arr(30, 60, 90), arr());
            assertBetweenTwoSets(arr(2, 4, 6), arr(24, 60, 120), arr(12));
            assertBetweenTwoSets(arr(100, 99, 98, 97, 96, 95, 94, 93, 92, 91), arr(1, 2, 3, 4, 5, 6, 7, 8, 9, 10), arr());
        }

        private void assertBetweenTwoSets(int[] a, int[] b, int[] expected)
        {
            Assert.AreEqual(expected, getNumBetween(a, b));
        }

        private int[] getNumBetween(int[] a, int[] b)
        {
            List<int> nums = new List<int>();
            int lcmA = getLcm(a);
            int limit = getLeastNum(b);
            int numA = lcmA;

            while(numA <= limit)
            {
                if (factorOfArrayElems(numA, b))
                    nums.Add(numA);

                numA += lcmA;
            }

            return nums.ToArray();
        }

        private bool factorOfArrayElems(int numA, int[] b)
        {
            for (int i = 0; i < b.Length; i++)
                if (b[i] % numA != 0)
                    return false;

            return true;
        }

        private int getLcm(int[] a)
        {
            int leastNum = getLeastNum(a);
            int largestNum = getLargestNum(a);
            int num = leastNum;
            int i = 2;

            while (!isLcm(num, a) && i <= largestNum)
                num = leastNum * i++;
            
            return num;
        }

        private int getLargestNum(int[] a)
        {
            int largestNum = a[0];

            for (int i = 1; i < a.Length; i++)
                if (a[i] > largestNum)
                    largestNum = a[i];

            return largestNum;
        }

        private bool isLcm(int num, int[] a)
        {
            for (int i = 0; i < a.Length; i++)
                if (num < a[i] || num % a[i] != 0)
                    return false;

            return true;
        }

        private int getLeastNum(int[] a)
        {
            int leastNum = a[0];

            for (int i = 1; i < a.Length; i++)
                if (a[i] < leastNum)
                    leastNum = a[i];

            return leastNum;
        }

        private int[] arr(params int[] nums)
        {
            return nums;
        }
    }
}
