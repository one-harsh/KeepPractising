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
    }
}
