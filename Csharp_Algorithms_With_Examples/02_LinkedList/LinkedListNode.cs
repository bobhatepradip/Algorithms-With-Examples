using System;

namespace TWL_Algorithms_Samples.LinkedList
{
    public abstract class LinkedListNode
    {
        public LinkedListNode CurrentNode { get; set; }
        public object Data { get; set; }
        public LinkedListNode Next { get; set; }

        public abstract LinkedListNode Clone();

        public abstract bool DeleteNode(LinkedListNode node);

        public abstract String ReadForward();

        public abstract void PrintForward();

        public abstract void PrintForward(string header);

        public abstract void SetNext(LinkedListNode n);

        public abstract int Size();
    }
}