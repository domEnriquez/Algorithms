using NUnit.Framework;

namespace HackerRank
{
    [TestFixture]
    public class MinimumSwaps
    {
        private int[] array(params int[] n)
        {
            return n;
        }

        private void assertMinSwaps(int[] arr, int expected)
        {
            Assert.AreEqual(expected, minimumSwaps(arr));
        }

        [Test]
        public void canReturnMinSwaps()
        {
            assertMinSwaps(null, 0);
            assertMinSwaps(array(), 0);
            assertMinSwaps(array(1), 0);
            assertMinSwaps(array(1, 2), 0);
            assertMinSwaps(array(2, 1), 1);
            assertMinSwaps(array(2, 1, 3), 1);
            assertMinSwaps(array(3, 2, 1), 1);
            assertMinSwaps(array(3, 1, 2), 2);

        }

        private int minimumSwaps(int[] arr)
        {
            if(arr == null)
                return 0;

            int size = arr.Length;

            if (size == 0 || size == 1)
                return 0;

            int swapCount = 0;

            for(int i = 0; i < size; i++)
            {
                if(i+1 != arr[i])
                {
                    int t = i;

                    while(arr[t] != i+1)
                    {
                        t++;
                    }

                    int temp = arr[t];
                    arr[t] = arr[i];
                    arr[i] = temp;

                    swapCount++;
                }
            }

            return swapCount;
        }
    }
}
