using KeepPractising.Stacks;
using System;
using System.Collections.Generic;

namespace KeepPractising.Graphs
{
    class DepthFirstTraversalOfGraph
    {
        public void DFTraversal<T>(MyGraphNode<T> root)
        {
            var visitedSet = new HashSet<MyGraphNode<T>>();
            var stack = new MyStack<MyGraphNode<T>>();
            var vertex = root;

            stack.Push(root);
            visitedSet.Add(root);

            while (!stack.Empty())
            {
                vertex = stack.Pop();
                Console.WriteLine(vertex.Data);

                foreach (MyGraphNode<T> node in vertex.Neighbors)
                {
                    if (!visitedSet.Contains(node))
                    {
                        visitedSet.Add(node);
                        stack.Push(node);
                    }
                }
            }
        }
    }
}
