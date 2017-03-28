using System;

namespace TWL_Algorithms_Samples.Queue
{
    public class MyQueueGeneric<T> //: MyQueue
    {
        private QueueNode<T> first;

        private QueueNode<T> last;

        public void Add(T item)
        {
            QueueNode<T> newItem = new QueueNode<T>(item);
            if (last != null)
            {
                last.next = newItem;
            }
            last = newItem;

            if (first == null)
            {
                first = last;
            }
        }

        public bool IsEmpty()
        {
            //if first ==null then last ==null
            return (first == null);
        }

        public T Peek()
        {
            if (first == null) { throw new Exception("ElementNotFound"); }
            return first.data;
        }

        public T Remove()
        {
            if (first == null) { throw new Exception("ElementNotFound"); }
            T data = first.data;
            first = first.next;
            if (first == null)
            {
                last = null;
            }
            return data;
        }

        public class QueueNode<T>
        {
            public T data;
            public QueueNode<T> next;

            public QueueNode(T data)
            {
                this.data = data;
            }
        }
    }
}