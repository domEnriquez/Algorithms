using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElementarySorts
{
    public class InsertionSortWithoutExchanges<T> : AbstractSort<T> where T : IComparable
    {
        public override string GetSortName()
        {
            return "InsertionSortWithoutExchanges";
        }

        public override T[] Sort(T[] a)
        {
            int arrSize = a.Length;

            for(int i = 1; i < arrSize; i++)
            {
                int j = i;
                T curr = a[i];
                while(j>0 && less(curr, a[j-1]))
                {
                    a[j] = a[j - 1];
                    j--;
                }
                a[j] = curr;
            }

            return a;
        }
    }
}
