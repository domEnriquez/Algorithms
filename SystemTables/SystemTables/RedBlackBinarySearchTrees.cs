using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SystemTables
{
    public class RedBlackBinarySearchTrees<Tkey, TVal> : BinarySearchTrees<Tkey, TVal> where Tkey : IComparable 
    {
        private const bool RED = true;
        private const bool BLACK = false;

        private bool isRed(Node node)
        {
            if (node == null)
                return false;

            return node.Color == RED;
        }

        protected override Node put(Node node, Tkey key, TVal val)
        {
            if (node == null)
                return new Node(key, val, RED);

            int cmp = key.CompareTo(node.Key);

            if (cmp < 0)
                node.Left = put(node.Left, key, val);
            else if (cmp > 0)
                node.Right = put(node.Right, key, val);
            else
                node.Val = val;

            if (isRed(node.Right) && !isRed(node.Left))
                node = rotateLeft(node);
            if (isRed(node.Left) && isRed(node.Left.Left))
                node = rotateRight(node);
            if (isRed(node.Left) && isRed(node.Right))
                flipColors(node);

            node.Count = 1 + size(node.Left) + size(node.Right);

            return node;
        }


        private Node rotateLeft(Node h)
        {
            Node x = h.Right;
            h.Right = x.Left;
            x.Left = h;
            x.Color = h.Color;
            h.Color = RED;

            return x;
        }

        private Node rotateRight(Node h)
        {
            Node x = h.Left;
            h.Left = x.Right;
            x.Right = h;
            x.Color = h.Color;
            h.Color = RED;
            return x;
        }

        private void flipColors(Node h)
        {
            h.Color = RED;
            h.Left.Color = BLACK;
            h.Right.Color = BLACK;
        }
    }
}
