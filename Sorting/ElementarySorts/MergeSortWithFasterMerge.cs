using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElementarySorts
{
    public class MergeSortWithFasterMerge<T> : MergeSort<T> where T : IComparable
    {
        public override string GetSortName()
        {
            return "MergeSortWithFasterMerge";
        }

        protected override void merge(T[] a, T[] aux, int low, int mid, int high)
        {
            arrayCopy(a, aux, low, mid);

            inverseArrayCopy(a, aux, mid, high);

            int i = low; int j = high;
            for (int k = low; k <= high; k++)
            {
                if (less(aux[i], aux[j])) a[k] = aux[i++];
                else a[k] = aux[j--];
            }
        }

        private static void arrayCopy(T[] source, T[] dest, int low, int high)
        {
            for (int h = low; h <= high; h++)
                dest[h] = source[h];
        }

        private static void inverseArrayCopy(T[] source, T[] dest, int low, int high)
        {
            for (int o = low + 1; o <= high; o++)
                dest[o] = source[high + low + 1 - o];
        }
    }
}
