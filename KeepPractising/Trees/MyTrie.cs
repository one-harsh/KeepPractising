using System;

namespace KeepPractising.Trees
{
    class MyTrie
    {
        MyTrie[] children;
        const int Int_a = (int)'a';

        public MyTrie()
        {
            children = new MyTrie[26];
        }

        public bool IsEnd { get; private set; }

        public int PrefixCount { get; private set; }

        MyTrie[] Children
        {
            get
            {
                if (children == null)
                    children = new MyTrie[26];

                return children;
            }
        }

        public void Add(string word)
        {
            var current = this;
            current.PrefixCount++;
            word = word.ToLower();

            for (int i = 0; i < word.Length; i++)
            {
                int letter = (int)word[i] - Int_a;
                if (letter >= 26 || letter < 0)
                    throw new Exception("Only characters are currently supported.");

                if (current.Children[letter] == null)
                    current.Children[letter] = new MyTrie();

                current.Children[letter].PrefixCount++;
                current = current.Children[letter];
            }

            current.IsEnd = true;
        }

        public bool Search(string word)
        {
            var current = this;
            word = word.ToLower();

            for (int i = 0; i < word.Length; i++)
            {
                int letter = (int)word[i] - Int_a;
                if (letter >= 26 || letter < 0)
                    return false;

                if (current.Children[letter] == null)
                    return false;

                current = current.Children[letter];
            }

            return current.IsEnd;
        }

        public int WordCountWithPrefix(string prefix)
        {
            var current = this;
            prefix = prefix.ToLower();

            for (int i = 0; i < prefix.Length; i++)
            {
                int letter = (int)prefix[i] - Int_a;
                if (letter >= 26 || letter < 0)
                    return 0;

                if (current.Children[letter] == null)
                    return 0;

                current = current.Children[letter];
            }

            return current.PrefixCount;
        }
    }
}
