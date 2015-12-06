using System;

namespace KeepPractising
{
    public class MyStack<T>
    {
        int count = 0;
        MyLinkedList<T> list = new MyLinkedList<T>();

        public MyStack()
        {
        }

        public void Push(T obj)
        {
            list.AddLast(obj);
            count++;
        }

        public T Pop()
        {
            if (count > 0)
            {
                var obj = list.Last;
                list.RemoveLast();
                count--;
                return obj;
            }
            else
                throw new Exception("Pop operation not allowed on empty stack!");
        }
    }
}
