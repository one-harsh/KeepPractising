using System;
using System.Reflection;

namespace KeepPractising
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter the method that contains the testing code!");
            string methodName = Console.ReadLine();
            methodName = methodName.Trim();

            MethodInfo method = typeof(Program).GetMethod(methodName, BindingFlags.Static | BindingFlags.NonPublic);
            method.Invoke(null, new object[] { });

            Console.Read();
        }

        static void TestStack()
        {
            Console.WriteLine("Testing stack operations!\n");

            MyStack<int> stack = new MyStack<int>();
            stack.Push(10);
            Console.WriteLine(stack.Pop());
            stack.Push(20);
            stack.Push(25);
            Console.WriteLine(stack.Pop());
            Console.WriteLine(stack.Pop());
            try
            {
                Console.WriteLine(stack.Pop());
            }
            catch (Exception)
            {
                Console.WriteLine("Test of deliberate pop on empty stack successful!");
            }
        }

        static void TestQueue()
        {
            Console.WriteLine("Testing queue operations!\n");

            MyQueue<int> queue = new MyQueue<int>();
            queue.Enqueue(10);
            Console.WriteLine(queue.Dequeue());
            queue.Enqueue(20);
            queue.Enqueue(25);
            Console.WriteLine(queue.Dequeue());
            Console.WriteLine(queue.Dequeue());
            try
            {
                Console.WriteLine(queue.Dequeue());
            }
            catch (Exception)
            {
                Console.WriteLine("Test of deliberate dequeue on empty queue successful!");
            }
        }

        static void TestLinkedList()
        {
            Console.WriteLine("Testing linked list operations!\n");

            MyLinkedList<int> list = new MyLinkedList<int>();
            list.AddFirst(10);
            list.AddFirst(20);
            list.AddLast(10);
            list.AddLast(20);

            list.PrintList();

            Console.WriteLine("Testing removal from linked list!");
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
    }
}
