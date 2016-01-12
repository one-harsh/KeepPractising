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

                if (num <= 0)
                    Console.WriteLine(-1);

                while (num > 2)
                {
                    long temp = a;
                    a = b;
                    b = a + temp;

                    num--;
                }

                Console.WriteLine(num + " fibonacci number - " + b);
            });
        }
        public static void TestThreadpoolScheduler()
        {
            MyThreadingTestSuite test = new MyThreadingTestSuite();

            ThreadpoolScheduler scheduler = new ThreadpoolScheduler(50);
            scheduler.TrySchedulingAndProcessing(10, 15, test.GetLongRunningAction());

            Console.WriteLine("Main thread work done!");
        }
    }
}
