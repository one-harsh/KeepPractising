namespace KeepPractising.Strings
{
    public static class LongestCommonSubstring
    {
        /// <summary>
        /// Returns the longest common substring/suffix found in str2 with respect to str1.
        /// </summary>
        /// <param name="str1"></param>
        /// <param name="str2"></param>
        /// <returns></returns>
        public static string FindLongestCommonSubstring(this string str1, string str2)
        {
            if (string.IsNullOrWhiteSpace(str1) || string.IsNullOrWhiteSpace(str2))
                return string.Empty;

            int[,] suffix = new int[str1.Length, str2.Length];
            int maxLength = 0, str1Indx = -1;

            for (int i = 0; i < str1.Length; i++)
            {
                for (int j = 0; j < str2.Length; j++)
                {
                    if (str1[i] == str2[j])
                    {
                        suffix[i, j] = GetValidSuffixCount(suffix, i - 1, j - 1) + 1;
                        if (maxLength < suffix[i, j])
                        {
                            maxLength = suffix[i, j];
                            str1Indx = i;
                        }
                    }
                    else
                        suffix[i, j] = 0;
                }
            }

            return str1.Substring(str1Indx - maxLength + 1, maxLength);
        }

        private static int GetValidSuffixCount(int[,] suffix, int i, int j)
        {
            return i < 0 || j < 0 ? 0 : suffix[i, j];
        }
    }
}
