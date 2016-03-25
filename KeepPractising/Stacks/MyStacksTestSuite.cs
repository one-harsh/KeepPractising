using System;

namespace KeepPractising.Stacks
{
    class MyStacksTestSuite
    {
        public static void TestStack()
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

        public static void TestKStacks()
        {
            Console.WriteLine("Testing K Stacks in an array!\n");

            MyKStacksInArray<int> kStacks = new MyKStacksInArray<int>(15, 3);
            kStacks.Push(15, 1);
            Console.WriteLine(kStacks.Pop(1));
            try
            {
                Console.WriteLine(kStacks.Pop(1));
            }
            catch (Exception)
            {
                Console.WriteLine("Stack underflow test detection successful!");
            }

            kStacks.Push(5, 2);
            kStacks.Push(10, 1);
            kStacks.Push(15, 1);
            kStacks.Push(20, 1);
            kStacks.Push(25, 2);
            kStacks.Push(30, 2);
            kStacks.Push(35, 3);
            kStacks.Push(40, 2);
            kStacks.Push(45, 3);
            kStacks.Push(50, 1);
            kStacks.Push(55, 2);
            kStacks.Push(60, 2);
            kStacks.Push(65, 1);
            kStacks.Push(70, 3);
            kStacks.Push(75, 1);
            try
            {
                kStacks.Push(80, 3);
            }
            catch (Exception)
            {
                Console.WriteLine("Stack overflow test detection successful!");
            }

            Console.WriteLine(kStacks.Pop(1));
            Console.WriteLine(kStacks.Pop(1));
            Console.WriteLine(kStacks.Pop(2));
            Console.WriteLine(kStacks.Pop(3));
            Console.WriteLine(kStacks.Pop(3));
            Console.WriteLine(kStacks.Pop(1));
            Console.WriteLine(kStacks.Pop(3));
            try
            {
                Console.WriteLine(kStacks.Pop(3));
            }
            catch (Exception)
            {
                Console.WriteLine("Stack underflow test detection successful!");
            }
        }

        public static void TestStackWithMinMethod()
        {
            StackWithMinMethod<int> stack = new StackWithMinMethod<int>();
            stack.Push(10);
            stack.Push(20);
            stack.Push(25);
            stack.Push(5);
            stack.Push(20);
            stack.Push(0);
            stack.Push(100);
            stack.Push(-5);
            Console.WriteLine("Min " + stack.GetMin());
            Console.WriteLine("Pop " + stack.Pop());
            Console.WriteLine("Min " + stack.GetMin());
            Console.WriteLine("Pop " + stack.Pop());
            Console.WriteLine("Min " + stack.GetMin());
            Console.WriteLine("Pop " + stack.Pop());
            Console.WriteLine("Min " + stack.GetMin());
        }
    }
}
