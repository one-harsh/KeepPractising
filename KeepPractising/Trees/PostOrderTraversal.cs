using KeepPractising.Stacks;
using System;

namespace KeepPractising.Trees
{
    class PostOrderTraversal<T>
    {
        public PostOrderTraversal(MyBinaryTree<T> tree)
        {
            Tree = tree;
        }

        public MyBinaryTree<T> Tree { get; private set; }

        public void PrintPostOrderRecursively()
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

            PrintTraversalRecursively(root.LeftNode);
            PrintTraversalRecursively(root.RightNode);
            Console.WriteLine(root.Data);
        }

        public void PrintPostOrderIteratively()
        {
            if (Tree == null)
            {
                Console.WriteLine("The tree is empty!");
                return;
            }

            var stack1 = new MyStack<MyBinaryTreeNode<T>>();
            var stack2 = new MyStack<MyBinaryTreeNode<T>>();
            var node = Tree.Root;

            stack1.Push(node);
            while (!stack1.Empty())
            {
                node = stack1.Pop();
                stack2.Push(node);

                if (node.LeftNode != null)
                    stack1.Push(node.LeftNode);
                if (node.RightNode != null)
                    stack1.Push(node.RightNode);
            }

            while (!stack2.Empty())
            {
                node = stack2.Pop();
                Console.WriteLine(node.Data);
            }
        }
    }
}
