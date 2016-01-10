using System;

namespace KeepPractising.Sorting
{
    class MySortingTestSuite
    {
        private static void PrintArray<T>(T[] arr)
        {
            foreach (var item in arr)
                Console.WriteLine(item);
        }

        public static void TestQuickSort()
        {
            string str = "TESTQUICKSORT";
            Console.WriteLine(str);

            Console.WriteLine("Sorted string from 2nd index to 9th index - " + str.QuickSort(2, 9));
            Console.WriteLine("Sorted string - " + str.QuickSort());

            var arr = new int[] { 32, 12, 431, 4531, 123, 1, -42, 0, 42, -89 };
            Console.WriteLine("\nInitial array:-");
            PrintArray(arr);

            arr.QuickSort(2, 8);
            Console.WriteLine("\nSorted array from 2nd index to 8th index :-");
            PrintArray(arr);

            arr.QuickSort();
            Console.WriteLine("\nSorted array:-");
            PrintArray(arr);
        }

        public static void TestMergeSort()
        {
            string str = "TESTMERGESORT";
            Console.WriteLine(str);

            Console.WriteLine("Sorted string from 2nd index to 9th index - " + str.MergeSort(2, 9));
            Console.WriteLine("Sorted string - " + str.MergeSort());

            var arr = new int[] { 32, 12, 431, 4531, 123, 1, -42, 0, 42, -89 };
            Console.WriteLine("\nInitial array:-");
            PrintArray(arr);

            arr.MergeSort(2, 8);
            Console.WriteLine("\nSorted array from 2nd index to 8th index :-");
            PrintArray(arr);

            arr.MergeSort();
            Console.WriteLine("\nSorted array:-");
            PrintArray(arr);
        }

        public static void TestHeapSort()
        {
            string str = "TESTHEAPSORT";
            Console.WriteLine(str);

            Console.WriteLine("Sorted string from 2nd index to 9th index - " + str.HeapSort(2, 9));
            Console.WriteLine("Sorted string - " + str.HeapSort());

            var arr = new int[] { 32, 12, 431, 4531, 123, 1, -42, 0, 42, -89 };
            Console.WriteLine("\nInitial array:-");
            PrintArray(arr);

            arr = new int[] { 32, 12, 431, 4531, 123, 1, -42, 0, 42, -89 };
            arr.HeapSort(2, 8);
            Console.WriteLine("\nSorted array from 2nd index to 8th index :-");
            PrintArray(arr);

            arr.HeapSort();
            Console.WriteLine("\nSorted array:-");
            PrintArray(arr);
        }

        public static void TestSelectionSort()
        {
            string str = "TESTSELECTIONSORT";
            Console.WriteLine(str);

            Console.WriteLine("Sorted string from 2nd index to 9th index - " + str.SelectionSort(2, 9));
            Console.WriteLine("Sorted string - " + str.SelectionSort());

            var arr = new int[] { 32, 12, 431, 4531, 123, 1, -42, 0, 42, -89 };
            Console.WriteLine("\nInitial array:-");
            PrintArray(arr);

            arr = new int[] { 32, 12, 431, 4531, 123, 1, -42, 0, 42, -89 };
            arr.SelectionSort(2, 8);
            Console.WriteLine("\nSorted array from 2nd index to 8th index :-");
            PrintArray(arr);

            arr.SelectionSort();
            Console.WriteLine("\nSorted array:-");
            PrintArray(arr);
        }

        public static void TestInsertionSort()
        {
            string str = "TESTINSERTIONSORT";
            Console.WriteLine(str);

            Console.WriteLine("Sorted string from 2nd index to 9th index - " + str.InsertionSort(2, 9));
            Console.WriteLine("Sorted string - " + str.InsertionSort());

            var arr = new int[] { 32, 12, 431, 4531, 123, 1, -42, 0, 42, -89 };
            Console.WriteLine("\nInitial array:-");
            PrintArray(arr);

            arr = new int[] { 32, 12, 431, 4531, 123, 1, -42, 0, 42, -89 };
            arr.InsertionSort(2, 8);
            Console.WriteLine("\nSorted array from 2nd index to 8th index :-");
            PrintArray(arr);

            arr.InsertionSort();
            Console.WriteLine("\nSorted array:-");
            PrintArray(arr);
        }

        public static void TestPancakeSort()
        {
            string str = "TESTPANCAKESORT";
            Console.WriteLine(str);

            Console.WriteLine("Sorted string from 2nd index to 9th index - " + str.PancakeSort(2, 9));
            Console.WriteLine("Sorted string - " + str.PancakeSort());

            var arr = new int[] { 32, 12, 431, 4531, 123, 1, -42, 0, 42, -89 };
            Console.WriteLine("\nInitial array:-");
            PrintArray(arr);

            arr = new int[] { 32, 12, 431, 4531, 123, 1, -42, 0, 42, -89 };
            arr.PancakeSort(2, 8);
            Console.WriteLine("\nSorted array from 2nd index to 8th index :-");
            PrintArray(arr);

            arr.PancakeSort();
            Console.WriteLine("\nSorted array:-");
            PrintArray(arr);
        }
    }
}
