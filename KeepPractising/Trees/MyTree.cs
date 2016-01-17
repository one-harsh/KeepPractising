namespace KeepPractising.Trees
{
    public class MyTree<T>
    {
        public MyNode<T> Root { get; set; }

        public void Clear()
        {
            Root = null;
        }
    }

    public class MyNode<T>
    {
        public MyNode(T data)
        {
            Data = data;
        }

        public T Data { get; protected set; }

        public NodeList<T> Neighbors { get; set; }
    }
}
