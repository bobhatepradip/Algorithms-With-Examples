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

        public abstract String PrintForward();

        public abstract String PrintForward(string header);

        public abstract void SetNext(LinkedListNode n);
    }
}