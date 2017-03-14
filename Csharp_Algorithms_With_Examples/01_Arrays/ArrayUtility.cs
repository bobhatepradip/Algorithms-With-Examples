using System;

namespace TWL_Algorithms_Samples.Arrays
{
    internal class ArrayUtility
    {
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

        public void Run()
        {
            //new Peaks_and_Valleys().Run();
            //this.Merge_Run();
            //Search_in_Rotated_Array_Run();
            //new OneEditChecker().Run();
            //new MatrixRotation().Run();
            new Zero_Matrix().Run();
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

        public void Search_in_Rotated_Array_Run()
        {
            int[] a = new int[] { 5, 6, 7, 8, 9, 1, 2, 3, 4 };
            int searchInput = 4;
            a.Print($"Input array (search for '{searchInput}'):");
            int searchIndex = Search_in_Rotated_Array(a, 0, a.Length - 1, searchInput);
            Console.WriteLine($"\nIndex of {searchInput} in array is {searchIndex}");
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

            private void Matrix_Rotate(int[][] matrix)
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

            private int[][] CloneMatrix(int[][] matrix)
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

            private bool MatricesAreEqual(int[][] matrix1, int[][] matrix2)
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

            private void NullifyColumn(int[][] matrix, int col)
            {
                for (var i = 0; i < matrix.Length; i++)
                {
                    matrix[i][col] = 0;
                }
            }

            private void NullifyRow(int[][] matrix, int row)
            {
                for (var j = 0; j < matrix[0].Length; j++)
                {
                    matrix[row][j] = 0;
                }
            }

            private void SetZeros(int[][] matrix)
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

            private void SetZeros2(int[][] matrix)
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