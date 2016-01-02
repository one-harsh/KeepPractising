using KeepPractising.LinkedLists;
using Exception = System.Exception;

namespace KeepPractising.Queues
{
    public class MyQueue<T>
    {
        int count = 0;
        MyLinkedList<T> list = new MyLinkedList<T>();

        public int Length
        {
            get
            {
                return list.Length;
            }
        }

        public void Enqueue(T obj)
        {
            list.AddLast(obj);
            count++;
        }

        public T Dequeue()
        {
            if (count > 0)
            {
                count--;
                var obj = list.First;
                list.RemoveFirst();

                return obj;
            }
            else
                throw new Exception("Dequeue operation not allowed on empty queue!");
        }

        public T Peek()
        {
            if (count > 0)
                return list.First;
            else
                throw new Exception("Peek operation not allowed on empty queue!");
        }
    }
}
