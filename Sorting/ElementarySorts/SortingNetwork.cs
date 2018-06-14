using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElementarySorts
{
    public class SortingNetwork<T> : AbstractSort<T> where T : IComparable
    {
        public override string GetSortName()
        {
            return "SortingNetwok";
        }

        public override T[] Sort(T[] a)
        {
            if (a.Length != 3)
                throw new SortingNetworkInvalidArraySizeException();

            if (less(a[1], a[0])) swap(a, 1, 0);
            if (less(a[2], a[1])) swap(a, 2, 1);
            if (less(a[1], a[0])) swap(a, 1, 0);

            return a;
        }

        public class SortingNetworkInvalidArraySizeException : ApplicationException
        {

        }
    }
}
