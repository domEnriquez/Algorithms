using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericStack
{
    public class ResizingArrayStack<T> : AbstractStack<T>
    {
        private T[] s;
        private int N = 0;

        public ResizingArrayStack()
        {
            s = new T[1];
        }

        public override void Push(T item)
        {
            if (N == s.Length)
                resize(2 * s.Length);

            s[N++] = item;
        }

        public override T Pop()
        {
            if (IsEmpty())
                throw new StackUnderflowException();

            T ss = s[--N];
            s[N] = default(T);

            if (N > 0 && N == s.Length / 4)
                resize(s.Length / 2);

            return ss;
        }

        public override T Peek()
        {
            return s[N-1];
        }

        private void resize(int capacity)
        {
            T[] copy = new T[capacity];

            for (int i = 0; i < N; i++)
                copy[i] = s[i];

            s = copy;
        }

        public override bool IsEmpty()
        {
            return N == 0;
        }

        public override int Size()
        {
            return N;
        }

        public override string GetStackType()
        {
            return "ResizingArrayStack";
        }
    }
}
