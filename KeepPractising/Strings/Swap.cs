namespace KeepPractising.Strings
{
    public static class Swap
    {
        /// <summary>
        /// Swaps the character at index i &amp; j and returns the new string. The indexes i &amp; j can be in any order.
        /// It returns the same string if the indexes are &lt; 0 and/or are &gt;= string's length.
        /// </summary>
        /// <param name="str"></param>
        /// <param name="i">1st index</param>
        /// <param name="j">2nd index</param>
        /// <returns></returns>
        public static string SwapCharacters(this string str, int i, int j)
        {
            if (i >= str.Length || j >= str.Length || i < 0 || j < 0)
                return str;
            
            var newStr = string.Empty;
            var chr = '\0';
            for (int index = 0; index < str.Length; index++)
            {
                if (index == i)
                    chr = str[j];
                else if (index == j)
                    chr = str[i];
                else
                    chr = str[index];

                newStr += chr;
            }

            return newStr;
        }
    }
}
