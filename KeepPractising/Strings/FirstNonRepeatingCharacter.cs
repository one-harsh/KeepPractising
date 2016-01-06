using System.Collections.Generic;

namespace KeepPractising.Strings
{
    public static class FirstNonRepeatingCharacter
    {
        public static char FindFirstNonRepeatingCharacter(this string str)
        {
            if (string.IsNullOrEmpty(str))
                return default(char);

            var charTable = new Dictionary<char, int>();
            foreach (var chr in str)
            {
                if (charTable.ContainsKey(chr))
                    charTable[chr] = charTable[chr] + 1;
                else
                    charTable[chr] = 1;
            }

            foreach (var chr in str)
                if (charTable[chr] == 1)
                    return chr;

            return default(char);
        }
    }
}
