using KeepPractising.Trees;

namespace KeepPractising.InterestingProblems
{
    /// <summary>
    /// This class helps in finding the median of incoming streams of integers.
    /// The idea is to use two heaps - a MaxHeap and a MinHeap. One can easily insert into a heap in O(log n) and can even extract in O(log n).
    /// <para>We will push the first half of sorted integers in MaxHeap and the second half into MinHeap so that we can calculate the median in constant time.</para>
    /// </summary>
    class MedianOfIntStream
    {
        MyMaxHeap<int> maxHeap;
        MyMinHeap<int> minHeap;

        public MedianOfIntStream()
        {
            maxHeap = new MyMaxHeap<int>();
            minHeap = new MyMinHeap<int>();
        }

        /// <summary>
        /// Inserts the data to the collection.
        /// </summary>
        /// <param name="num"></param>
        /// Inserts the data to MaxHeap if the overall collection count is even to begin with, otherwise the data is inserted to the MinHeap.
        /// Moreover, if the number being inserted into MaxHeap is greater than minimum of MinHeap, we do an extract on MinHeap and push the incoming data to the MinHeap.
        /// The extracted number from the MinHeap is then pushed to the MaxHeap, so that the peek on these heap always fetch us the middle elements.
        /// The same conditional check goes the other way round for inserting into MinHeap.
        public void Add(int num)
        {
            if ((maxHeap.Length + minHeap.Length) % 2 == 0)
            {
                if (minHeap.Length != 0 && minHeap.Peek() < num)
                {
                    var temp = minHeap.Extract();
                    minHeap.Add(num);
                    num = temp;
                }

                maxHeap.Add(num);
            }
            else
            {
                if (maxHeap.Length != 0 && maxHeap.Peek() > num)
                {
                    var temp = maxHeap.Extract();
                    maxHeap.Add(num);
                    num = temp;
                }

                minHeap.Add(num);
            }
        }

        /// <summary>
        /// Gets the median of all the integers which were inserted.
        /// </summary>
        /// <returns></returns>
        /// If the total number of elements in the collection is even, the median is calculated by peeking at both the heaps and averaging it.
        /// If the total count is odd, the median is simply calculated by peeking at the MaxHeap.
        public double GetMedian()
        {
            if (maxHeap.Length == minHeap.Length)
                return (maxHeap.Peek() + minHeap.Peek()) / 2.0;
            else
                return maxHeap.Peek();
        }
    }
}
