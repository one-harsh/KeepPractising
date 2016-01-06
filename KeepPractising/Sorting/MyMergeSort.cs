using System;

namespace KeepPractising.Sorting
{
    public static class MyMergeSort
    {
        /// <summary>
        /// Sorts the array using Merge sort technique.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="items"></param>
        /// <param name="startIndex"></param>
        /// <param name="endIndex"></param>
        public static void MergeSort<T>(this T[] items, int startIndex = -1, int endIndex = -1) where T : IComparable, IConvertible
        {
            startIndex = startIndex == -1 ? 0 : startIndex;
            endIndex = endIndex == -1 ? items.Length - 1 : endIndex;
            Sort(items, startIndex, endIndex);
        }

        /// <summary>
        /// Sorts the internal characters in the string using Merge sort technique and returns the sorted character string.
        /// </summary>
        /// <param name="str"></param>
        /// <param name="startIndex"></param>
        /// <param name="endIndex"></param>
        /// <returns></returns>
        public static string MergeSort(this string str, int startIndex = -1, int endIndex = -1)
        {
            startIndex = startIndex == -1 ? 0 : startIndex;
            endIndex = endIndex == -1 ? str.Length - 1 : endIndex;

            var items = str.ToCharArray();
            Sort(items, startIndex, endIndex);
            return string.Join("", items);
        }

        private static void Sort<T>(T[] items, int left, int right) where T : IComparable, IConvertible
        {
            if (left < right)
            {
                var mid = left + (right - left) / 2;
                Sort(items, left, mid);
                Sort(items, mid + 1, right);
                MergePartitions(items, left, mid, right);
            }
        }

        private static void MergePartitions<T>(T[] items, int left, int mid, int right) where T : IComparable, IConvertible
        {
            int i, j, k = left;

            var leftArr = new T[mid - left + 1];
            var rightArr = new T[right - mid];

            for (i = 0; i < mid - left + 1; i++)
                leftArr[i] = items[left + i];
            for (j = 0; j < right - mid; j++)
                rightArr[j] = items[mid + 1 + j];

            i = 0;
            j = 0;
            while (i < (mid - left + 1) && j < (right - mid))
            {
                if (leftArr[i].CompareTo(rightArr[j]) <= 0)
                {
                    items[k] = leftArr[i];
                    i++;
                }
                else
                {
                    items[k] = rightArr[j];
                    j++;
                }
                k++;
            }

            while (i < mid - left + 1)
            {
                items[k] = leftArr[i];
                i++;
                k++;
            }

            while (j < right - mid)
            {
                items[k] = rightArr[j];
                j++;
                k++;
            }
        }
    }
}
