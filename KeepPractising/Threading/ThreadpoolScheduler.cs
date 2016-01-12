using System;
using System.Diagnostics;
using System.Threading;

namespace KeepPractising.Threading
{
    public class ThreadpoolScheduler
    {
        public ThreadpoolScheduler(int tasksCount)
        {
            TasksCount = tasksCount;
        }

        public int TasksCount { get; private set; }

        public void TrySchedulingAndProcessing(int workerThreads, int completionPortThreads, Action processingAction)
        {
            ManualResetEvent[] doneEvents = new ManualResetEvent[TasksCount];
            bool setMaxWorkerThreads = ThreadPool.SetMaxThreads(workerThreads, completionPortThreads);

            Console.WriteLine("Scheduling some long running tasks!");
            for (int i = 0; i < TasksCount; i++)
            {
                doneEvents[i] = new ManualResetEvent(false);

                ThreadPoolProcessor processor = new ThreadPoolProcessor(doneEvents[i], processingAction);
                ThreadPool.QueueUserWorkItem(new WaitCallback(processor.SomeLongTask), i);
            }

            WaitHandle.WaitAll(doneEvents);
            Console.WriteLine("All processings are done!");
        }
    }

    public class ThreadPoolProcessor
    {
        private ManualResetEvent _doneEvenet;
        private Action _processingAction;

        public ThreadPoolProcessor(ManualResetEvent doneEvent, Action processingAction)
        {
            _doneEvenet = doneEvent;
            _processingAction = processingAction;
        }

        public void SomeLongTask(object state)
        {
            Console.WriteLine((int)state + " thread started!");
            Stopwatch wtch = new Stopwatch();
            wtch.Start();

            _processingAction.Invoke();

            wtch.Stop();
            Console.WriteLine("Milliseconds elapsed for state " + (int)state + " is - " + wtch.ElapsedMilliseconds);
            Console.WriteLine((int)state + " thread completed!");
            _doneEvenet.Set();
        }
    }
}
