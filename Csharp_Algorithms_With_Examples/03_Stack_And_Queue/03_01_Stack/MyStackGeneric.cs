namespace TWL_Algorithms_Samples.Stack
{
    /// <summary>
    /// Linked List Representation
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class MyStackGeneric<T>
    {
        private StackNode<T> top;

        public bool IsEmpty()
        {
            return (top == null);
        }

        public T peek()
        {
            if (top == null) throw new System.Exception("EmptyStackException");
            return top.data;
        }

        public T Pop()
        {
            if (top == null) throw new System.Exception("EmptyStackException");
            T item = top.data;
            top = top.next;
            return item;
        }

        public void Push(T item)
        {
            StackNode<T> t = new StackNode<T>(item);
            t.next = top;
            top = t;
        }

        public class StackNode<T>
        {
            public T data;
            public StackNode<T> next;

            public StackNode(T data)
            {
                this.data = data;
            }
        }
    }

    public class StackNode<T>
    {
        public T data;
        public StackNode<T> next;

        public StackNode(T data)
        {
            this.data = data;
        }
    }
}