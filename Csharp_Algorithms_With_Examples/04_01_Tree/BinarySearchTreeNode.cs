using System;
using TWL_Algorithms_Samples.Arrays;

namespace TWL_Algorithms_Samples.Tree
{
    public class BinarySearchTreeNode : BinaryTreeNode
    {
        public BinarySearchTreeNode(int data) : base(data)
        {
            this.Data = data;
            Size = 1;
        }

        public int Data { get; set; }
        public int Size { get; set; }

        //public BinarySearchTreeNode(int data)
        //{
        //    this.Data = data;
        //}
        new public BinarySearchTreeNode Left { get; set; }

        new public BinarySearchTreeNode Parent { get; set; }

        new public BinarySearchTreeNode Right { get; set; }

        public static BinarySearchTreeNode Create_Random(int N, int min, int max)
        {
            int[] dataArray = new int[N];
            int d = AssortedMethods.RandomIntInRange(min, max);
            BinarySearchTreeNode root = new BinarySearchTreeNode(d);
            dataArray[0] = d;
            for (int i = 1; i < N; i++)
            {
                dataArray[i] = AssortedMethods.RandomIntInRange(min, max);
            }
            dataArray.Print();
            for (int i = 1; i < N; i++)
            {
                root.InsertInOrder(dataArray[i]);
                root.Print();
            }
            return root;

            //return CreateMinimalBinarySearchTree(dataArray);
        }

        public void InsertInOrder(int data)
        {
            Console.WriteLine("$$$BSTN InsertInOrder");
            if (data <= this.Data)
            {
                if (Left == null)
                {
                    Console.WriteLine($"Added '{data}' Left of '{this.Data}' ");
                    SetLeftChild(new BinarySearchTreeNode(data));
                }
                else
                {
                   this.Left.InsertInOrder(data);
                }
            }
            else
            {
                if (Right == null)
                {
                    Console.WriteLine($"Added '{data}' Right of '{this.Data}' ");

                    SetRightChild(new BinarySearchTreeNode(data));
                }
                else
                {
                    Right.InsertInOrder(data);
                }
            }

            Size++;
        }

        public static BinarySearchTreeNode CreateMinimalBinarySearchTree(int[] array)
        {
            return CreateMinimalBinarySearchTree(array, 0, array.Length - 1);
        }

        public static BinarySearchTreeNode CreateMinimalBinarySearchTree(int[] array, int startIndex, int endIndex)
        {
            if (endIndex < startIndex)
            {
                return null;
            }

            var midIndex = (startIndex + endIndex) / 2;
            var binarySearchTree = new BinarySearchTreeNode(array[midIndex]);
            binarySearchTree.SetLeftChild(CreateMinimalBinarySearchTree(array, startIndex, midIndex - 1));
            binarySearchTree.SetRightChild(CreateMinimalBinarySearchTree(array, midIndex + 1, endIndex));

            return binarySearchTree;
        }

        //public void SetLeftChild(BinarySearchTreeNode left)
        //{
        //    Left = left;

        //    if (left != null)
        //    {
        //        left.Parent = this;
        //    }
        //}

        //public void SetRightChild(BinarySearchTreeNode right)
        //{
        //    Right = right;

        //    if (right != null)
        //    {
        //        right.Parent = this;
        //    }
        //}
    }
}