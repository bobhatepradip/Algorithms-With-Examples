﻿using System;
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

        public override String PrintForward(string header)
        {
            Console.WriteLine(header);
            return PrintForward();
        }

        public override void SetNext(LinkedListNode n)
        {
            LinkedListNodeSingly newNextNode = (LinkedListNodeSingly)n;
            Next = newNextNode;
            if (this == CurrentNode)
            {
                CurrentNode = (LinkedListNodeSingly)n;
            }
        }
    }
}