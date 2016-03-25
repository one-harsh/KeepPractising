using System.Collections.Generic;

namespace KeepPractising.Sorting
{
    public static class MyAnagramSort
    {
        public static void AnagramSort(this string[] items, int startIndex = -1, int endIndex = -1)
        {
            if (items == null || items.Length == 0)
                return;

            startIndex = startIndex == -1 ? 0 : startIndex;
            endIndex = endIndex == -1 ? items.Length - 1 : endIndex;
            Sort(items, startIndex, endIndex);
        }

        private static void Sort(string[] items, int startIndex, int endIndex)
        {
            var anagramMap = new Dictionary<string, List<string>>();
            for (int i = startIndex; i <= endIndex; i++)
            {
                var keyArray = items[i].ToCharArray();
                keyArray.QuickSort();
                var key = new string(keyArray);

                if (!anagramMap.ContainsKey(key))
                    anagramMap.Add(key, new List<string>());

                anagramMap[key].Add(items[i]);
            }

            int count = startIndex;
            foreach (var anagramCollection in anagramMap)
                foreach (var str in anagramCollection.Value)
                {
                    items[count] = str;
                    count++;
                }
        }
    }
}
