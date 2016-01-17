namespace KeepPractising.InterestingProblems
{
    public class RatInAMaze
    {
        private int[,] path;

        public int[,] Maze { get; private set; }

        public RatInAMaze(int[,] maze)
        {
            Maze = maze;
            ResetPath();
        }

        private void ResetPath()
        {
            path = new int[Maze.GetLength(0), Maze.GetLength(1)];
        }

        /// <summary>
        /// Returns the path, using backtracking technique, if it exists from [0, 0] position to [RowCount - 1, ColumnCount - 1].
        /// If the path doesn't exist, then the [0, 0] position's value is 0.
        /// </summary>
        /// <returns></returns>
        public int[,] FindPathUsingBackTracking()
        {
            ResetPath();
            BacktrackRecursively(0, 0);
            return path;
        }

        private bool IsValidPosition(int x, int y)
        {
            return (x >= 0 && x < Maze.GetLength(0)
                    && y >= 0 && y < Maze.GetLength(1)
                    && Maze[x, y] == 1);
        }

        private bool BacktrackRecursively(int x, int y)
        {
            if (x == Maze.GetLength(0) - 1 && y == Maze.GetLength(1) - 1)
            {
                path[x, y] = 1;
                return true;
            }

            if (IsValidPosition(x, y))
            {
                path[x, y] = 1;

                if (BacktrackRecursively(x + 1, y))
                    return true;

                if (BacktrackRecursively(x, y + 1))
                    return true;

                path[x, y] = 0;
                return false;
            }

            return false;
        }

        /// <summary>
        /// Returns the path, using BFS technique, if it exists from [0, 0] position to [RowCount - 1, ColumnCount - 1].
        /// If the path doesn't exist, then the [0, 0] position's value is 0.
        /// </summary>
        /// <returns></returns>
        public int[,] FindPathUsingBFS()
        {
            ResetPath();

            return path;
        }

        /// <summary>
        /// Returns the path, using A* technique, if it exists from [0, 0] position to [RowCount - 1, ColumnCount - 1].
        /// If the path doesn't exist, then the [0, 0] position's value is 0.
        /// </summary>
        /// <returns></returns>
        public int[,] FindPathUsingAStar()
        {
            ResetPath();

            return path;
        }
    }
}