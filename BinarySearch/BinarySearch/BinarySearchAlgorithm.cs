using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinarySearch
{
    public class BinarySearchAlgorithm
    {
        private int[] sortedArr;

        public BinarySearchAlgorithm(int[] sortedArr)
        {
            this.sortedArr = sortedArr;
        }

        public int Search(int num)
        {
            int low = 0;
            int high = sortedArr.Length - 1;

            while(low <= high)
            {
                int mid = low + (high - low) / 2;
                if (num < sortedArr[mid])
                    high = mid - 1;
                else if (num > sortedArr[mid])
                    low = mid + 1;
                else
                    return mid;
            }

            return -1;
        }
    }
}
