using System;
using System.Collections.ObjectModel;

namespace KeepPractising.Trees
{
    public interface IHeap<T> where T : IComparable<T>, IEquatable<T>
    {
        int Length { get; }

        void Add(T data);

        T Peek();

        T Extract();
    }

    class MyMaxHeap<T> : IHeap<T> where T : IComparable<T>, IEquatable<T>
    {
        private Collection<T> items;

        public MyMaxHeap()
        {
            items = new Collection<T>();
        }

        public int Length
        {
            get
            {
                return items.Count;
            }
        }

        public void Add(T data)
        {
            items.InsertIntoMaxHeap(data);
        }

        public T Extract()
        {
            var data = items.ExtractMax(items.Count - 1);
            items.RemoveAt(items.Count - 1);
            return data;
        }

        public T Peek()
        {
            return items[0];
        }
    }

    class MyMinHeap<T> : IHeap<T> where T : IComparable<T>, IEquatable<T>
    {
        private Collection<T> items;

        public MyMinHeap()
        {
            items = new Collection<T>();
        }

        public int Length
        {
            get
            {
                return items.Count;
            }
        }

        public void Add(T data)
        {
            items.InsertIntoMinHeap(data);
        }

        public T Extract()
        {
            var data = items.ExtractMin(items.Count - 1);
            items.RemoveAt(items.Count - 1);
            return data;
        }

        public T Peek()
        {
            return items[0];
        }
    }
}
