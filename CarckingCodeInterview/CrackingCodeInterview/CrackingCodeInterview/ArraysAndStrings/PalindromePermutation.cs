using NUnit.Framework;
using System.Collections.Generic;

namespace CrackingCodeInterview
{
    [TestFixture]
    public class PalindromePermutation
    {
        [Test]
        public void IsPalindoromeTest()
        {
            Assert.That(isPalindrome("a"), Is.True);
            Assert.That(isPalindrome("aba"), Is.True);
            Assert.That(isPalindrome("aab"), Is.True);
            Assert.That(isPalindrome("baa"), Is.True);
            Assert.That(isPalindrome("aabb"), Is.True);
            Assert.That(isPalindrome("baab"), Is.True);
            Assert.That(isPalindrome("baabc"), Is.True);
            Assert.That(isPalindrome("baadc"), Is.False);
            Assert.That(isPalindrome("aabbb"), Is.True);
            Assert.That(isPalindrome("tactcoa"), Is.True);
            Assert.That(isPalindrome("aaaa"), Is.True);
        }

        public bool isPalindrome(string s)
        {
            if (string.IsNullOrEmpty(s))
                return false;

            Dictionary<char, int> charFreqDict = new Dictionary<char, int>();

            for(int i = 0; i < s.Length; i++)
            {
                if (charFreqDict.ContainsKey(s[i]))
                    charFreqDict[s[i]] = ++charFreqDict[s[i]];
                else
                    charFreqDict[s[i]] = 1;
            }

            bool foundOdd = false;
            foreach(KeyValuePair<char, int> el in charFreqDict)
            {
                if (el.Value % 2 != 0)
                {
                    if (foundOdd)
                        return false;

                    foundOdd = true;
                }
            }

            return true;   
        }
        
    }
}
