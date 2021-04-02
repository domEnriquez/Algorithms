using NUnit.Framework;

namespace HackerRank
{
    [TestFixture]
    public class ArrayLeftRotation
    {
        private int[] array(params int[] n)
        {
            return n;
        }

        private void assertRotateLeft(int[] initArray, int numOfRotations, int[] rotatedArray, string comment)
        {
            Assert.AreEqual(rotatedArray, rotLeft(initArray, numOfRotations), comment);
        }

        [Test]
        public void canLeftRotateArray()
        {
            assertRotateLeft(null, 1, null, "1");
            assertRotateLeft(array(0), 0, array(0), "2");
            assertRotateLeft(array(0, 0), 0, array(0, 0), "3");
            assertRotateLeft(array(0, 1), 1, array(1, 0), "4");
            assertRotateLeft(array(0, 1), 2, array(0, 1), "5");
            assertRotateLeft(array(0, 1, 2), 1, array(1, 2, 0), "6");
        }

        private int[] rotLeft(int[] a, int d)
        {
            if(a == null)
                return null;

            if(d == 0)
                return a;

            int size = a.Length;
            int[] rotatedArray = new int[size];

            for(int i = 0; i < size; i++)
                rotatedArray[i] = a[(i + d) % size];

            return rotatedArray;
        }
    }
}
