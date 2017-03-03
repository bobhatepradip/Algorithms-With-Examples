using System;
using System.Collections.Generic;
using System.Text;
using TWL_Algorithms_Samples.Arrays;
using TWL_Algorithms_Samples;

namespace TWL_Algorithms_Samples.Sorting
{
    class Sorting
    {
        public void Run()
        {
            Console.WriteLine($"Start {this.GetType().Name}.Run");
            int[] array = Constants.cArrayNumbers;
            array.Print("Input:\n");
            QuickSort.Sort(array, 0, array.Length);
            Console.WriteLine($"End {this.GetType().Name}.Run");
        }

        internal class QuickSort
        {
            internal static void Sort(int[] array, int left, int right)
            {
                int i = 100;
                int index = Partition(array, left, right);
                if (left < index - 1)
                {
                    Sort(array, left, index - 1);
                }
                if (index <right)
                {
                    Sort(array, index, right);
                }
            }

            internal static int Partition(int[] array, int left, int right)
            {
                Console.WriteLine($"Start .Run");
                //pick pivote point
                int pivote = array[(left + right) / 2];
                //pivote.Print("Pivote:\n");
                while (left <= right)
                {
                    while (array[left] < pivote)
                    {
                        left++;
                        //left.Print("Left:\n");
                    }

                    while (array[right] > pivote)
                    {
                        right--;
                        //left.Print("Right:\n");
                    }

                    if (left <= right)
                    {
                        //swap(array, left, right);
                        left++;
                        right--;

                    }
                }

                left.Print("Median:\n");
                return left;
            }
        }
    }
}
