using System;

namespace TWL_Algorithms_Samples.Tree
{
    public class TreeNodeBinary
    {
        public int Data { get; set; }
        public TreeNodeBinary Left { get; set; }
        public TreeNodeBinary Right { get; set; }
        public TreeNodeBinary Parent { get; set; }
        public int Size { get; set; }

        public TreeNodeBinary(int data)
        {
            Data = data;
            Size = 1;
        }

        public void SetLeftChild(TreeNodeBinary left)
        {
            Left = left;

            if (left != null)
            {
                left.Parent = this;
            }
        }

        public void SetRightChild(TreeNodeBinary right)
        {
            Right = right;

            if (right != null)
            {
                right.Parent = this;
            }
        }

        public void InsertInOrder(int data)
        {
            if (data <= Data)
            {
                if (Left == null)
                {
                    SetLeftChild(new TreeNodeBinary(data));
                }
                else
                {
                    Left.InsertInOrder(data);
                }
            }
            else
            {
                if (Right == null)
                {
                    SetRightChild(new TreeNodeBinary(data));
                }
                else
                {
                    Right.InsertInOrder(data);
                }
            }

            Size++;
        }

        public bool IsBst()
        {
            if (Left != null)
            {
                if (Data < Left.Data || !Left.IsBst())
                {
                    return false;
                }
            }

            if (Right != null)
            {
                if (Data >= Right.Data || !Right.IsBst())
                {
                    return false;
                }
            }

            return true;
        }

        public int Height()
        {
            var leftHeight = Left != null ? Left.Height() : 0;
            var rightHeight = Right != null ? Right.Height() : 0;

            return 1 + Math.Max(leftHeight, rightHeight);
        }

        public TreeNodeBinary Find(int data)
        {
            if (data == Data)
            {
                return this;
            }
            else if (data <= Data)
            {
                return Left != null ? Left.Find(data) : null;
            }
            else if (data > Data)
            {
                return Right != null ? Right.Find(data) : null;
            }

            return null;
        }

        private static TreeNodeBinary CreateMinimalBst(int[] array, int start, int end)
        {
            if (end < start)
            {
                return null;
            }

            var mid = (start + end) / 2;
            var TreeNodeBinary = new TreeNodeBinary(array[mid]);
            TreeNodeBinary.SetLeftChild(CreateMinimalBst(array, start, mid - 1));
            TreeNodeBinary.SetRightChild(CreateMinimalBst(array, mid + 1, end));

            return TreeNodeBinary;
        }

        public static TreeNodeBinary CreateMinimalBst(int[] array)
        {
            return CreateMinimalBst(array, 0, array.Length - 1);
        }

        public void Print()
        {
            BTreePrinter.PrintNode(this);
        }
    }
}