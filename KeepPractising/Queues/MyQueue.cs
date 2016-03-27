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

        public bool Empty()
        {
            return list.Length == 0;
        }
    }

    public class MyQueueUsingArray<T>
    {
        T[] array;
        int front, rear;

        public MyQueueUsingArray(int maxLength)
        {
            array = new T[maxLength];
            front = -1;
            rear = -1;
        }

        public bool IsEmpty()
        {
            return front == rear && front == -1;
        }

        public bool IsFull()
        {
            return (rear + 1) % array.Length == front;
        }

        public void Enqueue(T data)
        {
            if (IsFull())
                throw new Exception("Overflow!");

            if (IsEmpty())
            {
                front = 0;
                rear = 0;
            }
            else
                rear = (rear + 1) % array.Length;

            array[rear] = data;
        }

        public T Dequeue()
        {
            if (IsEmpty())
                throw new Exception("Underflow!");

            var obj = array[front];

            if (front == rear)
            {
                front = -1;
                rear = -1;
            }
            else
                front = (front + 1) % array.Length;

            return obj;
        }

        public T Peek()
        {
            if (!IsEmpty())
                return array[front];
            else
                throw new Exception("Underflow!");
        }

        public int Length
        {
            get
            {
                return front <= rear ? (IsEmpty() ? 0 : rear - front + 1) : rear + array.Length - front + 1;
            }
        }
    }

}
