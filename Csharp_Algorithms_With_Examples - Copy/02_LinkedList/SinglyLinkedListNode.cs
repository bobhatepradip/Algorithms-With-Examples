using System;
using System.Diagnostics;

namespace TWL_Algorithms_Samples.LinkedList
{
    [DebuggerDisplay("Data = {Data}")]
    public class SinglyLinkedListNode : LinkedListNode
    {
        public SinglyLinkedListNode(object d, SinglyLinkedListNode n)
        {
            Data = d;
            SetNext(n);
            //SetPrevious(p);
        }

        public SinglyLinkedListNode()
        { }

        public override LinkedListNode Clone()
        {
            SinglyLinkedListNode next2 = null;
            if (Next != null)
            {
                next2 = (SinglyLinkedListNode)((LinkedListNode)Next).Clone();
            }
            SinglyLinkedListNode head2 = new SinglyLinkedListNode(Data, next2);
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
            SinglyLinkedListNode newNextNode = (SinglyLinkedListNode)n;
            Next = newNextNode;
            if (this == CurrentNode)
            {
                CurrentNode = (SinglyLinkedListNode)n;
            }
        }
    }
}