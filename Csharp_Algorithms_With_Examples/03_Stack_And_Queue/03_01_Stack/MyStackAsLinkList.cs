using System;
using TWL_Algorithms_Samples.LinkedList;

namespace TWL_Algorithms_Samples.Stack
{
    public class MyStackAsLinkList : MyStack
    {
        public MyStackAsLinkList()
        {
            Create();
        }

        public MyLinkedListNodeSingly linkListhead { get; set; }

        public override void Create()
        {
            linkListhead = new MyLinkedListNodeSingly();
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
                linkListhead.Next = (MyLinkedListNodeSingly)linkListhead.Next.Next;
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
            MyLinkedListNodeSingly newLinkListNode = new MyLinkedListNodeSingly(obj);
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