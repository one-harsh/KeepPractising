using KeepPractising.Trees;
using System.Collections.Generic;

namespace KeepPractising.Graphs
{
    public class MyGraphNode<T> : MyNode<T>
    {
        List<int> weights;

        public MyGraphNode(T data) : base(data) { }

        public new NodeList<T> Neighbors
        {
            get
            {
                if (base.Neighbors == null)
                    base.Neighbors = new NodeList<T>();

                return base.Neighbors;
            }
        }

        public List<int> Weights
        {
            get
            {
                if (weights == null)
                    weights = new List<int>();

                return weights;
            }
        }
    }
}
