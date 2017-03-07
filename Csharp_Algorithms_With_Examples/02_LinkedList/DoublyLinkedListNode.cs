using System;
using System.Diagnostics;

namespace TWL_Algorithms_Samples.LinkedList
{
    [DebuggerDisplay("Data = {Data}")]
    public class DoublyLinkedListNode : LinkedListNode, IDoublyLinkedListNode
    {
        public DoublyLinkedListNode(object d, DoublyLinkedListNode n, DoublyLinkedListNode p)
        {
            Data = d;
            SetNext(n);
            SetPrevious(p);
        }

        public DoublyLinkedListNode()
        { }

        public DoublyLinkedListNode Prev { get; set; }

        public override LinkedListNode Clone()
        {
            DoublyLinkedListNode next2 = null;
            if (Next != null)
            {
                next2 = (DoublyLinkedListNode)((LinkedListNode)Next).Clone();
            }
            DoublyLinkedListNode head2 = new DoublyLinkedListNode(Data, next2, null);
            return (LinkedListNode)head2;
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
            DoublyLinkedListNode newNextNode = (DoublyLinkedListNode)n;
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

        public void SetPrevious(DoublyLinkedListNode p)
        {
            Prev = p;
            if (p != null && p.Next != this)
            {
                p.SetNext(this);
            }
        }
    }
}