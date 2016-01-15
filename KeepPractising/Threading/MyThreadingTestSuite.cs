using System;
using System.Threading;

namespace KeepPractising.Threading
{
    class MyThreadingTestSuite
    {
        public Random Random { get; private set; }

        public MyThreadingTestSuite()
        {
            Random = new Random();
        }

        private Action GetLongRunningAction()
        {
            return (() => {
                Thread.Sleep(10000);
                int num = Random.Next(100, 450);
                long a = 1, b = 1;
                var copy = num;

                while (num > 2)
                {
                    long temp = a;
                    a = b;
                    b = a + temp;

                    num--;
                }

                Console.WriteLine(copy + " fibonacci number - " + b);
            });
        }

        public static void TestThreadpoolScheduler()
        {
            MyThreadingTestSuite test = new MyThreadingTestSuite();

            ThreadpoolScheduler scheduler = new ThreadpoolScheduler(50);
            scheduler.TrySchedulingAndProcessing(10, 15, test.GetLongRunningAction());

            Console.WriteLine("Main thread work done!");
        }

        public static void TestSemaphoreScheduler()
        {
            MyThreadingTestSuite test = new MyThreadingTestSuite();

            SemaphoreScheduler scheduler = new SemaphoreScheduler(50);
            scheduler.TrySchedulingAndProcessing(10, test.GetLongRunningAction());

            Console.WriteLine("Main thread work done!");
        }

        public static void TestSynchronizeOutput()
        {
            SynchronizeOutput sync = new SynchronizeOutput(5);
            sync.ProducePrintStream();
        }
    }
}
