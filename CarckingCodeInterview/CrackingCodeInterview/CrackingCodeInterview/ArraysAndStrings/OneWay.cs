using NUnit.Framework;
using System.Collections.Generic;

namespace CrackingCodeInterview
{
    [TestFixture]
    public class OneWay
    {
        [Test]
        public void oneWayTest()
        {
            Assert.That(isOneWay_OwnSolution("pale", "pale"), Is.True);
            Assert.That(isOneWay_OwnSolution("pale", "pales"), Is.True);
            Assert.That(isOneWay_OwnSolution("pale", "ple"), Is.True);
            Assert.That(isOneWay_OwnSolution("pale", "bale"), Is.True);
            Assert.That(isOneWay_OwnSolution("pale", "bales"), Is.False);
            Assert.That(isOneWay_OwnSolution("aple", "apple"), Is.True);
            Assert.That(isOneWay_OwnSolution("apple", "aple"), Is.True);
        }

        public bool isOneWay_OwnSolution(string s1, string s2)
        {
            string joined = s1 + s2;
            Dictionary<char, int> charFreq = new Dictionary<char, int>();

            for(int i = 0; i < joined.Length; i++)
            {
                if (charFreq.ContainsKey(joined[i]))
                    charFreq[joined[i]] = ++charFreq[joined[i]];
                else
                    charFreq[joined[i]] = 1;
            }

            int count = 0;

            foreach (KeyValuePair<char, int> el in charFreq)
            {
                if (el.Value != 2)
                    count++;

                if (count > 2)
                    return false;
            }

            return true;
        }

        public bool oneEditAway(string first, string second)
        {
            if (first.Length == second.Length)
                return oneEditReplace(first, second);
            else if (first.Length + 1 == second.Length)
                return oneEditInsert(first, second);
            else if (first.Length - 1 == second.Length)
                return oneEditInsert(second, first);

            return false;
        }

        private bool oneEditReplace(string first, string second)
        {
            bool foundDifference = false;

            for (int i = 0; i < first.Length; i++)
            {
                if (first[i] != second[i])
                {
                    if (foundDifference)
                        return false;

                    foundDifference = true;
                }
            }

            return true;
        }

        private bool oneEditInsert(string first, string second)
        {
            int index1 = 0;
            int index2 = 0;

            while (index2 < second.Length && index1 < first.Length)
            {
                if (first[index1] != second[index2])
                {
                    if (index1 != index2)
                    {
                        return false;
                    }

                    index2++;
                }
                else
                {
                    index1++;
                    index2++;
                }
            }
            
            return true;
        }
    }
}
