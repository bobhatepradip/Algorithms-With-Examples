using TWL_Algorithms_Samples.Arrays;

namespace TWL_Algorithms_Samples.Stack
{
    public class MyStackAsArray : MyStack
    {
        public MyStackAsArray(int size)
        {
            Create(size);
        }

        private int Max { get; set; }
        private int CurrentIndex { get; set; }

        private object[] array { get; set; }

        public override void Create()
        {
            array = new object[Max];
        }

        public void Create(int Size)
        {
            CurrentIndex = -1;
            Max = Size;
            Create();
        }

        public override void Destroy()
        {
            Max = 0;
            CurrentIndex = -1;
            array = null;
        }

        public override bool IsEmpty()
        {
            return (CurrentIndex == -1);
        }

        public override object Peek()
        {
            return IsEmpty() ? null : array[CurrentIndex];
        }

        public override object Pop()
        {
            var last = array[CurrentIndex];
            array[CurrentIndex] = null;
            CurrentIndex--;
            return last;
        }

        public override void Print()
        {
            array.Print();
        }

        public override void Push(object obj)
        {
            CurrentIndex++;
            array[CurrentIndex] = obj;
        }

        public override int Size()
        {
            return Max;
        }
    }
}