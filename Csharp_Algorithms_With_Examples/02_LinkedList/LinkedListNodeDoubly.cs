using System;
using System.Diagnostics;

namespace TWL_Algorithms_Samples.LinkedList
{
    [DebuggerDisplay("Data = {Data}")]
    public class LinkedListNodeDoubly : LinkedListNode, ILinkedListNodeDoubly
    {
        public LinkedListNodeDoubly(object d, LinkedListNodeDoubly n, LinkedListNodeDoubly p)
        {
            Data = d;
            SetNext(n);
            SetPrevious(p);
        }

        public LinkedListNodeDoubly()
        { }

        public LinkedListNodeDoubly Prev { get; set; }

        public override LinkedListNode Clone()
        {
            return (LinkedListNode)CloneLinkedListNodeDoubly();
        }

        public LinkedListNodeDoubly CloneLinkedListNodeDoubly()
        {
            LinkedListNodeDoubly next2 = null;
            if (Next != null)
            {
                next2 = (LinkedListNodeDoubly)((LinkedListNode)Next).Clone();
            }
            LinkedListNodeDoubly head2 = new LinkedListNodeDoubly(Data, next2, null);
            return head2;
        }

        public override String PrintForward()
        {
            if (Next != null)
            {
                return string.Format("{0}->{1}", Data, Next.PrintForward());
            }
            else
            {
                return string.Format("{0}", Data);
            }
        }

        public override void SetNext(LinkedListNode n)
        {
            LinkedListNodeDoubly newNextNode = (LinkedListNodeDoubly)n;
            Next = newNextNode;
            if (this == CurrentNode)
            {
                CurrentNode = newNextNode;
            }
            if (n != null && newNextNode.Prev != this)
            {
                newNextNode.SetPrevious(this);
            }
        }

        public void SetPrevious(LinkedListNodeDoubly p)
        {
            Prev = p;
            if (p != null && p.Next != this)
            {
                p.SetNext(this);
            }
        }
    }
}