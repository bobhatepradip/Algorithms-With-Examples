using System;
using System.Collections.Generic;
using System.Text;

namespace TWL_Algorithms_Samples.Arrays
{
    static class ArrayExtensions
    {
        public static void Print(this int[] array, String header)
        {
            string printString = header + "\n{";
            foreach (int nummber in array)
            {
                printString = printString + "'" + nummber + "'";
            }
            printString = printString + "}";
            Console.WriteLine(printString);
        }

        public static void Print(this int[] array, String header,int firstIndex, int secondIndex)
        {
            string printString = header + "\nfirstIndex-" + firstIndex+ " secondIndex-" + secondIndex + "\n{";
            for(int i=firstIndex; i <= secondIndex; i++)
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
