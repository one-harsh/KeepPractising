using System;

namespace KeepPractising.InterestingProblems
{
    class InterestingProblemsTestSuite
    {
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
    }
}
