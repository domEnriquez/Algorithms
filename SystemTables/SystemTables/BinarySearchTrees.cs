using System;

namespace SystemTables
{
    public class BinarySearchTrees<Tkey, TVal> : SystemTable<Tkey, TVal> where Tkey : IComparable
    {
        public class Node
        {
            public Tkey Key;
            public TVal Val;
            public Node Left;
            public Node Right;
            public int Count;
            public bool Color;

            public Node(Tkey key, TVal val)
            {
                Key = key;
                Val = val;
                Count = 1;
            }

            public Node(Tkey key, TVal val, bool color) : this(key,val)
            {
                Color = color;
            }
        }

        public Node root = null;

        public override bool Contains(Tkey key)
        {
            throw new NotImplementedException();
        }

        public override TVal Get(Tkey key)
        {
            if (root == null)
                return default(TVal);

            Node currNode = root;

            while (currNode != null)
            {
                int cmp = key.CompareTo(currNode.Key);
                if (cmp < 0)
                    currNode = currNode.Left;
                else if (cmp > 0)
                    currNode = currNode.Right;
                else
                    return currNode.Val;
            }

            return default(TVal);
        }

        public override void Put(Tkey key, TVal val)
        {
            root = put(root, key, val);
        }

        protected virtual Node put(Node node, Tkey key, TVal val)
        {
            if (node == null)
                return new Node(key, val);

            int cmp = key.CompareTo(node.Key);

            if (cmp < 0)
                node.Left = put(node.Left, key, val);
            else if (cmp > 0)
                node.Right = put(node.Right, key, val);
            else
                node.Val = val;

            node.Count = 1 + size(node.Left) + size(node.Right);

            return node;
        }

        public override string GetName()
        {
            return "BinarySearchTree";
        }

        public override Tkey Floor(Tkey key)
        {
            Node x = floor(root, key);

            if (x == null)
                return default(Tkey);

            return x.Key;
        }

        private Node floor(Node x, Tkey key)
        {
            if (x == null)
                return null;

            int cmp = key.CompareTo(x.Key);

            if (cmp == 0)
                return x;

            if (cmp < 0)
                return floor(x.Left, key);

            Node t = floor(x.Right, key);

            if (t != null)
                return t;
            else
                return x;
        }

        public override int Size()
        {
            return size(root);
        }

        public override int Rank(Tkey key)
        {
            return rank(key, root);
        }

        private int rank(Tkey key, Node node)
        {
            if (node == null)
                return 0;

            int cmp = key.CompareTo(node.Key);
            if (cmp < 0)
                return rank(key, node.Left);
            else if (cmp > 0)
                return 1 + size(node.Left) + rank(key, node.Right);
            else
                return size(node.Left);
        }

        protected int size(Node node)
        {
            if (node == null)
                return 0;
            else
                return node.Count;
        }

        public override void DeleteMin()
        {
            root = deleteMin(root);
        }

        private Node deleteMin(Node node)
        {
            if (node.Left == null)
                return node.Right;

            node.Left = deleteMin(node.Left);
            node.Count = 1 + size(node.Left) + size(node.Right);

            return node;
        }

        public override void Delete(Tkey key)
        {
            root = delete(root, key);
        }

        private Node delete(Node node, Tkey key)
        {
            if (node == null)
                return null;

            int cmp = key.CompareTo(node.Key);

            if (cmp < 0)
                node.Left = delete(node.Left, key);
            else if (cmp > 0)
                node.Right = delete(node.Right, key);
            else
            {
                if (node.Left == null)
                    return node.Right;
                if (node.Right == null)
                    return node.Left;

                Node temp = node;
                node = min(temp.Right);
                node.Right = deleteMin(temp.Right);
                node.Left = temp.Left;
            }

            node.Count = 1 + size(node.Left) + size(node.Right);
            return node;
        }

        private Node min(Node node)
        {
            while(node.Left != null)
            {
                node = node.Left;
            }

            return node;
        }
    }
}
