using System;

namespace TWL_Algorithms_Samples.Arrays
{
    internal class ArrayUtility
    {
        /// <summary>
        /// Merges array
        /// </summary>
        /// <param name="a">first array</param>
        /// <param name="b">second array</param>
        /// <param name="lastA">number of "real" elements in a</param>
        /// <param name="lastB">number of "real" elements in b</param>
        public void Merge(int[] a, int[] b, int lastA, int lastB)
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

        public void Merge_Run()
        {
            int[] a = new int[] { 2, 3, 4, 5, 6, 8, 10, 100, 0, 0, 0, 0, 0, 0 };
            int[] b = new int[] { 1, 4, 5, 6, 7, 7 };
            int lastA = 8;
            int lastB = 6;

            Merge(a, b, lastA, lastB);
            a.Print("Merged Array a:");
        }

        public void Run()
        {
            //new Peaks_and_Valleys().Run();
            //this.Merge_Run();
            //Search_in_Rotated_Array_Run();
        }

        /// <summary>
        /// As in the book, returns the correct index (tested)
        /// It's a real kludge though... good initial answer
        /// The code runs in O(logn) time - assuming that all elements are unique.
        /// However, with many duplicates, the algorithm is O(n)
        /// </summary>
        /// <param name="a"></param>
        /// <param name="low"></param>
        /// <param name="high"></param>
        /// <param name="x"></param>
        /// <returns></returns>
        public int Search_in_Rotated_Array(int[] a, int left, int right, int x)
        {
            int mid = (left + right) / 2;
            if (x == a[mid])
            { // Found element
                return mid;
            }
            if (right < left)
            {
                return -1;
            }

            /* While there may be an inflection point due to the rotation, either the left or
             * right half must be normally ordered.  We can look at the normally ordered half
             * to make a determination as to which half we should search.
             */
            if (a[left] < a[mid])
            { // Left is normally ordered.
                if (x >= a[left] && x < a[mid])
                {
                    return Search_in_Rotated_Array(a, left, mid - 1, x);
                }
                else
                {
                    return Search_in_Rotated_Array(a, mid + 1, right, x);
                }
            }
            else if (a[mid] < a[left])
            { // Right is normally ordered.
                if (x > a[mid] && x <= a[right])
                {
                    return Search_in_Rotated_Array(a, mid + 1, right, x);
                }
                else
                {
                    return Search_in_Rotated_Array(a, left, mid - 1, x);
                }
            }
            else if (a[left] == a[mid])
            { // Left is either all repeats OR loops around (with the right half being all dups)
                if (a[mid] != a[right])
                { // If right half is different, search there
                    return Search_in_Rotated_Array(a, mid + 1, right, x);
                }
                else
                { // Else, we have to search both halves
                    int result = Search_in_Rotated_Array(a, left, mid - 1, x);
                    if (result == -1)
                    {
                        return Search_in_Rotated_Array(a, mid + 1, right, x);
                    }
                    else
                    {
                        return result;
                    }
                }
            }
            return -1;
        }

        /* Another way is to do a pivoted binary search, where you first identify the problematic area, basically start of the originally
         * sorted array. */

        public void Search_in_Rotated_Array_Run()
        {
            int[] a = new int[] { 5, 6, 7, 8, 9, 1, 2, 3, 4 };
            int searchInput = 4;
            a.Print($"Input array (search for '{searchInput}'):");
            int searchIndex = Search_in_Rotated_Array(a, 0, a.Length - 1, searchInput);
            Console.WriteLine($"\nIndex of {searchInput} in array is {searchIndex}");
        }

        public class Peaks_and_Valleys : IQuestion
        {
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

            public void SortValleyPeak_UsingMaxIndex(int[] array)
            {
                for (int i = 1; i < array.Length; i += 2)
                {
                    int biggestIndex = SortValleyPeak_UsingMaxIndex_GetMaxIndex(array, i - 1, i, i + 1);
                    if (i != biggestIndex)
                    {
                        array.Swap(i, biggestIndex);
                    }
                    array.Print();
                }
            }

            public int SortValleyPeak_UsingMaxIndex_GetMaxIndex(int[] array, int a, int b, int c)
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

            public void SortValleyPeak_UsingSorting(int[] array)
            {
                Array.Sort(array);
                for (int i = 1; i < array.Length; i += 2)
                {
                    array.Swap(i - 1, i);
                }
            }
        }
    }
}