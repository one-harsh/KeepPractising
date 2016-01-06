using KeepPractising.Sorting;
using System;
using System.Collections.Generic;

namespace KeepPractising.Strings
{
    class Permutations
    {
        // This HashSet lets us maintain non-repeated permutations in case of repeated characters in string.
        // If it's okay to print a permutation twice caused by the repeated character,
        // we can eliminate this HashSet and directly print the permutation instead of maintaining it in HashSet.
        HashSet<string> permutationsSet;

        public Permutations()
        {
            permutationsSet = new HashSet<string>();
        }

        /// <summary>
        /// Prints all the permutations of the string.
        /// Takes O(n!) time and O(n!) space.
        /// </summary>
        /// <param name="str">The string whose permutations are to be printed</param>
        public void PrintAllPermutationsWithoutRepetition(string str)
        {
            permutationsSet = new HashSet<string>();
            PermuteGivenString(str, 0, str.Length - 1);
            PrintPermutations();
        }

        private void PrintPermutations()
        {
            Console.WriteLine("Total number of permutations found - " + permutationsSet.Count);
            foreach (var str in permutationsSet)
                Console.WriteLine(str);
        }

        private void PermuteGivenString(string str, int left, int right)
        {
            if (left == right)
            {
                permutationsSet.Add(str);
                return;
            }

            for (int i = left; i <= right; i++)
            {
                str = str.SwapCharacters(i, left);
                PermuteGivenString(str, left + 1, right);
                str = str.SwapCharacters(i, left);
            }
        }
    }
}
