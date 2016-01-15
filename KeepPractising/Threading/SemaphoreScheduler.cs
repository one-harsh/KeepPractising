using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace KeepPractising.Threading
{
    class SemaphoreScheduler
    {
        MySemaphore semaphore;

        public SemaphoreScheduler(int tasksCount)
        {
            TasksCount = tasksCount;
        }

        public int TasksCount { get; private set; }

        public void TrySchedulingAndProcessing(int maxConcurrentTasks, Action processingAction)
        {
            semaphore = new MySemaphore(maxConcurrentTasks, maxConcurrentTasks);
            List<Task> tasks = new List<Task>();

            for (int i = 0; i < TasksCount; i++)
                tasks.Add(Task.Run(() => ScheduleTask(processingAction)));

            Task.WaitAll(tasks.ToArray());
        }

        private void ScheduleTask(Action processingAction)
        {
            semaphore.Wait();
            processingAction();
            semaphore.TryRelease();
        }
    }
}
