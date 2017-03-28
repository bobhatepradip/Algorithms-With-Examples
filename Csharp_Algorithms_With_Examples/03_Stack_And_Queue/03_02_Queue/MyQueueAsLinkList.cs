using System;
using TWL_Algorithms_Samples.LinkedList;

namespace TWL_Algorithms_Samples.Queue
{
    public class MyQueueAsLinkList : MyQueue
    {
        public MyLinkedListNodeSingly insertNode;
        public MyLinkedListNodeSingly removeNode;

        public MyQueueAsLinkList()
        {
            Create();
        }

        public override void Add(object obj)
        {
            MyLinkedListNodeSingly newLinkListNode = new MyLinkedListNodeSingly(obj);
            if (insertNode.Next != null)
            {
                newLinkListNode.SetNext(insertNode.Next);
            }
            insertNode.SetNext(newLinkListNode);
            Console.WriteLine($"Added:{obj}");
        }

        public override void Create()
        {
            insertNode = new MyLinkedListNodeSingly();
            removeNode = insertNode;
        }

        public override void Destroy()
        {
            throw new NotImplementedException();
        }

        public override bool IsEmpty()
        {
            throw new NotImplementedException();
        }

        public override object Peek()
        {
            throw new NotImplementedException();
        }

        public override void Print()
        {
            removeNode.PrintForward();
        }

        public override object Remove()
        {
            var deletedNodeData = removeNode.Data;
            if (removeNode.Next != null)
            {
                removeNode.Next = (MyLinkedListNodeSingly)removeNode.Next.Next;
                Console.WriteLine($"Deleted:{deletedNodeData}");
            }
            return deletedNodeData;
        }

        public override int Size()
        {
            throw new NotImplementedException();
        }
    }
}