using System;

namespace KeepPractising.InterestingProblems
{
    class InterestingProblemsTestSuite
    {
        private static void PrintPath(int[,] path)
        {
            if (path[0, 0] == 0)
            {
                Console.WriteLine("No such path exists!");
                return;
            }

            for (int i = 0; i < path.GetLength(0); i++)
            {
                for (int j = 0; j < path.GetLength(1); j++)
                    Console.Write(" " + path[i, j] + " ");

                Console.WriteLine();
            }
        }

        public static void TestRatInMazeUsingBacktracking()
        {
            var maze = new int[,] {
                                    { 1, 0, 0, 0, 1 },
                                    { 1, 1, 1, 0, 0 },
                                    { 1, 1, 0, 0, 1 },
                                    { 0, 1, 1, 1, 1 }
                                };

            var ratInMaze = new RatInAMaze(maze);
            var path = ratInMaze.FindPathUsingBackTracking();
            PrintPath(path);
        }

        public static void TestDiskPlacingInWavyWell()
        {
            Console.WriteLine("The well's ring radius from top to bottom is taken as - { 5, 6, 7, 3, 4, 7 }.");
            Console.WriteLine("The disks array to be placed is { 2, 4, 1, 6 }.");

            var ringRadius = new int[]{ 5, 6, 7, 3, 4, 7 };
            var diskArray = new int[]{ 2, 4, 1, 6 };

            var count = NumberOfDisksInWavyCircularWell.FindNumberOfDisksThatCanBePlaced(ringRadius, diskArray);

            Console.WriteLine("The number of disks that can be placed for the above condition is - " + count);
        }

        public static void TestLargestSquareInBinaryMatrixUsingNaiveMethod()
        {
            int[,] image = new int[,]
                                {
                                    {1, 1, 1, 1, 1},
                                    {0, 0, 1, 1, 1},
                                    {0, 0, 1, 1, 1},
                                    {1, 1, 0, 1, 1}
                                };

            var squareFinder = new LargestSquareFinderInBinaryMatrix(image);
            var result = squareFinder.FindLargestSquareUsingNaiveApproach();
            Console.WriteLine(string.Format("Top-left cordinate of the square - ({0}, {1})", result.Top, result.Left));
            Console.WriteLine("Size of the square - " + result.Size);
            Console.WriteLine();

            image = new int[,]
                        {
                            { 1, 0, 1, 1 },
                            { 0, 1, 1, 1 },
                            { 1, 0, 0, 1 },
                            { 0, 1, 1, 0 }
                        };
            squareFinder = new LargestSquareFinderInBinaryMatrix(image);
            result = squareFinder.FindLargestSquareUsingNaiveApproach();
            Console.WriteLine(string.Format("Top-left cordinate of the square - ({0}, {1})", result.Top, result.Left));
            Console.WriteLine("Size of the square - " + result.Size);
            Console.WriteLine();

            image = new int[,]
                        {
                            { 1, 0, 1, 0 },
                            { 0, 1, 1, 1 },
                            { 1, 0, 0, 1 },
                            { 0, 1, 1, 0 }
                        };
            squareFinder = new LargestSquareFinderInBinaryMatrix(image);
            result = squareFinder.FindLargestSquareUsingNaiveApproach();
            Console.WriteLine(string.Format("Top-left cordinate of the square - ({0}, {1})", result.Top, result.Left));
            Console.WriteLine("Size of the square - " + result.Size);

            image = new int[,]
                        {
                            { 1, 1, 1, 0 },
                            { 1, 1, 1, 1 },
                            { 1, 1, 1, 1 },
                            { 0, 1, 1, 0 }
                        };
            squareFinder = new LargestSquareFinderInBinaryMatrix(image);
            result = squareFinder.FindLargestSquareUsingNaiveApproach();
            Console.WriteLine(string.Format("Top-left cordinate of the square - ({0}, {1})", result.Top, result.Left));
            Console.WriteLine("Size of the square - " + result.Size);
        }

        public static void TestLargestSquareInBinaryMatrixUsingDP()
        {
            int[,] image = new int[,]
                                {
                                    {1, 1, 1, 1, 1},
                                    {0, 0, 1, 1, 1},
                                    {0, 0, 1, 1, 1},
                                    {1, 1, 0, 1, 1}
                                };

            var squareFinder = new LargestSquareFinderInBinaryMatrix(image);
            var result = squareFinder.FindLargestSquareUsingDynamicProgramming();
            Console.WriteLine(string.Format("Top-left cordinate of the square - ({0}, {1})", result.Top, result.Left));
            Console.WriteLine("Size of the square - " + result.Size);
            Console.WriteLine();

            image = new int[,]
                        {
                            { 1, 0, 1, 1 },
                            { 0, 1, 1, 1 },
                            { 1, 0, 0, 1 },
                            { 0, 1, 1, 0 }
                        };
            squareFinder = new LargestSquareFinderInBinaryMatrix(image);
            result = squareFinder.FindLargestSquareUsingDynamicProgramming();
            Console.WriteLine(string.Format("Top-left cordinate of the square - ({0}, {1})", result.Top, result.Left));
            Console.WriteLine("Size of the square - " + result.Size);
            Console.WriteLine();

            image = new int[,]
                        {
                            { 1, 0, 1, 0 },
                            { 0, 1, 1, 1 },
                            { 1, 0, 0, 1 },
                            { 0, 1, 1, 0 }
                        };
            squareFinder = new LargestSquareFinderInBinaryMatrix(image);
            result = squareFinder.FindLargestSquareUsingDynamicProgramming();
            Console.WriteLine(string.Format("Top-left cordinate of the square - ({0}, {1})", result.Top, result.Left));
            Console.WriteLine("Size of the square - " + result.Size);

            image = new int[,]
                        {
                            { 1, 1, 1, 0 },
                            { 1, 1, 1, 1 },
                            { 1, 1, 1, 1 },
                            { 0, 1, 1, 0 }
                        };
            squareFinder = new LargestSquareFinderInBinaryMatrix(image);
            result = squareFinder.FindLargestSquareUsingDynamicProgramming();
            Console.WriteLine(string.Format("Top-left cordinate of the square - ({0}, {1})", result.Top, result.Left));
            Console.WriteLine("Size of the square - " + result.Size);
        }

        public static void TestMaximumSumSubArray()
        {
            var arr = new int[] { -2, -3, 4, -1, -2, 1, 5, -3 };
            MaxSumSubArray maxSum = new MaxSumSubArray();
            Console.WriteLine(maxSum.FindMaximumSumSubArray(arr));
        }

        public static void TestClusterSizeMedianOfBinaryMatrix()
        {
            int[,] grid = new int[,]
                                {
                                    {1, 1, 1, 1, 1},
                                    {0, 0, 1, 1, 1},
                                    {0, 0, 1, 0, 0},
                                    {1, 1, 0, 1, 1}
                                };

            var median = new MedianOfClustersSizeInGrid();
            Console.WriteLine(median.FindClusterSizeMedianOfBinaryMatrixGrid(grid));

            grid = new int[,]
                        {
                            { 1, 1, 1, 0 },
                            { 1, 1, 1, 1 },
                            { 1, 1, 1, 1 },
                            { 0, 1, 1, 0 }
                        };
            Console.WriteLine(median.FindClusterSizeMedianOfBinaryMatrixGrid(grid));

            grid = new int[,]
                        {
                            { 1, 0, 1, 0 },
                            { 0, 1, 1, 1 },
                            { 1, 0, 0, 1 },
                            { 0, 1, 1, 0 }
                        };
            Console.WriteLine(median.FindClusterSizeMedianOfBinaryMatrixGrid(grid));

            grid = new int[,]
                        {
                            { 0, 0, 0, 0 },
                            { 0, 0, 0, 0 },
                            { 0, 0, 0, 0 },
                            { 0, 0, 0, 0 }
                        };
            Console.WriteLine(median.FindClusterSizeMedianOfBinaryMatrixGrid(grid));

            grid = new int[,] { };
            Console.WriteLine(median.FindClusterSizeMedianOfBinaryMatrixGrid(grid));
        }

        public static void TestFindAllWordsInCrossword()
        {
            var crossWordSolver = new WordsInCrossword();
            char[,] crosswordGrid = new char[,]
                                {
                                    { 'G', 'e', 'i', 't', 's' },
                                    { 'e', 'k', 's', 'n', 'g'},
                                    { 'W', 'd', 'i', 'l', 'l'},
                                    { 'o', 'r', 's', 'o', 't'}
                                };

            crossWordSolver.FindAllWords(crosswordGrid);
        }

        public static void TestEnglishEquivalentOfGivenNumber()
        {
            var engEquivalent = new EnglishNumbers();
            Console.Write("0 is ");
            engEquivalent.PrintWord(0);
            Console.Write("9999 is ");
            engEquivalent.PrintWord(9999);
            Console.Write("8 is ");
            engEquivalent.PrintWord(8);
            Console.Write("10 is ");
            engEquivalent.PrintWord(10);
            Console.Write("15 is ");
            engEquivalent.PrintWord(15);
            Console.Write("101 is ");
            engEquivalent.PrintWord(101);
            Console.Write("115 is ");
            engEquivalent.PrintWord(115);
            Console.Write("2115 is ");
            engEquivalent.PrintWord(2115);
            Console.Write("115685 is ");
            engEquivalent.PrintWord(115685);
        }
    }
}
