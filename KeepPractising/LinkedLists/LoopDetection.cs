namespace KeepPractising.LinkedLists
{
    class LoopDetection
    {
        public static bool DetectLoop<T>(MyLinkedList<T> list)
        {
            var fastHeadNode = list.FirstNode;
            var slowHeadNode = list.FirstNode;

            while (fastHeadNode != null && fastHeadNode.Next != null)
            {
                slowHeadNode = slowHeadNode.Next;
                fastHeadNode = fastHeadNode.Next.Next;

                if (slowHeadNode == fastHeadNode)
                    return true;
            }

            return false;
        }
    }
}
