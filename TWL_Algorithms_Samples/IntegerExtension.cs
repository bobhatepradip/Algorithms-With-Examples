using System;
using System.Collections.Generic;
using System.Text;

namespace TWL_Algorithms_Samples
{
    public static class IntegerExtension
    {
        public static void Print(this int number, String header)
        {
            string printString = header + "{";
            printString = printString + "'" + number + "'";
            printString = printString + "}";
            Console.WriteLine(printString);
        }
    }
}
