using KeepPractising.Trees;

namespace KeepPractising.Graphs
{
    public class MyGraph<T>
    {
        private NodeList<T> nodes;

        public MyGraph()
        {
            nodes = new NodeList<T>();
        }

        public MyGraph(NodeList<T> nodes)
        {
            this.nodes = nodes == null ? new NodeList<T>() : nodes;
        }

        public NodeList<T> Nodes
        {
            get
            {
                return nodes;
            }
        }

        public int NodeCount
        {
            get
            {
                return nodes.Count;
            }
        }

        public void AddNode(MyGraphNode<T> node)
        {
            nodes.Add(node);
        }

        public void AddNode(MyNode<T> node)
        {
            var graphNode = node as MyGraphNode<T>;
            if (graphNode == null)
                return;

            AddNode(graphNode);
        }

        public void AddNode(T data)
        {
            AddNode(new MyGraphNode<T>(data));
        }

        public void AddDirectedEdge(MyGraphNode<T> from, MyGraphNode<T> to, int cost)
        {
            from.Neighbors.Add(to);
            from.Weights.Add(cost);
        }

        public void AddDirectedEdge(MyNode<T> from, MyGraphNode<T> to, int cost)
        {
            var fromGraphNode = from as MyGraphNode<T>;

            if (fromGraphNode == null)
                return;

            AddDirectedEdge(fromGraphNode, to, cost);
        }

        public void AddDirectedEdge(MyGraphNode<T> from, MyNode<T> to, int cost)
        {
            var toGraphNode = to as MyGraphNode<T>;

            if (toGraphNode == null)
                return;

            AddDirectedEdge(from, toGraphNode, cost);
        }

        public void AddDirectedEdge(MyNode<T> from, MyNode<T> to, int cost)
        {
            var fromGraphNode = from as MyGraphNode<T>;
            var toGraphNode = to as MyGraphNode<T>;

            if (fromGraphNode == null || toGraphNode == null)
                return;

            AddDirectedEdge(fromGraphNode, toGraphNode, cost);
        }

        public void AddUndirectedEdge(MyGraphNode<T> from, MyGraphNode<T> to, int cost)
        {
            from.Neighbors.Add(to);
            from.Weights.Add(cost);

            to.Neighbors.Add(from);
            to.Weights.Add(cost);
        }

        public void AddUndirectedEdge(MyNode<T> from, MyGraphNode<T> to, int cost)
        {
            var fromGraphNode = from as MyGraphNode<T>;

            if (fromGraphNode == null)
                return;

            AddUndirectedEdge(fromGraphNode, to, cost);
        }

        public void AddUndirectedEdge(MyGraphNode<T> from, MyNode<T> to, int cost)
        {
            var toGraphNode = to as MyGraphNode<T>;

            if (toGraphNode == null)
                return;

            AddUndirectedEdge(from, toGraphNode, cost);
        }

        public void AddUndirectedEdge(MyNode<T> from, MyNode<T> to, int cost)
        {
            var fromGraphNode = from as MyGraphNode<T>;
            var toGraphNode = to as MyGraphNode<T>;

            if (fromGraphNode == null || toGraphNode == null)
                return;

            AddUndirectedEdge(fromGraphNode, toGraphNode, cost);
        }

        public bool Contains(T data)
        {
            return nodes.FindByData(data) != null;
        }

        public bool Remove(T data)
        {
            MyGraphNode<T> reqNode = nodes.FindByData(data) as MyGraphNode<T>;

            if (reqNode == null)
                return false;

            nodes.Remove(reqNode);

            // Remove all the edges to this node
            foreach (MyGraphNode<T> node in nodes)
            {
                var index = node.Neighbors.IndexOf(reqNode);
                if (index != -1)
                {
                    node.Neighbors.RemoveAt(index);
                    node.Weights.RemoveAt(index);
                }
            }
            return true;
        }
    }
}
