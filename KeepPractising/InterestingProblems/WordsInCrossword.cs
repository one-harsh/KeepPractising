using KeepPractising.Graphs;
using KeepPractising.Stacks;
using KeepPractising.Trees;
using System;
using System.Collections.Generic;

namespace KeepPractising.InterestingProblems
{
    /// <summary>
    /// This class helps in finding all the words present in a given crossword when a dictionary containing all the essential words are provided.
    /// </summary>
    /// The following problem can also be solved using graphs, just the same way it was done for finding median size of a given cluster problem.
    /// Build the forest (a simple connected graph in this case). Traverse and check if the word exists in the HashSet. 
    /// It, however, brings the overhead of building the graph, when we already know that all nodes are completely connected to its every adjacent nodes.
    class WordsInCrossword
    {
        MyTrie trie5kWords = new MyTrie();

        public WordsInCrossword()
        {
            var words = System.IO.File.ReadAllLines("Assets/5000.txt");

            var fiveKWords = new HashSet<string>();
            foreach (var word in words)
            {
                if (!fiveKWords.Contains(word))
                {
                    try
                    {
                        trie5kWords.Add(word);
                        fiveKWords.Add(word);
                    }
                    catch (Exception)
                    {
                        continue;
                    }
                }
            }
        }

        /// <summary>
        /// Finds all the words present in the given crossword grid.
        /// </summary>
        /// <param name="crosswordGrid"></param>
        public void FindAllWords(char[,] crosswordGrid)
        {
            var visitedGrid = new bool[crosswordGrid.GetLength(0), crosswordGrid.GetLength(1)];
            for (int i = 0; i < crosswordGrid.GetLength(0); i++)
                for (int j = 0; j < crosswordGrid.GetLength(1); j++)
                    visitedGrid[i, j] = false;

            string word = string.Empty;
            HashSet<string> words = new HashSet<string>();
            
            for (int i = 0; i < crosswordGrid.GetLength(0); i++)
                for (int j = 0; j < crosswordGrid.GetLength(1); j++)
                    FindWords(crosswordGrid, visitedGrid, i, j, word, words);
        }

        /// <summary>
        /// Find all words with given starting point. It recursively calls itself to move into different directions with the current state of the word formed along with the next index to visit.
        /// </summary>
        /// <param name="crosswordGrid"></param>
        /// <param name="visitedGrid"></param>
        /// <param name="i"></param>
        /// <param name="j"></param>
        /// <param name="str"></param>
        /// <param name="wordList"></param>
        private void FindWords(char[,] crosswordGrid, bool[,] visitedGrid, int i, int j, string str, HashSet<string> wordList)
        {
            visitedGrid[i, j] = true;
            str = str + crosswordGrid[i, j];

            if (trie5kWords.WordCountWithPrefix(str) > 0)
            {
                if (trie5kWords.Search(str))
                    if (!wordList.Contains(str))
                    {
                        Console.WriteLine(str);
                        wordList.Add(str); 
                    }

                for (int i1 = i - 1; i1 <= i + 1 && i1 < crosswordGrid.GetLength(0); i1++)
                    for (int j1 = j - 1; j1 <= j + 1 && j1 < crosswordGrid.GetLength(1); j1++)
                        if (i1 >= 0 && j1 >= 0 && !visitedGrid[i1, j1])
                            FindWords(crosswordGrid, visitedGrid, i1, j1, str, wordList);

                str = str.Substring(0, str.Length - 1);
            }

            visitedGrid[i, j] = false;
        }
    }
}
