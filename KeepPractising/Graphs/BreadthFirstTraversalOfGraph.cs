using KeepPractising.Queues;
using System;
using System.Collections.Generic;

namespace KeepPractising.Graphs
{
    class BreadthFirstTraversalOfGraph
    {
        public void BFTraversal<T>(MyGraphNode<T> root)
        {
            var queue = new MyQueue<MyGraphNode<T>>();
            var set = new HashSet<MyGraphNode<T>>();

            queue.Enqueue(root);
            set.Add(root);

            while (!queue.Empty())
            {
                var vertex = queue.Dequeue();
                Console.WriteLine(vertex.Data);
                foreach (MyGraphNode<T> node in vertex.Neighbors)
                {
                    if (!set.Contains(node))
                    {
                        set.Add(node);
                        queue.Enqueue(node);
                    }
                }
            }
        }
    }
}
