using NUnit.Framework;

namespace CrackingCodeInterview.StacksAndQueues
{
    [TestFixture]
    public class ThreeStacksInOneArrayTests
    {
        [Test]
        public void canPushAndPopInThreeStacks()
        {
            ThreeStacksInOneArray stacks = new ThreeStacksInOneArray();

            stacks.Push(1, 1);
            stacks.Push(2, 2);
            stacks.Push(3, 3);
            stacks.Push(4, 1);
            stacks.Push(5, 2);
            stacks.Push(6, 3);

            Assert.That(stacks.Pop(1), Is.EqualTo(4));
            Assert.That(stacks.Pop(1), Is.EqualTo(1));
            Assert.That(stacks.Pop(2), Is.EqualTo(5));
            Assert.That(stacks.Pop(2), Is.EqualTo(2));
            Assert.That(stacks.Pop(3), Is.EqualTo(6));
            Assert.That(stacks.Pop(3), Is.EqualTo(3));
        }

    }

    public class ThreeStacksInOneArray
    {
        private int[] stack;
        private int N1 = 0;
        private int N2 = 1;
        private int N3 = 2;
        private int totalSize = 0;

        public ThreeStacksInOneArray()
        {
            stack = new int[3];
        }

        public void Push(int num, int stackNo)
        {
            if (totalSize == stack.Length)
                resize(2 * stack.Length);

            if (stackNo == 1)
            {
                stack[N1] = num;
                N1 += 3;
            }
            else if (stackNo == 2)
            {
                stack[N2] = num;
                N2 += 3;
            }
            else
            {
                stack[N3] = num;
                N3 += 3;
            }

            totalSize++;
        }

        public int Pop(int stackNo)
        {
            int result; 
            if(stackNo == 1)
            {
                N1 -= 3;
                result = stack[N1];
            }
            else if(stackNo == 2)
            {
                N2 -= 3;
                result = stack[N2];
            }
            else
            {
                N3 -= 3;
                result = stack[N3];
            }

            totalSize--;

            if (totalSize > 0 && totalSize == stack.Length / 4)
                resize(stack.Length / 2);

            return result;
        }

        private int pop(int n1)
        {
            int result;
            n1 -= 3;
            result = stack[n1];

            return result;
        }

        private void resize(int capacity)
        {
            int[] copy = new int[capacity];

            for (int i = 0; i < N1; i+=3)
                copy[i] = stack[i];

            for (int i = 1; i < N2; i += 3)
                copy[i] = stack[i];

            for (int i = 2; i < N3; i += 3)
                copy[i] = stack[i];

            stack = copy;
        }

    }

}
