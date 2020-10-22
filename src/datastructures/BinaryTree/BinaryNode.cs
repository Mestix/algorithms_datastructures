using System;
using System.Drawing;

namespace AD
{
    public partial class BinaryNode<T>
    {
        public T data;
        public BinaryNode<T> left;
        public BinaryNode<T> right;

        public BinaryNode() : this(default(T), default(BinaryNode<T>), default(BinaryNode<T>)) { }

        public BinaryNode(T data, BinaryNode<T> left, BinaryNode<T> right)
        {
            this.data = data;
            this.left = left;
            this.right = right;
        }

        public int Size()
        {
            return 1 + (left?.Size() ?? 0) + (right?.Size() ?? 0);
        }

        public int Height(BinaryNode<T> node)
        {
            if (node == null) return -1;
            return Math.Max(Height(node.left), Height(node.right)) + 1;
        }

        public int Leaves()
        {
            if (left == null && right == null) return 1;
            return (left?.Leaves() ?? 0) + (right?.Leaves() ?? 0);
        }

        public int LeavesWithOneChild()
        {
            if (left == null && right != null) return 1;
            if (right == null && left != null) return 1;
            return (left?.LeavesWithOneChild() ?? 0) + (right?.LeavesWithOneChild() ?? 0);
        }
        
        public int LeavesWithTwoChildren()
        {
            if (left != null && right != null) return 1 + (left.LeavesWithTwoChildren()) + (right.LeavesWithTwoChildren());
            return 0;
        }
    }
}