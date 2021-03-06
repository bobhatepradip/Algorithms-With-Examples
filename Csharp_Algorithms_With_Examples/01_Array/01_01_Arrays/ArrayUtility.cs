﻿using System;
using System.Text;

namespace TWL_Algorithms_Samples.Arrays
{
    public class ArrayUtility
    {
        public static int[] OneDArray = new int[] { 1, 2, 3, 4, 5, 6 };
        public static int[] OneDArrayZeroToFive = new int[] { 0, 1, 2, 3, 4, 5 };
        public static int[] OneDArrayZeroToTen = new int[] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
        public static int[] OneDArrayZeroToThree = new int[] { 0, 1, 2, 3 };
        public static int[][] TwoDArray = new int[][] { new int[] { 1, 1, 2, 3, 3, 4, 4 }, new int[] { 4, 4, 1, 1, 3, 2, 2 }, new int[] { 1, 2, 2, 3, 3 } };

        public static string CharArrayToString(char[] array)
        {
            StringBuilder buffer = new StringBuilder(array.Length);
            foreach (char c in array)
            {
                if (c == 0)
                {
                    break;
                }
                buffer.Append(c);
            }
            return buffer.ToString();
        }

        public static int[] GetArray_Serial(int min, int max)
        {
            int[] arrayInt = new int[(max - min) + 1];
            for (int i = 0; i <= max - min; i++)
            {
                arrayInt[i] = min + i;
            }
            return arrayInt;
        }

        public static void Matrix_Display(int[][] matrix, string header = "")
        {
            Console.WriteLine($"------------------------------------{header}----------------------------------");
            for (int i = 0; i < matrix.Length; i++)
            {
                for (int j = 0; j < matrix[i].Length; j++)
                {
                    if (matrix[i][j] < 100 && matrix[i][j] > -100)
                    {
                        Console.Write(" ");
                    }
                    if (matrix[i][j] < 10 && matrix[i][j] > -10)
                    {
                        Console.Write(" ");
                    }
                    if (matrix[i][j] >= 0)
                    {
                        Console.Write(" ");
                    }
                    Console.Write(" " + matrix[i][j]);
                }
                Console.WriteLine();
            }
        }

        public static int[][] Matrix_Get2DArrayRandom(int rowsCount, int columnCounts, int minNumber, int maxNumber)
        {
            int[][] matrix = new int[rowsCount][];
            for (int i = 0; i < rowsCount; i++)
            {
                matrix[i] = new int[columnCounts];
                for (int j = 0; j < columnCounts; j++)
                {
                    matrix[i][j] = AssortedMethods.RandomIntInRange(minNumber, maxNumber);
                }
            }
            return matrix;
        }

        public static int[][] Matrix_Get2DArraySerial(int rowsCount, int columnCounts)
        {
            int[][] matrix = new int[rowsCount][];
            for (int i = 0; i < rowsCount; i++)
            {
                matrix[i] = new int[columnCounts];
                for (int j = 0; j < columnCounts; j++)
                {
                    matrix[i][j] = (i + 1) * 10 + (j + 1);
                }
            }
            return matrix;
        }

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

        /// <summary>
        /// public static int[] arrayPartitionData = new int[] { 1, 9, 4, 3, 7, 5, 2, 8, 6, 10 };
        ///public static int[] arrayPartitionRange = new int[] { 1, 4,5, 7, 10 };
        /// </summary>
        /// <param name="partitionData"></param>
        /// <param name="partitionDataLeft"></param>
        /// <param name="partitionDataRight"></param>
        /// <param name="partitionRange"></param>
        /// <param name="partitionRangeLeft"></param>
        /// <param name="partitionRangeRight"></param>
        public void PartitionSortedArray(int[] partitionData, int partitionDataLeft, int partitionDataRight, int[] partitionRange, int partitionRangeLeft, int partitionRangeRight)
        {
            partitionData.Print("partitionData Before:", partitionDataLeft, partitionDataRight);
            partitionRange.Print("partitionRange Before:", partitionRangeLeft, partitionRangeRight);
            //for (int i = 0; i < partitionData.Length / 2; i++)
            while (partitionDataLeft <= partitionDataRight)
            {
                if (partitionData[partitionDataLeft] > partitionRange[partitionRangeLeft + 1] && partitionData[partitionDataRight] < partitionRange[partitionRangeRight - 1])
                {
                    partitionData.Swap(partitionDataLeft, partitionDataRight);
                }
                else if (partitionData[partitionDataLeft] < partitionRange[partitionRangeLeft + 1] || partitionData[partitionDataRight] > partitionRange[partitionRangeRight - 1])
                {
                    if (partitionData[partitionDataLeft] < partitionRange[partitionRangeLeft + 1])
                    {
                        partitionDataLeft++;
                    }
                    if (partitionData[partitionDataRight] > partitionRange[partitionRangeRight - 1])
                    {
                        partitionDataRight--;
                    }
                }
                else
                {
                    partitionDataLeft++;
                    partitionDataRight--;
                }
            }
            partitionData.Print("partitionData After:", partitionDataLeft, partitionDataRight);
            partitionRange.Print("partitionRange After:", partitionRangeLeft, partitionRangeRight);
            if (((partitionRangeLeft + 1) - (partitionRangeRight - 1)) > 1)
            {
                PartitionSortedArray(partitionData, partitionDataLeft + 1, partitionDataRight - 1, partitionRange, partitionRangeLeft + 1, partitionRangeRight - 1);
            }
        }

        public void PartitionSortedArray_Run()
        {
            int[] arrayPartitionData = new int[] { 10, 90, 65, 45, 35, 70, 50, 40, 15, 100, 80 };
            int[] arrayPartitionRange = new int[] { 0, 25, 50, 75, 100 };
            // PartitionSortedArray(arrayPartitionData, 0, arrayPartitionData.Length - 1, arrayPartitionRange, 0, arrayPartitionRange.Length - 1);
            arrayPartitionData.Print("");
        }

        private void QuickSort(int[] arr, int left, int right)
        {
            int index = QuickSortPartition(arr, left, right);
            //Sort left half
            if (left < index - 1)
            {
                QuickSort(arr, left, index - 1);
            }
            //Sort right half
            if (index < right)
            {
                QuickSort(arr, index, right);
            }
        }

        private int QuickSortPartition(int[] arr, int left, int right)
        {
            //Pick Pivote Point
            int pivoteValue = arr[(left + right) / 2];
            while (left <= right)
            {
                //Find element on left that should be on right
                while (arr[left] < pivoteValue) left++;
                //Find element on right that should be on left
                while (arr[left] < pivoteValue) left++;
                //Swap elements, and move left and right indices
                if (left < right)
                {
                    //swaps elements Swap(arr, left, right);
                    arr.Swap(left, right);
                    left++;
                    right--;
                }
            }
            return left;
        }

        private void MeargeSort(int[] arr)
        {
            int[] helper = new int[arr.Length];
            MergeSort(arr, helper, 0, arr.Length);
        }

        private void MergeSort(int[] arr, int[] helper, int low, int high)
        {
            if (low < high)
            {
                int middle = (low + high) / 2;
                MergeSort(arr, helper, low, middle);
                MergeSort(arr, helper, low, middle);
                Merge(arr, helper, low, middle, high);
            }
        }

        private void Merge(int[] arr, int[] helper, int low, int middle, int high)
        {
            //Copy both halves into a helper array
            for (int i = low; i <= high; i++)
            {
                helper[i] = arr[i];
            }

            int helperLeft = low;
            int helperRight = middle + 1;
            int current = low;
            /*
             Iterate through helper arry. Compare the left and riht half, Copying back
             the smaller element from the two halves into the original array.
             */
            while (helperLeft <= middle && helperRight <= high)
            {
                if (helper[helperLeft] <= helper[helperRight])
                {
                    arr[current] = helper[helperLeft];
                    helperLeft++;
                }
                //If right element is small than left element
                else
                {
                    arr[current] = helper[helperRight];
                    helperRight++;
                }
                current++;
            }

            //Copy the rest of the left side of the arry inot the target array
            int remaining = middle - helperLeft;
            for (int i = 0; i <= remaining; i++)
            {
                arr[current + i] = helper[helperLeft + i];
            }
        }

        /// <summary>
        /// given [1,2,3,4], return [24,12,8,6].
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public int[] ProductAllExceptSelf(int[] nums)
        {
            Console.WriteLine("given [1,2,3,4], return [24,12,8,6].");
            nums.Print("input:");
            int n = nums.Length;
            int[] res = new int[n];
            res[0] = 1;
            for (int i = 1; i < n; i++)
            {
                res[i] = res[i - 1] * nums[i - 1];
            }
            res.Print("res:");
            int right = 1;
            for (int i = n - 1; i >= 0; i--)
            {
                Console.WriteLine($"right='{right}' res[i]='{res[i]}'");
                res[i] *= right;
                right *= nums[i];
                Console.WriteLine($"nums[i]='{nums[i]}' right='{right}' res[i]='{res[i]}'");
                res.Print("res Temp");
            }
            res.Print("output:");
            return res;
        }

        /// <summary>
        /// Time complextiy : O(n). Assume that nn is the length of array. Each of i and j traverses at most n steps.
        /// Space complexity : O(1).
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public int RemoveDuplicatesInSortedArray(int[] nums)
        {
            nums.Print("Before:");
            if (nums.Length == 0) return 0;
            int i = 0;
            for (int j = 1; j < nums.Length; j++)
            {
                if (nums[j] != nums[i])
                {
                    i++;
                    nums[i] = nums[j];
                }
            }
            nums.Print("After:", 0, i);
            return i + 1;
        }

        public void Reverse(int[] nums, int start, int end)
        {
            while (start < end)
            {
                nums.Swap(start, end);
                start++;
                end--;
            }
        }

        /// <summary>
        /// nums={1,2,3,4,5,6,7} k=3
        /// revNums={7,6,5,4,3,2,1}
        /// outputNums={rev(0, nums.Length-k), rev(nums.Length-k-1, nums.Lenght)}
        /// outputNums={{4,5,6,7},{1,2,3}}
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="k"></param>
        public void RotateArray(int[] nums, int k)
        {
            Reverse(nums, 0, nums.Length - 1);
            Reverse(nums, 0, nums.Length - k - 1);
            //This should be Reverse(nums, k, (nums.Length  - k)- 1);
            Reverse(nums, nums.Length - k, nums.Length - 1);
        }

        public void RotateArray_Run()
        {
            var testArrayRotation = GetArray_Serial(1, 10);
            testArrayRotation.Print("Before Array Rotation:");
            RotateArray(testArrayRotation, 3);
            testArrayRotation.Print("After Array Rotation:");
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
        public int RotatedArray_Search(int[] a, int left, int right, int x)
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
                    return RotatedArray_Search(a, left, mid - 1, x);
                }
                else
                {
                    return RotatedArray_Search(a, mid + 1, right, x);
                }
            }
            else if (a[mid] < a[left])
            { // Right is normally ordered.
                if (x > a[mid] && x <= a[right])
                {
                    return RotatedArray_Search(a, mid + 1, right, x);
                }
                else
                {
                    return RotatedArray_Search(a, left, mid - 1, x);
                }
            }
            else if (a[left] == a[mid])
            { // Left is either all repeats OR loops around (with the right half being all dups)
                if (a[mid] != a[right])
                { // If right half is different, search there
                    return RotatedArray_Search(a, mid + 1, right, x);
                }
                else
                { // Else, we have to search both halves
                    int result = RotatedArray_Search(a, left, mid - 1, x);
                    if (result == -1)
                    {
                        return RotatedArray_Search(a, mid + 1, right, x);
                    }
                    else
                    {
                        return result;
                    }
                }
            }
            return -1;
        }

        public void RotatedArray_Search_Run()
        {
            int[] a = new int[] { 5, 6, 7, 8, 9, 1, 2, 3, 4 };
            int searchInput = 4;
            a.Print($"Input array (search for '{searchInput}'):");
            int searchIndex = RotatedArray_Search(a, 0, a.Length - 1, searchInput);
            Console.WriteLine($"\nIndex of {searchInput} in array is {searchIndex}");
        }

        public void Run()
        {
            //new Peaks_and_Valleys().Run();
            //this.Merge_Run();
            //RotatedArray_Search_Run();
            //new OneEditChecker().Run();
            //new MatrixRotation().Run();
            //new Zero_Matrix().Run();
            //RemoveDuplicatesInSortedArray(new int[] { 1, 2, 2, 3, 3, 3, 4, 5, 6, 6, 6, 6, 6, 6 });
            //TwoSumInSortedArray(new int[] { 1, 2, 7, 11, 15 }, 9);
            //ProductAllExceptSelf(new int[] { 1, 2, 3, 4 });
            //RotateArray_Run();
            PartitionSortedArray_Run();
        }

        public int[] TwoSumInSortedArray(int[] num, int target)
        {
            num.Print("input:");
            int[] indice = new int[2];
            if (num == null || num.Length < 2) return indice;
            int left = 0, right = num.Length - 1;
            while (left < right)
            {
                int v = num[left] + num[right];
                if (v == target)
                {
                    indice[0] = left + 1;
                    indice[1] = right + 1;
                    Console.WriteLine($"indice[0]={indice[0]} indice[1]={indice[1]} target({target}) = num[left] ({num[left]})+ num[right]({num[right]}) ; left={left} right={right}");
                    break;
                }
                else if (v > target)
                {
                    right--;
                }
                else
                {
                    left++;
                }
            }
            return indice;
        }

        public class MatrixRotation : IQuestion
        {
            public void Run()
            {
                const int size = 3;
                var matrix = Matrix_Get2DArraySerial(size, size);
                Matrix_Display(matrix);
                Matrix_Rotate(matrix);
                Matrix_Display(matrix);
            }

            public void Matrix_Rotate(int[][] matrix)
            {
                int n = matrix.Length;
                for (var layer = 0; layer < n / 2; ++layer)
                {
                    var first = layer;
                    var last = (n - 1) - layer;

                    for (var i = first; i < last; ++i)
                    {
                        Console.WriteLine($"Step--> {layer}:{i}");
                        var offset = i - first;
                        var top = matrix[first][i];
                        // save top
                        //Console.WriteLine($"layer:{layer} first:{first} last:{last} top:{top} offset:{offset}");
                        // left -> top
                        //Console.WriteLine($"left([last - offset][first]) [{last} - {offset}][{first}] -> top([first][i]) [{first}][{i}]");
                        matrix[first][i] = matrix[last - offset][first];
                        // bottom -> left
                        //Console.WriteLine($"bottom([last][last - offset]) [{last}][{last} - {offset}] -> left([last - offset][first]) [{last} - {offset}][{first}]");
                        matrix[last - offset][first] = matrix[last][last - offset];
                        // right -> bottom
                        //Console.WriteLine($"right([i][last]) [{i}][{last}] --> bottom([last][last - offset]) [{last}][{last} - {offset}]");
                        matrix[last][last - offset] = matrix[i][last];
                        // top -> right
                        //Console.WriteLine($"top={top}  --> right([i][last]) [{i}][{last}]");
                        matrix[i][last] = top; // right <- saved top
                        Matrix_Display(matrix);
                    }
                }
            }
        }

        public class OneEditChecker : IQuestion
        {
            public static bool OneEditAway_OneIteration(String first, String second)
            {
                /* Length checks. */
                if (Math.Abs(first.Length - second.Length) > 1)
                {
                    return false;
                }

                /* Get shorter and longer string.*/
                String shorterString = first.Length < second.Length ? first : second;
                String longerString = first.Length < second.Length ? second : first;

                int shorterStringIndex = 0;
                int longerStringIndex = 0;
                bool foundDifference = false;
                while (longerStringIndex < longerString.Length && shorterStringIndex < shorterString.Length)
                {
                    if (shorterString[shorterStringIndex] != longerString[longerStringIndex])
                    {
                        /* Ensure that this is the first difference found.*/
                        if (foundDifference)
                        {
                            return false;
                        }
                        foundDifference = true;
                        if (shorterString.Length == longerString.Length)
                        { // On replace, move shorter pointer
                            shorterStringIndex++;
                        }
                    }
                    else
                    {
                        shorterStringIndex++; // If matching, move shorter pointer
                    }
                    longerStringIndex++; // Always move pointer for longer string
                }
                return true;
            }

            public static bool OneEditAway_OneIterationWtihSerparateFunctions(String first, String second)
            {
                if (first.Length == second.Length)
                {
                    return OneEditReplace(first, second);
                }
                else if (first.Length + 1 == second.Length)
                {
                    return OneEditInsert(first, second);
                }
                else if (first.Length - 1 == second.Length)
                {
                    return OneEditInsert(second, first);
                }
                return false;
            }

            public static bool OneEditInsert(String s1, String s2)
            {
                int index1 = 0;
                int index2 = 0;
                while (index2 < s2.Length && index1 < s1.Length)
                {
                    if (s1[index1] != s2[index2])
                    {
                        if (index1 != index2)
                        {
                            return false;
                        }
                        index2++;
                    }
                    else
                    {
                        index1++;
                        index2++;
                    }
                }
                return true;
            }

            public static bool OneEditReplace(String s1, String s2)
            {
                bool foundDifference = false;
                for (int i = 0; i < s1.Length; i++)
                {
                    if (s1[i] != s2[i])
                    {
                        if (foundDifference)
                        {
                            return false;
                        }

                        foundDifference = true;
                    }
                }
                return true;
            }

            /* Check if you can insert a character into s1 to make s2. */

            public void Run()
            {
                string[][] stringPairs =             {
                new string[]{ "pse", "pale"},
                new string[]{ "pale", "zpale"},//1 insert
                new string[]{ "palez", "pale"},//1 insert
                new string[]{ "pale", "ale"},//1 edit
                new string[]{ "pal", "pale"},//1 edit
                new string[]{ "pale", "zzpale"},//2 insert
                 new string[]{ "palezz", "pale"},//2 insert
                 new string[]{ "pale", "zpalz"},//1 insert and 1 edit
            };
                foreach (string[] stringPair in stringPairs)
                {
                    var a = stringPair[0];
                    var b = stringPair[1];
                    bool isOneEdit = OneEditAway_OneIteration(a, b);
                    Console.WriteLine("OneEditAway: {0}, {1}: {2}", a, b, isOneEdit);

                    bool isOneEdit2 = OneEditAway_OneIteration(a, b);
                    Console.WriteLine("stringPair[0]: {0}, {1}: {2}", a, b, isOneEdit2);
                    Console.WriteLine("----------------------------------------------------");
                }
            }
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

        public class Zero_Matrix : IQuestion
        {
            public void Run()
            {
                const int numberOfRows = 5;
                const int numberOfColumns = 5;
                //var matrix1 = Matrix_Get2DArraySerial(numberOfRows, numberOfColumns);
                var matrix1 = Matrix_Get2DArrayRandom(numberOfRows, numberOfColumns, 0, 9);
                var matrix2 = CloneMatrix(matrix1);
                Matrix_Display(matrix1, "matrix1");
                SetZeros(matrix1);
                Matrix_Display(matrix1, "matrix1 after SetZeros");
                SetZeros2(matrix2);
                Matrix_Display(matrix2, "matrix2  after SetZeros2");
                Console.WriteLine();
                Matrix_Display(matrix2, "matrix2");
                Console.WriteLine(MatricesAreEqual(matrix1, matrix2) ? "Equal" : "Not Equal");
            }

            public int[][] CloneMatrix(int[][] matrix)
            {
                var clone = new int[matrix.Length][];

                for (var i = 0; i < matrix.Length; i++)
                {
                    clone[i] = new int[matrix[0].Length];

                    for (var j = 0; j < matrix[0].Length; j++)
                    {
                        clone[i][j] = matrix[i][j];
                    }
                }

                return clone;
            }

            public bool MatricesAreEqual(int[][] matrix1, int[][] matrix2)
            {
                if (matrix1.Length != matrix2.Length || matrix1[0].Length != matrix2[0].Length)
                {
                    return false;
                }

                for (var k = 0; k < matrix1.Length; k++)
                {
                    for (var j = 0; j < matrix1[0].Length; j++)
                    {
                        if (matrix1[k][j] != matrix2[k][j])
                        {
                            return false;
                        }
                    }
                }

                return true;
            }

            public void NullifyColumn(int[][] matrix, int col)
            {
                for (var i = 0; i < matrix.Length; i++)
                {
                    matrix[i][col] = 0;
                }
            }

            public void NullifyRow(int[][] matrix, int row)
            {
                for (var j = 0; j < matrix[0].Length; j++)
                {
                    matrix[row][j] = 0;
                }
            }

            public void SetZeros(int[][] matrix)
            {
                var row = new bool[matrix.Length];
                var column = new bool[matrix[0].Length];

                // Store the row and column index with value 0
                for (var i = 0; i < matrix.Length; i++)
                {
                    for (var j = 0; j < matrix[0].Length; j++)
                    {
                        if (matrix[i][j] == 0)
                        {
                            row[i] = true;
                            column[j] = true;
                            Console.WriteLine($"metrix 1: row:{i} column:{j} -Store the row and column index with value 0");
                        }
                    }
                }

                // Nullify rows
                for (var i = 0; i < row.Length; i++)
                {
                    if (row[i])
                    {
                        NullifyRow(matrix, i);
                        Matrix_Display(matrix, $"matrix1 after -NullifyRow row:{i} Store the row and column index with value 0");
                    }
                }

                // Nullify columns
                for (var j = 0; j < column.Length; j++)
                {
                    if (column[j])
                    {
                        NullifyColumn(matrix, j);
                        Matrix_Display(matrix, $"matrix1 after -NullifyColumn column:{j} Store the row and column index with value 0");
                    }
                }
            }

            public void SetZeros2(int[][] matrix)
            {
                Matrix_Display(matrix, $"matrix2 ");
                var firstRowHasZero = false;
                var firstColumnHasZero = false;

                // Check if first row has a zero
                for (var j = 0; j < matrix[0].Length; j++)
                {
                    if (matrix[0][j] == 0)
                    {
                        firstRowHasZero = true;
                        break;
                    }
                }

                // Check if first column has a zero
                for (var i = 0; i < matrix.Length; i++)
                {
                    if (matrix[i][0] == 0)
                    {
                        firstColumnHasZero = true;
                        break;
                    }
                }

                // Check for zeros in the rest of the array
                for (var i = 1; i < matrix.Length; i++)
                {
                    for (var j = 1; j < matrix[0].Length; j++)
                    {
                        if (matrix[i][j] == 0)
                        {
                            matrix[i][0] = 0;
                            matrix[0][j] = 0;
                        }
                    }
                }

                Matrix_Display(matrix, $"matrix2 after - Check for zeros in the rest of the array");

                // Nullify rows based on values in first column
                for (var i = 1; i < matrix.Length; i++)
                {
                    if (matrix[i][0] == 0)
                    {
                        NullifyRow(matrix, i);
                    }
                }
                Matrix_Display(matrix, $"matrix2 after - Nullify rows based on values in first column");

                // Nullify columns based on values in first row
                for (var j = 1; j < matrix[0].Length; j++)
                {
                    if (matrix[0][j] == 0)
                    {
                        NullifyColumn(matrix, j);
                    }
                }
                Matrix_Display(matrix, $"matrix2 after - Nullify columns based on values in first row");
                // Nullify first row
                if (firstRowHasZero)
                {
                    NullifyRow(matrix, 0);
                }

                Matrix_Display(matrix, $"matrix2 after - Nullify first row if firstRowHasZero in original merix");

                // Nullify first column
                if (firstColumnHasZero)
                {
                    NullifyColumn(matrix, 0);
                }
                Matrix_Display(matrix, $"matrix2 after - Nullify first column if firstColumnHasZero in original merix");
            }
        }

        /* Another way is to do a pivoted binary search, where you first identify the problematic area, basically start of the originally
         * sorted array. */
    }
}