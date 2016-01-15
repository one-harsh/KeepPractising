using System;

namespace KeepPractising.Threading
{
    /// <summary>
    /// A thread prints a stream of a particular natural number continuously. The next thread prints the next number continuously and so on.
    /// This class synchronizes their output so that each thread print their output in a specific round-robin fashion.
    /// <para>For example, if the first thread prints 111..., second prints 222... and so on. The output should be 123412341234..., if the total number of threads executing synchronously are 4. </para>
    /// </summary>
    class SynchronizeOutput
    {
        static int count = 0;
        MySemaphore[] semaphores;

        MyMutex mutex;
        MySemaphore semaphore;
        MySemaphore turnstile1, turnstile2;

        public SynchronizeOutput(int threadCount)
        {
            ThreadCount = threadCount;
            semaphore = new MySemaphore(1, 1);
            turnstile1 = new MySemaphore(0, 1);
            turnstile2 = new MySemaphore(1, 1);
            mutex = new MyMutex();
            semaphores = new MySemaphore[ThreadCount];
        }

        public int ThreadCount { get; private set; }

        /// <summary>
        /// This solution follows the approach used to solve the problem of reusable barrier mentioned in the publically available eBook - "Little Book of Semaphores".
        /// </summary>
        public void ProducePrintStream()
        {
            for (int i = 0; i < ThreadCount; i++)
                semaphores[i] = new MySemaphore(0, 1);

            semaphores[0].TryRelease();

            while (true)
            {
                semaphore.Wait();
                for (int i = 0; i < ThreadCount; i++)
                {
                    var streamNum = i + 1;
                    System.Threading.Tasks.Task.Run(() => Print(streamNum));
                }
            }
        }

        private void Print(int streamNum)
        {
            mutex.Wait();
                count++;
                if (count == ThreadCount)
                {
                    turnstile2.Wait();
                    turnstile1.TryRelease();
                }
            mutex.TryReleaseMutex();

            turnstile1.Wait();
            turnstile1.TryRelease();

            #region Critical Section
            semaphores[streamNum - 1].Wait();
            Console.Write(streamNum);
            semaphores[streamNum % ThreadCount].TryRelease(); 
            #endregion

            mutex.Wait();
                count--;
                if (count == 0)
                {
                    turnstile1.Wait();
                    turnstile2.TryRelease();
                    semaphore.TryRelease();
                }
            mutex.TryReleaseMutex();

            turnstile2.Wait();
            turnstile2.TryRelease();
        }
    }
}
