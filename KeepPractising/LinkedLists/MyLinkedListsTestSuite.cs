using System;
using System.Linq;

namespace KeepPractising.LinkedLists
{
    class MyLinkedListsTestSuite
    {
        public static void TestLinkedList()
        {
            Console.WriteLine("Testing linked list operations!\n");

            MyLinkedList<int> list = new MyLinkedList<int>();
            list.AddFirst(10);
            list.AddFirst(20);
            list.AddLast(10);
            list.AddLast(20);

            list.PrintList();

            Console.WriteLine("\nTesting removal from linked list!");
            Console.WriteLine(list.RemoveFirst());
            Console.WriteLine(list.RemoveFirst());
            Console.WriteLine(list.RemoveLast());
            Console.WriteLine(list.RemoveLast());

            try
            {
                list.RemoveFirst();
            }
            catch (Exception)
            {
                Console.WriteLine("Test of deliberate removal of a node on empty list successful!");
            }

            list.PrintList();
        }

        public static void TestLinkedListIntersectionPoint()
        {
            Console.WriteLine("Testing for linked list intersection point!");

            MyLinkedList<int> list1 = new MyLinkedList<int>();
            MyLinkedList<int> list2 = new MyLinkedList<int>();

            list1.AddLast(10);
            list1.AddLast(12);
            list1.AddLast(14);
            list1.AddLast(16);
            list1.AddLast(18);

            list2.AddLast(20);
            list2.AddLast(22);
            list2.AddLast(24);

            Console.WriteLine(IntersectionPoint.CheckIntersection(list1, list2));

            Console.WriteLine("\nTesting for the intersection list point after creating a valid intersection!");
            var method = list2.LastNode.GetType()
                                .GetMethods(System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance)
                                .FirstOrDefault(r => r.Name == "KeepPractising.LinkedLists.MyLinkedList<T>.INodeAction.SetNextNode");
            method.Invoke(list2.LastNode, new object[] { list1.FirstNode.Next.Next.Next });

            var field = list2.GetType().GetField("lastNode", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance);
            field.SetValue(list2, list2.FirstNode.Next.Next.Next.Next);

            Console.WriteLine(IntersectionPoint.CheckIntersection(list1, list2));
        }

        public static void TestLinkedListLoopDetection()
        {
            Console.WriteLine("Testing for linked list loop!");

            MyLinkedList<int> list = new MyLinkedList<int>();

            list.AddLast(10);
            list.AddLast(12);
            list.AddLast(14);
            list.AddLast(16);
            list.AddLast(18);

            Console.WriteLine(LoopDetection.DetectLoop(list));

            Console.WriteLine("\nTesting for loop in a linked list after creating a loop!");

            var method = list.LastNode.GetType()
                                .GetMethods(System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance)
                                .FirstOrDefault(r => r.Name == "KeepPractising.LinkedLists.MyLinkedList<T>.INodeAction.SetNextNode");
            method.Invoke(list.LastNode, new object[] { list.FirstNode.Next });

            Console.WriteLine(LoopDetection.DetectLoop(list));
        }
    }
}
