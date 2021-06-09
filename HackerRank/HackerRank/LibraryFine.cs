using NUnit.Framework;

namespace HackerRank
{
    [TestFixture]
    public class LibraryFine
    {
        [Test]
        public void whenReturnedDateEqualDueDate_ThenNoFine()
        {
            Assert.AreEqual(0, libaryFine(1, 1, 2021, 1, 1, 2021));
        }

        [Test]
        public void whenReturnedDateBeforDueDate_ThenNoFine()
        {
            Assert.AreEqual(0, libaryFine(1, 1, 2021, 1, 2, 2021));
            Assert.AreEqual(0, libaryFine(2, 1, 2021, 1, 2, 2021));
            Assert.AreEqual(0, libaryFine(1, 1, 2020, 1, 1, 2021));
            Assert.AreEqual(0, libaryFine(2, 7, 1014, 1, 1, 1015));
            Assert.AreEqual(0, libaryFine(2, 7, 1014, 1, 7, 1015));
        }

        [Test]
        public void whenReturnedDateAfterDueDate_SameMonthAndSameYear_ThenFineIs15MultipliedByDaysLate()
        {
            Assert.AreEqual(15, libaryFine(3, 1, 2021, 2, 1, 2021));
            Assert.AreEqual(30, libaryFine(4, 1, 2021, 2, 1, 2021));
            Assert.AreEqual(45, libaryFine(5, 1, 2021, 2, 1, 2021));
        }

        [Test]
        public void whenReturnDateAfterDueDate_DifferentMonthSameYear_ThenFineIs500MultipliedByMonthsLate()
        {
            Assert.AreEqual(500, libaryFine(3, 2, 2021, 1, 1, 2021));
            Assert.AreEqual(1000, libaryFine(3, 3, 2021, 1, 1, 2021));
        }

        [Test]
        public void whenReturnDateAfterDueDate_DifferentYear_ThenFineIs10000()
        {
            Assert.AreEqual(10000, libaryFine(1, 1, 2022, 1, 1, 2021));
        }

        private int libaryFine(int d1, int m1, int y1, int d2, int m2, int y2)
        {
            if(y1 > y2)
            {
                return 10000;
            }
            else if(m1 > m2 && y1 == y2)
            {
                return 500 * (m1 - m2);
            }
            else if (d1 > d2 && m1 == m2 && y1 == y2)
            {
                return 15 * (d1 - d2);
            }

            return 0;
        }
    }
}
