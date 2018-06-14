using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElementarySorts
{
    public class MergeSortWithSortedArrayTest<T> : MergeSort<T> where T : IComparable
    {
        public override string GetSortName()
        {
            return "MergeSortWithSortedArrayTest";
        }
        protected override void mergeSort(T[] a, T[] aux, int low, int high)
        {
            if (low >= high)
                return;

            int mid = low + (high - low) / 2;
            mergeSort(a, aux, low, mid);
            mergeSort(a, aux, mid + 1, high);

            if (!arrayIsSorted(a, mid))
            {
                merge(a, aux, low, mid, high);
            }
        }

        private bool arrayIsSorted(T[] a, int mid)
        {
            return lessOrEqual(a[mid], a[mid + 1]);
        }
    }
}
