using System;

namespace KeepPractising.Sorting
{
    public static class MySelectionSort
    {
        public static void SelectionSort<T>(this T[] items, int startIndex = -1, int endIndex = -1) where T : IComparable<T>, IEquatable<T>
        {
            if (items == null || items.Length == 0)
                return;

            startIndex = startIndex == -1 ? 0 : startIndex;
            endIndex = endIndex == -1 ? items.Length - 1 : endIndex;
            Sort(items, startIndex, endIndex);
        }

        public static string SelectionSort(this string str, int startIndex = -1, int endIndex = -1)
        {
            if (string.IsNullOrWhiteSpace(str))
                return str;

            startIndex = startIndex == -1 ? 0 : startIndex;
            endIndex = endIndex == -1 ? str.Length - 1 : endIndex;

            var items = str.ToCharArray();
            Sort(items, startIndex, endIndex);
            return string.Join("", items);
        }

        private static void Sort<T>(T[] items, int startIndex, int endIndex) where T : IComparable<T>, IEquatable<T>
        {
            T temp;
            int index;

            for (int i = startIndex; i < endIndex; i++)
            {
                index = i;
                for (int j = i + 1; j <= endIndex; j++)
                    if (items[j].CompareTo(items[index]) < 0)
                        index = j;

                temp = items[index];
                items[index] = items[i];
                items[i] = temp;
            }
        }
    }
}
