namespace KeepPractising.Threading
{
    /// <summary>
    /// A simple mutex implementation.
    /// </summary>
    class MyMutex
    {
        object lockObj;
        bool isLocked;

        public MyMutex()
        {
            lockObj = new object();
            isLocked = false;
        }

        public void Wait()
        {
            lock (lockObj)
            {
                while (isLocked)
                    System.Threading.Monitor.Wait(lockObj);

                isLocked = true;
            }
        }

        public bool TryReleaseMutex()
        {
            lock (lockObj)
            {
                if (isLocked)
                {
                    isLocked = false;
                    System.Threading.Monitor.Pulse(lockObj);
                    return true;
                }
                return false;
            }
        }
    }
}
