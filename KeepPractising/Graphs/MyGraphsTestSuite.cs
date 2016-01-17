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

            graph.AddUndirectedEdge(graph.Nodes.FindByData(10) as MyGraphNode<int>, graph.Nodes.FindByData(20) as MyGraphNode<int>, 5);
            graph.AddUndirectedEdge(graph.Nodes.FindByData(10) as MyGraphNode<int>, graph.Nodes.FindByData(30) as MyGraphNode<int>, 5);
            graph.AddUndirectedEdge(graph.Nodes.FindByData(10) as MyGraphNode<int>, graph.Nodes.FindByData(40) as MyGraphNode<int>, 5);
            graph.AddUndirectedEdge(graph.Nodes.FindByData(20) as MyGraphNode<int>, graph.Nodes.FindByData(30) as MyGraphNode<int>, 5);
            graph.AddUndirectedEdge(graph.Nodes.FindByData(20) as MyGraphNode<int>, graph.Nodes.FindByData(50) as MyGraphNode<int>, 5);
            graph.AddUndirectedEdge(graph.Nodes.FindByData(30) as MyGraphNode<int>, graph.Nodes.FindByData(40) as MyGraphNode<int>, 5);
            graph.AddUndirectedEdge(graph.Nodes.FindByData(30) as MyGraphNode<int>, graph.Nodes.FindByData(50) as MyGraphNode<int>, 5);

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

            graph.AddDirectedEdge(graph.Nodes.FindByData(10) as MyGraphNode<int>, graph.Nodes.FindByData(30) as MyGraphNode<int>, 5);
            graph.AddDirectedEdge(graph.Nodes.FindByData(10) as MyGraphNode<int>, graph.Nodes.FindByData(40) as MyGraphNode<int>, 5);
            graph.AddDirectedEdge(graph.Nodes.FindByData(20) as MyGraphNode<int>, graph.Nodes.FindByData(10) as MyGraphNode<int>, 5);
            graph.AddDirectedEdge(graph.Nodes.FindByData(20) as MyGraphNode<int>, graph.Nodes.FindByData(30) as MyGraphNode<int>, 5);
            graph.AddDirectedEdge(graph.Nodes.FindByData(20) as MyGraphNode<int>, graph.Nodes.FindByData(50) as MyGraphNode<int>, 5);
            graph.AddDirectedEdge(graph.Nodes.FindByData(30) as MyGraphNode<int>, graph.Nodes.FindByData(40) as MyGraphNode<int>, 5);
            graph.AddDirectedEdge(graph.Nodes.FindByData(30) as MyGraphNode<int>, graph.Nodes.FindByData(50) as MyGraphNode<int>, 5);

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
    }
}
