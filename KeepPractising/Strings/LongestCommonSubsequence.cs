using System;

namespace KeepPractising.Strings
{
    public static class LongestCommonSubsequence
    {
        /// <summary>
        /// Returns the longest common subsequence between the two strings irrespective of the subsequence being contiguous in either of the two.
        /// </summary>
        /// <param name="str1"></param>
        /// <param name="str2"></param>
        /// <returns></returns>
        public static string FindLongestCommonSubsequence(this string str1, string str2)
        {
            if (string.IsNullOrWhiteSpace(str1) || string.IsNullOrWhiteSpace(str2))
                return string.Empty;

            var maxLengthArray = FindLCSubsequenceLengthArray(str1, str2);
            return FindLCSubsequenceString(str1, str2, maxLengthArray);
        }

        private static int[,] FindLCSubsequenceLengthArray(string str1, string str2)
        {
            int[,] suffix = new int[str1.Length, str2.Length];
            int maxLength = 0;

            for (int i = 0; i < str1.Length; i++)
            {
                for (int j = 0; j < str2.Length; j++)
                {
                    // Building upon the longest common suffix problem, we modify our count array to maintain the largest possible subsequence instead of suffix.
                    if (str1[i] == str2[j])
                    {
                        suffix[i, j] = GetValidSubsequenceCount(suffix, i - 1, j - 1) + 1;
                        if (maxLength < suffix[i, j])
                            maxLength = suffix[i, j];
                    }
                    else
                        suffix[i, j] = Math.Max(GetValidSubsequenceCount(suffix, i - 1, j), GetValidSubsequenceCount(suffix, i, j - 1));
                }
            }

            return suffix;
        }

        private static int GetValidSubsequenceCount(int[,] suffix, int i, int j)
        {
            return i < 0 || j < 0 ? 0 : suffix[i, j];
        }

        private static string FindLCSubsequenceString(string str1, string str2, int[,] maxLengthArray)
        {
            string result = string.Empty;
            int i = str1.Length - 1, j = str2.Length - 1;
            int count = maxLengthArray[str1.Length - 1, str2.Length - 1];

            while (i >= 0 && j >= 0)
            {
                if (str1[i] == str2[j])
                {
                    result = str1[i] + result;
                    count--;
                    i--;
                    j--;
                }
                else if (GetValidValue(maxLengthArray, i - 1, j) > GetValidValue(maxLengthArray, i, j - 1))
                    i--;
                else
                    j--;

                if (count <= 0)
                    break;
            }

            return result;
        }

        private static int GetValidValue(int[,] maxLengthArray, int i, int j)
        {
            var x = i <= 0 ? 0 : i;
            var y = j <= 0 ? 0 : j;
            return maxLengthArray[x, y];
        }
    }
}
