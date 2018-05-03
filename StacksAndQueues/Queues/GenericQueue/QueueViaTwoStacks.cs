using GenericStack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericQueue
{
    public class QueueViaTwoStacks<T> : AbstractQueue<T>
    {
        private ResizingArrayStack<T> stack1;
        private ResizingArrayStack<T> stack2;
        private int size;
        private bool shouldTransfer;

        public QueueViaTwoStacks()
        {
            stack1 = new ResizingArrayStack<T>();
            stack2 = new ResizingArrayStack<T>();
        }

        public override T Dequeue()
        {
            if (IsEmpty())
                throw new QueueUnderFlowException();

            size--;

            if (stack1.IsEmpty() && shouldTransfer)
            {
                transferContents(stack2, stack1);

                return stack1.Pop();
            }
            else if (stack2.IsEmpty() && shouldTransfer)
            {
                transferContents(stack1, stack2);

                return stack2.Pop();
            }
            else if (!stack1.IsEmpty())
                return stack1.Pop();
            else
                return stack2.Pop();

        }

        private void transferContents(ResizingArrayStack<T> srcStack, ResizingArrayStack<T> destStack)
        {
            int size = srcStack.Size();

            for (int i = 0; i < size; i++)
                destStack.Push(srcStack.Pop());

            shouldTransfer = false;
        }

        public override void Enqueue(T item)
        {
            size++;
            shouldTransfer = true;

            if (stack1.IsEmpty())
                stack2.Push(item);
            else
                stack1.Push(item);
        }

        public override bool IsEmpty()
        {
            if (size == 0)
                return true;
            else
                return false;
        }

        public override int Size()
        {
            return size;
        }
    }
}
