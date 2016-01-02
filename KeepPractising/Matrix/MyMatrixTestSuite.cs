using System;

namespace KeepPractising.Matrix
{
    class MyMatrixTestSuite
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
    }
}
