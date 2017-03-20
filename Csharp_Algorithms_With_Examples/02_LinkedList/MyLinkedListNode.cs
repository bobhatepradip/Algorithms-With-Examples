using System;

namespace TWL_Algorithms_Samples.LinkedList
{
    public abstract class MyLinkedListNode
    {
        public MyLinkedListNode CurrentNode { get; set; }
        public object Data { get; set; }
        public MyLinkedListNode Next { get; set; }

        public abstract MyLinkedListNode Clone();

        public abstract bool DeleteNode(MyLinkedListNode node);

        public abstract String ReadForward();

        public abstract void PrintForward();

        public abstract void PrintForward(string header);

        public abstract void SetNext(MyLinkedListNode n);

        public abstract int Size();
    }
}