using KeepPractising.Trees;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace KeepPractising.Graphs
{
    class DijkstraShortestPath<T> where T : IComparable<T>, IEquatable<T>
    {
        class DijkstraMinHeapNode : IComparable<DijkstraMinHeapNode>, IEquatable<DijkstraMinHeapNode>
        {
            public DijkstraMinHeapNode(MyGraphNode<T> vertex, int distance)
            {
                Vertex = vertex;
                Distance = distance;
            }

            public MyGraphNode<T> Vertex { get; private set; }

            public int Distance { get; set; }

            public bool Equals(DijkstraMinHeapNode otherNode)
            {
                if (otherNode == null)
                    return false;

                if (otherNode.Distance == Distance && otherNode.Vertex.Data.Equals(Vertex.Data))
                    return true;
                else
                    return false;
            }

            public override bool Equals(object obj)
            {
                if (obj == null)
                    return false;

                var otherNode = obj as DijkstraMinHeapNode;
                if (otherNode == null)
                    return false;
                else
                    return Equals(otherNode);
            }

            public override int GetHashCode()
            {
                return base.GetHashCode();
            }

            public int CompareTo(DijkstraMinHeapNode otherNode)
            {
                return Distance - otherNode.Distance;
            }
        }

        public void FindShortestPath(MyGraph<T> graph, MyGraphNode<T> source, MyGraphNode<T> destination)
        {
            var previousNodes = new Dictionary<MyGraphNode<T>, MyGraphNode<T>>();
            var distances = new Dictionary<MyGraphNode<T>, int>();
            DijkstraTraversal(graph, source, destination, previousNodes, distances);

            var path = new LinkedLists.MyLinkedList<MyGraphNode<T>>();
            var traverse = true;
            var dest = destination;
            while (traverse)
            {
                path.AddFirst(dest);

                if (dest.Equals(source))
                    traverse = false;

                dest = previousNodes[dest];
            }

            var node = path.FirstNode;
            while (node != null)
            {
                Console.WriteLine(node.Object.Data);
                node = node.Next;
            }
        }

        private static void FixUp(Collection<DijkstraMinHeapNode> heap, int bottom, Dictionary<DijkstraMinHeapNode, int> positionDict)
        {
            DijkstraMinHeapNode temp;
            int tempPos;
            int k = (bottom - 1) / 2, j = bottom;
            while (k >= 0)
            {
                if (heap[k].CompareTo(heap[j]) <= 0)
                    break;

                temp = heap[k];
                tempPos = positionDict[heap[k]];
                heap[k] = heap[j];
                positionDict[heap[k]] = positionDict[heap[j]];
                heap[j] = temp;
                positionDict[heap[j]] = tempPos;

                j = k;
                k = (k - 1) / 2;
            }
        }

        private static Dictionary<MyGraphNode<T>, DijkstraMinHeapNode> CreateMinHeapAndGetDijkstraNodeMap(MyGraph<T> graph, MyGraphNode<T> source, Collection<DijkstraMinHeapNode> heap, Dictionary<MyGraphNode<T>, MyGraphNode<T>> previousNode, Dictionary<MyGraphNode<T>, int> distances, Dictionary<DijkstraMinHeapNode, int> positionDict)
        {
            var dijkstraNodeMap = new Dictionary<MyGraphNode<T>, DijkstraMinHeapNode>();

            // int.MaxValue is treated as "infinity".
            for (int i = 0; i < graph.NodeCount; i++)
            {
                var node = new DijkstraMinHeapNode(graph.Nodes[i] as MyGraphNode<T>, int.MaxValue);
                dijkstraNodeMap[graph.Nodes[i] as MyGraphNode<T>] = node;
                heap.Add(node);
                distances[node.Vertex] = int.MaxValue;
                positionDict[node] = i;

                if (source.Data.Equals(graph.Nodes[i].Data))
                {
                    var temp = heap[0];
                    var tempPos = positionDict[heap[0]];
                    heap[0] = heap[i];
                    positionDict[heap[i]] = positionDict[heap[i]];
                    heap[i] = temp;
                    positionDict[heap[i]] = tempPos;

                    heap[0].Distance = 0;

                    previousNode[heap[0].Vertex] = heap[0].Vertex;
                    distances[heap[0].Vertex] = heap[0].Distance;
                }
            }

            return dijkstraNodeMap;
        }

        private static void DijkstraTraversal(MyGraph<T> graph, MyGraphNode<T> source, MyGraphNode<T> destination, Dictionary<MyGraphNode<T>, MyGraphNode<T>> previousNodes, Dictionary<MyGraphNode<T>, int> distances)
        {
            var heap = new Collection<DijkstraMinHeapNode>();
            var positionDict = new Dictionary<DijkstraMinHeapNode, int>();
            var nodeMap = CreateMinHeapAndGetDijkstraNodeMap(graph, source, heap, previousNodes, distances, positionDict);

            var bottom = graph.NodeCount - 1;
            var root = 0;
            var visitedSet = new HashSet<MyGraphNode<T>>();
            while (root <= bottom)
            {
                var minHeapNode = heap.ExtractMin(bottom, positionDict);
                visitedSet.Add(minHeapNode.Vertex);
                bottom--;

                if (minHeapNode.Vertex.Equals(destination))
                    break;

                for (int i = 0; i < minHeapNode.Vertex.Neighbors.Count; i++)
                    if (!visitedSet.Contains(minHeapNode.Vertex.Neighbors[i] as MyGraphNode<T>))
                    {
                        var node = minHeapNode.Vertex.Neighbors[i] as MyGraphNode<T>;
                        if (distances[node] > minHeapNode.Distance + minHeapNode.Vertex.Weights[i])
                        {
                            heap[positionDict[nodeMap[node]]].Distance = minHeapNode.Distance + minHeapNode.Vertex.Weights[i];
                            distances[node] = heap[positionDict[nodeMap[node]]].Distance;
                            previousNodes[node] = minHeapNode.Vertex;

                            FixUp(heap, positionDict[nodeMap[node]], positionDict);
                        }
                    }
            }
        }
    }
}
