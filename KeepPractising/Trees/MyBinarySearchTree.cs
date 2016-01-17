using System;

namespace KeepPractising.Trees
{
    public class MyBinarySearchTree<T> where T : IComparable, IEquatable<T>
    {
        public MyBinarySearchTree(T rootData)
        {
            Root = new MyBinarySearchTreeNode(rootData);
        }

        public MyBinarySearchTreeNode Root { get; private set; }

        private interface INodeAction
        {
            MyBinarySearchTreeNode SetLeftNode(MyBinarySearchTreeNode node);

            MyBinarySearchTreeNode SetRightNode(MyBinarySearchTreeNode node);

            void SetData(T data);
        }

        public class MyBinarySearchTreeNode : INodeAction
        {
            T data;
            MyBinarySearchTreeNode leftNode, rightNode;

            public MyBinarySearchTreeNode(T data)
            {
                this.data = data;
            }

            public T Data
            {
                get
                {
                    return data;
                }
            }

            public MyBinarySearchTreeNode LeftNode
            {
                get
                {
                    return leftNode;
                }
            }

            public MyBinarySearchTreeNode RightNode
            {
                get
                {
                    return rightNode;
                }
            }

            MyBinarySearchTreeNode INodeAction.SetLeftNode(MyBinarySearchTreeNode node)
            {
                return leftNode = node;
            }

            MyBinarySearchTreeNode INodeAction.SetRightNode(MyBinarySearchTreeNode node)
            {
                return rightNode = node;
            }

            void INodeAction.SetData(T data)
            {
                this.data = data;
            }
        }

        private MyBinarySearchTreeNode FindMinValueNodeWithGivenRoot(MyBinarySearchTreeNode root)
        {
            var current = root;
            while (current.LeftNode != null)
                current = current.LeftNode;

            return current;
        }

        private MyBinarySearchTreeNode FindMaxValueNodeWithGivenRoot(MyBinarySearchTreeNode root)
        {
            var current = root;
            while (current.RightNode != null)
                current = current.RightNode;

            return current;
        }

        private MyBinarySearchTreeNode FindNode(MyBinarySearchTreeNode currentRoot, T data)
        {
            if (currentRoot == null || currentRoot.Data.Equals(data))
                return currentRoot;
            else if (currentRoot.Data.CompareTo(data) < 0)
                return FindNode(currentRoot.RightNode, data);
            else
                return FindNode(currentRoot.LeftNode, data);
        }

        private MyBinarySearchTreeNode DeleteWithGivenRoot(MyBinarySearchTreeNode root, T data)
        {
            if (root == null)
                return null;
            if (root.Data.CompareTo(data) > 0)
                (root as INodeAction).SetLeftNode(DeleteWithGivenRoot(root.LeftNode, data));
            else if (root.Data.CompareTo(data) < 0)
                (root as INodeAction).SetRightNode(DeleteWithGivenRoot(root.RightNode, data));
            else
            {
                if (root.LeftNode == null)
                    return root.RightNode;
                else if (root.RightNode == null)
                    return root.LeftNode;

                var minNode = FindMinValueNodeWithGivenRoot(root.RightNode);
                (root as INodeAction).SetData(minNode.Data);
                (root as INodeAction).SetRightNode(DeleteWithGivenRoot(root.RightNode, minNode.Data));
            }

            return root;
        }

        public MyBinarySearchTreeNode Insert(T data)
        {
            var node = new MyBinarySearchTreeNode(data);
            if (Root == null)
                return Root = node;

            var currentRoot = Root;
            while (currentRoot != null)
            {
                if (currentRoot.Data.CompareTo(data) < 0)
                {
                    if (currentRoot.RightNode == null)
                        break;

                    currentRoot = currentRoot.RightNode;
                }
                else
                {
                    if (currentRoot.LeftNode == null)
                        break;

                    currentRoot = currentRoot.LeftNode;
                }
            }

            if (currentRoot.Data.CompareTo(data) < 0)
                return (currentRoot as INodeAction).SetRightNode(node);
            else
                return (currentRoot as INodeAction).SetLeftNode(node);
        }

        public void Delete(T data)
        {
            DeleteWithGivenRoot(Root, data);
        }

        public void Delete(MyBinarySearchTreeNode node)
        {
            Delete(node.Data);
        }

        public MyBinarySearchTreeNode Search(T data)
        {
            return FindNode(Root, data);
        }
    }
}
