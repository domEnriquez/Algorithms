using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shuffling
{
    public class Shuffler
    {
        public static void shuffle(Object[] a)
        {
            Random rand = new Random();
            int N = a.Length;
            for(int i = 0; i < N; i++)
            {
                int r = rand.Next(0, i + 1);
                swap(a, i, r);
            }
        }

        private static void swap(object[] a, int i, int r)
        {
            object temp = a[i];
            a[i] = a[r];
            a[r] = temp;
        }
    }
}
