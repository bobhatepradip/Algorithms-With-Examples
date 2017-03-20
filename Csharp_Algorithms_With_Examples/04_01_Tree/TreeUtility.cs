using System.Collections.Generic;

namespace TWL_Algorithms_Samples.Tree
{
    public class TreeUtility
    {
        public void Run()
        {
            var binaryTree = BinaryTree_CreateFromArray(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 });
            binaryTree.Print();
        }

        public static TreeNodeBinary BinaryTree_CreateFromArray(int[] array)
        {
            if (array.Length > 0)
            {
                var root = new TreeNodeBinary(array[0]);
                var queue = new Queue<TreeNodeBinary>();
                queue.Enqueue(root);
                var done = false;
                var i = 1;

                while (!done)
                {
                    var treeNode = queue.Peek();

                    if (treeNode.Left == null)
                    {
                        treeNode.Left = new TreeNodeBinary(array[i]);
                        i++;
                        queue.Enqueue(treeNode.Left);
                    }
                    else if (treeNode.Right == null)
                    {
                        treeNode.Right = new TreeNodeBinary(array[i]);
                        i++;
                        queue.Enqueue(treeNode.Right);
                    }
                    else
                    {
                        queue.Dequeue();
                    }

                    if (i == array.Length)
                    {
                        done = true;
                    }
                }

                return root;
            }

            return null;
        }
    }
}