using BinarySearch;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThreeSum
{
    public class FastThreeSum : AbstractThreeSum
    {
        private BinarySearchAlgorithm bs;

        public FastThreeSum(int[] arr) : base(arr)
        {
            bs = new BinarySearchAlgorithm(arr);
        }

        public override int Count()
        {
            int count = 0;

            sort(NumArray);

            for (int i = 0; i < NumArray.Length; i++)
                for (int j = i + 1; j < NumArray.Length; j++)
                {
                    int index = bs.Search(-(NumArray[i] + NumArray[j]));

                    if (index != -1 && firstOccurrenceOfThreeNums(i, j, index))
                        count++;
                }


            return count;
        }

        private void sort(int[] numArray)
        {
            for(int i = 1; i < NumArray.Length; i++)
            {
                for(int j = i; j > 0; j--)
                {
                    if (NumArray[j] > NumArray[j - 1])
                        break;
                    swap(j, j - 1);
                }
            }

        }

        private void swap(int i, int j)
        {
            int temp = NumArray[i];
            NumArray[i] = NumArray[j];
            NumArray[j] = temp;
        }

        private bool firstOccurrenceOfThreeNums(int i, int j, int index)
        {
            if (i < j && j < index)
                return true;
            else
                return false;
        }
    }
}
