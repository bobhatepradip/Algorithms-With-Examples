using System;

namespace TWL_Algorithms_Samples.Arrays
{
    internal class ArrayUtility
    {
        public void Run()
        {
            int[] a = new int[] { 2, 3, 4, 5, 6, 8, 10, 100, 0, 0, 0, 0, 0, 0 };
            int[] b = new int[] { 1, 4, 5, 6, 7, 7 };
            int lastA = 8;
            int lastB = 6;

            Merge(a, b, lastA, lastB);
            a.Print("Meaged Array a:");
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
    }
}