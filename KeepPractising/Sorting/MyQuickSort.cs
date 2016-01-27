using System;

namespace KeepPractising.Sorting
{
    public static class MyQuickSort
    {
        /// <summary>
        /// Sorts the array using Quick sort technique.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="items"></param>
        /// <param name="startIndex"></param>
        /// <param name="endIndex"></param>
        public static void QuickSort<T>(this T[] items, int startIndex = -1, int endIndex = -1) where T : IComparable, IEquatable<T>
        {
            if (items == null || items.Length == 0)
                return;

            startIndex = startIndex == -1 ? 0 : startIndex;
            endIndex = endIndex == -1 ? items.Length - 1 : endIndex;
            Sort(items, startIndex, endIndex);
        }

        /// <summary>
        /// Sorts the internal characters in the string using Quick sort technique and returns the sorted character string.
        /// </summary>
        /// <param name="str"></param>
        /// <param name="startIndex"></param>
        /// <param name="endIndex"></param>
        /// <returns></returns>
        public static string QuickSort(this string str, int startIndex = -1, int endIndex = -1)
        {
            if (string.IsNullOrWhiteSpace(str))
                return str;

            startIndex = startIndex == -1 ? 0 : startIndex;
            endIndex = endIndex == -1 ? str.Length - 1 : endIndex;

            var items = str.ToCharArray();
            Sort(items, startIndex, endIndex);
            return string.Join("", items);
        }

        private static void Sort<T>(T[] items, int left, int right) where T : IComparable, IEquatable<T>
        {
            int i = left, j = right;
            var pivot = items[left + (right - left) / 2];

            while (i <= j)
            {
                while (items[i].CompareTo(pivot) < 0)
                {
                    i++;
                }
                while (items[j].CompareTo(pivot) > 0)
                {
                    j--;
                }

                if (i <= j)
                {
                    var temp = items[i];
                    items[i] = items[j];
                    items[j] = temp;

                    i++;
                    j--;
                }
            }

            if (left < j)
                Sort(items, left, j);
            if (i < right)
                Sort(items, i, right);
        }
    }
}
