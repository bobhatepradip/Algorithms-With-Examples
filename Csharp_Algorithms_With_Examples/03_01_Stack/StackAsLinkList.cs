using System;
using TWL_Algorithms_Samples.LinkedList;

namespace TWL_Algorithms_Samples.Stack
{
    public class StackAsLinkList : Stack
    {
        public StackAsLinkList()
        {
            Create();
        }

        private LinkedListNodeSingly linkListhead { get; set; }

        public override void Create()
        {
            linkListhead = new LinkedListNodeSingly();
        }

        public override void Destroy()
        {
            linkListhead = null;
        }

        public override bool IsEmpty()
        {
            return (linkListhead == null || linkListhead.Next == null);
        }

        public override object Peek()
        {
            return IsEmpty() ? null : linkListhead.Next.Data;
        }

        public override object Pop()
        {
            var deletedNodeData = linkListhead.Data;
            if (linkListhead.Next != null)
            {
                linkListhead.Next = (LinkedListNodeSingly)linkListhead.Next.Next;
                Console.WriteLine($"Poped:{deletedNodeData}");
            }
            return deletedNodeData;
        }

        public override void Print()
        {
            linkListhead.PrintForward();
        }

        public override void Push(object obj)
        {
            LinkedListNodeSingly newLinkListNode = new LinkedListNodeSingly(obj);
            if (linkListhead.Next != null)
            {
                newLinkListNode.SetNext(linkListhead.Next);
            }
            linkListhead.SetNext(newLinkListNode);
            Console.WriteLine($"Pushed:{obj}");
        }

        public override int Size()
        {
            return linkListhead.Size();
        }
    }
}