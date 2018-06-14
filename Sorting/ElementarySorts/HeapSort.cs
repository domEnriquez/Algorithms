using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElementarySorts
{
    public class HeapSort<T> : AbstractSort<T> where T : IComparable
    {
        public override string GetSortName()
        {
            return "HeapSort";
        }

        public override T[] Sort(T[] a)
        {
            constructHeap(a);
            return sort(a);
        }

        private T[] sort(T[] a)
        {
            int size = a.Length;

            while (size > 1)
            {
                adjustedSwap(a, 1, size);
                sink(a, 1, --size);
            }

            return a;
        }

        private void constructHeap(T[] a)
        {
            int size = a.Length;

            for(int i = size/2; i >= 1; i--)
                sink(a, i, size);
        }

        private void sink(T[]a, int i, int size)
        {
            while(i*2 <= size)
            {
                int j = i * 2;
                if (j < size && less(a, j, j+1))
                    j++;
                if (less(a, j, i))
                    break;
                adjustedSwap(a, i, j);
                i = j;
            }
        }

        private bool less(T[] a, int j, int k)
        {
            return less(a[j - 1], a[k - 1]);
        }

        private void adjustedSwap(T[] a, int i, int j)
        {
            swap(a, i - 1, j - 1);
        } 
    }
}
