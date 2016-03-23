using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace KeepPractising.Trees
{
    public static class MinHeap
    {
        /// <summary>
        /// MinHeapifies the given array.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="arr"></param>
        /// <param name="root"></param>
        /// <param name="bottom"></param>
        /// <param name="positionDictionary">If the positionDicitonary is passed, the method updates the updated positions of the elements in the array.</param>
        public static void MinHeapify<T>(this T[] arr, int root, int bottom, Dictionary<T, int> positionDictionary = null) where T : IComparable<T>, IEquatable<T>
        {
            T temp;
            int tempPos;
            while (2 * root + 1 <= bottom)
            {
                var j = 2 * root + 1;

                if (j < bottom && arr[j].CompareTo(arr[j + 1]) > 0)
                    j++;

                if (arr[root].CompareTo(arr[j]) <= 0)
                    break;

                // Update the new positions
                if (positionDictionary != null && positionDictionary.Count == arr.Length)
                {
                    tempPos = positionDictionary[arr[root]];
                    positionDictionary[arr[root]] = positionDictionary[arr[j]];
                    positionDictionary[arr[j]] = tempPos;
                }

                // Update the collection
                temp = arr[root];
                arr[root] = arr[j];
                arr[j] = temp;

                root = j;
            }
        }

        /// <summary>
        /// MinHeapifies the given collection.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="arr"></param>
        /// <param name="root"></param>
        /// <param name="bottom"></param>
        /// <param name="positionDictionary">If the positionDicitonary is passed, the method updates the updated positions of the elements in the collection.</param>
        public static void MinHeapify<T>(this Collection<T> arr, int root, int bottom, Dictionary<T, int> positionDictionary = null) where T : IComparable<T>, IEquatable<T>
        {
            T temp;
            int tempPos;
            while (2 * root + 1 <= bottom)
            {
                var j = 2 * root + 1;

                if (j < bottom && arr[j].CompareTo(arr[j + 1]) > 0)
                    j++;

                if (arr[root].CompareTo(arr[j]) <= 0)
                    break;

                // Update the new positions
                if (positionDictionary != null && positionDictionary.Count == arr.Count)
                {
                    tempPos = positionDictionary[arr[root]];
                    positionDictionary[arr[root]] = positionDictionary[arr[j]];
                    positionDictionary[arr[j]] = tempPos; 
                }

                // Update the collection
                temp = arr[root];
                arr[root] = arr[j];
                arr[j] = temp;

                root = j;
            }
        }

        /// <summary>
        /// This method extracts the minimum value from Min Heap.
        /// The method assumes that the array is a MinHeap to begin with.
        /// If the positionDicitonary is passed, the method returns the updated position dictionary of the elements in the array.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="arr"></param>
        /// <param name="bottom"></param>
        /// <param name="positionDictionary">If the positionDicitonary is passed, the method updates the updated positions of the elements in the array.</param>
        /// <returns></returns>
        public static T ExtractMin<T>(this T[] arr, int bottom, Dictionary<T, int> positionDictionary = null) where T : IComparable<T>, IEquatable<T>
        {
            if (positionDictionary != null && positionDictionary.Count == arr.Length)
            {
                var tempPos = positionDictionary[arr[0]];
                positionDictionary[arr[0]] = positionDictionary[arr[bottom]];
                positionDictionary[arr[bottom]] = tempPos;
            }

            var temp = arr[0];
            arr[0] = arr[bottom];
            arr[bottom] = temp;

            arr.MinHeapify(0, bottom - 1, positionDictionary);
            return temp;
        }

        /// <summary>
        /// This method extracts the minimum value from Min Heap.
        /// The method assumes that the collection is a MinHeap to begin with.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="arr"></param>
        /// <param name="bottom"></param>
        /// <param name="positionDictionary">If the positionDicitonary is passed, the method updates the updated positions of the elements in the collection.</param>
        /// <returns></returns>
        public static T ExtractMin<T>(this Collection<T> arr, int bottom, Dictionary<T, int> positionDictionary = null) where T : IComparable<T>, IEquatable<T>
        {
            if (positionDictionary != null && positionDictionary.Count == arr.Count)
            {
                var tempPos = positionDictionary[arr[0]];
                positionDictionary[arr[0]] = positionDictionary[arr[bottom]];
                positionDictionary[arr[bottom]] = tempPos;
            }

            var temp = arr[0];
            arr[0] = arr[bottom];
            arr[bottom] = temp;

            arr.MinHeapify(0, bottom - 1, positionDictionary);
            return temp;
        }

        /// <summary>
        /// This method inserts a new element into the min heap, while maintaining its MinHeap structure.
        /// The method assumes that the collection is a MinHeap to begin with.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="arr"></param>
        /// <param name="data"></param>
        /// <param name="positionDictionary"></param>
        public static void InsertIntoMinHeap<T>(this Collection<T> arr, T data, Dictionary<T, int> positionDictionary = null) where T : IComparable<T>, IEquatable<T>
        {
            T temp;
            int tempPos;
            arr.Add(data);
            positionDictionary.Add(data, arr.Count - 1);
            int k = ((arr.Count - 1) - 1) / 2, j = arr.Count - 1;

            while (k >= 0)
            {
                if (arr[k].CompareTo(arr[j]) <= 0)
                    break;

                // Update the new positions
                if (positionDictionary != null && positionDictionary.Count == arr.Count)
                {
                    tempPos = positionDictionary[arr[k]];
                    positionDictionary[arr[k]] = positionDictionary[arr[j]];
                    positionDictionary[arr[j]] = tempPos;
                }

                // Update the collection
                temp = arr[k];
                arr[k] = arr[j];
                arr[j] = temp;

                j = k;
                k = (k - 1) / 2;
            }
        }

        /// <summary>
        /// This method inserts a new element into the min heap, while maintaining its MinHeap structure.
        /// The method assumes that the array is a MinHeap to begin with and there are no elements after the specified index.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="arr"></param>
        /// <param name="index"></param>
        /// <param name="data"></param>
        /// <param name="positionDictionary"></param>
        public static void InsertIntoMinHeap<T>(this T[] arr, int index, T data, Dictionary<T, int> positionDictionary = null) where T : IComparable<T>, IEquatable<T>
        {
            T temp;
            int tempPos;
            arr[index] = data;
            positionDictionary.Add(data, index);
            int k = (index - 1) / 2, j = index;

            while (k >= 0)
            {
                if (arr[k].CompareTo(arr[j]) <= 0)
                    break;

                // Update the new positions
                if (positionDictionary != null && positionDictionary.Count == index)
                {
                    tempPos = positionDictionary[arr[k]];
                    positionDictionary[arr[k]] = positionDictionary[arr[j]];
                    positionDictionary[arr[j]] = tempPos;
                }

                // Update the array
                temp = arr[k];
                arr[k] = arr[j];
                arr[j] = temp;

                j = k;
                k = (k - 1) / 2;
            }
        }
    }


    public static class MaxHeap
    {
        /// <summary>
        /// MaxHeapifies the given array.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="arr"></param>
        /// <param name="root"></param>
        /// <param name="bottom"></param>
        /// <param name="positionDictionary">If the positionDicitonary is passed, the method updates the updated positions of the elements in the array.</param>
        public static void MaxHeapify<T>(this T[] arr, int root, int bottom, Dictionary<T, int> positionDictionary = null) where T : IComparable<T>, IEquatable<T>
        {
            T temp;
            int tempPos;
            while (2 * root + 1 <= bottom)
            {
                var j = 2 * root + 1;

                if (j < bottom && arr[j].CompareTo(arr[j + 1]) < 0)
                    j++;

                if (arr[root].CompareTo(arr[j]) >= 0)
                    break;

                // Update the new positions
                if (positionDictionary != null && positionDictionary.Count == arr.Length)
                {
                    tempPos = positionDictionary[arr[root]];
                    positionDictionary[arr[root]] = positionDictionary[arr[j]];
                    positionDictionary[arr[j]] = tempPos;
                }

                // Update the collection
                temp = arr[root];
                arr[root] = arr[j];
                arr[j] = temp;

                root = j;
            }
        }

        /// <summary>
        /// MaxHeapifies the given collection.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="arr"></param>
        /// <param name="root"></param>
        /// <param name="bottom"></param>
        /// <param name="positionDictionary">If the positionDicitonary is passed, the method updates the updated positions of the elements in the collection.</param>
        public static void MaxHeapify<T>(this Collection<T> arr, int root, int bottom, Dictionary<T, int> positionDictionary = null) where T : IComparable<T>, IEquatable<T>
        {
            T temp;
            int tempPos;
            while (2 * root + 1 <= bottom)
            {
                var j = 2 * root + 1;

                if (j < bottom && arr[j].CompareTo(arr[j + 1]) < 0)
                    j++;

                if (arr[root].CompareTo(arr[j]) >= 0)
                    break;

                // Update the new positions
                if (positionDictionary != null && positionDictionary.Count == arr.Count)
                {
                    tempPos = positionDictionary[arr[root]];
                    positionDictionary[arr[root]] = positionDictionary[arr[j]];
                    positionDictionary[arr[j]] = tempPos;
                }

                // Update the collection
                temp = arr[root];
                arr[root] = arr[j];
                arr[j] = temp;

                root = j;
            }
        }

        /// <summary>
        /// This method extracts the maximum value from Max Heap.
        /// The method assumes that the array is a MaxHeap to begin with.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="arr"></param>
        /// <param name="bottom"></param>
        /// <param name="positionDictionary">If the positionDicitonary is passed, the method updates the updated positions of the elements in the array.</param>
        /// <returns></returns>
        public static T ExtractMax<T>(this T[] arr, int bottom, Dictionary<T, int> positionDictionary = null) where T : IComparable<T>, IEquatable<T>
        {
            if (positionDictionary != null && positionDictionary.Count == arr.Length)
            {
                var tempPos = positionDictionary[arr[0]];
                positionDictionary[arr[0]] = positionDictionary[arr[bottom]];
                positionDictionary[arr[bottom]] = tempPos;
            }

            var temp = arr[0];
            arr[0] = arr[bottom];
            arr[bottom] = temp;

            arr.MaxHeapify(0, bottom - 1, positionDictionary);
            return temp;
        }

        /// <summary>
        /// This method extracts the maximum value from Max Heap.
        /// The method assumes that the collection is a MaxHeap to begin with.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="arr"></param>
        /// <param name="bottom"></param>
        /// <param name="positionDictionary">If the positionDicitonary is passed, the method updates the updated positions of the elements in the collection.</param>
        /// <returns></returns>
        public static T ExtractMax<T>(this Collection<T> arr, int bottom, Dictionary<T, int> positionDictionary = null) where T : IComparable<T>, IEquatable<T>
        {
            if (positionDictionary != null && positionDictionary.Count == arr.Count)
            {
                var tempPos = positionDictionary[arr[0]];
                positionDictionary[arr[0]] = positionDictionary[arr[bottom]];
                positionDictionary[arr[bottom]] = tempPos;
            }

            var temp = arr[0];
            arr[0] = arr[bottom];
            arr[bottom] = temp;

            arr.MaxHeapify(0, bottom - 1, positionDictionary);
            return temp;
        }

        /// <summary>
        /// This method inserts a new element into the max heap, while maintaining its MaxHeap structure.
        /// The method assumes that the collection is a MaxHeap to begin with.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="arr"></param>
        /// <param name="data"></param>
        /// <param name="positionDictionary"></param>
        public static void InsertIntoMaxHeap<T>(this Collection<T> arr, T data, Dictionary<T, int> positionDictionary = null) where T : IComparable<T>, IEquatable<T>
        {
            T temp;
            int tempPos;
            arr.Add(data);
            positionDictionary.Add(data, arr.Count - 1);
            int k = ((arr.Count - 1) - 1) / 2, j = arr.Count - 1;

            while (k >= 0)
            {
                if (arr[k].CompareTo(arr[j]) >= 0)
                    break;

                // Update the new positions
                if (positionDictionary != null && positionDictionary.Count == arr.Count)
                {
                    tempPos = positionDictionary[arr[k]];
                    positionDictionary[arr[k]] = positionDictionary[arr[j]];
                    positionDictionary[arr[j]] = tempPos;
                }

                // Update the collection
                temp = arr[k];
                arr[k] = arr[j];
                arr[j] = temp;

                j = k;
                k = (k - 1) / 2;
            }
        }

        /// <summary>
        /// This method inserts a new element into the max heap, while maintaining its MaxHeap structure.
        /// The method assumes that the array is a MaxHeap to begin with and there are no elements after the specified index.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="arr"></param>
        /// <param name="index"></param>
        /// <param name="data"></param>
        /// <param name="positionDictionary"></param>
        public static void InsertIntoMaxHeap<T>(this T[] arr, int index, T data, Dictionary<T, int> positionDictionary = null) where T : IComparable<T>, IEquatable<T>
        {
            T temp;
            int tempPos;
            arr[index] = data;
            positionDictionary.Add(data, index);
            int k = (index - 1) / 2, j = index;

            while (k >= 0)
            {
                if (arr[k].CompareTo(arr[j]) >= 0)
                    break;

                // Update the new positions
                if (positionDictionary != null && positionDictionary.Count == index)
                {
                    tempPos = positionDictionary[arr[k]];
                    positionDictionary[arr[k]] = positionDictionary[arr[j]];
                    positionDictionary[arr[j]] = tempPos;
                }

                // Update the array
                temp = arr[k];
                arr[k] = arr[j];
                arr[j] = temp;

                j = k;
                k = (k - 1) / 2;
            }
        }
    }
}
