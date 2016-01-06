using System;

namespace KeepPractising.Sorting
{
    public static class MyHeapSort
    {
        /// <summary>
        /// Sorts the array using Heap sort technique.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="items"></param>
        /// <param name="startIndex"></param>
        /// <param name="endIndex"></param>
        public static void HeapSort<T>(this T[] items, int startIndex = -1, int endIndex = -1) where T : IComparable, IConvertible
        {
            startIndex = startIndex == -1 ? 0 : startIndex;
            endIndex = endIndex == -1 ? items.Length - 1 : endIndex;

            // Keeping the index manipulation simple and understandable, we would do sorting on a shadow array which only contains the elements which are to be sorted.
            var temp = new T[endIndex - startIndex + 1];
            for (int i = 0; i < temp.Length; i++)
                temp[i] = items[startIndex + i];

            Sort(temp);

            // Copying back the elements to their effective position.
            for (int i = startIndex; i <= endIndex; i++)
                items[i] = temp[i - startIndex];
        }

        /// <summary>
        /// Sorts the internal characters in the string using Heap sort technique and returns the sorted character string.
        /// </summary>
        /// <param name="str"></param>
        /// <param name="startIndex"></param>
        /// <param name="endIndex"></param>
        /// <returns></returns>
        public static string HeapSort(this string str, int startIndex = -1, int endIndex = -1)
        {
            startIndex = startIndex == -1 ? 0 : startIndex;
            endIndex = endIndex == -1 ? str.Length - 1 : endIndex;

            // Keeping the index manipulation simple and understandable, we would do sorting on a shadow array which only contains the elements which are to be sorted.
            var items = new char[endIndex - startIndex + 1];
            for (int i = 0; i < items.Length; i++)
                items[i] = str[startIndex + i];

            Sort(items);

            // Copying back the elements to their effective position.
            var copyArr = str.ToCharArray();
            for (int i = startIndex; i <= endIndex; i++)
                copyArr[i] = items[i - startIndex];

            return string.Join("", copyArr);
        }

        private static void Sort<T>(T[] items) where T : IComparable, IConvertible
        {
            T temp;

            for (int i = (items.Length / 2) - 1; i >= 0; i--)
                FixDown(items, i, items.Length - 1);

            for (int i = items.Length - 1; i >= 1; i--)
            {
                temp = items[0];
                items[0] = items[i];
                items[i] = temp;
                FixDown(items, 0, i - 1);
            }
        }

        /// <summary>
        /// Fix the heap going down the heap tree.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="arr"></param>
        /// <param name="root"></param>
        /// <param name="bottom"></param>
        private static void FixDown<T>(T[] arr, int root, int bottom) where T : IComparable, IConvertible
        {
            T temp;
            while(2 * root <= bottom)
            {
                var j = 2 * root;

                if (j < bottom && arr[j].CompareTo(arr[j + 1]) < 0)
                    j++;

                if (arr[root].CompareTo(arr[j]) >= 0)
                    break;

                temp = arr[root];
                arr[root] = arr[j];
                arr[j] = temp;

                root = j;
            }
        }

        /// <summary>
        /// Fix the heap going up the heap tree.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="arr"></param>
        /// <param name="bottom"></param>
        private static void FixUp<T>(T[] arr, int bottom) where T : IComparable, IConvertible // Kept it if someone is interested in doing it the opposite way.
        {
            T temp;
            int k = bottom / 2, j = bottom;
            while (k > 1)
            {
                if (arr[k].CompareTo(arr[j]) >= 0)
                    break;

                temp = arr[k];
                arr[k] = arr[j];
                arr[j] = temp;

                j = k;
                k /= 2;
            }
        }
    }
}
