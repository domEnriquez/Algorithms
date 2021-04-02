using NUnit.Framework;

namespace HackerRank
{
    [TestFixture]
    public class RepeatedString
    {
        private void assertCountOfA(string s, long n, long expected, string comment)
        {
            Assert.AreEqual(expected, repeatedString(s, n), comment);
        }

        [Test]
        public void canReturnHowManyAs()
        {
            assertCountOfA(null, 0, -1, "1");
            assertCountOfA("", 0, 0, "2");
            assertCountOfA("a", 0, 0, "3");
            assertCountOfA("b", 1, 0, "4");
            assertCountOfA("a", 1, 1, "5");
            assertCountOfA("aa", 1, 1, "6");
            assertCountOfA("aa", 2, 2, "7");
            assertCountOfA("a", 2, 2, "8");
            assertCountOfA("aba", 10, 7, "9");
            assertCountOfA("a", 1000000000000, 1000000000000, "10");
            assertCountOfA("kmretasscityylpdhuwjirnqimlkcgxubxmsxpypgzxtenweirknjtasxtvxemtwxuarabssvqdnktqadhyktagjxoanknhgilnm",
                736778906400,
                51574523448,
                "11");
        }


        private long repeatedString(string s, long n)
        {
            if (s == null)
                return -1;

            if (s == string.Empty || n == 0 || !s.Contains("a"))
                return 0;

            if (s.Length == 1)
                return n;

            int stringSize = s.Length;

            return countA(s, stringSize) * (n / stringSize) 
                + countA(s, n % stringSize);

        }

        private static long countA(string s, long upTo)
        {
            int count = 0;

            for (int i = 0; i < upTo; i++)
            {
                if (s[i] == 'a')
                    count++;
            }

            return count;
        }
    }
}
