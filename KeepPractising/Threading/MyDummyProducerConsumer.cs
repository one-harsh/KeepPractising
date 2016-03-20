using System;
using System.Threading;
using KeepPractising.Queues;

namespace KeepPractising.Threading
{
    public class MyDummyProducerConsumer<T> : IDisposable
    {
        object lockObj = new object();
        Thread[] workers;
        MyQueue<T> producerQueue = new MyQueue<T>();
        Action<T> processingAction;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="workerCount">Consumer thread count</param>
        /// <param name="processingAction">Consumer action</param>
        public MyDummyProducerConsumer(int workerCount, Action<T> processingAction)
        {
            // To scale Consumer jobs
            workers = new Thread[workerCount];

            // Consuming action
            this.processingAction = processingAction;

            for (int i = 0; i < workerCount; i++)
            {
                workers[i] = new Thread(Consume);
                workers[i].Start();
            }
        }

        public void Dispose()
        {
            // Kill all Consumer threads
            foreach (Thread worker in workers)
                Produce(default(T));
        }

        /// <summary>
        /// Dummy producer method
        /// </summary>
        /// <param name="buffer">The input buffer which goes on to the queue to be processed by the consumer</param>
        public void Produce(T buffer)
        {
            lock (lockObj)
            {
                producerQueue.Enqueue(buffer);
                Console.WriteLine("Producing " + buffer);

                // PulseAll is used in case if multiple buffers are placed in the queue, then all the Consumer threads can be woken up so that they all can start consumer processing
                Monitor.PulseAll(lockObj);
            }
        }

        /// <summary>
        /// Dummy consumer method which acts upon the available buffer according to <see cref="processingAction"/> defined.
        /// </summary>
        void Consume()
        {
            while (true)
            {
                T buffer;
                lock (lockObj)
                {
                    while (producerQueue.Length == 0)
                        Monitor.Wait(lockObj);

                    buffer = producerQueue.Dequeue();
                    processingAction.Invoke(buffer);
                }

                // A bit flawed implementation in our case. But this stopping condition again can be designed according to the given statement.
                if (buffer.Equals(default(T)))
                    return;

                Thread.Sleep(1000);
            }
        }
    }
}
