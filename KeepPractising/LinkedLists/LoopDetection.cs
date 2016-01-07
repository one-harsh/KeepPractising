namespace KeepPractising.LinkedLists
{
    public class LoopDetection
    {
        public static bool DetectLoop<T>(MyLinkedList<T> list)
        {
            if (list == null)
                return false;

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
