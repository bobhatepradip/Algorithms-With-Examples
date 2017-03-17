using System;
using TWL_Algorithms_Samples.LinkedList;

namespace TWL_Algorithms_Samples.Queue
{
    public class QueueAsLinkList : Queue
    {
        LinkedListNodeSingly insertNode;
        LinkedListNodeSingly removeNode;
        public QueueAsLinkList()
        {
            Create();
        }
        public override void Add(object obj)
        {
            LinkedListNodeSingly newLinkListNode = new LinkedListNodeSingly(obj);
            if (insertNode.Next != null)
            {
                newLinkListNode.SetNext(insertNode.Next);
            }
            insertNode.SetNext(newLinkListNode);
            Console.WriteLine($"Added:{obj}");
        }

        public override void Create()
        {
            insertNode = new LinkedListNodeSingly();
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
                removeNode.Next = (LinkedListNodeSingly)removeNode.Next.Next;
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