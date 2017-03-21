using System;
using System.Collections.Generic;
using TWL_Algorithms_Samples.Arrays;

namespace TWL_Algorithms_Samples.Tree
{
    public class BinaryTreeNode
    {
        public BinaryTreeNode(int data)
        {
            Data = data;
            Size = 1;
        }

        public int Data { get; set; }

        public BinaryTreeNode Left { get; set; }

        public BinaryTreeNode Parent { get; set; }

        public BinaryTreeNode Right { get; set; }

        public int Size { get; set; }

        public static BinaryTreeNode Create_FromArray_InsertInOrder(int[] array)
        {
            if (array.Length > 0)
            {
                var root = new BinaryTreeNode(array[0]);
                var queue = new Queue<BinaryTreeNode>();
                queue.Enqueue(root);
                var done = false;
                var i = 1;

                while (!done)
                {
                    var treeNode = queue.Peek();
                    //Console.WriteLine($"queue={queue.Peek().Data}");
                    if (treeNode.Left == null)
                    {
                        treeNode.Left = new BinaryTreeNode(array[i]);
                        i++;
                        queue.Enqueue(treeNode.Left);
                        //Console.WriteLine($"*Enqueue:treeNode.Left={treeNode.Left.Data} queue={queue.Peek().Data}");
                    }
                    else if (treeNode.Right == null)
                    {
                        treeNode.Right = new BinaryTreeNode(array[i]);
                        i++;
                        queue.Enqueue(treeNode.Right);
                        //Console.WriteLine($"*Enqueue:treeNode.Right={treeNode.Right.Data} queue={queue.Peek().Data}");
                    }
                    else
                    {
                        //Console.WriteLine($"****queue Dequeue {queue.Peek().Data}");
                        queue.Dequeue();
                        //Console.WriteLine($"****queue={queue.Peek().Data}");
                    }

                    if (i == array.Length)
                    {
                        done = true;
                    }
                    //Console.WriteLine($"queue={queue.Peek().Data}");
                    //treeNode.Print();
                }

                return root;
            }

            return null;
        }

        public static BinaryTreeNode Create_Random(int N, int min, int max)
        {
            int[] dataArray = new int[N];
            int d = AssortedMethods.RandomIntInRange(min, max);
            BinaryTreeNode root = new BinaryTreeNode(d);
            dataArray[0] = d;
            for (int i = 1; i < N; i++)
            {
                dataArray[i] = AssortedMethods.RandomIntInRange(min, max);
            }
            dataArray.Print();
            for (int i = 1; i < N; i++)
            {
                // Console.WriteLine($"Processing dataArray[i]='{dataArray[i]}' ");
                root.InsertInOrder(dataArray[i]);
            }
            return root;
        }

        public static BinaryTreeNode Create_Serial(int min, int max)
        {
            BinaryTreeNode root = new BinaryTreeNode(min);
            min++;
            while (min <= max)
            {
                // Console.WriteLine($"Processing dataArray[i]='{dataArray[i]}' ");
                root.InsertInOrder(min);
                min++;
            }
            return root;
        }

        public BinaryTreeNode Find(int data)
        {
            if (data == this.Data)
            {
                return this;
            }
            else if (data <= this.Data)
            {
                return Left != null ? Left.Find(data) : null;
            }
            else if (data > this.Data)
            {
                return Right != null ? Right.Find(data) : null;
            }

            return null;
        }

        public int Height()
        {
            var leftHeight = Left != null ? Left.Height() : 0;
            var rightHeight = Right != null ? Right.Height() : 0;

            //1 for root
            return 1 + Math.Max(leftHeight, rightHeight);
        }
        public void InsertInOrder(int data)
        {
            // Console.WriteLine("BTN InsertInOrder");
            if (data <= this.Data)
            {
                if (Left == null)
                {
                    SetLeftChild(new BinaryTreeNode(data));
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
                    SetRightChild(new BinaryTreeNode(data));
                }
                else
                {
                    Right.InsertInOrder(data);
                }
            }

            Size++;
        }

        public void InsertInOrder2(int data)
        {
            if (this.Left == null)
            {
                //Console.WriteLine($"Added '{data}' Left of '{this.Data}' ");
                SetLeftChild(new BinaryTreeNode(data));
                Size++;
            }
            else if (this.Right == null)
            {
                //Console.WriteLine($"Added '{data}' Right of '{this.Data}' ");
                SetRightChild(new BinaryTreeNode(data));
                Size++;
            }
            else if (this.Left.Size <= 2)
            {
                this.Left.InsertInOrder2(data);
            }
            else
            {
                this.Right.InsertInOrder2(data);
            }
        }
        public void InsertInOrderMain(int data)
        {
            Console.WriteLine("BTN InsertInOrder");
            if (data <= this.Data)
            {
                if (Left == null)
                {
                    SetLeftChild(new BinaryTreeNode(data));
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
                    SetRightChild(new BinaryTreeNode(data));
                }
                else
                {
                    Right.InsertInOrder(data);
                }
            }

            Size++;
        }

        public void Print(string header = "")
        {
            BTreePrinter.PrintNode(this, header);
        }

        public void SetLeftChild(BinaryTreeNode left)
        {
            Left = left;

            if (left != null)
            {
                left.Parent = this;
            }
        }

        public void SetRightChild(BinaryTreeNode right)
        {
            Right = right;

            if (right != null)
            {
                right.Parent = this;
            }
        }
    }
}