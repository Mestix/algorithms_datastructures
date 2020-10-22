using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;


namespace AD
{
    public partial class PriorityQueue<T> : IPriorityQueue<T>
        where T : IComparable<T>
    {
        public static int DEFAULT_CAPACITY = 100;
        public int size;   // Number of elements in heap
        public T[] array;  // The heap array

        //----------------------------------------------------------------------
        // Constructor
        //----------------------------------------------------------------------
        public PriorityQueue()
        {
            size = 0;
            array = new T[DEFAULT_CAPACITY+1];
        }

        //----------------------------------------------------------------------
        // Interface methods that have to be implemented for exam
        //----------------------------------------------------------------------
        public int Size()
        {
            return size;
        }

        public void Clear()
        {
            array = new T[DEFAULT_CAPACITY];
            size = 0;
        }

        public void Add(T x)
        {
            AddFreely(x); // Add at end of array

            PercolateUp(Size());
        }

        // Removes the smallest item in the priority queue
        public T Remove()
        {
            if (IsEmpty()) { throw new PriorityQueueEmptyException(); }

            T smallestNode  = array[1]; // Get smallest node (node to delete)
            T last = array[Size()]; // Get last leaf

            array[1] = last; // fill root node with last leaf

            PercolateDown(1); // percolate down from root node

            size--;

            return smallestNode;
        }

        public bool IsEmpty()
        {
            return Size() == 0;
        }

        private bool IsFull()
        {
            return Size() + 1 == array.Length;
        }

        private void DoubleArray()
        {
            int length = array.Length;
            T[] newArray = new T[length * 2];

            for (int i = 0; i < length; i++)
            {
                newArray[i] = array[i];
            }

            array = newArray;
        }


        //----------------------------------------------------------------------
        // Interface methods that have to be implemented for homework
        //----------------------------------------------------------------------

        public void AddFreely(T x)
        {
            if (IsFull()) DoubleArray(); // Array full
            array[Size() + 1] = x; // Add item at end of array
            size++; // Size 1 up
        }
        
        private void PercolateUp(int childIndex)
        {
            int parentIndex = childIndex / 2;
            
            if (parentIndex < 1) return; // child has no parent
            if (array[parentIndex].CompareTo(array[childIndex]) <= 0) return; // parent is smaller or the same as child (so in correct place)

            Swap(parentIndex, childIndex); // child is smaller then parent so swap parent and child
            PercolateUp(parentIndex); // repeat for child
        }

        private void PercolateDown(int parentIndex)
        {
            T parent = array[parentIndex];

            int leftChildIndex = parentIndex * 2; // left child index
            int rightChildIndex = leftChildIndex + 1; // right child index

            int smallestChildIndex;

            if (leftChildIndex > Size()) return; // has no left child so there is also no right child (no children)

            if (rightChildIndex > Size() || array[rightChildIndex].CompareTo(array[leftChildIndex]) > 0) // has no right child or left child is smaller then right child 
            {
                smallestChildIndex = leftChildIndex; // left child is the smallest child
            }
            else
            {
                smallestChildIndex = rightChildIndex; //  right child is the smallest child
            }

            T minChild = array[smallestChildIndex]; // smallest child

            if (parent.CompareTo(minChild) <= 0) return; // parent is smaller or the same as child (so in correct place)

            Swap(parentIndex, smallestChildIndex); // child is smaller then parent so swap parent and child
            PercolateDown(smallestChildIndex); // repeat for child
        }

        public void BuildHeap()
        {
            for (int i = size / 2; i > 0; i--)
            {
                /*
                    size / 2 is the root node index, so do percolate down from root node to leaves
                 */
                PercolateDown(i);
            }
        }

        public void Swap(int index1, int index2)
        {
            T temp1 = array[index1];
            T temp2 = array[index2];

            array[index1] = temp2;
            array[index2] = temp1;
        }

        public override string ToString()
        {
            string result = "";
            for (int i = 1; i <= Size() ; i++)
            {
                result += array[i] + " ";
            }

            return result.Trim();
        }
    }
}
