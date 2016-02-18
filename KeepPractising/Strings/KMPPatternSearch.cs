using System.Collections.Generic;

namespace KeepPractising.Strings
{
    public static class KMPPatternSearch
    {
        public static List<int> KMPSearch(this string str, string pattern)
        {
            if (string.IsNullOrWhiteSpace(str) || string.IsNullOrWhiteSpace(pattern))
                return new List<int>();

            var lps = ComputeLPS(pattern);
            var i = 0;
            var j = 0;
            var indicesList = new List<int>(); 

            while (i < str.Length)
            {
                if (str[i] == pattern[j])
                {
                    i++;
                    j++;
                }

                if (j == pattern.Length)
                {
                    indicesList.Add(i - j);
                    j = lps[j - 1];
                }
                else if (i < str.Length && str[i] != pattern[j]) // Mismatch check
                    if (j == 0)
                        i++;
                    else
                        j = lps[j - 1];
            }
            return indicesList;
        }

        private static int[] ComputeLPS(string pattern)
        {
            var lps = new int[pattern.Length];
            var prevLongestSuffixLength = 0;
            var i = 1;
            lps[0] = 0;

            while (i < pattern.Length)
            {
                if (pattern[i] == pattern[prevLongestSuffixLength])
                {
                    prevLongestSuffixLength++;
                    lps[i] = prevLongestSuffixLength;
                    i++;
                }
                else
                {
                    if (prevLongestSuffixLength != 0)
                        prevLongestSuffixLength = lps[prevLongestSuffixLength - 1];
                    else
                    {
                        lps[i] = 0;
                        i++;
                    }
                }
            }

            return lps;
        }
    }
}
