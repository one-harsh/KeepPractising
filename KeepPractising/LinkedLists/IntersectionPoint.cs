namespace KeepPractising.LinkedLists
{
    class IntersectionPoint
    {
        public static bool CheckIntersection<T>(MyLinkedList<T> list1, MyLinkedList<T> list2)
        {
            bool flagHead1;
            MyLinkedList<T>.MyNode tempNode = null, node1, node2;
            int diff = GetCountDifferenceOfLists(list1, list2, out flagHead1, out tempNode);

            while (tempNode != null && diff != 0)
            {
                diff--;
                tempNode = tempNode.Next;
            }

            if (flagHead1)
            {
                node1 = tempNode;
                node2 = list2.FirstNode;
            }
            else
            {
                node1 = list1.FirstNode;
                node2 = tempNode;
            }

            while (node1 != null)
            {
                if (node1 == node2)
                    return true;

                node1 = node1.Next;
                node2 = node2.Next;
            }

            return false;
        }

        private static int GetCountDifferenceOfLists<T>(MyLinkedList<T> list1, MyLinkedList<T> list2, out bool flagHead1, out MyLinkedList<T>.MyNode tempNode)
        {
            flagHead1 = true;
            int count1 = list1.Length, count2 = list2.Length;

            if (count2 > count1)
            {
                tempNode = list2.FirstNode;
                flagHead1 = false;
                return count2 - count1;
            }
            else
            {
                tempNode = list1.FirstNode;
                return count1 - count2;
            }
        }
    }
}
