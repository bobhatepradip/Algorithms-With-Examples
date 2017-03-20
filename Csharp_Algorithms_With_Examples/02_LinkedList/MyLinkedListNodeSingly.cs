using System;
using System.Diagnostics;

namespace TWL_Algorithms_Samples.LinkedList
{
    [DebuggerDisplay("Data = {Data}")]
    public class MyLinkedListNodeSingly : MyLinkedListNode
    {
        public MyLinkedListNodeSingly(object d, MyLinkedListNodeSingly n)
        {
            Data = d;
            SetNext(n);
        }

        public MyLinkedListNodeSingly(object d)
        {
            Data = d;
        }

        public MyLinkedListNodeSingly()
        { }

        //public LinkedListNodeSingly(int d, LinkedListNode n)
        //{
        //    Data = d;
        //    SetNext(n);
        //}
        public override MyLinkedListNode Clone()
        {
            MyLinkedListNodeSingly next2 = null;
            if (Next != null)
            {
                next2 = (MyLinkedListNodeSingly)((MyLinkedListNode)Next).Clone();
            }
            MyLinkedListNodeSingly head2 = new MyLinkedListNodeSingly(Data, next2);
            return (MyLinkedListNode)head2;
        }

        public override bool DeleteNode(MyLinkedListNode nodeToDelete)
        {
            if (nodeToDelete == null || nodeToDelete.Next == null)
            {
                return false; // Failure
            }

            nodeToDelete.Data = nodeToDelete.Next.Data;
            nodeToDelete.Next = nodeToDelete.Next.Next;

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

        public override void SetNext(MyLinkedListNode n)
        {
            MyLinkedListNodeSingly newNextNode = (MyLinkedListNodeSingly)n;
            SetNext(newNextNode);
        }

        public void SetNext(MyLinkedListNodeSingly newNextNode)
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