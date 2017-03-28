using TWL_Algorithms_Samples.Arrays;
using TWL_Algorithms_Samples.Tree;
namespace TWL_Algorithms_Samples.TreeAndGraph
{
    public class TreeAndGraph_Q1_01_Route_Beetween_Nodes : IQuestion
    {
        public void Run()
        {
        }
    }

    /// <summary>
    /// Minimal Tree = BST with minmanl height
    /// </summary>
    public class TreeAndGraph_Q4_02_CreateMinimalTree : IQuestion
    {
        public void Run()
        {            
            TreeNode treeNode = TreeUtility.CreateMinimalBinarySearchTree(TreeUtility.arraySorted_UniqueElements);
            //((BinarySearchTreeNode)treeNode).Print();

            TreeUtility.arraySorted_UniqueElements.Print("Input for CreateMinimalBinarySearchTree:");
            var binarySearchTree2 = BinarySearchTreeNode.CreateMinimalBinarySearchTree(TreeUtility.arraySorted_UniqueElements);            
            binarySearchTree2.Print();
        }
    }

    public class TreeAndGraph_Q4_03 : IQuestion
    {
        public void Run()
        {
        }
    }

    public class TreeAndGraph_Q4_04 : IQuestion
    {
        public void Run()
        {
        }
    }

    public class TreeAndGraph_Q4_05 : IQuestion
    {
        public void Run()
        {
        }
    }

    public class TreeAndGraph_Q4_06 : IQuestion
    {
        public void Run()
        {
        }
    }

    public class TreeAndGraph_Q4_07 : IQuestion
    {
        public void Run()
        {
        }
    }

    public class TreeAndGraph_Q4_08 : IQuestion
    {
        public void Run()
        {
        }
    }

    public class TreeAndGraph_Q4_09 : IQuestion
    {
        public void Run()
        {
        }
    }

    public class TreeAndGraph_Q4_10 : IQuestion
    {
        public void Run()
        {
        }
    }

    public class TreeAndGraph_Q4_11 : IQuestion
    {
        public void Run()
        {
        }
    }

    public class TreeAndGraph_Q4_12 : IQuestion
    {
        public void Run()
        {
        }
    }

    public class TreeAndGraphQuestions : IQuestion
    {
        public void Run()
        {
            new TreeAndGraph_Q1_01_Route_Beetween_Nodes().Run();
        }
    }
}