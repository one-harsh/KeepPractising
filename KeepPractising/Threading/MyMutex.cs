namespace KeepPractising.Threading
{
    /// <summary>
    /// A simple mutex implementation.
    /// </summary>
    /// Would re-implement in a better way.
    class MyMutex
    {
        MySemaphore semaphore;

        public MyMutex()
        {
            semaphore = new MySemaphore(1, 1);
        }

        public void Wait()
        {
            semaphore.Wait();
        }

        public bool TryReleaseMutex()
        {
            return semaphore.TryRelease();
        }
    }
}
