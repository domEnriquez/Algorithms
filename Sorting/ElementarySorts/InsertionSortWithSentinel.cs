using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElementarySorts
{
    public class InsertionSortWithSentinel<T> : AbstractSort<T> where T : IComparable
    {
        public override string GetSortName()
        {
            return "InsertionSortWithSentinel";
        }

        public override T[] Sort(T[] a)
        {
            int arrSize = a.Length;

            int exchanges = positionMinimumValue(a, arrSize);

            if (exchanges == 0)
                return a;

            for (int i = 2; i < arrSize; i++)
            {
                int j = i;
                while (less(a[j], a[j - 1]))
                {
                    swap(a, j, j - 1);
                    j--;
                }
            }

            return a;
        }

        private int positionMinimumValue(T[] a, int arrSize)
        {
            int exchanges = 0;

            for (int i = arrSize - 1; i > 0; i--)
            {
                if (less(a[i], a[i-1]))
                {
                    swap(a, i, i - 1);
                    exchanges++;
                }
            }

            return exchanges;
        }
    }
}
