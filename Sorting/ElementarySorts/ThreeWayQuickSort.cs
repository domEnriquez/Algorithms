using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElementarySorts
{
    public class ThreeWayQuickSort<T> : AbstractSort<T> where T : IComparable
    {
        public override string GetSortName()
        {
            return "ThreeWayQuickSort";
        }

        public override T[] Sort(T[] a)
        {
            sort(a, 0, a.Length - 1);
            return a;
        }

        private void sort(T[] a, int low, int high)
        {
            if (low >= high)
                return;

            int i = low + 1;
            int lt = low;
            int gt = high;
            T pe = a[lt];

            while(i <= gt)
            {
                if(less(a[i], pe))
                    swap(a, i++, lt++);
                else if(less(pe, a[i]))
                    swap(a, i, gt--);
                else
                    i++;
            }

            sort(a, low, lt - 1);
            sort(a, gt + 1, high);
        }
    }
}
