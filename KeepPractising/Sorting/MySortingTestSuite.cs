using System;

namespace KeepPractising.Sorting
{
    class MySortingTestSuite
    {
        public static void TestQuickSort()
        {
            string str = "TESTQUICKSORT";
            Console.WriteLine(str);

            Console.WriteLine("Sorted string from 2nd index to 9th index - " + str.QuickSort(2, 9));
            Console.WriteLine("Sorted string - " + str.QuickSort());

            var arr = new int[] { 32, 12, 431, 4531, 123, 1, -42, 0, 42, -89 };
            Console.WriteLine("\nInitial array:-");
            foreach (var item in arr)
                Console.WriteLine(item);

            arr.QuickSort(2, 8);
            Console.WriteLine("\nSorted array from 2nd index to 8th index :-");
            foreach (var item in arr)
                Console.WriteLine(item);

            arr.QuickSort();
            Console.WriteLine("\nSorted array:-");
            foreach (var item in arr)
                Console.WriteLine(item);
        }

        public static void TestMergeSort()
        {
            string str = "TESTMERGESORT";
            Console.WriteLine(str);

            Console.WriteLine("Sorted string from 2nd index to 9th index - " + str.MergeSort(2, 9));
            Console.WriteLine("Sorted string - " + str.MergeSort());

            var arr = new int[] { 32, 12, 431, 4531, 123, 1, -42, 0, 42, -89 };
            Console.WriteLine("\nInitial array:-");
            foreach (var item in arr)
                Console.WriteLine(item);

            arr.MergeSort(2, 8);
            Console.WriteLine("\nSorted array from 2nd index to 8th index :-");
            foreach (var item in arr)
                Console.WriteLine(item);

            arr.MergeSort();
            Console.WriteLine("\nSorted array:-");
            foreach (var item in arr)
                Console.WriteLine(item);
        }

        public static void TestHeapSort()
        {
            string str = "TESTHEAPSORT";
            Console.WriteLine(str);

            Console.WriteLine("Sorted string from 2nd index to 9th index - " + str.HeapSort(2, 9));
            Console.WriteLine("Sorted string - " + str.HeapSort());

            var arr = new int[] { 32, 12, 431, 4531, 123, 1, -42, 0, 42, -89 };
            Console.WriteLine("\nInitial array:-");
            foreach (var item in arr)
                Console.WriteLine(item);

            arr = new int[] { 32, 12, 431, 4531, 123, 1, -42, 0, 42, -89 };
            arr.HeapSort(2, 8);
            Console.WriteLine("\nSorted array from 2nd index to 8th index :-");
            foreach (var item in arr)
                Console.WriteLine(item);

            arr.HeapSort();
            Console.WriteLine("\nSorted array:-");
            foreach (var item in arr)
                Console.WriteLine(item);
        }
    }
}
