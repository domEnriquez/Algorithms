using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThreeSum
{
    public class BruteForceThreeSum : AbstractThreeSum
    {
        public BruteForceThreeSum(int[] arr) : base(arr)
        {
        }

        public override int Count()
        {
            int count = 0;

            for (int i = 0; i < NumArray.Length; i++)
                for (int j = i + 1; j < NumArray.Length; j++)
                    for (int k = j + 1; k < NumArray.Length; k++)
                        if (NumArray[i] + NumArray[j] + NumArray[k] == 0)
                            count++;

            return count;
        }
    }
}
