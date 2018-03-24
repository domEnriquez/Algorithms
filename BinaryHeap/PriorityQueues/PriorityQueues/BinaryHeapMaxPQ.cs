using System;

namespace PriorityQueues
{
    public class BinaryHeapMaxPQ<T> : BinaryHeapPriorityQueue<T> where T : IComparable
    {
        protected override bool Compare(T num1, T num2)
        {
            return less(num1, num2);
        }

        public bool less(T v1, T v2)
        {
            return v1.CompareTo(v2) < 0;
        }
    }
}
