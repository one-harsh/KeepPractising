using KeepPractising.LinkedLists;
using Exception = System.Exception;

namespace KeepPractising.Stacks
{
    public class MyStack<T>
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

        public T Peek()
        {
            if (count > 0)
                return list.Last;
            else
                throw new Exception("Peek operation not allowed on empty stack!");
        }

        public bool Empty()
        {
            return list.Length == 0;
        }
    }
}
