using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElementarySorts
{
    public class MergeWithInsertionSort<T> : MergeSort<T> where T : IComparable
    {
        private const int CUTOFF = 3;
        private InsertionSort<T> insSort;

        public MergeWithInsertionSort()
        {
            insSort = new InsertionSort<T>();
        }

        public override string GetSortName()
        {
            return "MergeWithInsertionSort";
        }

        protected override void mergeSort(T[] a, T[] aux, int low, int high)
        {
            if ((high - low + 1) <= CUTOFF)
            {
                insSort.Sort(a, low, high);
                return;
            }

            int mid = low + (high - low) / 2;
            mergeSort(a, aux, low, mid);
            mergeSort(a, aux, mid + 1, high);
            merge(a, aux, low, mid, high);
        }
    }
}
