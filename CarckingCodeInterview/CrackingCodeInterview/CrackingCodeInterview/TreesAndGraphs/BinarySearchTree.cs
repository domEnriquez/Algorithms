using NUnit.Framework;

namespace CrackingCodeInterview.TreesAndGraphs
{
    public class BinarySearchTree
    {
        [TestFixture]
        public class BinarySearchTreeTests
        {
            [Test]
            public void CanValidateBST()
            {
                Node root = new Node(4);
                root.Left = new Node(2);
                root.Left.Left = new Node(1);
                root.Left.Right = new Node(3);

                root.Right = new Node(6);
                root.Right.Left = new Node(5);
                root.Right.Right = new Node(7);



                BinarySearchTree bst = new BinarySearchTree();

                Assert.That(bst.ValidateBST(root), Is.True);
            }
        }

        public class Node
        {
            public int val;
            public Node Left;
            public Node Right;
            public int Count;

            public Node(int val)
            {
                this.val = val;
                Count = 1;
            }
        }

        private Node root = null;

        public void Put(int val)
        {
            root = Put(root, val);
        }

        private Node Put(Node node, int val)
        {

            if (node == null)
                return new Node(val);

            if (val <= node.val)
                node.Left = Put(node.Left, val);
            else
                node.Right = Put(node.Right, val);

            return node;
        }

        public int GetTreeHeight(Node node)
        {
            if (node == null)
                return 0;

            int leftHeight = GetTreeHeight(node.Left);
            int rightHeight = GetTreeHeight(node.Right);

            if (leftHeight > rightHeight)
                return leftHeight + 1;
            else
                return rightHeight + 1;
        }

        public Node CreateMinimalTree(int[] sortedArray)
        {
            return createMinimalTree(sortedArray, 0, sortedArray.Length - 1);
        }

        private Node createMinimalTree(int[] sortedArray, int start, int end)
        {
            if (end < start)
                return null;

            int mid = (start + end) / 2;
            Node n = new Node(sortedArray[mid]);
            n.Left = createMinimalTree(sortedArray, start, mid - 1);
            n.Right = createMinimalTree(sortedArray, mid + 1, end);

            return n;
        }

        public bool ValidateBST(Node node)
        {
            if (node == null || node.Left == null || node.Right == null)
                return true;

            if (node.Left.val > node.val || node.Right.val < node.val)
                return false;

            bool leftTreeBST = ValidateBST(node.Left);
            bool rightTreeBST = ValidateBST(node.Right);

            if (leftTreeBST && rightTreeBST)
                return true;
            else
                return 
                    false;
        }
    }
}
