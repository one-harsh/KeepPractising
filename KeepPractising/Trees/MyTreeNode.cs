namespace KeepPractising.Trees
{
    class MyTreeNode<T>
    {
        public MyTreeNode(T data)
        {
            Data = data;
        }

        public T Data { get; private set; }

        public MyTreeNode<T> LeftNode { get; set; }

        public MyTreeNode<T> RightNode { get; set; }
    }
}
