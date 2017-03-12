using System;
using TWL_Algorithms_Samples.Arrays;
using TWL_Algorithms_Samples.Arrays.Strings;
using TWL_Algorithms_Samples.LinkedList;
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
        new StringUtility().Run();
        new Sorting().Run();
        Console.WriteLine("======================================================================");
        Console.WriteLine("Press any key to quit");
        Console.ReadKey();
    }
}