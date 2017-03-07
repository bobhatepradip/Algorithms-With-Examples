using System;

namespace TWL_Algorithms_Samples.Arrays
{
    internal class ArrayUtility
    {
        public void Run()
        {
            new Peaks_and_Valleys().Run();
            //this.Merge_Run();
        }

        public void Merge_Run()
        {
            int[] a = new int[] { 2, 3, 4, 5, 6, 8, 10, 100, 0, 0, 0, 0, 0, 0 };
            int[] b = new int[] { 1, 4, 5, 6, 7, 7 };
            int lastA = 8;
            int lastB = 6;

            Merge(a, b, lastA, lastB);
            a.Print("Merged Array a:");
        }

        /// <summary>
        /// Merges array
        /// </summary>
        /// <param name="a">first array</param>
        /// <param name="b">second array</param>
        /// <param name="lastA">number of "real" elements in a</param>
        /// <param name="lastB">number of "real" elements in b</param>
        internal static void Merge(int[] a, int[] b, int lastA, int lastB)
        {
            a.Print($"Input Array a (lastA={lastA}):");
            b.Print($"Input Array b (lastB={lastB}):");
            Console.WriteLine("---------------------------------------");
            int indexMerged = lastB + lastA - 1; /* Index of last location of merged array */
            int indexA = lastA - 1; /* Index of last element in array a */
            int indexB = lastB - 1; /* Index of last element in array b  */
            /* Merge a and b, starting from the last element in each */
            while (indexB >= 0)
            {
                //if (indexA >= 0 && indexB >= 0){Console.WriteLine($"indexA:{indexA}, indexB:{indexB}, indexMerged:{indexMerged}, a[indexA]:{a[indexA]}, b[indexB]:{b[indexB]}");}

                if (indexA >= 0 && a[indexA] > b[indexB])
                { /* end of a is bigger than end of b */
                    a[indexMerged] = a[indexA]; // copy element
                    indexA--;
                }
                else
                {
                    a[indexMerged] = b[indexB]; // copy element
                    indexB--;
                }
                indexMerged--; // move indices
                //a.Print();
                //Console.ReadLine();
            }
        }

        public class Peaks_and_Valleys : IQuestion
        {
            
            public void SortValleyPeak_UsingSorting(int[] array)
            {
                Array.Sort(array);
                for (int i = 1; i < array.Length; i += 2)
                {
                    array.Swap(i - 1, i);
                }
            }

           
            public void SortValleyPeak_UsingMaxIndex(int[] array)
            {
                for (int i = 1; i < array.Length; i += 2)
                {
                    int biggestIndex = SortValleyPeakMaxIndex(array, i - 1, i, i + 1);
                    if (i != biggestIndex)
                    {
                        array.Swap(i, biggestIndex);
                    }
                    array.Print();
                }
            }

            public int SortValleyPeakMaxIndex(int[] array, int a, int b, int c)
            {
                int len = array.Length;
                int aValue = a >= 0 && a < len ? array[a] : int.MinValue;
                int bValue = b >= 0 && b < len ? array[b] : int.MinValue;
                int cValue = c >= 0 && c < len ? array[c] : int.MinValue;

                int max = Math.Max(aValue, Math.Max(bValue, cValue));

                if (aValue == max)
                {
                    return a;
                }
                else if (bValue == max)
                {
                    return b;
                }
                else
                {
                    return c;
                }
            }

            
            public static void SortValleyPeak3(int[] array)
            {
                for (int i = 1; i < array.Length; i += 2)
                {
                    if (array[i - 1] < array[i])
                    {
                        array.Swap(i - 1, i);
                        //array.Print();
                    }
                    if (i + 1 < array.Length && array[i + 1] < array[i])
                    {
                        array.Swap(i + 1, i);
                        //array.Print();
                    }
                }
            }

            public void Run()
            {
                int[] array = { 48, 40, 31, 62, 28, 21, 64, 40, 23, 17 };
                //int[] array2 = array;
                //int[] array3 = array;
                array.Print();
                SortValleyPeak_UsingSorting(array);
                array.Print();
                Console.WriteLine("=================================================");
                int[] array2 = { 48, 40, 31, 62, 28, 21, 64, 40, 23, 17 };
                array2.Print();
                SortValleyPeak_UsingMaxIndex(array2);
                array2.Print();
                Console.WriteLine("=================================================");
                int[] array3 = { 48, 40, 31, 62, 28, 21, 64, 40, 23, 17 };
                array3.Print();
                SortValleyPeak3(array3);
                array3.Print();
                Console.WriteLine("=================================================");
            }

           
        }
    }
}