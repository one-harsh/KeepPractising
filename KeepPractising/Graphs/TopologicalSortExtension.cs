using System;
using System.Collections.Generic;

namespace KeepPractising.Graphs
{
    public static class TopologicalSortExtension
    {
        /// <summary>
        /// Does a topological sort on the given graph if it is a directed acyclic graph.
        /// It throws a <see cref="NotDAGException"/> when the graph is not a DAG.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="graph"></param>
        /// <exception cref="NotDAGException"></exception>
        public static void TopologicalSort<T>(this MyGraph<T> graph)
        {
            var inDegrees = new Dictionary<MyGraphNode<T>, int>();
            var zeroDegrees = new List<MyGraphNode<T>>();

            if (!IsDirectedAcyclicGraph(graph, out inDegrees, out zeroDegrees))
                throw new NotDAGException("graph");

            while (zeroDegrees.Count != 0)
            {
                var currentNode = zeroDegrees[0];
                zeroDegrees.RemoveAt(0);

                Console.WriteLine(currentNode.Data);
                var temp = currentNode.Neighbors;
                foreach (MyGraphNode<T> node in temp)
                {
                    if (inDegrees[node] == 1)
                        zeroDegrees.Add(node);

                    inDegrees[node] = inDegrees[node] - 1;
                }
            }
        }

        /// <summary>
        /// Checks if the graph is a directed acyclic graph.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="graph"></param>
        /// <returns></returns>
        public static bool IsDirectedAcyclicGraph<T>(this MyGraph<T> graph)
        {
            Dictionary<MyGraphNode<T>, int> inDegrees;
            List<MyGraphNode<T>> zeroDegrees;
            return IsDirectedAcyclicGraph(graph, out inDegrees, out zeroDegrees);
        }

        private static bool IsDirectedAcyclicGraph<T>(MyGraph<T> graph, out Dictionary<MyGraphNode<T>, int> inDegrees, out List<MyGraphNode<T>> zeroDegrees)
        {
            zeroDegrees = new List<MyGraphNode<T>>();
            inDegrees = new Dictionary<MyGraphNode<T>, int>();
            GetInDegreesAndZeroDegreeList(graph, out inDegrees, out zeroDegrees);

            if (zeroDegrees.Count == 0)
                return false;
            
            return !IsCyclic(graph);
        }

        private static bool IsCyclic<T>(MyGraph<T> graph)
        {
            var visited = new bool[graph.NodeCount];
            var recStack = new bool[graph.NodeCount];
            for (int i = 0; i < graph.NodeCount; i++)
            {
                visited[i] = false;
                recStack[i] = false;
            }

            for (int i = 0; i < graph.NodeCount; i++)
                if (IsCyclicRecurse(graph, i, visited, recStack))
                    return true;

            return false;
        }

        private static bool IsCyclicRecurse<T>(MyGraph<T> graph, int index, bool[] visited, bool[] backTracker)
        {
            if (visited[index] == false)
            {
                visited[index] = true;
                backTracker[index] = true;

                foreach (var node in graph.Nodes[index].Neighbors)
                {
                    var i = graph.Nodes.IndexOf(node);
                    if ((!visited[i] && IsCyclicRecurse(graph, i, visited, backTracker)) || backTracker[i])
                        return true;
                }

            }

            // Restore
            backTracker[index] = false; 
            return false;
        }

        private static void GetInDegreesAndZeroDegreeList<T>(MyGraph<T> graph, out Dictionary<MyGraphNode<T>, int> inDegrees, out List<MyGraphNode<T>> zeroDegrees)
        {
            zeroDegrees = new List<MyGraphNode<T>>();
            inDegrees = new Dictionary<MyGraphNode<T>, int>();

            foreach (MyGraphNode<T> node in graph.Nodes)
            {
                var temp = node;
                foreach (MyGraphNode<T> item in node.Neighbors)
                    inDegrees[item] = inDegrees.ContainsKey(item) ? inDegrees[item] + 1 : 1;
            }

            foreach (MyGraphNode<T> node in graph.Nodes)
                if (!inDegrees.ContainsKey(node))
                    zeroDegrees.Add(node);
        }
    }

    public class NotDAGException : Exception
    {
        public NotDAGException() { }
        public NotDAGException(string message) : base(message) { }
        public NotDAGException(string message, Exception inner) : base(message, inner) { }
        protected NotDAGException(
          System.Runtime.Serialization.SerializationInfo info,
          System.Runtime.Serialization.StreamingContext context) : base(info, context)
        { }

        public override string Message
        {
            get
            {
                return "Not a directed acyclic graph.";
            }
        }
    }
}
