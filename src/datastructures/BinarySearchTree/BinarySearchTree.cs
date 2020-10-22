using System.Xml;

namespace AD
{
    public partial class BinarySearchTree<T> : BinaryTree<T>, IBinarySearchTree<T>
        where T : System.IComparable<T>
    {

        //----------------------------------------------------------------------
        // Interface methods that have to be implemented for exam
        //----------------------------------------------------------------------

        public void Insert(T x)
        {
            if (root == null)
            {
                root = new BinaryNode<T>(x, null, null);
                return;
            }
            Insert(root, x);
        }

        private void Insert(BinaryNode<T> node, T value)
        {
            BinaryNode<T> newNode = new BinaryNode<T>(value, null, null);
            
            int comparison = node.data.CompareTo(value);

            if (comparison > 0) // value < node.data
            {
                if (node.left == null)
                {
                    node.left = newNode;
                }
                else
                {
                    Insert(node.left, value);
                }
            }
            else if(comparison < 0) // value > node.data
            {
                if (node.right == null)
                {
                    node.right = newNode;
                }
                else
                {
                    Insert(node.right, value);
                }
            }
            else
            {
                throw new BinarySearchTreeDoubleKeyException();
            }
            
        }

        public T FindMin()
        {
            if (IsEmpty()) throw new BinarySearchTreeEmptyException();
            return FindMin(root).data;
        }

        private BinaryNode<T> FindMin(BinaryNode<T> node)
        {
            if (node.left == null) return node;
            return FindMin(node.left);
        }

        public void RemoveMin()
        {
            if (IsEmpty()) throw new BinarySearchTreeEmptyException();
            root = RemoveMin(root);
        }

        private BinaryNode<T> RemoveMin(BinaryNode<T> node)
        {
            if (node == null) throw new BinarySearchTreeElementNotFoundException();

            if (node.left == null)
            {
                return node.right;
            }

            node.left = RemoveMin(node.left);
            return node;
        }

        public void Remove(T x)
        {
            root = Remove(root, x);
        }

        private BinaryNode<T> Remove(BinaryNode<T> node, T value)
        {
            if (node == null) throw new BinarySearchTreeElementNotFoundException();
            int comparison = node.data.CompareTo(value);

            if (comparison > 0) // value < node
            {
                node.left = Remove(node.left, value);
            } else if (comparison < 0) // value > node
            {
                node.right = Remove(node.right, value);
            } else // Found node
            {
                if (node.left != null && node.right != null) // two children
                {
                    node.data = FindMin(node.right).data;
                    node.right = RemoveMin(node.right);
                }
                else // one child
                {
                    node = node.left ?? node.right;
                }
                
            }
            
            return node; // Node to be found
        }

        private BinaryNode<T> FindNode(BinaryNode<T> node, T value)
        {
            if (node == null) throw new BinarySearchTreeElementNotFoundException();

            int comparison = value.CompareTo(node.data);
            
            if (comparison == 0) return node;

            if (comparison > 0) // value < node
            {
                return FindNode(node.left, value);
            }
            else // value > node
            {
                return FindNode(node.right, value);
            }
        }

        public string InOrder()
        {
            return IsEmpty() ? "" : InOrder(root).Trim();
        }

        private string InOrder(BinaryNode<T> node)
        {
            if (node == null) return "";
            return InOrder(node.left)
                   + node.data + " "
                   + InOrder(node.right);
        }

        public override string ToString()
        {
            return InOrder();
        }
    }
}
