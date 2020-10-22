using System;

namespace AD
{
    public partial class FirstChildNextSibling<T> : IFirstChildNextSibling<T>
    {
        public FCNSNode<T> root;

        public int Size()
        {
            return IsEmpty() ? 0 : SizeRecursive(root);
        }

        private bool IsEmpty()
        {
            return root == null;
        }

        private int SizeRecursive(FCNSNode<T> node)
        {
            if (node == null) return 0;
            return SizeRecursive(node.firstChild) + SizeRecursive(node.nextSibling) + 1;
        }

        public void PrintPreOrder()
        {
            Console.WriteLine(PreOrderRecursive(root));
        }

        private string PreOrderRecursive(FCNSNode<T> node)
        {
            if (node == null) return "";
            return node.data 
                   + (node.firstChild != null ? Environment.NewLine + " " + PreOrderRecursive(node.firstChild) : "") 
                   + (node.nextSibling != null ? Environment.NewLine + " " + PreOrderRecursive(node.nextSibling) : "");
        }

        public override string ToString()
        {
            return IsEmpty() ? "NIL" : this.TraversePreOrder(root);
        }

        private string TraversePreOrder(FCNSNode<T> node)
        {
            // outcome: <data>,FC(<contents first child>),NS(<contents next sibling>)
            return node.data 
                   + (node.firstChild != null ? ",FC(" + TraversePreOrder(node.firstChild) + ")" : "") 
                   + (node.nextSibling != null ? ",NS(" + TraversePreOrder(node.nextSibling) + ")" : "");
        }

    }
}