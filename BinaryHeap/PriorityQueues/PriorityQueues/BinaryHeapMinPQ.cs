using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PriorityQueues
{
    public class BinaryHeapMinPQ<T> : BinaryHeapPriorityQueue<T> where T : IComparable
    {
        protected override bool Compare(T num1, T num2)
        {
            return greater(num1, num2);
        }

        public bool greater(T num1, T num2)
        {
            return num1.CompareTo(num2) > 0;
        }
    }
}
