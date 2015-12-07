using System;

namespace KeepPractising.Queues
{
    class MyQueuesTestSuite
    {
        public static void TestQueue()
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
    }
}
