using System;

namespace TWL_Algorithms_Samples.Arrays
{
    internal static class ArrayExtensions
    {
        public static void Print(this int[] array, String header)
        {
            string printString = header + "\n{";
            foreach (int arrayElemnt in array)
            {
                printString = printString + "'" + arrayElemnt + "'";
            }
            printString = printString + "}";
            Console.WriteLine(printString);
        }

        public static void Print(this char[] array, String header)
        {
            string printString = header + "\n{";
            foreach (int arrayElemnt in array)
            {
                printString = printString + "'" + arrayElemnt + "'";
            }
            printString = printString + "}";
            Console.WriteLine(printString);
        }

        public static void Print(this int[] array, String header, int firstIndex, int secondIndex)
        {
            string printString = header + "\nfirstIndex-" + firstIndex + " secondIndex-" + secondIndex + "\n{";
            for (int i = firstIndex; i <= secondIndex; i++)
            {
                printString = printString + "'" + array[i] + "'";
            }
            printString = printString + "}";
            Console.WriteLine(printString);
        }

        public static void Swap(this int[] array, int firstIndex, int secondIndex)
        {
            var temp = array[firstIndex];
            array[firstIndex] = array[secondIndex];
            array[secondIndex] = temp;
        }
    }
}