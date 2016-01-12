using KeepPractising.Stacks;
using System;

namespace KeepPractising.Trees
{
    class InOrderTraversal<T>
    {
        public InOrderTraversal(MyTreeNode<T> root)
        {
            Root = root;
        }

        public MyTreeNode<T> Root { get; private set; }

        public void PrintInOrderRecursively()
        {
            if (Root == null)
            {
                Console.WriteLine("The tree is empty!");
                return;
            }

            PrintTraversalRecursively(Root);
        }

        private void PrintTraversalRecursively(MyTreeNode<T> root)
        {
            if (root == null)
                return;

            PrintTraversalRecursively(root.LeftNode);
            Console.WriteLine(root.Data);
            PrintTraversalRecursively(root.RightNode);
        }

        public void PrintInOrderIteratively()
        {
            if (Root == null)
            {
                Console.WriteLine("The tree is empty!");
                return;
            }

            var stack = new MyStack<MyTreeNode<T>>();
            var node = Root;

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
