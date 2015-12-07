using KeepPractising.LinkedLists;
using System;

namespace KeepPractising.Queues
{
    public class MyQueue<T>
    {
        int count = 0;
        MyLinkedList<T> list = new MyLinkedList<T>();

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
    }
}
