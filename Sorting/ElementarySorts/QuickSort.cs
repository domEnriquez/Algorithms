using System;

namespace ElementarySorts
{
    public class QuickSort<T> : AbstractSort<T> where T : IComparable
    {
        public override string GetSortName()
        {
            return "QuickSort";
        }

        public override T[] Sort(T[] a)
        {
            shuffle(a);
            sort(a, 0, a.Length-1);
            return a;
        }

        private void sort(T[] a, int low, int high)
        {
            if (high <= low) return;
            int j = partition(a, low, high);
            sort(a, low, j - 1);
            sort(a, j + 1, high);
        }

        private int partition(T[] a, int low, int high)
        {
            int i = low;
            T k = a[low];
            int j = high + 1;

            while(true)
            {
                while (less(a[++i], k))
                    if (i == high) break;

                while (less(k, a[--j]))
                    if (j == low) break;

                if (i >= j) break;
                swap(a, i, j);
            }

            swap(a, low, j);

            return j;
        }

        private void shuffle(T[] a)
        {
            Random rand = new Random();
            int N = a.Length;
            for (int i = 0; i < N; i++)
            {
                int r = rand.Next(0, i + 1);
                swap(a, i, r);
            }
        }
    }
}
