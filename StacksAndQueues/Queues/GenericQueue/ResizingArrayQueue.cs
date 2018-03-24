using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericQueue
{
    public class ResizingArrayQueue<T> : AbstractQueue<T>
    {
        private T[] s;
        private int head = 0;
        private int tail = 0;
        private int N = 0;

        public ResizingArrayQueue()
        {
            s = new T[1];
        }

        public override bool IsEmpty()
        {
            return Size() == 0;
        }

        public override void Enqueue(T item)
        {
            if(N == s.Length)
                resizeArray(s.Length * 2);

            s[tail++] = item;

            if (tail == s.Length) 
                tail = 0;

            N++;
        }

        public override T Dequeue()
        {
            if (IsEmpty())
                throw new QueueUnderFlowException();

            T item = s[head];
            s[head++] = default(T);
            N--;

            if (N > 0 && N == s.Length / 4)
                resizeArray(s.Length / 2);

            return item;
        }

        public override int Size()
        {
            return N;
        }

        private void resizeArray(int capacity)
        {
            T[] temp = new T[capacity];

            for (int i = 0; i < temp.Length; i++)
                temp[i] = s[(i + head) % s.Length];

            s = temp;
            head = 0;
            tail = N;
        }
    }
}
