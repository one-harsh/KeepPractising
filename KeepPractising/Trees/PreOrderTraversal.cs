using KeepPractising.Stacks;
using System;

namespace KeepPractising.Trees
{
    class PreOrderTraversal<T>
    {
        public PreOrderTraversal(MyBinaryTree<T> tree)
        {
            Tree = tree;
        }

        public MyBinaryTree<T> Tree { get; private set; }

        public void PrintPreOrderRecursively()
        {
            if (Tree == null)
            {
                Console.WriteLine("The tree is empty!");
                return;
            }

            PrintTraversalRecursively(Tree.Root);
        }

        private void PrintTraversalRecursively(MyBinaryTreeNode<T> root)
        {
            if (root == null)
                return;

            Console.WriteLine(root.Data);
            PrintTraversalRecursively(root.LeftNode);
            PrintTraversalRecursively(root.RightNode);
        }

        public void PrintPreOrderIteratively()
        {
            if (Tree == null)
            {
                Console.WriteLine("The tree is empty!");
                return;
            }

            var stack = new MyStack<MyBinaryTreeNode<T>>();
            var node = Tree.Root;

            stack.Push(node);
            
            while (!stack.Empty())
            {
                node = stack.Pop();
                Console.WriteLine(node.Data);

                if (node.RightNode != null)
                    stack.Push(node.RightNode);
                if (node.LeftNode != null)
                    stack.Push(node.LeftNode);
            }
        }
    }
}
