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

    public class MyStackUsingArray<T>
    {
        T[] array;
        int top, bottom;

        public MyStackUsingArray(int maxLength)
        {
            array = new T[maxLength];
            top = -1;
            bottom = -1;
        }

        public bool IsEmpty()
        {
            return top == bottom && top == -1;
        }

        public bool IsFull()
        {
            return (top + 1) % array.Length == bottom;
        }

        public void Push(T data)
        {
            if (IsFull())
                throw new Exception("Stack overflow!");

            if (IsEmpty())
            {
                top = 0;
                bottom = 0;
            }
            else
                top = (top + 1) % array.Length;

            array[top] = data;
        }

        public T Pop()
        {
            if (IsEmpty())
                throw new Exception("Stack underflow!");

            var obj = array[top];

            if (top == bottom)
            {
                top = - 1;
                bottom = -1;
            }
            else
                top = (top - 1) % array.Length;

            return obj;
        }

        public T Peek()
        {
            if (!IsEmpty())
                return array[top];
            else
                throw new Exception("Stack underflow!");
        }

        public int Length
        {
            get
            {
                return bottom <= top ? (IsEmpty() ? 0 : top - bottom + 1) : top + array.Length - bottom + 1;
            }
        }
    }
}
