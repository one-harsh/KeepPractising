using System;

namespace KeepPractising.LinkedLists
{
    class MyLinkedList<T>
    {
        private MyNode firstNode, lastNode;

        private interface INodeAction
        {
            void SetNextNode(MyNode node);
        }

        public class MyNode : INodeAction
        {
            private MyNode nextNode;
            private T obj;

            public T Object
            {
                get
                {
                    return obj;
                }
            }

            public MyNode Next
            {
                get
                {
                    return nextNode;
                }
            }

            public MyNode(T obj)
            {
                this.obj = obj;
            }

            void INodeAction.SetNextNode(MyNode nextNode)
            {
                this.nextNode = nextNode;
            }
        }

        public T First
        {
            get
            {
                return firstNode.Object;
            }
        }

        public MyNode FirstNode
        {
            get
            {
                return firstNode;
            }
        }

        public T Last
        {
            get
            {
                return lastNode.Object;
            }
        }

        public MyNode LastNode
        {
            get
            {
                return lastNode;
            }
        }

        public int Length
        {
            get
            {
                int count = 0;
                MyNode node = FirstNode;
                while (node != null)
                {
                    count++;
                    node = node.Next;
                }

                return count;
            }
        }

        public void AddFirst(T obj)
        {
            INodeAction node = new MyNode(obj);
            node.SetNextNode(firstNode);

            firstNode = node as MyNode;

            if (lastNode == null)
                lastNode = node as MyNode;
        }

        public void AddLast(T obj)
        {
            MyNode node = new MyNode(obj);
            if (lastNode != null)
                (lastNode as INodeAction).SetNextNode(node);
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
                    (lastNode as INodeAction).SetNextNode(null);

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

            MyNode node = firstNode;
            while (node != null)
            {
                Console.WriteLine(node.Object);
                node = node.Next;
            }
        }
    }
}
