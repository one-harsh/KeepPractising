using System;

namespace KeepPractising.Sorting
{
    public static class MyPancakeSort
    {
        public static void PancakeSort<T>(this T[] pancakes, int topIndex = -1, int bottomIndex = -1) where T : IComparable, IEquatable<T>
        {
            if (pancakes == null)
                return;

            topIndex = topIndex == -1 ? 0 : topIndex;
            bottomIndex = bottomIndex == -1 ? pancakes.Length - 1 : bottomIndex;

            // You can't sort pancakes without affecting the entire pancake stack.
            // For simplicity, we extract the required stack of pancakes out and sort them.
            var temp = new T[bottomIndex - topIndex + 1];
            for (int i = 0; i < temp.Length; i++)
                temp[i] = pancakes[topIndex + i];

            Sort(temp);

            // Copying back the elements to their effective position.
            for (int i = topIndex; i <= bottomIndex; i++)
                pancakes[i] = temp[i - topIndex];
        }

        public static string PancakeSort(this string pancakeyString, int topIndex = -1, int bottomIndex = -1)
        {
            if (string.IsNullOrWhiteSpace(pancakeyString))
                return pancakeyString;

            topIndex = topIndex == -1 ? 0 : topIndex;
            bottomIndex = bottomIndex == -1 ? pancakeyString.Length - 1 : bottomIndex;

            // You can't sort pancakes without affecting the entire pancake stack.
            // For simplicity, we extract the required stack of pancakes out and sort them.
            var pancakes = new char[bottomIndex - topIndex + 1];
            for (int i = 0; i < pancakes.Length; i++)
                pancakes[i] = pancakeyString[topIndex + i];

            Sort(pancakes);

            // Copying back the elements to their effective position.
            var copyArr = pancakeyString.ToCharArray();
            for (int i = topIndex; i <= bottomIndex; i++)
                copyArr[i] = pancakes[i - topIndex];

            return string.Join("", copyArr);
        }

        private static void Sort<T>(T[] pancakes) where T : IComparable, IEquatable<T>
        {
            int topIndex = 0, bottomIndex = pancakes.Length - 1;

            for (int currentStackSize = bottomIndex - topIndex + 1; currentStackSize > topIndex + 1; currentStackSize--)
            {
                int currentSubStackMaxIndex = FindPancakesSubStackMaxIndex(pancakes, topIndex, currentStackSize);

                if (currentSubStackMaxIndex != currentStackSize - 1)
                {
                    ReversePancakeStack(pancakes, topIndex, currentSubStackMaxIndex); // Max to the beginning of pancakes stack
                    ReversePancakeStack(pancakes, topIndex, currentStackSize - 1); // Max to the final end position
                }
            }
        }

        private static int FindPancakesSubStackMaxIndex<T>(T[] pancakes, int topIndex, int currentStackSize) where T : IComparable, IEquatable<T>
        {
            int maxSizeIndex = 0;
            for (int i = topIndex; i < topIndex + currentStackSize; i++)
                if (pancakes[i].CompareTo(pancakes[maxSizeIndex]) > 0)
                    maxSizeIndex = i;
            return maxSizeIndex;
        }

        public static void ReversePancakeStack<T>(T[] pancakes, int topIndex, int bottomIndex)
        {
            T temp;
            while (topIndex < bottomIndex)
            {
                temp = pancakes[topIndex];
                pancakes[topIndex] = pancakes[bottomIndex];
                pancakes[bottomIndex] = temp;
                topIndex++;
                bottomIndex--;
            }
        }
    }
}
