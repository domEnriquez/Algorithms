using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericQueue
{
    public class LinkedQueue<T> : AbstractQueue<T>
    {
        private Node first = null;
        private Node last = null;
        private int size = 0;

        private class Node
        {
            public Node next;
            public T item;
            public Node(T item)
            {
                this.item = item;
            }
        }

        public override bool IsEmpty()
        {
            return first == null;
        }

        public override int Size()
        {
            return size;
        }

        public override void Enqueue(T item)
        {
            Node oldLast = last;
            last = new Node(item);
            last.next = null;
            size++;

            if (IsEmpty())
                first = last;
            else
                oldLast.next = last;
        }

        public override T Dequeue()
        {
            if (IsEmpty())
            {
                last = null;
                throw new QueueUnderFlowException();
            }
                

            T item = first.item;
            first = first.next;
            size--;
            return item;
        }
    }
}
