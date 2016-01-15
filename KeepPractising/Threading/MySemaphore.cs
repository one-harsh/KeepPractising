namespace KeepPractising.Threading
{
    /// <summary>
    /// A simple semaphore implementation.
    /// </summary>
    public class MySemaphore
    {
        int count;
        int limit;
        object lockObj;

        public MySemaphore(int initialCount, int maximumCount)
        {
            count = initialCount;
            limit = maximumCount;
            lockObj = new object();
        }

        public void Wait()
        {
            lock (lockObj)
            {
                while (count == 0)
                    System.Threading.Monitor.Wait(lockObj);

                count--;
            }
        }

        public bool TryRelease()
        {
            lock (lockObj)
            {
                if (count < limit)
                {
                    count++;
                    System.Threading.Monitor.PulseAll(lockObj);
                    return true;
                }
                return false;
            }
        }
    }

}
