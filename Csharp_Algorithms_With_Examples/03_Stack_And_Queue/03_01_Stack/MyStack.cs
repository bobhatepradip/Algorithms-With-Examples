namespace TWL_Algorithms_Samples.Stack
{
    public abstract class MyStack
    {
        public abstract void Create();

        public abstract void Destroy();

        public abstract bool IsEmpty();

        public abstract object Peek();

        public abstract object Pop();

        public abstract void Print();

        public abstract void Push(object obj);
        public abstract int Size();
    }
}