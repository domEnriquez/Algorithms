using System;

namespace GenericStack
{
    public abstract class AbstractStack<T>
    {
        public abstract bool IsEmpty();
        public abstract int Size();
        public abstract void Push(T item);
        public abstract T Pop();
        public abstract string GetStackType();
        public abstract T Peek();

        public class StackUnderflowException : ApplicationException
        {

        }

    }
}
