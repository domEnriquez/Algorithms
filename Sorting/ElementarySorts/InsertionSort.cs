using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElementarySorts
{
    public class InsertionSort<T> : AbstractSort<T> where T : IComparable
    {
        public override string GetSortName()
        {
            return "InsertionSort";
        }

        public override T[] Sort(T[] a)
        {
            insertionSort(a, 0, a.Length-1);

            return a;
        }

        private void insertionSort(T[] a, int low, int high)
        {
            for (int i = low; i <= high; i++)
                for (int j = i; j > 0; j--)
                    if (less(a[j], a[j - 1]))
                        swap(a, j, j - 1);
                    else
                        break;
        }

        public T[] Sort(T[] a, int low, int high)
        {
            insertionSort(a, low, high);
            return a;
        }
    }
}
