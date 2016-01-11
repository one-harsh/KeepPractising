using System;

namespace KeepPractising.Strings
{
    class StringsTestSuite
    {
        public static void TestFirstNonRepeatingCharacter()
        {
            var str = "ABCDEFghijABCDeF";
            Console.WriteLine("The first non-repeating character in \"{0}\" is '{1}'.", str, str.FindFirstNonRepeatingCharacter());

            str = null;
            Console.WriteLine("The first non-repeating character in NULL string is '{1}'.", str, str.FindFirstNonRepeatingCharacter());
        }

        public static void TestAllPermutationsOfString()
        {
            var perm = new Permutations();
            var str = "ACAE";
            Console.WriteLine("The given string for permutations is \"{0}\".", str);
            perm.PrintAllPermutationsWithoutRepetition(str);
        }

        public static void FindLongestCommonSuffix()
        {
            var str1 = "Flacid";
            var str2 = "Falafel";

            Console.WriteLine("Longest common suffix of \"{0}\" & \"{1}\" is \"{2}\".", str1, str2, str1.FindLongestCommonSubstring(str2));
        }

        public static void FindLongestCommonSubsequence()
        {
            var str1 = "Fanciful";
            var str2 = "Falafel";

            Console.WriteLine("Longest common suffix of \"{0}\" & \"{1}\" is \"{2}\".", str1, str2, str1.FindLongestCommonSubsequence(str2));
        }
    }
}
