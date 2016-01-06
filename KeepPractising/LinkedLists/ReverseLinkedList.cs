namespace KeepPractising.LinkedLists
{
    public static class ReverseLinkedList
    {
        public static MyLinkedList<T> Reverse<T>(this MyLinkedList<T> list)
        {
            if (list == null)
                return null;

            var initialFirstNode = list.FirstNode;
            var node = list.FirstNode;
            while(node.Next != null)
            {
                node = list.RemoveNextNode(node);
                list.AddFirst(node); // current node != null because it entered the while loop
                node = initialFirstNode;
            }

            return list;
        }
    }
}
