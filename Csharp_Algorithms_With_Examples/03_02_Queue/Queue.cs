namespace TWL_Algorithms_Samples.Queue
{
    public abstract class Queue
    {
        public abstract void Create();

        public abstract void Destroy();

        public abstract object Remove();

        public abstract void Add(object obj);

        public abstract void Print();

        public abstract int Size();

        public abstract object Peek();

        public abstract bool IsEmpty();
    }
}