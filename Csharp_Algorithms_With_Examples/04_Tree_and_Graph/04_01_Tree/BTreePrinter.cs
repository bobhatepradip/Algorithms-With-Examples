﻿using System;
using System.Collections.Generic;

namespace TWL_Algorithms_Samples.Tree
{
    public class BTreePrinter
    {
        public static void PrintNode(BinaryTreeNode root, string header = "")
        {
            int maxLevel = BTreePrinter.MaxLevel(root);
            if (!string.IsNullOrEmpty(header))
            {
                Console.WriteLine($"Max Level ={maxLevel} {header}");
            }

            PrintNodeInternal(new List<BinaryTreeNode>() { root }, 1, maxLevel);
        }

        public static bool IsAllElementsNull<T>(IEnumerable<T> list)
        {
            foreach (object o in list)
            {
                if (o != null)
                    return false;
            }

            return true;
        }

        public static int MaxLevel(BinaryTreeNode node)
        {
            if (node == null)
                return 0;

            return Math.Max(BTreePrinter.MaxLevel(node.Left), BTreePrinter.MaxLevel(node.Right)) + 1;
        }

        public static void PrintNodeInternal(List<BinaryTreeNode> nodes, int level, int maxLevel)
        {
            if (nodes.Count == 0 || BTreePrinter.IsAllElementsNull(nodes))
                return;

            int floor = maxLevel - level;
            int endgeLines = (int)Math.Pow(2, (Math.Max(floor - 1, 0)));
            int firstSpaces = (int)Math.Pow(2, (floor)) - 1;
            int betweenSpaces = (int)Math.Pow(2, (floor + 1)) - 1;

            BTreePrinter.PrintWhitespaces(firstSpaces);

            List<BinaryTreeNode> newNodes = new List<BinaryTreeNode>();
            foreach (BinaryTreeNode node in nodes)
            {
                if (node != null)
                {
                    Console.Write(node.Value);
                    newNodes.Add(node.Left);
                    newNodes.Add(node.Right);
                }
                else
                {
                    newNodes.Add(null);
                    newNodes.Add(null);
                    Console.Write(" ");
                }

                BTreePrinter.PrintWhitespaces(betweenSpaces);
            }
            Console.WriteLine();

            for (int i = 1; i <= endgeLines; i++)
            {
                for (int j = 0; j < nodes.Count; j++)
                {
                    BTreePrinter.PrintWhitespaces(firstSpaces - i);
                    if (nodes[j] == null)
                    {
                        BTreePrinter.PrintWhitespaces(endgeLines + endgeLines + i + 1);
                        continue;
                    }

                    if (nodes[j].Left != null)
                        Console.Write("/");
                    else
                        BTreePrinter.PrintWhitespaces(1);

                    BTreePrinter.PrintWhitespaces(i + i - 1);

                    if (nodes[j].Right != null)
                        Console.Write("\\");
                    else
                        BTreePrinter.PrintWhitespaces(1);

                    BTreePrinter.PrintWhitespaces(endgeLines + endgeLines - i);
                }

                Console.WriteLine();
            }

            PrintNodeInternal(newNodes, level + 1, maxLevel);
        }

        public static void PrintWhitespaces(int count)
        {
            string padding = string.Format("{0}", count);
            padding = "{0," + padding + "}";
            Console.Write(padding, " ");
            //for (int i = 0; i < count; i++)
            //    Console.Write(" ");
        }
    }
}