using System;

namespace KeepPractising.Graphs
{
    class MyGraphsTestSuite
    {
        private static MyGraph<int> GetADummyGraph()
        {
            var graph = new MyGraph<int>();
            graph.AddNode(10);
            graph.AddNode(20);
            graph.AddNode(30);
            graph.AddNode(40);
            graph.AddNode(50);

            graph.AddUndirectedEdge(graph.Nodes.FindByData(10), graph.Nodes.FindByData(20), 5);
            graph.AddUndirectedEdge(graph.Nodes.FindByData(10), graph.Nodes.FindByData(30), 5);
            graph.AddUndirectedEdge(graph.Nodes.FindByData(10), graph.Nodes.FindByData(40), 5);
            graph.AddUndirectedEdge(graph.Nodes.FindByData(20), graph.Nodes.FindByData(30), 5);
            graph.AddUndirectedEdge(graph.Nodes.FindByData(20), graph.Nodes.FindByData(50), 5);
            graph.AddUndirectedEdge(graph.Nodes.FindByData(30), graph.Nodes.FindByData(40), 5);
            graph.AddUndirectedEdge(graph.Nodes.FindByData(30), graph.Nodes.FindByData(50), 5);

            /*
                       10
                      / | \
                    20-30-40
                      \ |
                       50
            */

            return graph;
        }

        private static MyGraph<int> GetADummyDAG()
        {
            var graph = new MyGraph<int>();
            graph.AddNode(10);
            graph.AddNode(20);
            graph.AddNode(30);
            graph.AddNode(40);
            graph.AddNode(50);

            graph.AddDirectedEdge(graph.Nodes.FindByData(10), graph.Nodes.FindByData(30), 5);
            graph.AddDirectedEdge(graph.Nodes.FindByData(10), graph.Nodes.FindByData(40), 5);
            graph.AddDirectedEdge(graph.Nodes.FindByData(20), graph.Nodes.FindByData(10), 5);
            graph.AddDirectedEdge(graph.Nodes.FindByData(20), graph.Nodes.FindByData(30), 5);
            graph.AddDirectedEdge(graph.Nodes.FindByData(20), graph.Nodes.FindByData(50), 5);
            graph.AddDirectedEdge(graph.Nodes.FindByData(30), graph.Nodes.FindByData(40), 5);
            graph.AddDirectedEdge(graph.Nodes.FindByData(30), graph.Nodes.FindByData(50), 5);

            /*
                          10
                        ~
                       /   |   \
                           ~    ~
                    20 -~ 30 -~ 40

                       \   |
                        ~  ~
                          50
            */

            return graph;
        }

        private static MyGraph<int> GetADummyWeightedGraph()
        {
            var graph = new MyGraph<int>();
            graph.AddNode(10);
            graph.AddNode(20);
            graph.AddNode(30);
            graph.AddNode(40);
            graph.AddNode(50);

            graph.AddUndirectedEdge(graph.Nodes.FindByData(10), graph.Nodes.FindByData(20), 5);
            graph.AddUndirectedEdge(graph.Nodes.FindByData(10), graph.Nodes.FindByData(30), 5);
            graph.AddUndirectedEdge(graph.Nodes.FindByData(10), graph.Nodes.FindByData(40), 20);
            graph.AddUndirectedEdge(graph.Nodes.FindByData(20), graph.Nodes.FindByData(30), 10);
            graph.AddUndirectedEdge(graph.Nodes.FindByData(20), graph.Nodes.FindByData(50), 12);
            graph.AddUndirectedEdge(graph.Nodes.FindByData(30), graph.Nodes.FindByData(40), 10);
            graph.AddUndirectedEdge(graph.Nodes.FindByData(30), graph.Nodes.FindByData(50), 2);

            /*
                          10
                        
                      5/  5| 20\
                        10   10   
                    20  - 30  -  40

                     12\  2|
                          
                          50
            */

            return graph;
        }

        public static void TestBreadthFirstTraversal()
        {
            var graph = GetADummyGraph();
            new BreadthFirstTraversalOfGraph().BFTraversal(graph.Nodes[1] as MyGraphNode<int>);
        }

        public static void TestDepthFirstTraversal()
        {
            var graph = GetADummyGraph();
            new DepthFirstTraversalOfGraph().DFTraversal(graph.Nodes[1] as MyGraphNode<int>);
        }

        public static void TestTopologicalSortOnDAG()
        {
            var graph = GetADummyDAG();
            graph.TopologicalSort();

            try
            {
                graph = GetADummyGraph();
                graph.TopologicalSort();
            }
            catch (NotDAGException)
            {
                Console.WriteLine("Caught the expected NotDAGException as the graph was not a DAG.");
            }
        }

        public static void TestDijkstraAlgorithm()
        {
            var graph = GetADummyWeightedGraph();
            var dijkstras = new DijkstraShortestPath<int>();
            Console.WriteLine("Path between {0} and {1} is as follows - ", graph.Nodes[0].Data, graph.Nodes[3].Data);
            dijkstras.FindShortestPath(graph, graph.Nodes[0] as MyGraphNode<int>, graph.Nodes[3] as MyGraphNode<int>);
            Console.WriteLine("Path between {0} and {1} is as follows - ", graph.Nodes[1].Data, graph.Nodes[4].Data);
            dijkstras.FindShortestPath(graph, graph.Nodes[1] as MyGraphNode<int>, graph.Nodes[4] as MyGraphNode<int>);
            Console.WriteLine("Path between {0} and {1} is as follows - ", graph.Nodes[0].Data, graph.Nodes[4].Data);
            dijkstras.FindShortestPath(graph, graph.Nodes[0] as MyGraphNode<int>, graph.Nodes[4] as MyGraphNode<int>);
        }
    }
}
