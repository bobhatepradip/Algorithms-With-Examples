using System;
using TWL_Algorithms_Samples.Arrays;

namespace TWL_Algorithms_Samples.Tree
{
    public class TreeUtility
    {
        private int[] arraySample = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

        public void BinaryTreeCreation_Run()
        {
            var binaryTree = BinaryTreeNode.Create_FromArray_InsertInOrder(arraySample);
            arraySample.Print("Input for Create_FromArray_InsertInOrder:");
            binaryTree.Print();
            var binaryTree2 = BinaryTreeNode.Create_Random(10, 0, 9);
            binaryTree2.Print();
            Console.WriteLine($"CheckIfBinaryTreeIsBinarySearchTree ={CheckIfBinaryTreeIsBinarySearchTree(binaryTree2)}");
        }

        public void BinarySearchTreeCreation_Run()
        {
            /* Will take a look at at when get time
            var binarySearchTree = BinarySearchTreeNode.Create_Random(10, 0, 9);
            binarySearchTree.Print();
            Console.WriteLine($"CheckIfBinaryTreeIsBinarySearchTree ={CheckIfBinaryTreeIsBinarySearchTree((BinaryTreeNode)binarySearchTree)}");
            */
            //arraySample.Reverse();

            var binarySearchTree2 = BinarySearchTreeNode.CreateMinimalBinarySearchTree(arraySample);
            arraySample.Print("Input for CreateMinimalBinarySearchTree:");
            binarySearchTree2.Print();
            Console.WriteLine($"CheckIfBinaryTreeIsBinarySearchTree ={CheckIfBinaryTreeIsBinarySearchTree(binarySearchTree2)}");

            var binarySearchTree3 = BinarySearchTreeNode.CreateMinimalBinarySearchTree(arraySample, 0, 4);
            arraySample.Print("\nInput CreateMinimalBinarySearchTree(arr, start, end):", 0, 4);
            binarySearchTree3.Print();
        }

        public bool CheckIfBinaryTreeIsBinarySearchTree(BinaryTreeNode binaryTreeNode)
        {
            if (binaryTreeNode.Left != null)
            {
                if (binaryTreeNode.Data < binaryTreeNode.Left.Data || !CheckIfBinaryTreeIsBinarySearchTree(binaryTreeNode.Left))
                {
                    return false;
                }
            }

            if (binaryTreeNode.Right != null)
            {
                if (binaryTreeNode.Data >= binaryTreeNode.Right.Data || !CheckIfBinaryTreeIsBinarySearchTree(binaryTreeNode.Right))
                {
                    return false;
                }
            }

            return true;
        }

        public void Run()
        {
            BinaryTreeCreation_Run();
            BinarySearchTreeCreation_Run();
        }
    }
}