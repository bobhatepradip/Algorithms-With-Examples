using System;
using System.Collections;
using System.Collections.Generic;
using TWL_Algorithms_Samples.Arrays;

namespace TWL_Algorithms_Samples.SortingAndSearching
{
    public class SortingAndSearchingUtility
    {
        public void Run()
        {
        }

        public class Q10_02_Group_Anagrams : IQuestion
        {
            public void Run()
            {
                AssortedMethods.PrintLine('-', "Sort_GroupWordsByAnagram_UsingCustomAnagramComparator");
                string[] array = { "apple", "banana", "carrot", "ele", "duck", "papel", "tarroc", "cudk", "eel", "lee" };
                Sort_GroupWordsByAnagram_UsingCustomAnagramComparator(array);
                AssortedMethods.PrintLine('-', "Sort_GroupWordsByAnagram_UsingDictionary");
                string[] array2 = { "apple", "banana", "carrot", "ele", "duck", "papel", "tarroc", "cudk", "eel", "lee" };
                Sort_GroupWordsByAnagram_UsingDictionary(array2);
            }

            public static void Sort_GroupWordsByAnagram_UsingCustomAnagramComparator(string[] array)
            {
                Console.WriteLine(AssortedMethods.StringArrayToString(array));
                Array.Sort(array, new AnagramComparator());
                Console.WriteLine(AssortedMethods.StringArrayToString(array));
            }

            /// <summary>
            /// Using HashMapList/Dictionary
            /// </summary>
            /// <param name="array"></param>
            public static void Sort_GroupWordsByAnagram_UsingDictionary(string[] array)
            {
                Console.WriteLine(AssortedMethods.StringArrayToString(array));
                Dictionary<string, LinkedList<string>> hash = new Dictionary<string, LinkedList<string>>();

                /* Group words by anagram */
                foreach (string s in array)
                {
                    string key = SortChars(s);
                    if (!hash.ContainsKey(key))
                    {
                        hash.Add(key, new LinkedList<string>());
                    }
                    LinkedList<string> anagrams = hash[key];
                    anagrams.AddLast(s);
                }

                /* Convert hash table to array */
                int index = 0;
                foreach (string key in hash.Keys)
                {
                    LinkedList<string> list = hash[key];
                    foreach (string t in list)
                    {
                        array[index] = t;
                        index++;
                    }
                }

                Console.WriteLine(AssortedMethods.StringArrayToString(array));
            }

            public static string SortChars(string s)
            {
                char[] content = s.ToCharArray();
                Array.Sort<char>(content);
                return new string(content);
            }

            public class AnagramComparator : IComparer
            {
                /// <summary>
                /// From IComparer
                /// </summary>
                /// <param name="x"></param>
                /// <param name="y"></param>
                /// <returns></returns>
                int IComparer.Compare(Object x, Object y)
                {
                    return SortChars((string)x).CompareTo(SortChars((string)y));
                }

                public string SortChars(string s)
                {
                    char[] content = s.ToCharArray();
                    Array.Sort<char>(content);
                    return new string(content);
                }
            }
        }

        public class Q10_05_Sparse_Search : IQuestion
        {
            public static int Search(String[] strings, String str, int first, int last)
            {
                if (first > last)
                {
                    return -1;
                }

                /* Move mid to the middle */
                int mid = (last + first) / 2;

                /* If mid is empty, find closest non-empty string. */
                if (string.IsNullOrEmpty(strings[mid]))
                {
                    int left = mid - 1;
                    int right = mid + 1;
                    while (true)
                    {
                        if (left < first && right > last)
                        {
                            return -1;
                        }
                        else if (right <= last && !string.IsNullOrEmpty(strings[right]))
                        {
                            mid = right;
                            break;
                        }
                        else if (left >= first && !string.IsNullOrEmpty(strings[left]))
                        {
                            mid = left;
                            break;
                        }
                        right++;
                        left--;
                    }
                }

                /* Check for string, and recurse if necessary */
                if (str.Equals(strings[mid]))
                { // Found it!
                    return mid;
                }
                else if (strings[mid].CompareTo(str) < 0)
                { // Search right
                    return Search(strings, str, mid + 1, last);
                }
                else
                { // Search left
                    return Search(strings, str, first, mid - 1);
                }
            }

            public static int Search(String[] strings, String str)
            {
                if (strings == null || string.IsNullOrEmpty(str))
                {
                    return -1;
                }
                return Search(strings, str, 0, strings.Length - 1);
            }

            public static int Search2(String[] strings, String str)
            {
                if (strings == null || string.IsNullOrEmpty(str))
                {
                    return -1;
                }
                return SearchR(strings, str, 0, strings.Length - 1);
            }

            public static int SearchI(String[] strings, String str, int first, int last)
            {
                while (first <= last)
                {
                    /* Move mid to the middle */
                    int mid = (last + first) / 2;

                    /* If mid is empty, find closest non-empty string */
                    if (string.IsNullOrEmpty(strings[mid]))
                    {
                        int left = mid - 1;
                        int right = mid + 1;
                        while (true)
                        {
                            if (left < first && right > last)
                            {
                                return -1;
                            }
                            else if (right <= last && !string.IsNullOrEmpty(strings[right]))
                            {
                                mid = right;
                                break;
                            }
                            else if (left >= first && !string.IsNullOrEmpty(strings[left]))
                            {
                                mid = left;
                                break;
                            }
                            right++;
                            left--;
                        }
                    }

                    int res = strings[mid].CompareTo(str);
                    if (res == 0)
                    { // Found it!
                        return mid;
                    }
                    else if (res < 0)
                    { // Search right
                        first = mid + 1;
                    }
                    else
                    { // Search left
                        last = mid - 1;
                    }
                }
                return -1;
            }

            public static int SearchR(String[] strings, String str, int first, int last)
            {
                if (first > last)
                {
                    return -1;
                }

                /* Move mid to the middle */
                int mid = (last + first) / 2;

                /* If mid is empty, find closest non-empty string. */
                if (string.IsNullOrEmpty(strings[mid]))
                {
                    int left = mid - 1;
                    int right = mid + 1;
                    while (true)
                    {
                        if (left < first && right > last)
                        {
                            return -1;
                        }
                        else if (right <= last && !string.IsNullOrEmpty(strings[right]))
                        {
                            mid = right;
                            break;
                        }
                        else if (left >= first && !string.IsNullOrEmpty(strings[left]))
                        {
                            mid = left;
                            break;
                        }
                        right++;
                        left--;
                    }
                }

                /* Check for string, and recurse if necessary */
                if (str.Equals(strings[mid]))
                { // Found it!
                    return mid;
                }
                else if (strings[mid].CompareTo(str) < 0)
                { // Search right
                    return SearchR(strings, str, mid + 1, last);
                }
                else
                { // Search left
                    return SearchR(strings, str, first, mid - 1);
                }
            }

            public void Run()
            {
                String[] stringList = { "apple", "", "", "banana", "", "", "", "carrot", "duck", "", "", "eel", "", "flower" };

                Console.WriteLine(Search(stringList, "duck"));

                Console.WriteLine(Search2(stringList, "duck"));
            }
        }

        public class Q10_08_Find_Duplicates : IQuestion
        {
            public static void checkDuplicates(int[] array)
            {
                BitSet bs = new BitSet(32000);
                for (int i = 0; i < array.Length; i++)
                {
                    int num = array[i];
                    int num0 = num - 1; // bitset starts at 0, numbers start at 1
                    if (bs.Get(num0))
                    {
                        Console.WriteLine(num);
                    }
                    else
                    {
                        bs.Set(num0);
                    }
                }
            }

            public void Run()
            {
                int[] array = AssortedMethods.RandomArray(30, 1, 30);
                Console.WriteLine(AssortedMethods.ArrayToString(array));
                checkDuplicates(array);
            }

            public class BitSet
            {
                public int[] bitset;

                public BitSet(int size)
                {
                    bitset = new int[(size >> 5) + 1]; // divide by 32
                }

                public bool Get(int pos)
                {
                    int wordNumber = (pos >> 5); // divide by 32
                    int bitNumber = (pos & 0x1F); // mod 32
                    return (bitset[wordNumber] & (1 << bitNumber)) != 0;
                }

                public void Set(int pos)
                {
                    int wordNumber = (pos >> 5); // divide by 32
                    int bitNumber = (pos & 0x1F); // mod 32
                    bitset[wordNumber] |= 1 << bitNumber;
                }
            }
        }

        public class Q10_09_Sorted_Matrix_Search : IQuestion
        {
            public static bool FindElement(int[][] matrix, int elem)
            {
                int row = 0;
                int col = matrix[0].Length - 1;
                while (row < matrix.Length && col >= 0)
                {
                    if (matrix[row][col] == elem)
                    {
                        return true;
                    }
                    else if (matrix[row][col] > elem)
                    {
                        col--;
                    }
                    else
                    {
                        row++;
                    }
                }
                return false;
            }

            public void Run()
            {
                Run1();
                Run2();
            }

            public void Run1()
            {
                int M = 10;
                int N = 5;
                var matrix = new int[M][];
                for (int i = 0; i < M; i++)
                {
                    matrix[i] = new int[N];
                    for (int j = 0; j < N; j++)
                    {
                        matrix[i][j] = 10 * i + j;
                    }
                }

                ArrayUtility.Matrix_Display(matrix);

                for (int i = 0; i < M; i++)
                {
                    for (int j = 0; j < M; j++)
                    {
                        int v = 10 * i + j;
                        Console.WriteLine(v + ": " + FindElement(matrix, v));
                    }
                }
            }

            public void Run2()
            {
                int[][] matrix = new[] {
                            new [] {15, 30,  50,  70,  73},
                            new [] {35, 40, 100, 102, 120},
                            new [] {36, 42, 105, 110, 125},
                            new [] {46, 51, 106, 111, 130},
                            new [] {48, 55, 109, 140, 150}
            };

                ArrayUtility.Matrix_Display(matrix);

                int m = matrix.Length;
                int n = matrix[0].Length;

                int count = 0;
                int littleOverTheMax = matrix[m - 1][n - 1] + 10;
                for (int i = 0; i < littleOverTheMax; i++)
                {
                    Coordinate c = FindElement2(matrix, i);
                    if (c != null)
                    {
                        Console.WriteLine(i + ": (" + c.row + ", " + c.column + ")");
                        count++;
                    }
                }
                Console.WriteLine("Found " + count + " unique elements.");
            }

            public class Coordinate : ICloneable
            {
                public int column;
                public int row;

                public Coordinate(int r, int c)
                {
                    row = r;
                    column = c;
                }

                public Object Clone()
                {
                    return new Coordinate(row, column);
                }

                public bool Inbounds(int[][] matrix)
                {
                    return row >= 0 &&
                            column >= 0 &&
                            row < matrix.Length &&
                            column < matrix[0].Length;
                }

                public bool IsBefore(Coordinate p)
                {
                    return row <= p.row && column <= p.column;
                }

                public void MoveDownRight()
                {
                    row++;
                    column++;
                }

                public void SetToAverage(Coordinate min, Coordinate max)
                {
                    row = (min.row + max.row) / 2;
                    column = (min.column + max.column) / 2;
                }
            }

            #region Solution B

            public static Coordinate FindElement2(int[][] matrix, Coordinate origin, Coordinate dest, int x)
            {
                if (!origin.Inbounds(matrix) || !dest.Inbounds(matrix))
                {
                    return null;
                }
                if (matrix[origin.row][origin.column] == x)
                {
                    return origin;
                }
                else if (!origin.IsBefore(dest))
                {
                    return null;
                }

                /* Set start to start of diagonal and end to the end of the diagonal. Since
                 * the grid may not be square, the end of the diagonal may not equal dest.
                 */
                Coordinate start = (Coordinate)origin.Clone();
                int diagDist = Math.Min(dest.row - origin.row, dest.column - origin.column);
                Coordinate end = new Coordinate(start.row + diagDist, start.column + diagDist);
                Coordinate p = new Coordinate(0, 0);

                /* Do binary search on the diagonal, looking for the first element greater than x */
                while (start.IsBefore(end))
                {
                    p.SetToAverage(start, end);
                    if (x > matrix[p.row][p.column])
                    {
                        start.row = p.row + 1;
                        start.column = p.column + 1;
                    }
                    else
                    {
                        end.row = p.row - 1;
                        end.column = p.column - 1;
                    }
                }

                /* Split the grid into quadrants. Search the bottom left and the top right. */
                return PartitionAndSearch(matrix, origin, dest, start, x);
            }

            public static Coordinate FindElement2(int[][] matrix, int x)
            {
                Coordinate origin = new Coordinate(0, 0);
                Coordinate dest = new Coordinate(matrix.Length - 1, matrix[0].Length - 1);
                return FindElement2(matrix, origin, dest, x);
            }

            public static Coordinate PartitionAndSearch(int[][] matrix, Coordinate origin, Coordinate dest, Coordinate pivot, int x)
            {
                Coordinate lowerLeftOrigin = new Coordinate(pivot.row, origin.column);
                Coordinate lowerLeftDest = new Coordinate(dest.row, pivot.column - 1);
                Coordinate upperRightOrigin = new Coordinate(origin.row, pivot.column);
                Coordinate upperRightDest = new Coordinate(pivot.row - 1, dest.column);

                Coordinate lowerLeft = FindElement2(matrix, lowerLeftOrigin, lowerLeftDest, x);
                if (lowerLeft == null)
                {
                    return FindElement2(matrix, upperRightOrigin, upperRightDest, x);
                }
                return lowerLeft;
            }

            #endregion Solution B
        }

        public class Q10_10_Rank_from_Stream : IQuestion
        {
            public static RankNode root = null;

            public static int GetRankOfNumber(int number)
            {
                return root.GetRank(number);
            }

            public static void Track(int number)
            {
                if (root == null)
                {
                    root = new RankNode(number);
                }
                else
                {
                    root.Insert(number);
                }
            }

            public void Run()
            {
                int size = 100;
                int[] list = AssortedMethods.RandomArray(size, -100, 100);
                for (int i = 0; i < list.Length; i++)
                {
                    Track(list[i]);
                }

                int[] tracker = new int[size];
                for (int i = 0; i < list.Length; i++)
                {
                    int v = list[i];
                    int rank1 = root.GetRank(list[i]);
                    tracker[rank1] = v;
                }

                for (int i = 0; i < tracker.Length - 1; i++)
                {
                    if (tracker[i] != 0 && tracker[i + 1] != 0)
                    {
                        if (tracker[i] > tracker[i + 1])
                        {
                            Console.WriteLine("ERROR at " + i);
                        }
                    }
                }

                Console.WriteLine("Array: " + AssortedMethods.ArrayToString(list));
                Console.WriteLine("Ranks: " + AssortedMethods.ArrayToString(tracker));
            }

            public class RankNode
            {
                public int data = 0;
                public RankNode left;
                public int left_size = 0;
                public RankNode right;

                public RankNode(int d)
                {
                    data = d;
                }

                public int GetRank(int d)
                {
                    if (d == data)
                    {
                        return left_size;
                    }
                    else if (d < data)
                    {
                        if (left == null)
                        {
                            return -1;
                        }
                        else
                        {
                            return left.GetRank(d);
                        }
                    }
                    else
                    {
                        int right_rank = right == null ? -1 : right.GetRank(d);
                        if (right_rank == -1)
                        {
                            return -1;
                        }
                        else
                        {
                            return left_size + 1 + right_rank;
                        }
                    }
                }

                public void Insert(int d)
                {
                    if (d <= data)
                    {
                        if (left != null)
                        {
                            left.Insert(d);
                        }
                        else
                        {
                            left = new RankNode(d);
                        }
                        left_size++;
                    }
                    else
                    {
                        if (right != null)
                        {
                            right.Insert(d);
                        }
                        else
                        {
                            right = new RankNode(d);
                        }
                    }
                }
            }
        }
    }
}