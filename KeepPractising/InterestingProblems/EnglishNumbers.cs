using System;

namespace KeepPractising.InterestingProblems
{
    class EnglishNumbers
    {
        readonly string[] firstDigits = new string[]
            {
                " zero ", " one ", " two ", " three ", " four ", " five ", " six ", " seven ", " eight ", " nine "
            };

        readonly string[] tens = new string[]
        {
              " ten ", " eleven ", " twelve ", " thirteen ", " fourteen ", " fifteen ", " sixteen ", " seventeen ", " eighteen ", " nineteen "
        };

        readonly string[] doubleDigits = new string[]
        {
              " twenty ", " thirty ", " forty ", " fifty ", " sixty ", " seventy ", " eighty ", " ninety "
        };

        readonly string[] powers = new string[]
        {
              " hundred ", " thousand "
        };

        /// <summary>
        /// This method prints the english equivalent of the given number. The allowed range is 0-999,999.
        /// </summary>
        /// <param name="num"></param>
        public void PrintWord(int num)
        {
            if (num < 0 || num > 999999)
                throw new Exception(string.Format("The provided number - {0} is outside the allowed range."));

            if (num.ToString().Length <= 3)
                Console.WriteLine(GetWord(num));
            else
            {
                var word = WordFor3Digits(num / 1000) + powers[1];
                word = word + GetWord(num - (num / 1000) * 1000);
                Console.WriteLine(word);
            }
        }

        private string GetWord(int num)
        {
            if (num < 100)
                return WordFor2Digits(num);
            else
                return WordFor3Digits(num);
        }

        private string WordFor3Digits(int num)
        {
            var word = "";
            var rem = num / 100;
            var mod = num % 100;
            if (rem > 0)
                word = firstDigits[rem] + powers[0];
            if (mod > 0)
                word = word + WordFor2Digits(mod);
            return word;

        }

        private string WordFor2Digits(int num)
        {
            if (num < 10)
                return firstDigits[num];
            else if (num < 20)
                return tens[num - 10];

            for (int i = 0; i < doubleDigits.Length; i++)
            {
                var twoDigitNum = doubleDigits[i];
                int upperCap = 20 + 10 * i;
                if (upperCap + 10 > num)
                {
                    if ((num % 10) != 0)
                        return twoDigitNum + firstDigits[num % 10];
                    return twoDigitNum;
                }
            }

            // Should never happen
            return null;
        }
    }
}