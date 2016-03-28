using System;

namespace KeepPractising.Trees
{
    class ConstructBinaryTree<T>
    {
        int preIndex = 0;

        public MyBinaryTree<T> ConstructBinaryTreeFromInAndPre(T[] inOrder, T[] preOrder)
        {
            if (inOrder == null || preOrder == null || inOrder.Length == 0 || preOrder.Length == 0)
                return null;

            preIndex = 0;
            var root = ConstructNodeFromInAndPre(inOrder, preOrder, 0, inOrder.Length - 1);
            return new MyBinaryTree<T>() { Root = root };
        }

        private MyBinaryTreeNode<T> ConstructNodeFromInAndPre(T[] inOrder, T[] preOrder, int inStart, int inEnd)
        {
            // Done because inStart and inIndex - 1 || inIndex + 1 and inEnd might lead to this issue when inIndex and inStart || inIndex and inEnd are same.
            if (inStart > inEnd)
                return null;

            var node = new MyBinaryTreeNode<T>(preOrder[preIndex]);
            preIndex++;

            if (inStart == inEnd)
                return node;

            var inIndex = FindNodeInInOrderSubArray(inOrder, inStart, inEnd, node.Data);

            node.LeftNode = ConstructNodeFromInAndPre(inOrder, preOrder, inStart, inIndex - 1);
            node.RightNode = ConstructNodeFromInAndPre(inOrder, preOrder, inIndex + 1, inEnd);

            return node;
        }

        private int FindNodeInInOrderSubArray(T[] inOrder, int inStart, int inEnd, T data)
        {
            var index = Array.IndexOf(inOrder, data);
            if (index != -1)
                return index >= inStart && index <= inEnd ? index : -1;
            else
                return -1;
        }
    }
}
