using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericQueue
{
    public abstract class AbstractQueue<T>
    {
        public abstract bool IsEmpty();
        public abstract void Enqueue(T item);
        public abstract T Dequeue();

        public abstract int Size();

        public class QueueUnderFlowException : ApplicationException
        {

        }
    }
}
