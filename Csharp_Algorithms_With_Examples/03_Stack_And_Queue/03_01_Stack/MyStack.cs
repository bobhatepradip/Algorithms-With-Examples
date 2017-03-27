namespace TWL_Algorithms_Samples.Stack
{
    public abstract class MyStack
    {
        public abstract void Create();

        public abstract void Destroy();

        public abstract object Pop();

        public abstract void Push(object obj);

        public abstract void Print();

        public abstract int Size();

        public abstract object Peek();

        public abstract bool IsEmpty();
    }
}