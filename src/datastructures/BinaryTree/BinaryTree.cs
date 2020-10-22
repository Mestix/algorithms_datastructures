using System;

namespace AD
{
    public partial class BinaryTree<T> : IBinaryTree<T>
    {
        public BinaryNode<T> root;

        //----------------------------------------------------------------------
        // Cunstructors
        //----------------------------------------------------------------------

        public BinaryTree()
        {
            root = null;
        }

        public BinaryTree(T rootItem)
        {
            root = new BinaryNode<T>(rootItem, null, null);
        }


        //----------------------------------------------------------------------
        // Interface methods that have to be implemented for exam
        //----------------------------------------------------------------------

        public BinaryNode<T> GetRoot()
        {
            return root;
        }

        public int Size()
        {
            return IsEmpty() ? 0 : SizeRecursive(root);       // Size calculation from binary tree
            // return IsEmpty() ? 0 : root.Size();            // Size calculation from root node 
        }

        public int Height()
        {
            return IsEmpty() ? -1 : HeightRecursive(root);    // Height calculation from Binary tree
            // return IsEmpty() ? -1 : root.Height(root);     // Height calculation from root node
        }

        private int SizeRecursive(BinaryNode<T> node)
        {
            if (node == null) return 0;
            return SizeRecursive(node.left) + SizeRecursive(node.right) + 1;
        }

        private int HeightRecursive(BinaryNode<T> node)
        {
            if (node == null) return - 1; // if tree is empty the height is =1 because when the tree only has a root the height is 0

            int leftDepth = HeightRecursive(node.left); // calculate left depth from node
            int rightDepth = HeightRecursive(node.right); // calculate right depth from node

            return Math.Max(leftDepth, rightDepth) + 1; // return the greatest value from both left depth and right depth and add 1 
        }

        public void MakeEmpty()
        {
            root = null;
        }

        public bool IsEmpty()
        {
            return root == null;
        }

        public void Merge(T rootItem, BinaryTree<T> t1, BinaryTree<T> t2)
        {
            if (t1.root == t2.root && t1.root != null) throw new Exception(); // trying to merge the same trees

            root = new BinaryNode<T>(rootItem, t1.root, t2.root); // add tree t1 as left child and tree t2 as right child from given root node

            if (this != t1) t1.root = null; 
            if (this != t2) t2.root = null;
        }

        private string PrefixTraverse(BinaryNode<T> node)
        {
            if (node == null) return "NIL";

            return "["  
                   + " " + node.data
                   + " " + PrefixTraverse(node.left) 
                   + " " + PrefixTraverse(node.right)
                   + " ]";
        }

        private string InfixTraverse(BinaryNode<T> node)
        {
            if (node == null) return "NIL";

            return "["  
                   + " " + InfixTraverse(node.left) 
                   + " " + node.data
                   + " " + InfixTraverse(node.right)
                   + " ]";
        }

        private string PostfixTraverse(BinaryNode<T> node)
        {
            if (node == null) return "NIL";

            return "[" 
                   + " " + PostfixTraverse(node.left) 
                   + " " + PostfixTraverse(node.right)
                   + " " + node.data
                   + " ]";
        }
        
        public string ToPrefixString()
        {
            return IsEmpty() ? "NIL" : PrefixTraverse(root);
        }

        public string ToInfixString()
        {
            return IsEmpty() ? "NIL" : InfixTraverse(root);
        }

        public string ToPostfixString()
        {
            return IsEmpty() ? "NIL" : PostfixTraverse(root);
        }


        //----------------------------------------------------------------------
        // Interface methods : methods that have to be implemented for homework
        //----------------------------------------------------------------------

        public int NumberOfLeaves()
        {
            // return IsEmpty() ? 0 : root.Leaves();
            return IsEmpty() ? 0 : NumberOfLeavesRecursive(root);
        }

        public int NumberOfNodesWithOneChild()
        {
            // return IsEmpty() ? 0 : root.LeavesWithOneChild();
            return IsEmpty() ? 0 : NumberOfNodesWithOneChildRecursive(root);
        }

        public int NumberOfNodesWithTwoChildren()
        {
            // return IsEmpty() ? 0 : root.LeavesWithTwoChildren();
            return IsEmpty() ? 0 : NumberOfNodesWithTwoChildrenRecursive(root);
        }

        private int NumberOfLeavesRecursive(BinaryNode<T> node)
        {
            if (node.left == null && node.right == null) return 1;
            return (node.left?.Leaves() ?? 0) + (node.right?.Leaves() ?? 0);
        }

        private int NumberOfNodesWithOneChildRecursive(BinaryNode<T> node)
        {
            if (node.left == null && node.right != null) return 1;
            if (node.right == null && node.left != null) return 1;
            return (node.left?.LeavesWithOneChild() ?? 0) + (node.right?.LeavesWithOneChild() ?? 0);
        }

        private int NumberOfNodesWithTwoChildrenRecursive(BinaryNode<T> node)
        {
            if (node.left != null && node.right != null) return 1 + (node.left.LeavesWithTwoChildren()) + (node.right.LeavesWithTwoChildren());
            return 0;
        }
    }
}