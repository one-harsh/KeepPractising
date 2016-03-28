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

        public static void TestTries()
        {
            var tries = new MyTrie();
            Console.WriteLine("Adding \"word\"");
            tries.Add("word");
            Console.WriteLine("Adding \"wordament\"");
            tries.Add("wordament");
            Console.WriteLine("Adding \"puzzle\"");
            tries.Add("puzzle");
            Console.WriteLine("Adding \"Skadoosh\"");
            tries.Add("Skadoosh");
            Console.WriteLine("Adding \"Funtoosh\"");
            tries.Add("Funtoosh");

            try
            {
                tries.Add("Fun2sh");
            }
            catch (System.Exception ex)
            {
                if (ex.Message.Contains("Only characters are currently supported."))
                    Console.WriteLine("Caught an expected \"not supported character\" exception while adding \"Fun2sh\".");
            }

            Console.WriteLine("Searching for the word - \"word\"");
            Console.WriteLine(tries.Search("word"));
            Console.WriteLine("Searching for the word - \"Word\"");
            Console.WriteLine(tries.Search("Word"));
            Console.WriteLine("Searching for the word - \"Wordamenting\"");
            Console.WriteLine(tries.Search("Wordamenting"));
            Console.WriteLine("Searching for the word - \"Wor\"");
            Console.WriteLine(tries.Search("Wor"));
            Console.WriteLine("Counting the number of words that start with - \"Wor\"");
            Console.WriteLine(tries.WordCountWithPrefix("Wor"));
            Console.WriteLine("Counting the number of words that start with - \"Wordament\"");
            Console.WriteLine(tries.WordCountWithPrefix("Wordament"));
            Console.WriteLine("Counting the number of words that start with - \"Wordamenting\"");
            Console.WriteLine(tries.WordCountWithPrefix("Wordamenting"));
        }

        public static void TestBinaryTreeGenerationFromInAndPreOrder()
        {
            var inOrder = new int[] { 6, 8, 10, 11, 12, 15 };
            var preOrder = new int[] { 10, 8, 6, 12, 11, 15 };

            var inOrder1 = new int[] { 10, 11, 12, 15 };
            var preOrder1 = new int[] { 10, 12, 11, 15 };

            var obj = new ConstructBinaryTree<int>();
            var tree = obj.ConstructBinaryTreeFromInAndPre(inOrder, preOrder);
            Console.WriteLine("Inorder traversal for tree");
            new InOrderTraversal<int>(tree).PrintInOrderRecursively();

            var tree1 = obj.ConstructBinaryTreeFromInAndPre(inOrder1, preOrder1);
            Console.WriteLine("Inorder traversal for tree1");
            new InOrderTraversal<int>(tree1).PrintInOrderRecursively();
        }
    }
}
