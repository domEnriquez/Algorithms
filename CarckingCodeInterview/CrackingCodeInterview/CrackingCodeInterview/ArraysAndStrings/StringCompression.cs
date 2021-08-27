using NUnit.Framework;
using System;
using System.Text;

namespace CrackingCodeInterview
{
    [TestFixture]
    public class StringCompression
    {
        [Test]
        public void canCompressString()
        {
            Assert.That(() => compress_Own(null), Throws.TypeOf<ArgumentNullException>(), "1");
            Assert.That(compress_Own(""), Is.EqualTo(string.Empty), "2");
            Assert.That(compress_Own("a"), Is.EqualTo("a"), "3");
            Assert.That(compress_Own("aaa"), Is.EqualTo("a3"), "4");
            Assert.That(compress_Own("aaabb"), Is.EqualTo("a3b2"), "5");
            Assert.That(compress_Own("aabcccccaaa"), Is.EqualTo("a2b1c5a3"), "6");
            Assert.That(compress_Own("aaaAAA"), Is.EqualTo("a3A3"), "6");
            Assert.That(compress_Own("abc"), Is.EqualTo("abc"), "6");
        }

        private string compress_Own(string s)
        {
            if (s == null)
                throw new ArgumentNullException();

            if (s == string.Empty)
                return s;

            StringBuilder compressed = new StringBuilder();
            int count = 0;

            for (int i = 0; i < s.Length; i++)
            {
                count++;

                if (i == s.Length - 1 || s[i] != s[i + 1])
                {
                    compressed.Append(s[i]);
                    compressed.Append(count.ToString());
                    count = 0;
                }
            }

            if (compressed.Length < s.Length)
                return compressed.ToString();
            else
                return s;
        }

        private string compress(string str)
        {
            int finallength = countCompression(str);
            if (finallength >= str.Length) return str;

            StringBuilder compressed = new StringBuilder(finallength);
            int count = 0;

            for (int i = 0; i < str.Length; i++)
            {
                count++;

                if (i == str.Length - 1 || str[i] != str[i + 1])
                {
                    compressed.Append(str[i]);
                    compressed.Append(count.ToString());
                    count = 0;
                }
            }

            return compressed.ToString();
        }

        int countCompression(string str)
        {
            int compressedlength = 0;
            int countConsecutive = 0;

            for (int i = 0; i < str.Length; i++)
            {
                countConsecutive++;

                /* If next character is different than current, increase the length.*/
                if (i + 1 >= str.Length || str[i] != str[i + 1])
                {
                    compressedlength += 1 + countConsecutive.ToString().Length;
                    countConsecutive = 0;
                }
            }

            return compressedlength;
        }
    }
}
