﻿using KeepPractising.Queues;
using System;
using System.Collections.Generic;

namespace KeepPractising.Graphs
{
    class BreadthFirstTraversalOfGraph
    {
        public void BFTraversal<T>(MyGraphNode<T> root)
        {
            var queue = new MyQueue<MyGraphNode<T>>();
            var visitedSet = new HashSet<MyGraphNode<T>>();

            queue.Enqueue(root);
            visitedSet.Add(root);

            while (!queue.Empty())
            {
                var vertex = queue.Dequeue();
                Console.WriteLine(vertex.Data);
                foreach (MyGraphNode<T> node in vertex.Neighbors)
                {
                    if (!visitedSet.Contains(node))
                    {
                        visitedSet.Add(node);
                        queue.Enqueue(node);
                    }
                }
            }
        }
    }
}
