using System;

namespace KeepPractising.Stacks
{
    class StackWithMinMethod<T> : MyStack<T> where T : IComparable<T>, IEquatable<T>
    {
        MyStack<T> minStack;

        public StackWithMinMethod()
        {
            minStack = new MyStack<T>();
        }

        public new void Push(T obj)
        {
            base.Push(obj);

            if (minStack.Length == 0)
                minStack.Push(obj);
            else if (obj.CompareTo(minStack.Peek()) < 0)
                minStack.Push(obj);
        }

        public new T Pop()
        {
            var temp = base.Pop();
            if (minStack.Peek().Equals(temp))
                minStack.Pop();

            return temp;
        }

        public T GetMin()
        {
            return minStack.Peek();
        }
    }
}
