using System;

namespace TWL_Algorithms_Samples.LinkedList
{
    public abstract class LinkedListNode
    {
        public object Data { get; set; }
        public LinkedListNode CurrentNode { get; set; }
        public LinkedListNode Next { get; set; }
        public abstract String PrintForward();

        public abstract void SetNext(LinkedListNode n);

        public abstract LinkedListNode Clone();
    }
}