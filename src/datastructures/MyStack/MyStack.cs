namespace AD
{
    public partial class MyStack<T> : IMyStack<T>
    {
        private MyLinkedList<T> _stack = new MyLinkedList<T>();
        
        public bool IsEmpty()
        {
            return _stack.Size().Equals(0);
        }

        public T Pop()
        {
            if (IsEmpty()) throw new MyStackEmptyException();
            
            T first = _stack.GetFirst(); // Get top item of list
            _stack.RemoveFirst(); // remove first item of list
            return first;
        }

        public void Push(T data)
        {
            _stack.AddFirst(data); // add item ad beginning of list
        }

        public T Top()
        {
            if (IsEmpty()) throw new MyStackEmptyException();

            return _stack.GetFirst(); // just return the first item of the list
        }

    }
}
