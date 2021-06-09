using NUnit.Framework;
using System.Collections.Generic;

namespace HackerRank
{
    [TestFixture]
    public class FairRations
    {

        [Test]
        public void canFindMinLoafDistributions()
        {
            Assert.That(fairRations(null), Is.EqualTo("NO"), "1");
            Assert.That(fairRations(new List<int>() { }), Is.EqualTo("NO"), "2");
            Assert.That(fairRations(new List<int>() { 2 }), Is.EqualTo("0"), "3");
            Assert.That(fairRations(new List<int>() { 1 }), Is.EqualTo("1"), "4");
            Assert.That(fairRations(new List<int>() { 2, 2 }), Is.EqualTo("0"), "5");
            Assert.That(fairRations(new List<int>() { 1, 1 }), Is.EqualTo("2"), "6");
            Assert.That(fairRations(new List<int>() { 1, 2 }), Is.EqualTo("NO"), "7");
            Assert.That(fairRations(new List<int>() { 1, 2, 3 }), Is.EqualTo("4"), "8");
            Assert.That(fairRations(new List<int>() { 2, 3, 4, 5, 6 }), Is.EqualTo("4"), "9");
        }


        private string fairRations(List<int> B)
        {
            if (B == null || B.Count == 0)
                return "NO";

            int size = B.Count;

            if(size == 1)
            {
                if (B[0] % 2 == 0)
                    return "0";
                else
                    return "1";
            }

            int minCount = 0;

            for(int i = 0; i < size - 1; i++)
            {
                if(B[i] % 2 != 0)
                {
                    B[i + 1]++;
                    minCount += 2;
                }
            }

            if (B[size - 1] % 2 == 0)
                return minCount.ToString();
            else
                return "NO";

        }
    }
}
