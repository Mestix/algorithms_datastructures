using System.Collections.Generic;

namespace AD
{
    public partial class MyQueue<T> : IMyQueue<T>
    {
        List<T> queue = new List<T>();
        
        public bool IsEmpty()
        {
            return queue.Count.Equals(0);
        }

        public void Enqueue(T data)
        {
            queue.Add(data);
        }

        public T GetFront()
        {
            if(IsEmpty()) throw new MyQueueEmptyException();
            
            return queue[0];
        }

        public T Dequeue()
        {
            if(IsEmpty()) throw new MyQueueEmptyException();
            
            T first = queue[0]; // get first item from queue
            queue.Remove(first); // remove first item from queue
            
            return first; 
        }

        public void Clear()
        {
            queue.Clear();
        } 
    }
}