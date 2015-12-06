using System;

namespace KeepPractising
{
    class MyLinkedList<T>
    {
        private MyNode<T> firstNode, lastNode;

        public T First
        {
            get
            {
                return firstNode.Object;
            }
        }

        public T Last
        {
            get
            {
                return lastNode.Object;
            }
        }

        private class MyNode<N>
        {
            public N Object { get; set; }

            public MyNode<N> Next { get; set; }

            public MyNode(N obj)
            {
                Object = obj;
            }
        }

        public void AddFirst(T obj)
        {
            MyNode<T> node = new MyNode<T>(obj);
            node.Next = firstNode;

            firstNode = node;

            if (lastNode == null)
                lastNode = node; 
        }

        public void AddLast(T obj)
        {
            MyNode<T> node = new MyNode<T>(obj);
            if (lastNode != null)
                lastNode.Next = node;
            else
                lastNode = node;

            if (firstNode == null)
                firstNode = node;

            lastNode = node;
        }

        public T RemoveFirst()
        {
            if (firstNode != null)
            {
                var obj = firstNode;
                firstNode = firstNode.Next;
                lastNode = firstNode == null ? null : lastNode;
                return obj.Object;
            }
            else
                throw new Exception("RemoveFirst operation not allowed on empty linked list!");
        }

        public T RemoveLast()
        {
            if (lastNode != null)
            {
                T val;
                var node = firstNode;
                while (node.Next != null)
                {
                    if (node.Next == lastNode)
                        break;
                    else
                        node = node.Next;
                }

                if (node == lastNode)
                {
                    val = node.Object;
                    lastNode = null;
                    firstNode = null;
                }
                else
                {
                    val = node.Next.Object;
                    lastNode = node;
                }

                if (lastNode != null)
                    lastNode.Next = null;

                return val;
            }
            else
                throw new Exception("RemoveLast operation not allowed on empty linked list!");
        }


        public void PrintList()
        {
            Console.WriteLine("Printing the linked list!");
            if (firstNode == null)
            {
                Console.WriteLine("The list is empty!");
                return;
            }

            MyNode<T> node = firstNode;
            while (node != null)
            {
                Console.WriteLine(node.Object);
                node = node.Next;
            }
        }
    }
}
