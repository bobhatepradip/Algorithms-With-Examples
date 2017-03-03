namespace TWL_Algorithms_Samples.LinkedList
{
    public interface IDoublyLinkedListNode
    {
        DoublyLinkedListNode Prev { get; set; }

        void SetPrevious(DoublyLinkedListNode p);
    }
}