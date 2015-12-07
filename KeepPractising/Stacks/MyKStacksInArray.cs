using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KeepPractising.Stacks
{
    class MyKStacksInArray<T>
    {
        T[] arr;
        int index;
        int[] next;
        int[] top;

        public MyKStacksInArray(int arrSize, int stackCount)
        {
            arr = new T[arrSize];
            next = new int[arrSize];
            top = new int[stackCount];

            Initialize();
        }

        private void Initialize()
        {
            index = 0;
            for (int i = 0; i < next.Length; i++)
                next[i] = i + 1;

            next[next.Length - 1] = -1;
            for (int i = 0; i < top.Length; i++)
                top[i] = -1;
        }

        public void Push(T obj, int stackNumber)
        {
            if (index == -1)
                throw new Exception("Buffer overflow in the given array!");

            int i = index;
            index = next[i];
            next[i] = top[stackNumber - 1];
            top[stackNumber - 1] = i;

            arr[i] = obj;
        }

        public T Pop(int stackNumber)
        {
            if (top[stackNumber - 1] == -1)
                throw new Exception("Stack underflow for given stack!");

            int i = top[stackNumber - 1];
            top[stackNumber - 1] = next[i];
            next[i] = index;
            index = i;

            return arr[i];
        }
    }
}
