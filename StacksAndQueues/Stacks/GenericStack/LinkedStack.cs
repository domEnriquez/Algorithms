using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericStack
{
    public class LinkedStack<T> : AbstractStack<T>
    {
        private Node first = null;
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
            return size == 0;
        }

        public override void Push(T item)
        {
            if (first == null)
                first = new Node(item);
            else
            {
                Node oldFirst = first;
                first = new Node(item);
                first.next = oldFirst;
            }

            size++;
        }

        public override T Pop()
        {
            if (IsEmpty())
                throw new StackUnderflowException();

            size--;
            T item = first.item;
            first = first.next;
            return item;
        }

        public override T Peek()
        {
            return first.item;
        }

        public override int Size()
        {
            return size;
        }

        public override string GetStackType()
        {
            return "LinkedStack";
        }
    }
}
