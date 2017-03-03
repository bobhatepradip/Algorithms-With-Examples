using System;
using System.Collections.Generic;
using System.Text;

namespace TWL_Algorithms_Samples.Arrays
{
    static class ArrayExtensions
    {
        public static void Print(this int[] array, String header)
        {
            string printString = header + "{";
            foreach (int nummber in array)
            {
                printString = printString + "'" + nummber + "'";
            }
            printString = printString + "}";
            Console.WriteLine(printString);
        }
    }
}
