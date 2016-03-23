using System.Collections.ObjectModel;

namespace KeepPractising.Trees
{
    public class NodeList<T> : Collection<MyNode<T>>
    {
        public NodeList() { }

        public NodeList(int initialSize)
        {
            for (int i = 0; i < initialSize; i++)
                Items.Add(default(MyNode<T>));
        }

        public MyNode<T> FindByData(T data)
        {
            foreach (var node in Items)
                if (node != null && node.Data.Equals(data))
                    return node;

            return null;
        }
    }
}
