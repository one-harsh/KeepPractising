using KeepPractising.Stacks;
using System;

namespace KeepPractising.Trees
{
    class PostOrderTraversal<T>
    {
        public PostOrderTraversal(MyTreeNode<T> root)
        {
            Root = root;
        }

        public MyTreeNode<T> Root { get; private set; }

        public void PrintPostOrderRecursively()
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
            PrintTraversalRecursively(root.RightNode);
            Console.WriteLine(root.Data);
        }

        public void PrintPostOrderIteratively()
        {
            if (Root == null)
            {
                Console.WriteLine("The tree is empty!");
                return;
            }

            var stack1 = new MyStack<MyTreeNode<T>>();
            var stack2 = new MyStack<MyTreeNode<T>>();
            var node = Root;

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
