using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HackerRank
{
    [TestFixture]
    public class Kangaroo
    {
        [Test]
        public void CanKangaroosMeet()
        {
            Assert.AreEqual("YES", CanKangaroosMeet2(0, 0, 0, 0), "1");
            Assert.AreEqual("YES", CanKangaroosMeet2(0, 1, 0, 1), "2");
            Assert.AreEqual("NO", CanKangaroosMeet2(0, 2, 0, 1), "3");
            Assert.AreEqual("NO", CanKangaroosMeet2(0, 1, 0, 2), "4");
            Assert.AreEqual("NO", CanKangaroosMeet2(0, 1, 1, 1), "5");
            Assert.AreEqual("NO", CanKangaroosMeet2(1, 1, 0, 1), "6");
            Assert.AreEqual("YES", CanKangaroosMeet2(1, 3, 2, 2), "7");
            Assert.AreEqual("NO", CanKangaroosMeet2(0, 2, 5, 3), "8");
            Assert.AreEqual("YES", CanKangaroosMeet2(0, 2, 5, 1), "9");
            Assert.AreEqual("YES", CanKangaroosMeet2(0, 3, 4, 2), "10");
            Assert.AreEqual("NO", CanKangaroosMeet2(8, 2, 4, 5), "11");
        }

        public string CanKangaroosMeet2(int x1, int v1, int x2, int v2)
        {
            if (x2 == x1 && v2 == v1)
                return "YES";

            if (v2 == v1)
                return "NO";

            if (((x2 - x1)/(v1-v2) > 0) && ((x2 - x1) % (v1 - v2) == 0))
                return "YES";
            else
                return "NO";
        }

        public string CanKangaroosMeet(int x1, int v1, int x2, int v2)
        {
            if (x2 == x1 && v2 == v1)
                return "YES";

            if (x2 != x1 && v2 == v1)
                return "NO";

            if (x1 == x2 && v1 != v2)
                return "NO";

            if (x2 > x1 && v2 > v1)
                return "NO";

            return resultAfterJumpSimulations(x1, v1, x2, v2);
        }

        private string resultAfterJumpSimulations(int x1, int v1, int x2, int v2)
        {
            string result = "NO";

            if (x2 < x1)
                result = simulateJumps(x1, v1, x2, v2);

            if (x1 < x2)
                result = simulateJumps(x2, v2, x1, v1);

            return result;
        }

        private string simulateJumps(int a1, int b1, int a2, int b2)
        {
            while (a2 < a1)
            {
                a2 += b2;
                a1 += b1;
                if (a2 == a1)
                    return "YES";
            }

            return "NO";
        }
    }
}
