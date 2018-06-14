using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElementarySorts
{
    public class BottomUpMergeSort<T> : MergeSort<T> where T : IComparable
    {
        public override string GetSortName()
        {
            return "BottomUpMergeSort";
        }

        public override T[] Sort(T[] a)
        {
            int arrSize = a.Length;
            T[] aux = new T[arrSize];

            for(int sz = 1; sz < arrSize; sz = sz + sz)
                for(int low = 0; low < arrSize-sz; low += sz + sz)
                    merge(a, aux, low, low + sz - 1, Math.Min(low + sz + sz - 1, arrSize-1));

            return a;
        }
    }
}
