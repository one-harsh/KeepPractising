namespace KeepPractising.Trees
{
    class MyTreeTestSuite
    {
        private static MyTreeNode<int> GetADummyTree()
        {
            MyTreeNode<int> root = new MyTreeNode<int>(15);
            root.LeftNode = new MyTreeNode<int>(10);
            root.RightNode = new MyTreeNode<int>(20);
            root.LeftNode.LeftNode = new MyTreeNode<int>(8);
            root.LeftNode.RightNode = new MyTreeNode<int>(12);
            root.RightNode.LeftNode = new MyTreeNode<int>(18);
            root.RightNode.RightNode = new MyTreeNode<int>(22);

            return root;
        }

        public static void TestInOrderRecursiveTraversal()
        {
            var root = GetADummyTree();
            var inOrder = new InOrderTraversal<int>(root);
            inOrder.PrintInOrderRecursively();
        }

        public static void TestInOrderIterativeTraversal()
        {
            var root = GetADummyTree();
            var inOrder = new InOrderTraversal<int>(root);
            inOrder.PrintInOrderIteratively();
        }

        public static void TestPreOrderRecursiveTraversal()
        {
            var root = GetADummyTree();
            var preOrder = new PreOrderTraversal<int>(root);
            preOrder.PrintPreOrderRecursively();
        }

        public static void TestPreOrderIterativeTraversal()
        {
            var root = GetADummyTree();
            var preOrder = new PreOrderTraversal<int>(root);
            preOrder.PrintPreOrderIteratively();
        }

        public static void TestPostOrderRecursiveTraversal()
        {
            var root = GetADummyTree();
            var preOrder = new PostOrderTraversal<int>(root);
            preOrder.PrintPostOrderRecursively();
        }

        public static void TestPostOrderIterativeTraversal()
        {
            var root = GetADummyTree();
            var preOrder = new PostOrderTraversal<int>(root);
            preOrder.PrintPostOrderIteratively();
        }
    }
}
