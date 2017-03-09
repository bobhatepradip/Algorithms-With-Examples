namespace TWL_Algorithms_Samples.LinkedList
{
    public interface ILinkedListNodeDoubly
    {
        LinkedListNodeDoubly Prev { get; set; }

        void SetPrevious(LinkedListNodeDoubly p);
    }
}