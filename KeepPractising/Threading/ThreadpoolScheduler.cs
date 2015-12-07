using System;
using System.Diagnostics;
using System.Threading;

namespace KeepPractising.Threading
{
    class ThreadpoolScheduler
    {
        public void TrySchedulingAndProcessing(int workerThreads, int completionPortThreads)
        {
            ManualResetEvent[] doneEvents = new ManualResetEvent[50];

            bool setMaxWorkerThreads = ThreadPool.SetMaxThreads(workerThreads, completionPortThreads);
            Random rand = new Random();

            Console.WriteLine("Scheduling some long running tasks!");
            for (int i = 0; i < 50; i++)
            {
                doneEvents[i] = new ManualResetEvent(false);

                ThreadPoolFibonacci tFib = new ThreadPoolFibonacci(doneEvents[i])
                {
                    Number = rand.Next(100, 450)
                };
                ThreadPool.QueueUserWorkItem(new WaitCallback(tFib.SomeLongTask), i);
            }

            WaitHandle.WaitAll(doneEvents);
            Console.WriteLine("All processings are done!");
        }
    }

    public class ThreadPoolFibonacci
    {
        private ManualResetEvent _doneEvenet;

        public ThreadPoolFibonacci(ManualResetEvent doneEvent)
        {
            _doneEvenet = doneEvent;
        }

        public int Number { get; set; }

        public void SomeLongTask(object state)
        {
            Stopwatch wtch = new Stopwatch();
            wtch.Start();

            Thread.Sleep(10000);
            Console.WriteLine((int)state + " started for number - " + Number);

            long a = 1, b = 1;
            int num = Number;

            if (num <= 0)
                Console.WriteLine(-1);

            while (num > 2)
            {
                long temp = a;
                a = b;
                b = a + temp;

                num--;
            }

            wtch.Stop();
            Console.WriteLine((int)state + " thread! " + Number + " fibonacci number - " + b);
            Console.WriteLine("Milliseconds elapsed for state " + (int)state + " is - " + wtch.ElapsedMilliseconds);
            _doneEvenet.Set();
        }
    }
}
