using System;
using System.Linq;

namespace AD
{
    public partial class MyArrayList : IMyArrayList
    {
        private int[] data;
        private int size;

        public MyArrayList(int capacity)
        {
            data = new int[capacity];
            size = 0;
        }

        public void Add(int n)
        {
            if (IsFull()) throw new MyArrayListFullException();
            data[size] = n;
            size++;
        }

        private bool IsFull()
        {
            return Size() == Capacity();
        }

        public int Get(int index)
        {
            if (IsIndexOutOfRange(index)) throw new MyArrayListIndexOutOfRangeException();
            return data[index];
        }

        public void Set(int index, int n)
        {
            if (IsIndexOutOfRange(index)) throw new MyArrayListIndexOutOfRangeException();
            data[index] = n;
        }

        private bool IsIndexOutOfRange(int i)
        {
            return i < 0 || i >= Size();
        }

        public int Capacity()
        {
            return data.Length;
        }

        public int Size()
        {
            return size;
        }

        public void Clear()
        {
            data = new int[Capacity()];
            size = 0;
        }

        public int CountOccurences(int n)
        {
            return data.Count(i => i == n);
        }

        private bool IsEmpty()
        {
            return Size() == 0;
        }

        public override string ToString()
        {
            if (IsEmpty()) return "NIL";
            return "[" + string.Join(",", data.Where(item => item != 0)) + "]";
        }
    }
}
