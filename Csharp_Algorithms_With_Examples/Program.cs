using System;
using TWL_Algorithms_Samples.Arrays;
using TWL_Algorithms_Samples.Arrays.Strings;
using TWL_Algorithms_Samples.BitManipulation;
using TWL_Algorithms_Samples.LinkedList;
using TWL_Algorithms_Samples.Queue;
using TWL_Algorithms_Samples.SortingAndSearching;
using TWL_Algorithms_Samples.Stack;

internal class Program
{
    private static void Main(string[] args)
    {
        Console.WriteLine("======================================================================");
        new ArrayUtility().Run();
        new LinkedListUtility().Run();
        new StackUtility().Run();
        new QueueUtility().Run();
        new StringUtility().Run();
        new BitManipulationUtility().Run();
        new Sorting().Run();
        new SortingAndSearchingUtility().Run();
        Console.WriteLine("======================================================================");
        Console.WriteLine("Press any key to quit");
        Console.ReadKey();
    }
}