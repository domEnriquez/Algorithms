using GenericQueue;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Josephus
{
    public class JosephusSolver
    {
        private AbstractQueue<int> queue;

        public JosephusSolver(AbstractQueue<int> q)
        {
            queue = q;
        }

        public string printEliminated(int posToEleminate, int size)
        {
            fillQueue(size);

            StringBuilder s = new StringBuilder();
            int posCounter = 1;

            while(queue.Size() > 1)
            {
                if (posCounter == posToEleminate)
                {
                    s.Append(queue.Dequeue() + " ");
                    posCounter = 1;
                }
                else
                {
                    queue.Enqueue(queue.Dequeue());
                    posCounter++;
                }
            }

            return s.Append(queue.Dequeue()).ToString().Trim();
        }

        private void fillQueue(int size)
        {
            for (int i = 0; i < size; i++)
                queue.Enqueue(i);
        }
    }
}
