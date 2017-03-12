using System;
using System.Diagnostics;

namespace TWL_Algorithms_Samples.LinkedList
{
    [DebuggerDisplay("Data = {Data}")]
    public class LinkedListNodeSingly : LinkedListNode
    {
        public LinkedListNodeSingly(object d, LinkedListNodeSingly n)
        {
            Data = d;
            SetNext(n);
        }

        public LinkedListNodeSingly(object d)
        {
            Data = d;
        }

        public LinkedListNodeSingly()
        { }

        //public LinkedListNodeSingly(int d, LinkedListNode n)
        //{
        //    Data = d;
        //    SetNext(n);
        //}
        public override LinkedListNode Clone()
        {
            LinkedListNodeSingly next2 = null;
            if (Next != null)
            {
                next2 = (LinkedListNodeSingly)((LinkedListNode)Next).Clone();
            }
            LinkedListNodeSingly head2 = new LinkedListNodeSingly(Data, next2);
            return (LinkedListNode)head2;
        }

        public override bool DeleteNode(LinkedListNode node)
        {
            if (node == null || node.Next == null)
            {
                return false; // Failure
            }

            var next = node.Next;
            node.Data = next.Data;
            node.Next = next.Next;

            return true;
        }

        public override String ReadForward()
        {
            if (Next != null)
            {
                return string.Format("{0}->{1}", Data, Next.ReadForward());
            }
            else
            {
                return string.Format("{0}", Data);
            }
        }

        public override void PrintForward()
        {
            Console.WriteLine(ReadForward());
        }

        public override void PrintForward(string header)
        {
            Console.WriteLine(header);
            PrintForward();
        }

        public override void SetNext(LinkedListNode n)
        {
            LinkedListNodeSingly newNextNode = (LinkedListNodeSingly)n;
            SetNext(newNextNode);
        }

        public void SetNext(LinkedListNodeSingly newNextNode)
        {
            Next = newNextNode;
            if (this == CurrentNode)
            {
                CurrentNode = newNextNode;
            }
        }

        public override int Size()
        {
            int size = 0;
            while (this.Next != null)
            {
                size++;
            }
            return size;
        }
    }
}