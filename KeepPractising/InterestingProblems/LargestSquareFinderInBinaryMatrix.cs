using System;

namespace KeepPractising.InterestingProblems
{
    public class SquareResult
    {
        public int Top { get; set; }
        public int Left { get; set; }
        public int Size { get; set; }
    }

    /// <summary>
    /// The prerogative of this class is to find the largest square possible within the given binary image matrix
    /// where the value 1 represents a valid pixel.
    /// </summary>
    class LargestSquareFinderInBinaryMatrix
    {
        public LargestSquareFinderInBinaryMatrix(int[,] image)
        {
            Image = image;
            Result = new SquareResult()
                        {
                            Left = -1,
                            Top = -1,
                            Size = 0
                        };
        }

        public int[,] Image { get; private set; }

        public int LengthX
        {
            get
            {
                if (Image == null)
                    throw new NullReferenceException("Image matrix cannot be null.");
                else
                    return Image.GetLength(0);
            }
        }

        public int LengthY
        {
            get
            {
                if (Image == null)
                    throw new NullReferenceException("Image matrix cannot be null.");
                else
                    return Image.GetLength(1);
            }
        }

        public SquareResult Result { get; private set; }

        #region Naive Flood-fill
        /// <summary>
        /// Finds the largest square possible by flood-filling in naive way.
        /// The solution takes O(n^2 * m^2) time and takes O(n * m) extra space.
        /// </summary>
        /// <returns></returns>
        public SquareResult FindLargestSquareUsingNaiveApproach()
        {
            int[,] subSquareSize = new int[LengthX, LengthY];

            for (int i = 0; i < LengthX; i++)
            {
                for (int j = 0; j < LengthY; j++)
                {
                    if (Image[i, j] == 0)
                    {
                        subSquareSize[i, j] = 0;
                        continue;
                    }

                    subSquareSize[i, j] = FindLargestPossibleSizeWithGivenIndexAsOrigin(i, j);
                }
            }

            SetResult(subSquareSize);
            return Result;
        }

        private int FindLargestPossibleSizeWithGivenIndexAsOrigin(int x, int y)
        {
            int size = 1;
            for (int i = x + 1, j = y + 1; i < LengthX && j < LengthY; i++, j++)
                if (Image[i, y] == 1 && Image[x, j] == 1)
                    size++;
                else
                    break;

            for (int i = x; i < x + size; i++)
            {
                for (int j = y; j < y + size; j++)
                {
                    if (Image[i, j] != 1)
                        size = j - y + 1;
                }
            }
            return size;
        }

        private void SetResult(int[,] subSquareSize)
        {
            for (int i = 0; i < LengthX; i++)
                for (int j = 0; j < LengthY; j++)
                    if (Result.Size < subSquareSize[i, j])
                    {
                        Result.Size = subSquareSize[i, j];
                        Result.Top = i;
                        Result.Left = j + subSquareSize[i, j] - 1;
                    }
        }
        #endregion

        #region Dynamic Programming
        /// <summary>
        /// Finds the largest square possible using dynamic programming.
        /// The idea is to count the number of squares a given cell would be a part of when counting from (0, 0) going rightwards &amp; downwards.
        /// Thus, by design, the cell with the biggest entry will be the part of the biggest square.
        /// </summary>
        /// <returns></returns>
        public SquareResult FindLargestSquareUsingDynamicProgramming()
        {
            // Building upon the naive solution, a cell going downwards & rightwards, if is a part of a bigger square,
            // it also would be part of a smaller square too.
            // We carry this information forward and find the biggest square.

            int[,] subSquareSize = new int[LengthX, LengthY];

            // If a cell is a part of the square, all the adjacent cells above it and towards its left have also got to be the square's participant.
            // The following loop takes this logic into account.
            // Moreover, as all the cells have to be part of the square, the max size of the square the current cell can be a part of,
            // would be decided by the cell which can be part of least number of squares, which would be 1 greater than the smallest count.
            for (int i = 0; i < LengthX; i++)
                for (int j = 0; j < LengthY; j++)
                    if (Image[i, j] == 1)
                        subSquareSize[i, j] = Math.Min(Math.Min(GetValidSubSquareSize(subSquareSize, i, j -1), GetValidSubSquareSize(subSquareSize, i - 1, j)), GetValidSubSquareSize(subSquareSize, i - 1, j - 1)) + 1;
                    else
                        subSquareSize[i, j] = 0;

            for (int i = 0; i < LengthX; i++)
                for (int j = 0; j < LengthY; j++)
                    if (Result.Size < subSquareSize[i, j])
                    {
                        Result.Size = subSquareSize[i, j];
                        Result.Top = i - subSquareSize[i, j] + 1;
                        Result.Left = j;
                    }

            return Result;
        }

        /// <summary>
        /// Returns the valid size at given index stored in the array. 
        /// If the co-ordinate of the cell itself is invalid, it returns 0.
        /// </summary>
        /// <param name="subSquareSize"></param>
        /// <param name="i"></param>
        /// <param name="j"></param>
        /// <returns></returns>
        private int GetValidSubSquareSize(int[,] subSquareSize, int i, int j)
        {
            return i < 0 || j < 0 ? 0 : subSquareSize[i, j];
        }
        #endregion
    }
}
