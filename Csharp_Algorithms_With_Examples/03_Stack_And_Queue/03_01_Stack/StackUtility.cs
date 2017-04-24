namespace TWL_Algorithms_Samples.Stack
{
    public class StackUtility
    {
        public void Run()
        {
            //RunBasicOperations();
        }

        public void RunBasicOperations()
        {
            MyStackAsLinkList stackAsLinkList = new MyStackAsLinkList();
            stackAsLinkList.Push(10);
            stackAsLinkList.Push(20);
            stackAsLinkList.Push(30);
            stackAsLinkList.Print();
            stackAsLinkList.Pop();
            stackAsLinkList.Print();

            MyStackAsArray stackAsArray = new MyStackAsArray(10);
            stackAsArray.Push(10);
            stackAsArray.Print();
            stackAsArray.Push(20);
            stackAsArray.Push(30);
            stackAsArray.Print();
            stackAsArray.Pop();
            stackAsArray.Print();
        }
    }
}