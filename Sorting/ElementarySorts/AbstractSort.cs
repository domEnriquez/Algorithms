using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElementarySorts
{
    public abstract class AbstractSort<T> where T : IComparable
    {
        public abstract T[] Sort(T[] a);

        public abstract string GetSortName();

        public bool less(T v1, T v2)
        {
            return v1.CompareTo(v2) < 0;
        }

        public bool lessOrEqual(T v1, T v2)
        {
            return v1.CompareTo(v2) <= 0;
        }

        public void swap(T[] a, int i, int j)
        {
            T temp = a[i];
            a[i] = a[j];
            a[j] = temp;
        }
    }
}
