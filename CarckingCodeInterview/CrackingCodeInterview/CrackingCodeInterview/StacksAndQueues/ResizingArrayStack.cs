namespace CrackingCodeInterview.StacksAndQueues
{
    public class ResizingArrayStack
    {
        private int[] stack;
        private int N;
        private int[] minIdeces;
        private int N_min;

        public ResizingArrayStack()
        {
            stack = new int[1];
            minIdeces = new int[1];
        }

        public void Push(int num)
        {
            if (N == stack.Length)
                resize(2 * stack.Length, stack);

            if (N_min == minIdeces.Length)
                resize(2 * minIdeces.Length, minIdeces);

            stack[N++] = num;

            if (N_min == 0 || num < minIdeces[N_min-1])
                minIdeces[N_min++] = num;
        }

        public int Pop()
        {
            int num = stack[--N];
            stack[N] = default;

            if(N == minIdeces[N_min-1])
                minIdeces[--N_min] = default;

            if (N > 0 && N == stack.Length / 4)
                resize(stack.Length / 2, stack);

            if (N_min > 0 && N_min == minIdeces.Length / 4)
                resize(minIdeces.Length / 2, minIdeces);

            return num;
        }

        public int Min()
        {
            return minIdeces[N_min-1];
        }

        private void resize(int capacity, int[] s)
        {
            int[] copy = new int[capacity];

            for (int i = 0; i < N; i++)
                copy[i] = s[i];

            s = copy;
        }
    }
}
