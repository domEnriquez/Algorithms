using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HackerRank
{
    [TestFixture]
    public class GradingStudents
    {
        private const int BOUNDARY_GRADE = 38;

        private void assertRoundUp(int Actual, int Expected)
        {
            Assert.AreEqual(Expected, round(Actual));
        }

        [Test]
        public void GivenGrades_WhenTriedToRoundUp_ThenRoundUpAccordingToRules()
        {
            assertRoundUp(0, 0);
            assertRoundUp(1, 1);
            assertRoundUp(35, 35);
            assertRoundUp(BOUNDARY_GRADE, 40);
            assertRoundUp(39, 40);
            assertRoundUp(41, 41);
            assertRoundUp(43, 45);
            assertRoundUp(73, 75);
            assertRoundUp(67, 67);
        }



        private int round(int num)
        {
            if (num >= BOUNDARY_GRADE)
            {
                int remainder = num % 5;

                if (remainder == 3 || remainder == 4)
                    return num / 5 * 5 + 5;
                else
                    return num;
            }

            return num;
        }
    }
}
