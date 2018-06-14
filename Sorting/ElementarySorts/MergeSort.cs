using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElementarySorts
{
    public class MergeSort<T> : AbstractSort<T> where T : IComparable
    {
        public override string GetSortName()
        {
            return "MergeSort";
        }

        public override T[] Sort(T[] a)
        {
            int arrSize = a.Length;
            T[] aux = new T[arrSize];
            mergeSort(a, aux, 0, arrSize-1);
            return a;
        }

        protected virtual void mergeSort(T[] a, T[] aux ,int low, int high)
        {
            if (low >= high)
                return;

            int mid = low + (high - low) / 2;
            mergeSort(a, aux, low, mid);
            mergeSort(a, aux, mid + 1, high);
            merge(a, aux, low, mid, high);
        }

        protected virtual void merge(T[] a, T[] aux, int low, int mid, int high)
        {
            arrayCopy(a, aux, low, high);

            int i = low;
            int j = mid + 1;
            for(int k = low; k <= high; k++)
            {
                if (i > mid) a[k] = aux[j++];
                else if (j > high) a[k] = aux[i++];
                else if (less(aux[i], aux[j])) a[k] = aux[i++];
                else a[k] = aux[j++];
            }
        }

        private void arrayCopy(T[] source, T[] dest, int low, int high)
        {
            for (int i = low; i <= high; i++)
                dest[i] = source[i];
        }
    }
}
