using KeepPractising.Graphs;
using KeepPractising.Queues;
using KeepPractising.Sorting;
using System;
using System.Collections.Generic;

namespace KeepPractising.InterestingProblems
{
    /// <summary>
    /// Given a binary matrix where 1 denotes presence of a system and 0 doesn't, 
    /// this class finds the median of the size of these clusters where a cluster is constituted 
    /// when two systems are adjacently present and are non-diagonal.
    /// </summary>
    class MedianOfClustersSizeInGrid
    {
        class Coordinates : IEquatable<Coordinates>
        {
            public Coordinates(int x, int y)
            {
                X = x;
                Y = y;
            }

            public int X { get; private set; }
            public int Y { get; private set; }

            public bool Equals(Coordinates otherCoordinates)
            {
                if (otherCoordinates == null)
                    return false;

                if (X == otherCoordinates.X && Y == otherCoordinates.Y)
                    return true;
                else
                    return false;
            }

            public override bool Equals(object obj)
            {
                if (obj == null)
                    return false;

                Coordinates otherCoordinates = obj as Coordinates;
                if (otherCoordinates == null)
                    return false;
                else
                    return Equals(otherCoordinates);
            }

            public override int GetHashCode()
            {
                return base.GetHashCode();
            }
        }

        /// <summary>
        /// Returns a single precision floating point integer which is the median of all the clusters present in the grid.
        /// The solution takes O(M*N) extra space to build the graph using Adjacency List and takes O(M*N) time to compute the median.
        /// </summary>
        /// <param name="grid"></param>
        /// <returns></returns>
        public float FindClusterSizeMedianOfBinaryMatrixGrid(int[,] grid)
        {
            MyGraph<Coordinates> graph = new MyGraph<Coordinates>();
            BuildTheForest(grid, graph);

            var visitedSet = new HashSet<MyGraphNode<Coordinates>>();
            var sizes = new List<int>();
            foreach (MyGraphNode<Coordinates> node in graph.Nodes)
            {
                if (!visitedSet.Contains(node))
                {
                    var list = TraverseBreadthFirstAndGetVisitedSet(node);
                    foreach (MyGraphNode<Coordinates> visitedNode in list)
                        visitedSet.Add(visitedNode);

                    sizes.Add(list.Count);
                }
            }

            var temp = sizes.ToArray();
            temp.QuickSort();

            return temp.Length % 2 == 0 ? (temp[temp.Length / 2] + temp[temp.Length / 2 - 1]) / 2.0f : temp[temp.Length / 2];
        }

        private void BuildTheForest(int[,] grid, MyGraph<Coordinates> graph)
        {
            for (int i = 0; i < grid.GetLength(0); i++)
                for (int j = 0; j < grid.GetLength(1); j++)
                    if (grid[i, j] == 1)
                    {
                        var tempCoordinates = new Coordinates(i, j);
                        if (!graph.Contains(tempCoordinates))
                            graph.AddNode(tempCoordinates);

                        if (GetValidValue(grid, i + 1, j) == 1)
                        {
                            var otherCoordinates = new Coordinates(i + 1, j);
                            if (!graph.Contains(otherCoordinates))
                                graph.AddNode(otherCoordinates);
                            graph.AddUndirectedEdge(graph.Nodes.FindByData(tempCoordinates), graph.Nodes.FindByData(otherCoordinates), 0);
                        }
                        if (GetValidValue(grid, i, j + 1) == 1)
                        {
                            var otherCoordinates = new Coordinates(i, j + 1);
                            if (!graph.Contains(otherCoordinates))
                                graph.AddNode(otherCoordinates);
                            graph.AddUndirectedEdge(graph.Nodes.FindByData(tempCoordinates), graph.Nodes.FindByData(otherCoordinates), 0);
                        }
                    }
        }

        private HashSet<MyGraphNode<Coordinates>> TraverseBreadthFirstAndGetVisitedSet(MyGraphNode<Coordinates> root)
        {
            var queue = new MyQueue<MyGraphNode<Coordinates>>();
            var visitedSet = new HashSet<MyGraphNode<Coordinates>>();

            queue.Enqueue(root);
            visitedSet.Add(root);

            while (!queue.Empty())
            {
                var vertex = queue.Dequeue();
                foreach (MyGraphNode<Coordinates> node in vertex.Neighbors)
                {
                    if (!visitedSet.Contains(node))
                    {
                        visitedSet.Add(node);
                        queue.Enqueue(node);
                    }
                }
            }

            return visitedSet;
        }

        private int GetValidValue(int[,] arr, int i, int j)
        {
            return i >= arr.GetLength(0) || j >= arr.GetLength(1) ? 0 : arr[i, j];
        }
    }
}
