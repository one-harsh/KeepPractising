using Console = System.Console;

namespace KeepPractising.Trees
{
    class MyTreeTestSuite
    {
        private static MyBinaryTree<int> GetADummyTree()
        {
            var tree = new MyBinaryTree<int>();
            tree.Root = new MyBinaryTreeNode<int>(15);
            tree.Root.LeftNode = new MyBinaryTreeNode<int>(10);
            tree.Root.RightNode = new MyBinaryTreeNode<int>(20);
            tree.Root.LeftNode.LeftNode = new MyBinaryTreeNode<int>(8);
            tree.Root.LeftNode.RightNode = new MyBinaryTreeNode<int>(12);
            tree.Root.RightNode.LeftNode = new MyBinaryTreeNode<int>(18);
            tree.Root.RightNode.RightNode = new MyBinaryTreeNode<int>(22);

            return tree;
        }

        public static void TestInOrderRecursiveTraversal()
        {
            var tree = GetADummyTree();
            var inOrder = new InOrderTraversal<int>(tree);
            inOrder.PrintInOrderRecursively();
        }

        public static void TestInOrderIterativeTraversal()
        {
            var tree = GetADummyTree();
            var inOrder = new InOrderTraversal<int>(tree);
            inOrder.PrintInOrderIteratively();
        }

        public static void TestPreOrderRecursiveTraversal()
        {
            var tree = GetADummyTree();
            var preOrder = new PreOrderTraversal<int>(tree);
            preOrder.PrintPreOrderRecursively();
        }

        public static void TestPreOrderIterativeTraversal()
        {
            var tree = GetADummyTree();
            var preOrder = new PreOrderTraversal<int>(tree);
            preOrder.PrintPreOrderIteratively();
        }

        public static void TestPostOrderRecursiveTraversal()
        {
            var tree = GetADummyTree();
            var preOrder = new PostOrderTraversal<int>(tree);
            preOrder.PrintPostOrderRecursively();
        }

        public static void TestPostOrderIterativeTraversal()
        {
            var tree = GetADummyTree();
            var preOrder = new PostOrderTraversal<int>(tree);
            preOrder.PrintPostOrderIteratively();
        }

        public static void TestBinarySearchTree()
        {
            var bst = new MyBinarySearchTree<int>(15);
            bst.Insert(8);
            bst.Insert(12);
            bst.Insert(10);
            bst.Insert(18);
            bst.Insert(22);
            bst.Insert(20);

            var find = bst.Search(12);
            if (find != null)
                Console.WriteLine("The node with value 12 was found in the BST!");

            bst.Delete(8);
            find = bst.Search(8);
            if (find == null)
                Console.WriteLine("The node with value 8 was deleted from the BST!");
            
            bst.Delete(15);
            find = bst.Search(15);
            if (find == null)
                Console.WriteLine("The root node with value 15 was deleted from the BST!");
        }
    }
}
