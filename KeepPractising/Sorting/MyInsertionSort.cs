using System;

namespace KeepPractising.Sorting
{
    public static class MyInsertionSort
    {
        public static void InsertionSort<T>(this T[] items, int startIndex = -1, int endIndex = -1) where T : IComparable<T>, IEquatable<T>
        {
            if (items == null || items.Length == 0)
                return;

            startIndex = startIndex == -1 ? 0 : startIndex;
            endIndex = endIndex == -1 ? items.Length - 1 : endIndex;
            Sort(items, startIndex, endIndex);
        }

        public static string InsertionSort(this string str, int startIndex = -1, int endIndex = -1)
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
            T key;
            int j = 0;
            for (int i = startIndex + 1; i <= endIndex; i++)
            {
                key = items[i];
                j = i - 1;

                while (j >= startIndex && items[j].CompareTo(key) > 0)
                {
                    items[j + 1] = items[j];
                    j = j - 1;
                }
                items[j + 1] = key;
            }
        }
    }
}
