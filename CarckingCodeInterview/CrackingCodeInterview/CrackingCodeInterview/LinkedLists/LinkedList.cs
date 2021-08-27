using NUnit.Framework;
using System.Collections.Generic;
using System.Text;

namespace CrackingCodeInterview.LinkedLists
{
    [TestFixture]
    public class LinkedListTests
    {

        [Test]
        public void canRemoveDuplicate()
        {
            LinkedList linkedList = new LinkedList();
            linkedList.AppendToTail(new int[] { 1, 3, 5, 3, 6, 7 });
            linkedList.RemoveDuplicate();
            Assert.That(linkedList.DisplayAllData(), Is.EqualTo("13567"));

            LinkedList linkedList1 = new LinkedList();
            linkedList1.AppendToTail(new int[] { 1, 2, 3, 3, 3, 4, 4, 5, 6, 7, 6, 8 });
            linkedList1.RemoveDuplicate();
            Assert.That(linkedList1.DisplayAllData(), Is.EqualTo("12345678"));
        }

        [Test]
        public void kthToLast()
        {
            LinkedList linkedList = new LinkedList();
            linkedList.AppendToTail(new int[] { 1, 2, 3, 4, 5, 6 });
            Assert.That(linkedList.kthToLast(2), Is.EqualTo(5));
            Assert.That(linkedList.kthToLast(3), Is.EqualTo(4));
            Assert.That(linkedList.kthToLast(4), Is.EqualTo(3));
            Assert.That(linkedList.kthToLast(5), Is.EqualTo(2));
            Assert.That(linkedList.kthToLast(6), Is.EqualTo(1));
        }

        [Test]
        public void partition()
        {
            LinkedList linkedList = new LinkedList();
            linkedList.AppendToTail(new int[] { 3, 5, 8, 5, 9, 2, 1 });
            Assert.That(linkedList.Partition(5).DisplayAllData(), Is.EqualTo("3215859"));
        }


    }


    public class LinkedList
    {
        private Node first = null;
        private Node last = null;
        private int size = 0;

        public class Node
        {
            public Node next;
            public Node prev;
            public int data;

            public Node(int data)
            {
                this.data = data;
            }

        }

        public void Push(int d)
        {
            Node oldFirst = first;
            first = new Node(d);
            first.next = oldFirst;
            size++;

            if (size == 1)
                last = first;
        }

        public void AppendToTail(int[] d)
        {
            for (int i = 0; i < d.Length; i++)
                AppendToTail(d[i]);
        }

        public void AppendToTail(int d)
        {
            Node oldLast = last;
            last = new Node(d);
            last.next = null;
            size++;

            if (size == 1)
                first = last;
            else
            {

                oldLast.next = last;
                last.prev = oldLast;
            }
        }

        public bool IsEmpty()
        {
            return first == null;
        }

        public void DeleteNode(int data)
        {
            Node n = first;

            if (n.data == data)
                first = first.next;

            while(n.next != null)
            {
                if(n.next.data == data)
                    n.next = n.next.next;

                n = n.next;
            }
        }

        public void RemoveDuplicate()
        {
            Node n = first;

            while (n != null)
            {
                Node p = n.next;

                while (p != null)
                {

                    if (n.data == p.data)
                    {
                        p.next.prev = p.prev;
                        p.prev.next = p.next;
                    }

                    p = p.next;
                }

                n = n.next;
            }
        }

        public int kthToLast(int k)
        {
            if (k == size)
                return first.data;

            Node n = first;
            int count = size;

            while (n != null)
            {
                n = n.next;
                count--;

                if (count == k)
                    return n.data;
            }

            return default(int);
        }

        public LinkedList Partition(int partitionNum)
        {
            LinkedList partitioned = new LinkedList();
            List<int> greaterThan = new List<int>();
            Node n = first;

            while(n != null)
            {
                if(n.data < partitionNum)
                {                    
                    partitioned.AppendToTail(n.data);
                }
                else
                {
                    greaterThan.Add(n.data);
                }

                n = n.next;
            }

            partitioned.AppendToTail(greaterThan.ToArray());

            return partitioned;
        }

        public bool Contains(int d)
        {
            Node n = first;

            while (n != null)
            {
                if (n.data == d)
                    return true;

                n = n.next;
            }

            return false;
        }

        public string DisplayAllData()
        {
            StringBuilder dataString = new StringBuilder();
            Node n = first;

            while (n != null)
            {
                dataString.Append(n.data.ToString());
                n = n.next;
            }

            return dataString.ToString();
        }

        public Node GetHead()
        {
            return first;
        }
    }
}
