using NUnit.Framework;

namespace HackerRank
{
    [TestFixture]
    public class TwoDArray
    {
        [Test]
        public void canFindMaxHourGlassSum()
        {
            Assert.AreEqual(0, hourglassSum(null));
            Assert.AreEqual(1, hourglassSum(new int[][] {
                new int[] { 1, 0, 0, 0, 0, 0 },
                new int[] { 0, 0, 0, 0, 0, 0 },
                new int[] { 0, 0, 0, 0, 0, 0 },
                new int[] { 0, 0, 0, 0, 0, 0 },
                new int[] { 0, 0, 0, 0, 0, 0 },
                new int[] { 0, 0, 0, 0, 0, 0 },
            }), "1");
            Assert.AreEqual(2, hourglassSum(new int[][] {
                new int[] { 1, 1, 0, 0, 0, 0 },
                new int[] { 0, 0, 0, 0, 0, 0 },
                new int[] { 0, 0, 0, 0, 0, 0 },
                new int[] { 0, 0, 0, 0, 0, 0 },
                new int[] { 0, 0, 0, 0, 0, 0 },
                new int[] { 0, 0, 0, 0, 0, 0 },
            }), "2");
            Assert.AreEqual(7, hourglassSum(new int[][] {
                new int[] { 1, 1, 1, 0, 0, 0 },
                new int[] { 0, 1, 0, 0, 0, 0 },
                new int[] { 1, 1, 1, 0, 0, 0 },
                new int[] { 0, 0, 0, 0, 0, 0 },
                new int[] { 0, 0, 0, 0, 0, 0 },
                new int[] { 0, 0, 0, 0, 0, 0 },
            }), "3");
            Assert.AreEqual(7, hourglassSum(new int[][] {
                new int[] { 1, 1, 1, 0, 0, 0 },
                new int[] { 1, 1, 0, 0, 0, 0 },
                new int[] { 1, 1, 1, 0, 0, 0 },
                new int[] { 0, 0, 0, 0, 0, 0 },
                new int[] { 0, 0, 0, 0, 0, 0 },
                new int[] { 0, 0, 0, 0, 0, 0 },
            }), "4");
            Assert.AreEqual(9, hourglassSum(new int[][] {
                new int[] { 1, 1, 1, 5, 0, 0 },
                new int[] { 1, 1, 0, 0, 0, 0 },
                new int[] { 1, 1, 1, 0, 0, 0 },
                new int[] { 0, 0, 0, 0, 0, 0 },
                new int[] { 0, 0, 0, 0, 0, 0 },
                new int[] { 0, 0, 0, 0, 0, 0 },
            }), "5");
            Assert.AreEqual(-6, hourglassSum(new int[][] {
                new int[] { -1, -1, 0, -9, -2, -2 },
                new int[] { -2, -1, -6, -8, -2, -5 },
                new int[] { -1, -1, -1, -2, -3, -4 },
                new int[] { -1, -9, -2, -4, -4, -5 },
                new int[] { -7, -3, -3, -2, -9, -9 },
                new int[] { -1, -3, -1, -2, -4, -5 },
            }), "6");

        }

        private double hourglassSum(int[][] arr)
        {
            if (arr == null)
                return 0;

            int largestSum = -100;

            for(int i = 0; i < arr.Length - 2; i++)
            {
                int sum = 0;

                for (int j = 0; j < arr[i].Length - 2; j++)
                {
                    sum = arr[i][j] + arr[i][j + 1] + arr[i][j + 2]
                        + arr[i + 1][j + 1] 
                        + arr[i + 2][j] + arr[i + 2][j + 1] + arr[i + 2][j + 2];

                    if (sum > largestSum)
                        largestSum = sum;
                }
            }


            return largestSum;
        }
    }
}
