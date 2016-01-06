using Console = System.Console;
using Exception = System.Exception;

namespace KeepPractising.LinkedLists
{
    public class MyLinkedList<T>
    {
        private MyNode firstNode, lastNode;

        private interface INodeAction
        {
            /// <summary>
            /// Sets toBeSetNode as the parent node to the current node.
            /// </summary>
            /// <param name="toBeSetNode"></param>
            void SetAsFirstNode(MyNode toBeSetNode);

            /// <summary>
            /// Inserts nextNode after the current node.
            /// </summary>
            /// <param name="nextNode"></param>
            void SetNextNode(MyNode nextNode);

            /// <summary>
            /// Removes the next node to the current node. The next node of the previous next node is set as its new next node.
            /// </summary>
            /// <returns></returns>
            MyNode RemoveNextNode();
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

            void INodeAction.SetAsFirstNode(MyNode toBeSetNode)
            {
                if (toBeSetNode == null)
                    throw new Exception("Cannot set null node as first node!");
                toBeSetNode.nextNode = this;
            }

            void INodeAction.SetNextNode(MyNode nextNode)
            {
                var temp = this.nextNode;
                this.nextNode = nextNode;
                if (nextNode != null)
                    nextNode.nextNode = temp;
            }

            MyNode INodeAction.RemoveNextNode()
            {
                var temp = nextNode;
                if (nextNode != null)
                    nextNode = nextNode.nextNode;
                return temp;
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
            var node = new MyNode(obj);
            AddFirst(node as MyNode);
        }

        public void AddFirst(MyNode node)
        {
            if (firstNode != null)
                (firstNode as INodeAction).SetAsFirstNode(node);

            firstNode = node;

            if (lastNode == null)
                lastNode = node;
        }

        public void AddLast(T obj)
        {
            var node = new MyNode(obj);
            AddLast(node);
        }

        public void AddLast(MyNode node)
        {
            if (lastNode != null)
                (lastNode as INodeAction).SetNextNode(node);
            else
                lastNode = node;

            if (firstNode == null)
                firstNode = node;

            lastNode = node;
        }

        private MyNode RemoveFirstNode()
        {
            if (firstNode != null)
            {
                var obj = firstNode;
                firstNode = firstNode.Next;
                lastNode = firstNode == null ? null : lastNode;
                return obj;
            }
            else
                throw new Exception("RemoveFirst operation not allowed on empty linked list!");
        }

        public T RemoveFirst()
        {
            return RemoveFirstNode().Object;
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
                    (lastNode as INodeAction).RemoveNextNode();

                return val;
            }
            else
                throw new Exception("RemoveLast operation not allowed on empty linked list!");
        }

        public void InsertAfter(MyNode node, T obj)
        {
            if (node == null)
                throw new Exception("Cannot insert after null node!");

            MyNode newNode = new MyNode(obj);
            InsertAfter(node, newNode);
        }

        public void InsertAfter(MyNode node, MyNode newNode)
        {
            if (node == null)
                throw new Exception("Cannot insert after null node!");

            (node as INodeAction).SetNextNode(newNode);
        }

        public MyNode RemoveNode(MyNode node)
        {
            if (node == null)
                return null;

            if (node == firstNode)
                return RemoveFirstNode();

            MyNode current = firstNode;
            while(current.Next != node)
            {
                current = current.Next;
            }

            if (current.Next == lastNode)
                lastNode = current;

            return RemoveNextNode(current);
        }

        public MyNode RemoveNextNode(MyNode node)
        {
            return (node as INodeAction).RemoveNextNode();
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
