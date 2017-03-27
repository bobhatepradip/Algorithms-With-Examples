using System;
using TWL_Algorithms_Samples;
using TWL_Algorithms_Samples.Arrays;
using TWL_Algorithms_Samples.Arrays.Strings;
using TWL_Algorithms_Samples.BitManipulation;
using TWL_Algorithms_Samples.LinkedList;
using TWL_Algorithms_Samples.Queue;
using TWL_Algorithms_Samples.SortingAndSearching;
using TWL_Algorithms_Samples.Stack;
using TWL_Algorithms_Samples.Tree;

internal class Program
{
    private static void Main(string[] args)
    {
        Console.WriteLine("======================================================================");
        //UtilityTester();
        //QuestionsAndSolutionsByChapters();
        QuestionsAndSolutionsByNumbers();
        Console.WriteLine("======================================================================");
        Console.WriteLine("Press any key to quit");
        Console.ReadKey();
    }

    private static void UtilityTester()
    {
        new ArrayUtility().Run();
        new LinkedListUtility().Run();
        new StackUtility().Run();
        new QueueUtility().Run();
        new StringUtility().Run();
        new BitManipulationUtility().Run();
        new Sorting().Run();
        new SortingAndSearchingUtility().Run();
        new TreeUtility().Run();
    }

    private static void QuestionsAndSolutionsByChapters()
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

        Console.WriteLine(string.Format("{0}{1}", Environment.NewLine, Environment.NewLine));
        Console.WriteLine("Press [Enter] to quit");
        Console.ReadLine();
    }

    private static void QuestionsAndSolutionsByNumbers()
    {
        var questionsSetByNumbers = new[]
            {
                //// Chapters
                new IQuestion[] {
                    new Array_Q1_01_Is_String_Has_Unique_Chars(),
                },
                //new IQuestion[] { new Q2_01_Remove_Dups(), new Q2_02_Return_Kth_To_Last(), new Q2_03_Delete_Middle_Node(), new Q2_04_Partition(), new Q2_05_Sum_Lists(), new Q2_06_Palindrome(), new Q2_07_Intersection(), new Q2_08_Loop_Detection() },
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

        Console.WriteLine(string.Format("{0}{1}", Environment.NewLine, Environment.NewLine));
        Console.WriteLine("Press [Enter] to quit");
        Console.ReadLine();
    }
}