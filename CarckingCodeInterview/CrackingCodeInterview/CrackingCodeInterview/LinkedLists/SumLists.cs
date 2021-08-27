using NUnit.Framework;

namespace CrackingCodeInterview.LinkedLists
{
    [TestFixture]
    public class SumLists
    {
        [Test]
        public void testSumLists()
        {
            LinkedList l1 = new LinkedList();
            l1.AppendToTail(new int[] { 7, 1, 6 });
            LinkedList l2 = new LinkedList();
            l2.AppendToTail(new int[] { 5, 9, 2 });

            LinkedList expected = new LinkedList();
            expected.AppendToTail(new int[] { 9, 1, 2 });

            Assert.That(SumTwoLinkedLists(l1, l2).DisplayAllData(), Is.EqualTo("912"));
        }

        public LinkedList SumTwoLinkedLists(LinkedList l1, LinkedList l2)
        {
            int sum = transformToNum(l1) + transformToNum(l2);

            return transformToLinkedList(sum);
        }

        private int transformToNum(LinkedList l1)
        {
            int num = 0;
            LinkedList.Node n = l1.GetHead();
            int count = 1;

            while (n != null)
            {
                num += (n.data * count);
                count *= 10;
                n = n.next;
            }

            return num;
        }

        private LinkedList transformToLinkedList(int num)
        {
            LinkedList list = new LinkedList();

            do
            {
                int rem = num % 10;
                list.Push(rem);

                num = num / 10;
            } while (num != 0);

            return list;
        }


    }
}
