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

        public override int Size()
        {
            int size = 0;
            while (this.Next != null)
            {
                size++;
            }
            return size;
        }

        //public LinkedListNodeDoubly(int d, LinkedListNode n, LinkedListNode p)
        //{
        //    Data = d;
        //    SetNext(n);
        //    SetPrevious(p);
        //}

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

        public override string ReadForward()
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