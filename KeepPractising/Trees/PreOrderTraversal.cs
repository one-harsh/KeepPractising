using KeepPractising.Stacks;
using System;

namespace KeepPractising.Trees
{
    class PreOrderTraversal<T>
    {
        public PreOrderTraversal(MyTreeNode<T> root)
        {
            Root = root;
        }

        public MyTreeNode<T> Root { get; private set; }

        public void PrintPreOrderRecursively()
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

            Console.WriteLine(root.Data);
            PrintTraversalRecursively(root.LeftNode);
            PrintTraversalRecursively(root.RightNode);
        }

        public void PrintPreOrderIteratively()
        {
            if (Root == null)
            {
                Console.WriteLine("The tree is empty!");
                return;
            }

            var stack = new MyStack<MyTreeNode<T>>();
            var node = Root;

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
