using System;

namespace SystemTables
{
    public class UnorderedLinkedListST<TKey, TVal> : SystemTable<TKey, TVal> where TKey : IComparable
    {
        public Node first = null;
        private int size;

        public class Node
        {
            public Node next = null;
            public TKey key;
            public TVal val;

            public Node(TKey key, TVal val)
            {
                this.key = key;
                this.val = val;
            }
        }
        public override void Put(TKey key, TVal val)
        {
            size++;

            if (first == null)
            {
                first = new Node(key, val);
                return;
            }

            if (Contains(key))
                replaceVal(key, val);
            else
                putInFirst(key, val);
        }

        private void replaceVal(TKey key, TVal newVal)
        {
            Node currentNode = first;

            while (currentNode != null)
            {
                if (currentNode.key.Equals(key))
                    currentNode.val = newVal;

                currentNode = currentNode.next;
            }
        }

        private void putInFirst(TKey key, TVal val)
        {
            Node oldFirst = first;
            first = new Node(key, val);
            first.next = oldFirst;
        }

        public override TVal Get(TKey key)
        {
            Node currentNode = first;

            while(currentNode != null)
            {
                if (currentNode.key.Equals(key))
                    return currentNode.val;

                currentNode = currentNode.next;
            }

            return default(TVal);
        }

        public override bool Contains(TKey key)
        {
            if (Get(key) == null)
                return false;
            else
                return true;
        }

        public override string GetName()
        {
            return "UnorderedLinkedListST";
        }

        public override TKey Floor(TKey key)
        {
            Node currentNode = first;
            TKey floorKey = default(TKey);

            while (currentNode != null)
            {
                TKey currKey = currentNode.key;

                if (currKey.Equals(key))
                    return currKey;

                if (currKey.CompareTo(floorKey) > 0 && currKey.CompareTo(key) < 0)
                    floorKey = currKey;

                currentNode = currentNode.next;
            }

            return floorKey;
        }

        public override int Size()
        {
            return size;
        }

        public override int Rank(TKey key)
        {
            Node currentNode = first;
            int rank = 0;

            while (currentNode != null)
            {
                if (key.CompareTo(currentNode.key) > 0)
                    rank++;

                currentNode = currentNode.next;
            }

            return rank;
        }

        public override void DeleteMin()
        {
            size--;
            TKey minKey = first.key;
            Node currentNode = first.next;

            while (currentNode != null)
            {
                if (minKey.CompareTo(currentNode.key) > 0)
                    minKey = currentNode.key;

                currentNode = currentNode.next;
            }

            first = delete(first, minKey);
        }

        public Node delete(Node node, TKey minKey)
        {
            if (node.key.Equals(minKey))
                return node.next;

            node.next = delete(node.next, minKey);

            return node;
        }

        public override void Delete(TKey key)
        {
            size--;
            first = delete(first, key);
        }
    }
}
