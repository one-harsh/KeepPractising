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

        public static void TestQueueUsingArrays()
        {
            var queue = new MyQueueUsingArray<int>(5);
            queue.Enqueue(10);
            queue.Enqueue(20);
            queue.Enqueue(25);
            Console.WriteLine(queue.Dequeue());
            queue.Enqueue(20);
            queue.Enqueue(0);
            queue.Enqueue(100);

            try
            {
                queue.Enqueue(-5);
            }
            catch (Exception)
            {
                Console.WriteLine("Caught an overflow exception!");
            }

            Console.WriteLine(queue.Dequeue());
            Console.WriteLine(queue.Dequeue());
            Console.WriteLine(queue.Dequeue());
            Console.WriteLine(queue.Dequeue());
            Console.WriteLine(queue.Dequeue());

            try
            {
                Console.WriteLine(queue.Dequeue());
            }
            catch (Exception)
            {
                Console.WriteLine("Caught an underflow exception!");
            }
        }
    }
}
