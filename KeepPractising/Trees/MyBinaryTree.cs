namespace KeepPractising.Trees
{
    public class MyBinaryTree<T>
    {
        public MyBinaryTreeNode<T> Root { get; set; }

        public void Clear()
        {
            Root = null;
        }
    }

    public class MyBinaryTreeNode<T> : MyNode<T>
    {
        public MyBinaryTreeNode(T data) : base(data)
        {
            Data = data;
            Neighbors = new NodeList<T>(2);
            Neighbors[0] = LeftNode;
            Neighbors[1] = RightNode;
        }

        public MyBinaryTreeNode<T> LeftNode
        {
            get
            {
                return Neighbors == null ? null : Neighbors[0] as MyBinaryTreeNode<T>;
            }
            set
            {
                if (Neighbors == null)
                    Neighbors = new NodeList<T>(2);
                Neighbors[0] = value;
            }
        }

        public MyBinaryTreeNode<T> RightNode
        {
            get
            {
                return Neighbors == null ? null : Neighbors[1] as MyBinaryTreeNode<T>;
            }
            set
            {
                if (Neighbors == null)
                    Neighbors = new NodeList<T>(2);
                Neighbors[1] = value;
            }
        }
    }
}
