using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PriorityQueues
{
    public abstract class BinaryHeapPriorityQueue<T> where T : IComparable
    {
        protected T[] pq;
        protected int size = 0;

        public BinaryHeapPriorityQueue()
        {
            pq = new T[1];
        }

        protected abstract bool Compare(T num1, T num2);

        public int Size()
        {
            return size;
        }

        public bool IsEmpty()
        {
            return Size() == 0;
        }

        public void Insert(T item)
        {
            if (size == pq.Length - 1)
                resizeArray(pq.Length * 2);

            pq[++size] = item;
            swim(size);
        }

        private void resizeArray(int newSize)
        {
            T[] auxPq = new T[newSize];

            for (int i = 1; i <= size; i++)
                auxPq[i] = pq[i];

            pq = auxPq;
        }

        public T DeleteTop()
        {
            if (IsEmpty())
                throw new HeapUnderflowException();

            T top = pq[1];
            swap(pq, 1, size--);
            pq[size + 1] = default(T);
            sink(1);

            if (size > 0 && size == (pq.Length - 1) / 4)
                resizeArray(pq.Length / 2);

            return top;
        }

        private void sink(int k)
        {
            while (2 * k <= size)
            {
                int j = 2 * k;
                if (j < size && Compare(pq[j], pq[j + 1]))
                    j++;

                if (Compare(pq[j], pq[k]))
                    break;

                swap(pq, k, j);
                k = j;
            }
        }

        private void swim(int k)
        {
            while (k > 1 && Compare(pq[k / 2], pq[k]))
            {
                swap(pq, k, k / 2);
                k = k / 2;
            }
        }

        public void swap(T[] pq, int i, int j)
        {
            T temp = pq[i];
            pq[i] = pq[j];
            pq[j] = temp;
        }
        public T PeekTop()
        {
            if (IsEmpty())
                throw new HeapUnderflowException();

            return pq[1];
        }

        public class HeapUnderflowException : ApplicationException
        {
        }

    }
}
