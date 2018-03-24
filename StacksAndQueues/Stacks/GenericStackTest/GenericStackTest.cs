using GenericStack;
using NUnit.Framework;
using System.Collections.Generic;

namespace GenericStackTest
{
    [TestFixture]
    public class GenericStackTest
    {
        private List<AbstractStack<int>> stacks;

        [SetUp]
        public void GivenANewStack()
        {
            stacks = new List<AbstractStack<int>>() { new LinkedStack<int>(), new ResizingArrayStack<int>() };
        }

        [Test]
        public void WhenPushOne_ThenIncreaseStackSize()
        {
            foreach(AbstractStack<int> stack in stacks)
            {
                stack.Push(1);
                Assert.AreEqual(1, stack.Size(), stack.GetStackType());
            }

        }

        [Test]
        public void WhenPopOne_ThenDecreaseStackSize()
        {
            foreach (AbstractStack<int> stack in stacks)
            {
                stack.Push(1);
                stack.Pop();
                Assert.AreEqual(true, stack.IsEmpty(), stack.GetStackType());
            }

        }

        [Test]
        public void WhenPoppedWithZeroSize_ThenThrowUnderflowException()
        {
            foreach (AbstractStack<int> stack in stacks)
                Assert.Throws<AbstractStack<int>.StackUnderflowException>(()=>stack.Pop(), stack.GetStackType());
        }

        [Test]
        public void WhenPushOne_ThenPopOne()
        {
            foreach (AbstractStack<int> stack in stacks)
            {
                stack.Push(1);
                Assert.AreEqual(1, stack.Pop(), stack.GetStackType());
            }
        }

        [Test]
        public void WhenPushOneAndPushTwo_ThenPopTwoAndPopOne()
        {
            foreach (AbstractStack<int> stack in stacks)
            {
                stack.Push(1);
                stack.Push(2);
                Assert.AreEqual(2, stack.Pop(), stack.GetStackType());
                Assert.AreEqual(1, stack.Pop(), stack.GetStackType());
            }
        }

        [Test]
        public void WhenPeek_ThenReturnTopOfTheStack()
        {
            foreach (AbstractStack<int> stack in stacks)
            {
                stack.Push(1);
                stack.Push(2);
                Assert.AreEqual(2, stack.Peek(), stack.GetStackType());
                Assert.AreEqual(2, stack.Size(), stack.GetStackType());

                stack.Push(4);
                stack.Push(6);
                stack.Pop();
                Assert.AreEqual(4, stack.Peek(), stack.GetStackType());
                Assert.AreEqual(3, stack.Size(), stack.GetStackType());
            }
        }

    }
}
