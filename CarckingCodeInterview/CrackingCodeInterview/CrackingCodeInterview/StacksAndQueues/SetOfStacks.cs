using NUnit.Framework;
using System.Collections.Generic;

namespace CrackingCodeInterview.StacksAndQueues
{
    [TestFixture]
    public class SetOfStacksTest
    {
        [Test]
        public void canPushAndPop()
        {
            SetOfStacks setOfStacks = new SetOfStacks(2);

            for(int i = 0; i < 8; i++)
                setOfStacks.Push(i);

            for(int i = 7; i >=0; i--)
                Assert.That(i, Is.EqualTo(setOfStacks.Pop()));
        }
    }

    public class SetOfStacks
    {
        private int capacity;
        private int N;
        private int currentStack;
        private List<ArrayStack> stacks;

        public SetOfStacks(int capacity)
        {
            this.capacity = capacity;
            stacks = new List<ArrayStack>();
            stacks.Add(new ArrayStack());
        }

        public void Push (int n)
        {
            if(N <= capacity)
            {
                stacks[currentStack].Push(n);
            } else
            {
                stacks.Add(new ArrayStack());
                stacks[++currentStack].Push(n);
                N = 0;
            }

            N++;
        }

        public int Pop ()
        {
            int result;

            if(N > 0)
            {
                result = stacks[currentStack].Pop();
                N--;
            } else
            {
                stacks.Remove(stacks[currentStack]);
                result = stacks[--currentStack].Pop();
                N = capacity;
            }

            return result;
        }
    }

    public class ArrayStack
    {
        private int[] s;
        private int N = 0;

        public ArrayStack()
        {
            s = new int[1];
        }

        public void Push(int item)
        {
            if (N == s.Length)
                resize(2 * s.Length);

            s[N++] = item;
        }

        public int Pop()
        {
            int ss = s[--N];
            s[N] = default(int);

            if (N > 0 && N == s.Length / 4)
                resize(s.Length / 2);

            return ss;
        }

        private void resize(int capacity)
        {
            int[] copy = new int[capacity];

            for (int i = 0; i < N; i++)
                copy[i] = s[i];

            s = copy;
        }
    }
}
