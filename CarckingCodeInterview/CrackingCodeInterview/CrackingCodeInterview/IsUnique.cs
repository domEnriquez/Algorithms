using NUnit.Framework;

namespace CrackingCodeInterview
{
    [TestFixture]
    public class IsUnique
    {
        [Test]
        public void nothing()
        {
            Assert.That(isUniqueChars("abcd"), Is.True);
            Assert.That(isUniqueChars("abcda"), Is.False);
        }

        bool isUniqueChars(string s)
        {
            if (s.Length > 128)
                return false;

            bool[] chars = new bool[128];

            for(int i = 0; i < s.Length; i++)
            {
                int c = s[i];
                
                if (chars[c])
                    return false;

                chars[c] = true;
            }

            return true;
        }
    }
}
