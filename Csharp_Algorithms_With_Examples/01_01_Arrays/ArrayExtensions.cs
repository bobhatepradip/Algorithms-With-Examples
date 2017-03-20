using System;

namespace TWL_Algorithms_Samples.Arrays
{
    internal static class ArrayExtensions
    {
        public static void Print(this int[] array, String header)
        {
            Console.WriteLine(header);
            array.Print();
        }

        public static void Print(this int[] array)
        {
            string printString = "{";
            foreach (int arrayElemnt in array)
            {
                printString = printString + "'" + arrayElemnt + "'";
            }
            printString = printString + "}";
            Console.WriteLine(printString);
        }

        public static void Print(this object[] array, String header)
        {
            Console.WriteLine(header);
            array.Print();
        }

        public static void Print(this object[] array)
        {
            string printString = "{";
            foreach (object arrayElement in array)
            {
                printString = printString + "'" + arrayElement + "',";
            }
            printString = printString + "}";
            Console.WriteLine(printString);
        }

        public static void Print(this object[] array, int length, String header)
        {
            Console.WriteLine(header);
            array.Print(length);
        }

        public static void Print(this object[] array, int length)
        {
            string printString = "{";
            for (int i = 0; i < length - 1; i++)
            {
                printString = printString + "'" + array[i] + "',";
            }
            printString = printString + "}";
            Console.WriteLine(printString);
        }

        public static void Print(this char[] array)
        {
            string printString = "{";
            foreach (int arrayElemnt in array)
            {
                printString = printString + "'" + arrayElemnt + "'";
            }
            printString = printString + "}";
            Console.WriteLine(printString);
        }

        public static void Print(this char[] array, String header)
        {
            Console.WriteLine(header);
            array.Print();
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

        public static void Swap(this object[] array, int firstIndex, int secondIndex)
        {
            var temp = array[firstIndex];
            array[firstIndex] = array[secondIndex];
            array[secondIndex] = temp;
        }

        public static void Swap(this char[] array, int firstIndex, int secondIndex)
        {
            var temp = array[firstIndex];
            array[firstIndex] = array[secondIndex];
            array[secondIndex] = temp;
        }
    }
}