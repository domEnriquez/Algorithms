using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElementarySorts
{
    public class SelectionSort<T> : AbstractSort<T> where T : IComparable
    {
        public override string GetSortName()
        {
            return "SelectionSort";
        }

        public override T[] Sort(T[] a)
        {
            int arrSize = a.Length;

            for (int i = 0; i < arrSize; i++)
            {
                int indexWithMin = i;
                for(int j = i+1; j < arrSize; j++)
                {
                    if (less(a[j], a[indexWithMin]))
                        indexWithMin = j;
                }
                swap(a, i, indexWithMin);
            }

            return a;
        }
    }
}
