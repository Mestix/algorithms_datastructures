using System.Diagnostics.SymbolStore;
using System.Net.Http.Headers;

namespace AD
{
    public partial class MyLinkedList<T> : IMyLinkedList<T>
    {
        public MyLinkedListNode<T> head;
        private int size;

        public MyLinkedList()
        {
            head = null;
            size = 0;
        }

        public void AddFirst(T data)
        {
            // Write implementation here
            MyLinkedListNode<T> newNode = new MyLinkedListNode<T>{data = data};

            if (!IsEmpty()) newNode.next = head; // If list is not empty set the next of the new node to head
            
            head = newNode;
            size++;
        }

        private bool IsEmpty()
        {
            return Size() == 0;
        }

        public T GetFirst()
        {
            if (IsEmpty()) throw new MyLinkedListEmptyException();
            
            return head.data;
        }

        public void RemoveFirst()
        {
            if (IsEmpty()) throw new MyLinkedListEmptyException(); 
            
            head = head.next;
            size--;
        }

        public int Size()
        {
            return size;
        }

        public void Clear()
        {
            head = new MyLinkedListNode<T>();
            size = 0;
        }

        private bool IsIndexOutOfRange(int i)
        {
            return i > Size() || i < 0;
        }

        public void Insert(int index, T data)
        {
            if (IsIndexOutOfRange(index)) throw new MyLinkedListIndexOutOfRangeException();
            
            if (index == 0)
            {
                AddFirst(data);
                return;
            }

            MyLinkedListNode<T> prevNode = head;
            
            int count = 0;
            while (++count < index) // if index is 5 stop at node 4
            {
                prevNode = prevNode.next;
            }
            
            // Add the new node between previous node and previous node.next
            MyLinkedListNode<T> newNode = new MyLinkedListNode<T>(data, prevNode.next); 
            prevNode.next = newNode; 
            
            size++;
        }

        public override string ToString()
        {
            if (IsEmpty()) return "NIL";
            
            MyLinkedListNode<T> node = head;

            string result = "[";
            while (node.next != null)
            {
                result += node.data + ",";
                node = node.next;
            }
            return result + node.data + "]";
        }
    }
}