using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThreeSum
{
    public abstract class AbstractThreeSum
    {
        public AbstractThreeSum(int[] arr)
        {
            NumArray = arr;
            
        }

        public int[] NumArray;
        public abstract int Count();
    }
}
