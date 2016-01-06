using System;

namespace KeepPractising.Strings
{
    class StringsTestSuite
    {
        public static void TestFirstNonRepeatingCharacter()
        {
            var str = "ABCDEFghijABCDeF";
            Console.WriteLine(string.Format("The first non-repeating character in \"{0}\" is '{1}'.", str, str.FindFirstNonRepeatingCharacter()));

            str = null;
            Console.WriteLine(string.Format("The first non-repeating character in NULL string is '{1}'.", str, str.FindFirstNonRepeatingCharacter()));
        }

        public static void TestAllPermutationsOfString()
        {
            var perm = new Permutations();
            var str = "ACAE";
            Console.WriteLine("The given string for permutations is \"" + str + "\".");
            perm.PrintAllPermutationsWithoutRepetition(str);
        }
    }
}
