using System;
using TWL_Algorithms_Samples;
using TWL_Algorithms_Samples.Arrays;
using TWL_Algorithms_Samples.Arrays.Strings;
using TWL_Algorithms_Samples.BitManipulation;
using TWL_Algorithms_Samples.LinkedList;
using TWL_Algorithms_Samples.Queue;
using TWL_Algorithms_Samples.SortingAndSearching;
using TWL_Algorithms_Samples.Stack;
using TWL_Algorithms_Samples.StackAndQueue;
using TWL_Algorithms_Samples.Tree;
using TWL_Algorithms_Samples.TreeAndGraph;

internal class Program
{
    public static void Main(string[] args)
    {
        Console.WriteLine("======================================================================");
        UtilityTester();
        //QuestionsAndSolutionsByChapters();
        //QuestionsAndSolutionsByNumbers();
        Console.WriteLine("======================================================================");
        Console.WriteLine("Press any key to quit");
        Console.ReadKey();
    }

    public static void QuestionsAndSolutionsByChapters()
    {
        var chapters = new[]
            {
                //// Intro
                //new IQuestion[] { new CompareBinaryToHex(), new SwapMinMax(), },

                //// Chapters
                new IQuestion[] {
                    new Array_Q1_01_Is_String_Has_Unique_Chars(),
                    //,  new Q1_02_Check_Permutation(), new Q1_03_URLify(), new Q1_04_Palindrome_Permutation(), new Q1_05_One_Away_A(), new Q1_06_String_Compression(), new Q1_07_Rotate_Matrix(), new Q1_08_Zero_Matrix(), new Q1_09_String_Rotation(),
                },

                //new IQuestion[] { new Q2_01_Remove_Dups(), new Q2_02_Return_Kth_To_Last(), new Q2_03_Delete_Middle_Node(), new Q2_04_Partition(), new Q2_05_Sum_Lists(), new Q2_06_Palindrome(), new Q2_07_Intersection(), new Q2_08_Loop_Detection() },

                //new IQuestion[] { new Q5_01_Insertion(), new Q5_02_Binary_to_String(), new Q5_04_Next_Number(), new Q5_06_Conversion(), new Q5_06_Conversion(), new Q5_07_Pairwise_Swap(), new Q5_08_Draw_Line() },

                //new IQuestion[] { new Q10_01_Sorted_Merge(), new Q10_02_Group_Anagrams(), new Q10_03_Search_in_Rotated_Array(), new Q10_05_Sparse_Search(), new Q10_08_Find_Duplicates(), new Q10_09_Sorted_Matrix_Search(), new Q10_10_Rank_from_Stream(), new Q10_11_Peaks_and_Valleys() },
            };

        foreach (var chapter in chapters)
        {
            foreach (IQuestion q in chapter)
            {
                Console.WriteLine(string.Format("{0}{1}", Environment.NewLine, Environment.NewLine));
                AssortedMethods.PrintType(q);
                q.Run();
            }

            Console.WriteLine();
            Console.WriteLine("Press Enter to continue..");
            //Console.ReadLine();
        }
    }

    public static void QuestionsAndSolutionsByNumbers()
    {
        var dummy = new IQuestion[] {
                    new Array_Q1_00(),
                    new LinkedList_Q2_00(),
                    new StackAndQueue_Q3_00(),
                    new TreeAndGraph_Q4_00(),
                    new BitManipulation_Q5_00(),
                    new SortingAndSearching_Q10_00(),
                };
        var questionsSetByNumbers = new[]
            {
                //new IQuestion[] {
                //    new Array_Q1_01_Is_String_Has_Unique_Chars(),
                //    new LinkedList_Q2_01_Remove_Duplicates(),
                //    new StackAndQueue_Q3_01(),
                //    new TreeAndGraph_Q1_01_Route_Beetween_Nodes(),
                //    new BitManipulation_Q5_01(),
                //    new SortingAndSearching_Q10_01(),
                //},
                new IQuestion[] {
                    //new Array_Q1_02_Check_For_Permutations(),
                    //new LinkedList_Q2_02_Return_Kth_To_Last(),
                    //new StackAndQueue_Q3_02_StackWithMinFunction(),
                    //new TreeAndGraph_Q4_02_CreateMinimalTree(),
                    //new BitManipulation_Q5_02_PrintBinaryToString(),
                    //new SortingAndSearching_Q10_02_Group_Anagrams(),
                },
                // new IQuestion[] {
                //    new Array_Q1_03(),
                //    new LinkedList_Q2_03(),
                //    new StackAndQueue_Q3_03(),
                //    new TreeAndGraph_Q4_03(),
                //    new BitManipulation_Q5_03(),
                //    new SortingAndSearching_Q10_03(),
                //},
                // new IQuestion[] {
                //    new Array_Q1_04(),
                //    new LinkedList_Q2_04(),
                //    new StackAndQueue_Q3_04(),
                //    new TreeAndGraph_Q4_04(),
                //    new BitManipulation_Q5_04(),
                //    new SortingAndSearching_Q10_04(),
                //},
                // new IQuestion[] {
                //    new Array_Q1_05(),
                //    new LinkedList_Q2_05(),
                //    new StackAndQueue_Q3_05(),
                //    new TreeAndGraph_Q4_05(),
                //    new BitManipulation_Q5_05(),
                //    new SortingAndSearching_Q10_05(),
                //},
                // new IQuestion[] {
                //    new Array_Q1_06(),
                //    new LinkedList_Q2_06(),
                //    new StackAndQueue_Q3_06(),
                //    new TreeAndGraph_Q4_06(),
                //    new BitManipulation_Q5_06(),
                //    new SortingAndSearching_Q10_06(),
                //},
                // new IQuestion[] {
                //    new Array_Q1_07(),
                //    new LinkedList_Q2_07(),
                //    new TreeAndGraph_Q4_07(),
                //    new BitManipulation_Q5_07(),
                //    new SortingAndSearching_Q10_07(),
                //},
                // new IQuestion[] {
                //    new Array_Q1_08(),
                //    new LinkedList_Q2_08(),
                //    new TreeAndGraph_Q4_08(),
                //    new BitManipulation_Q5_08(),
                //    new SortingAndSearching_Q10_08(),
                //},
                // new IQuestion[] {
                //    new Array_Q1_09(),
                //    new TreeAndGraph_Q4_09(),
                //    new SortingAndSearching_Q10_09(),
                //},
                // new IQuestion[] {
                //    new TreeAndGraph_Q4_10(),
                //    new SortingAndSearching_Q10_10(),
                //},
                // new IQuestion[] {
                //    new TreeAndGraph_Q4_11(),
                //    new SortingAndSearching_Q10_11(),
                //},
                //  new IQuestion[] {
                //    new TreeAndGraph_Q4_12(),
                //},
                };

        foreach (var questionsSet in questionsSetByNumbers)
        {
            foreach (IQuestion q in questionsSet)
            {
                Console.WriteLine(string.Format("{0}{1}", Environment.NewLine, Environment.NewLine));
                AssortedMethods.PrintType(q);
                q.Run();
            }

            Console.WriteLine();
            Console.WriteLine("Press Enter to continue..");
            //Console.ReadLine();
        }
    }

    public static void UtilityTester()
    {
        new ArrayUtility().Run();
        new LinkedListUtility().Run();
        new StackUtility().Run();
        new QueueUtility().Run();
        new StringUtility().Run();
        //new BitManipulationUtility().Run();
        new Sorting().Run();
        new SortingAndSearchingUtility().Run();
        new TreeUtility().Run();
    }
}