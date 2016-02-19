namespace KeepPractising.InterestingProblems
{
    class NonConsecutive1BinaryStrings
    {
        /// <summary>
        /// This method finds the number of binary strings of given length without consecutive 1s in them.
        /// The method uses DP approach to solve it as 0 can be appended to all the strings ending in 0 or 1, 
        /// while 1 can only be appended to the strings which end in 0.
        /// </summary>
        /// <param name="length">The lenght of valid binary strings to be considered.</param>
        /// <returns>Count of all binary strings without consecutive 1s.</returns>
        /// As is evident, it follows the Fibonnacci series with a series shifted leftwards by 1.
        public int CountBinaryStringsNonConsecutive1s(int length)
        {
            if (length <= 0)
                return 0;

            var endingZeros = new int[length];
            var endingOnes = new int[length];

            endingZeros[0] = 1;
            endingOnes[0] = 1;

            var i = 1;
            while (i < length)
            {
                // Count of strings ending in 0s for a given length 'i' is count of all strings with length (i - 1) as 0 can be appended to any string.
                endingZeros[i] = endingZeros[i - 1] + endingOnes[i - 1];

                // Count of strings ending in 1s for a given length 'i' is count of strings ending in 0s with length (i - 1) as 1 can be appended only to them.
                endingOnes[i] = endingZeros[i - 1];

                i++;
            }

            return endingZeros[length - 1] + endingOnes[length - 1];
        }
    }
}
