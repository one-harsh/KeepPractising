using KeepPractising.Stacks;
using System;

namespace KeepPractising.Trees
{
    class InOrderTraversal<T>
    {
        public InOrderTraversal(MyBinaryTree<T> tree)
        {
            Tree = tree;
        }

        public MyBinaryTree<T> Tree { get; private set; }

        public void PrintInOrderRecursively()
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
            Console.WriteLine(root.Data);
            PrintTraversalRecursively(root.RightNode);
        }

        public void PrintInOrderIteratively()
        {
            if (Tree == null)
            {
                Console.WriteLine("The tree is empty!");
                return;
            }

            var stack = new MyStack<MyBinaryTreeNode<T>>();
            var node = Tree.Root;

            stack.Push(node);
            while(!stack.Empty())
            {
                while (node.LeftNode != null)
                {
                    node = node.LeftNode;
                    stack.Push(node);
                }

                while (!stack.Empty())
                {
                    node = stack.Pop();
                    Console.WriteLine(node.Data);

                    if (node.RightNode != null)
                    {
                        node = node.RightNode;
                        stack.Push(node);
                        break;
                    }
                }
            }
        }
    }
}
