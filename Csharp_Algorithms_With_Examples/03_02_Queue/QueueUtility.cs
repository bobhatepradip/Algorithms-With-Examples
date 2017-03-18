namespace TWL_Algorithms_Samples.Queue
{
    public class QueueUtility
    {
        public void Run()
        {
            //RunBasicOperations();
        }

        public void RunBasicOperations()
        {
            QueueAsLinkList QueueAsLinkList = new QueueAsLinkList();
            QueueAsLinkList.Add(10);
            QueueAsLinkList.Add(20);
            QueueAsLinkList.Add(30);
            QueueAsLinkList.Print();
            QueueAsLinkList.Remove();
            QueueAsLinkList.Print();

            //QueueAsArray QueueAsArray = new QueueAsArray(10);
            //QueueAsArray.Add(10);
            //QueueAsArray.Print();
            //QueueAsArray.Add(20);
            //QueueAsArray.Add(30);
            //QueueAsArray.Print();
            //QueueAsArray.Remove();
            //QueueAsArray.Print();
        }
    }
}