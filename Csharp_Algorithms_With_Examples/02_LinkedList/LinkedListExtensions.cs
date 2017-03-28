using System;

namespace TWL_Algorithms_Samples.LinkedList
{
    internal static class LinkedListExtensions
    {
        public static void PrintNode(this MyLinkedListNode myLinkListNode, String header = "")
        {
            if (!string.IsNullOrEmpty(header)) { Console.WriteLine(header); }

            if (myLinkListNode != null)
            {
                Console.WriteLine($"Node value is '{myLinkListNode.Data}'");
            }
            else
            {
                Console.WriteLine($"Node does not exist!!!");
            }
        }

        public static object NodeValue(this MyLinkedListNode myLinkListNode, String header = "")
        {
            if (myLinkListNode != null)
            {
                return myLinkListNode.Data;
            }
            else
            {
                return null;
            }
        }
    }
}