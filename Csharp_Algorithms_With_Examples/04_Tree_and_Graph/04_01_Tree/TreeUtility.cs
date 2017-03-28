using System;
using System.Collections.Generic;
using TWL_Algorithms_Samples.Arrays;

namespace TWL_Algorithms_Samples.Tree
{
    public class TreeUtility
    {
        public static int[] arraySorted_UniqueElements = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };//
        public BinarySearchTreeNode currentBinarySearchTreeNode;
        public BinaryTreeNode currentBinaryTreeNode;

        public static TreeNode CreateMinimalBinarySearchTree(int[] array)
        {
            array.Print("Input:");
            return CreateMinimalBinarySearchTree(array, 0, array.Length - 1);
        }

        public static TreeNode CreateMinimalBinarySearchTree(int[] array, int startIndex, int endIndex)
        {
            if (endIndex < startIndex)
            {
                return null;
            }

            var midIndex = (startIndex + endIndex) / 2;
            TreeNode treeNode = new TreeNode(array[midIndex]);
            treeNode.Childrens = new TreeNode[2];
            treeNode.Childrens[(int)ChildernType.Left] = CreateMinimalBinarySearchTree(array, startIndex, midIndex - 1);
            treeNode.Childrens[(int)ChildernType.Right] = CreateMinimalBinarySearchTree(array, midIndex + 1, endIndex);
            return treeNode;
        }


        public void BinarySearchTreeCreation_Run()
        {
            /* Will take a look at at when get time
            var binarySearchTree = BinarySearchTreeNode.Create_Random(10, 0, 9);
            binarySearchTree.Print();
            Console.WriteLine($"CheckIfBinaryTreeIsBinarySearchTree ={CheckIfBinaryTreeIsBinarySearchTree((BinaryTreeNode)binarySearchTree)}");
            */
            //arraySample.Reverse();

            var binarySearchTree2 = BinarySearchTreeNode.CreateMinimalBinarySearchTree(arraySorted_UniqueElements);
            arraySorted_UniqueElements.Print("Input for CreateMinimalBinarySearchTree:");
            binarySearchTree2.Print();
            Console.WriteLine($"CheckIfBinaryTreeIsBinarySearchTree ={ValidateBinarySearchTree(binarySearchTree2)}");

            var binarySearchTree3 = BinarySearchTreeNode.CreateMinimalBinarySearchTree(arraySorted_UniqueElements, 0, 4);
            arraySorted_UniqueElements.Print("\nInput CreateMinimalBinarySearchTree(arr, start, end):", 0, 4);
            binarySearchTree3.Print();
        }

        public void BinaryTreeCreation_Run()
        {
            var binaryTree = BinaryTreeNode.Create_FromArray_InsertInOrder(arraySorted_UniqueElements);
            var binaryTree2 = BinaryTreeNode.Create_Random(10, 0, 9);
            binaryTree2.Print();
            Console.WriteLine($"CheckIfBinaryTreeIsBinarySearchTree ={ValidateBinarySearchTree(binaryTree2)}");
        }

        public List<String> BinaryTreePaths(BinaryTreeNode root)
        {
            List<String> answer = new List<String>();
            if (root != null)
            {
                BinaryTreePathsList(root, "", answer);
            }
            return answer;
        }

        public void BinaryTreePaths_Run()
        {
            currentBinarySearchTreeNode.Print();
            Console.WriteLine(string.Join(", ", BinaryTreePaths(currentBinarySearchTreeNode)));
        }

        public bool HasPathSum(BinaryTreeNode root, int sum)
        {
            if (root == null)
            {
                return false;
            }

            if (root.Left == null && root.Right == null && sum - root.Value == 0)
            {
                return true;
            }
            return HasPathSum(root.Left, sum - root.Value) || HasPathSum(root.Right, sum - root.Value);
        }

        public void HasPathSum_Run()
        {
            var binarySearchTree = BinarySearchTreeNode.CreateMinimalBinarySearchTree(arraySorted_UniqueElements);
            arraySorted_UniqueElements.Print("Input for CreateMinimalBinarySearchTree:");
            binarySearchTree.Print();
            int sum = 8;
            int sum2 = 4;
            Console.WriteLine($"HasPathSum of {sum} ={HasPathSum(binarySearchTree, sum)}  HasPathSum of {sum2} ={HasPathSum(binarySearchTree, sum2)}");
        }

        public bool IsSameTree(BinaryTreeNode p, BinaryTreeNode q)
        {
            if (p == null && q == null) return true;
            if (p == null || q == null) return false;
            if (p.Value == q.Value)
                return IsSameTree(p.Left, q.Left) && IsSameTree(p.Right, q.Right);
            return false;
        }

        public void IsSameTree_Run()
        {
            var firstBinaryTree = BinaryTreeNode.Create_Random(4, 0, 9);
            var secondBinaryTree = BinaryTreeNode.Create_Random(5, 0, 9);
            firstBinaryTree.Print("firstBinaryTree");
            secondBinaryTree.Print("secondBinaryTree");
            Console.WriteLine($"IsSameTree(firstBinaryTree, secondBinaryTree)='{IsSameTree(firstBinaryTree, secondBinaryTree)}'");
            Console.WriteLine("*********************************************************************************");
            var thirdBinaryTree = BinaryTreeNode.Create_Serial(0, 3);
            var fourthBinaryTree = BinaryTreeNode.Create_Serial(0, 3);
            thirdBinaryTree.Print("thirdBinaryTree");
            fourthBinaryTree.Print("fourthBinaryTree");
            Console.WriteLine($"IsSameTree(thirdBinaryTree, fourthBinaryTree)='{IsSameTree(thirdBinaryTree, fourthBinaryTree)}'");
        }

        public List<List<int>> LevelOrder(BinaryTreeNode root)
        {
            Queue<BinaryTreeNode> queue = new Queue<BinaryTreeNode>();
            List<List<int>> wrapList = new List<List<int>>();

            if (root == null) return wrapList;

            queue.Enqueue(root);
            while (queue.Count > 0)
            {
                int levelNum = queue.Count;
                List<int> subList = new List<int>();
                for (int i = 0; i < levelNum; i++)
                {
                    if (queue.Peek().Left != null) queue.Enqueue(queue.Peek().Left);
                    if (queue.Peek().Right != null) queue.Enqueue(queue.Peek().Right);
                    subList.Add(queue.Dequeue().Value);
                }
                wrapList.Add(subList);
            }
            return wrapList;
        }

        public void LevelOrder_Run()
        {
            var sampleBinaryTree = BinaryTreeNode.Create_FromArray_InsertInOrder(arraySorted_UniqueElements);
            arraySorted_UniqueElements.Print("Input:");
            sampleBinaryTree.Print();
            var tesm = LevelOrder(sampleBinaryTree);
        }

        public void MaxDepth_Run()
        {
            var sampleBinaryTree = BinaryTreeNode.Create_Random(8, 0, 9);
            Console.WriteLine("Max Depth of tree is Height of tree");
            sampleBinaryTree.Print($"Input Tree: Height='{sampleBinaryTree.Height()}' MaxDepth='{MaxDepth(sampleBinaryTree)}' MaxDepth2='{MaxDepth2(sampleBinaryTree)}'");
        }

        public void Run()
        {
            currentBinarySearchTreeNode = BinarySearchTreeNode.CreateMinimalBinarySearchTree(arraySorted_UniqueElements);
            currentBinaryTreeNode = BinaryTreeNode.Create_FromArray_InsertInOrder(arraySorted_UniqueElements);
            //BinaryTreeCreation_Run();
            //BinarySearchTreeCreation_Run();
            //LevelOrder_Run();
            //MaxDepth_Run();
            //IsSameTree_Run();
            // HasPathSum_Run();
            //BinaryTreePaths_Run();
            //ValidateBinarySearchTree_Run();
        }

        public bool ValidateBinarySearchTree(BinaryTreeNode binaryTreeNode)
        {
            if (binaryTreeNode.Left != null)
            {
                if (binaryTreeNode.Value < binaryTreeNode.Left.Value || !ValidateBinarySearchTree(binaryTreeNode.Left))
                {
                    return false;
                }
            }

            if (binaryTreeNode.Right != null)
            {
                if (binaryTreeNode.Value >= binaryTreeNode.Right.Value || !ValidateBinarySearchTree(binaryTreeNode.Right))
                {
                    return false;
                }
            }

            return true;
        }

        public void ValidateBinarySearchTree_Run()
        {
            currentBinaryTreeNode.Print("currentBinaryTreeNode:");
            Console.WriteLine($"IsValidBinarySearchTree 'currentBinaryTreeNode' {ValidateBinarySearchTree(currentBinaryTreeNode)}");
            //Console.WriteLine($"IsValidBinarySearchTree2 'currentBinaryTreeNode' {ValidateBinarySearchTree2(currentBinaryTreeNode, null)}");
            currentBinarySearchTreeNode.Print("currentBinarySearchTreeNode:");
            Console.WriteLine($"IsValidBinarySearchTree 'currentBinarySearchTreeNode' {ValidateBinarySearchTree(currentBinarySearchTreeNode)}");
            //Console.WriteLine($"IsValidBinarySearchTree2 'currentBinarySearchTreeNode' {ValidateBinarySearchTree2(currentBinarySearchTreeNode, null)}");
        }

        /// <summary>
        /// INPROGRESS
        /// </summary>
        /// <param name="node"></param>
        /// <param name="prev"></param>
        /// <returns></returns>
        public bool ValidateBinarySearchTree2(BinaryTreeNode node, BinaryTreeNode prev)
        {
            if (node == null)
            {
                return true;
            }
            if (!ValidateBinarySearchTree2(node.Left, prev))
            {
                return false;
            }
            if (prev != null && prev.Value >= node.Value)
            {
                return false;
            }
            prev = node;
            return ValidateBinarySearchTree2(node.Right, prev);
        }

        /// <summary>
        /// Max Depth of tree is Height of tree
        /// </summary>
        /// <param name="node"></param>
        /// <returns></returns>
        public static int MaxDepth(BinaryTreeNode node)
        {
            if (node == null)
            {
                return 0;
            }
            else
            {
                return node.Height();
            }
        }

        /// <summary>
        /// Max Depth of tree is total height
        /// </summary>
        /// <param name="node"></param>
        /// <returns></returns>
        public static int MaxDepth2(BinaryTreeNode node)
        {
            if (node == null)
                return 0;

            return Math.Max(MaxDepth(node.Left), MaxDepth(node.Right)) + 1;
        }

        public void BinaryTreePathsList(BinaryTreeNode root, String path, List<String> answer)
        {
            if (root.Left == null && root.Right == null) answer.Add(path + root.Value);
            if (root.Left != null) BinaryTreePathsList(root.Left, path + root.Value + "->", answer);
            if (root.Right != null) BinaryTreePathsList(root.Right, path + root.Value + "->", answer);
        }
    }
}