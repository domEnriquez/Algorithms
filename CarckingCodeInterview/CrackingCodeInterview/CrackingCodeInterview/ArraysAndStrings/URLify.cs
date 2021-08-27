using NUnit.Framework;

namespace CrackingCodeInterview
{
    [TestFixture]
    public class URLify
    {
        [Test]
        public void canURLify()
        {
            Assert.That(Urlify(null), Is.EqualTo(null));
            Assert.That(Urlify(""), Is.EqualTo(null));
            Assert.That(Urlify("s"), Is.EqualTo("s"));
            Assert.That(Urlify("s s"), Is.EqualTo("s%20s"));
            Assert.That(Urlify("s s s"), Is.EqualTo("s%20s%20s"));
            Assert.That(Urlify("   s  s   s  "), Is.EqualTo("s%20s%20s"));
            Assert.That(Urlify("Mr John Smith   "), Is.EqualTo("Mr%20John%20Smith"));

        }

        private string Urlify(string s)
        {
            if(string.IsNullOrEmpty(s))
                return null;

            s = s.Trim();

            for (int i = 0; i < s.Length; i++)
                if(s[i] == ' ')
                    s = s.Substring(0, i).Trim() + "%20" + s.Substring(i + 1).Trim();

            return s;
        }
    }
}
