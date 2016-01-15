using System;

namespace KeepPractising.InterestingProblems
{
    class MaxSumSubArray
    {
        public int FindMaximumSumSubArray(int[] arr)
        {
            var max = arr[0];
            var tempMax = arr[0];
            for (int i = 0; i < arr.Length; i++)
            {
                tempMax = Math.Max(arr[i], arr[i] + tempMax);
                max = Math.Max(max, tempMax);
            }

            return max;
        }
    }
}
