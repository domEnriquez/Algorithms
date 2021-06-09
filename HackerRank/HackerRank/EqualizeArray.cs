using NUnit.Framework;

namespace HackerRank
{
    [TestFixture]
    public class EqualizeArray
    {
        private int[] array(params int[] n)
        {
            return n;
        }

        private void assertEqualizeArray(int[] arr, int expected, string message)
        {
            Assert.That(equalizeArray(arr), Is.EqualTo(expected), message);
        }

        [Test]
        public void canEqualizeArray()
        {
            assertEqualizeArray(null, 0, "1");
            assertEqualizeArray(array(), 0, "2");
            assertEqualizeArray(array(1), 0, "3");
            assertEqualizeArray(array(1, 1), 0, "4");
            assertEqualizeArray(array(1, 2), 1, "5");
            assertEqualizeArray(array(1, 2, 2), 1, "6");
            assertEqualizeArray(array(1, 2, 2), 1, "7");
            assertEqualizeArray(array(2, 2, 1), 1, "8");
            assertEqualizeArray(array(1, 2, 2, 3), 2, "9");
            assertEqualizeArray(array(3, 3, 2, 1, 3), 2, "10");
        }

        private int equalizeArray(int[] arr)
        {
            if(arr == null || arr.Length == 1)
                return 0;

            int noOfLargeSame = 0;
            int arrLength = arr.Length;

            for(int i = 0; i < arrLength - 1; i++)
            {
                int noOfSame = 1;

                for (int j = i+1; j < arrLength; j++)
                {
                    if (arr[i] == arr[j])
                        noOfSame++;
                }

                if (noOfSame > noOfLargeSame)
                    noOfLargeSame = noOfSame;
            }

            return arrLength - noOfLargeSame;
        }

    }
}
