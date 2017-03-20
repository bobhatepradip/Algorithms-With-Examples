namespace TWL_Algorithms_Samples.LinkedList
{
    public interface IMyLinkedListNodeDoubly
    {
        MyLinkedListNodeDoubly Prev { get; set; }

        void SetPrevious(MyLinkedListNodeDoubly p);
    }
}