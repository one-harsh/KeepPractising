namespace KeepPractising.Trees
{
    public class MyBinaryTree<T> : MyTree<T>
    {
        public new MyBinaryTreeNode<T> Root { get; set; }

        public new void Clear()
        {
            Root = null;
            base.Clear();
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

        public new NodeList<T> Neighbors
        {
            get
            {
                return base.Neighbors;
            }
            set
            {
                if (value.Count > 2)
                    throw new System.Exception("Binary Trees cannot have more than 2 nodes.");

                base.Neighbors = value;
            }
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
