using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElementarySorts
{
    public class ShellSort<T> : AbstractSort<T> where T : IComparable
    {
        public override string GetSortName()
        {
            return "ShellSort";
        }

        public override T[] Sort(T[] a)
        {
            int arrSize = a.Length;

            int h = 1;

            while (h < arrSize/3)
                h = 3 * h + 1;

            while (h>=1)
            {
                for (int i = h; i < arrSize; i++)
                    for (int j = i; j >= h; j -= h)
                        if (less(a[j], a[j - h]))
                            swap(a, j, j - h);
                        else
                            break;

                h = h / 3;
            }

            return a;
        }
    }
}
