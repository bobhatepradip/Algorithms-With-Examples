using System;
using TWL_Algorithms_Samples.Arrays;
using TWL_Algorithms_Samples.Arrays.Strings;
using TWL_Algorithms_Samples.SortingAndSearching;

internal class Program
{
    private static void Main(string[] args)
    {
        Console.WriteLine("======================================================================");
        new ArrayUtility().Run();
        new ArrayUtility().Run();
        new StringUtility().Run();
        new Sorting().Run();
        Console.WriteLine("======================================================================");
        Console.WriteLine("Press any key to quit");
        Console.ReadKey();
    }
}