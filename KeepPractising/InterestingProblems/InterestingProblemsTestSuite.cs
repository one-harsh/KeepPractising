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
    }
}
