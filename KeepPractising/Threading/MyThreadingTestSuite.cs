using System;

namespace KeepPractising.Threading
{
    class MyThreadingTestSuite
    {
        public static void TestThreadpoolScheduler()
        {
            ThreadpoolScheduler scheduler = new ThreadpoolScheduler();
            scheduler.TrySchedulingAndProcessing(5, 10);

            Console.WriteLine("Main thread work done!");
        }
    }
}
