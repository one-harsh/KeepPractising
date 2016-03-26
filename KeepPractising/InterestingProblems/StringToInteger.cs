using System;

namespace KeepPractising.InterestingProblems
{
    class StringToInteger
    {
        public int AToI(string str)
        {
            bool isNegative = false;

            if (str[0] == '-')
            {
                isNegative = true;
                str = str.Substring(1);
                var minString = int.MinValue.ToString().Substring(1);

                if (str.Length > int.MinValue.ToString().Length || (str.Length == minString.Length && str.CompareTo(minString) > 0))
                    throw new Exception("Integer overflow");
            }
            else if (str.Length > int.MaxValue.ToString().Length || (str.Length == int.MaxValue.ToString().Length && str.CompareTo(int.MaxValue.ToString()) > 0))
                throw new Exception("Integer overflow");

            int index = str.Length - 1;
            int num = 0;
            int temp = -1;
            while (index >= 0)
            {
                temp = GetIntegerFromASCIICode(str[index]);
                num += temp * (int)Math.Pow(10, str.Length - index - 1);
                index--;
            }

            return isNegative ? num * (-1) : num;
        }

        private int GetIntegerFromASCIICode(char chr)
        {
            if (chr > 47 && chr < 58)
                return chr - 48;
            else
                throw new Exception("Not an integer");
        }
    }
}
