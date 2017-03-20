using System;

namespace TWL_Algorithms_Samples.Queue
{
    public class MyQueueAsArray : Queue
    {
        private int Max { get; set; }
        private int CurrentIndex { get; set; }

        public override void Add(object obj)
        {
            throw new NotImplementedException();
        }
        public MyQueueAsArray(int size)
        {
            Create(size);
        }

        public void Create(int Size)
        {
            CurrentIndex = -1;
            Max = Size;
            Create();
        }

        public override void Create()
        {
            throw new NotImplementedException();
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
            throw new NotImplementedException();
        }

        public override object Remove()
        {
            throw new NotImplementedException();
        }

        public override int Size()
        {
            throw new NotImplementedException();
        }
    }
}