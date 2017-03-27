using TWL_Algorithms_Samples.Arrays.Strings;

namespace TWL_Algorithms_Samples.Arrays
{
    public class ArrayQuestions : IQuestion
    {
        public void Run()
        {
            new Array_Q1_01_Is_String_Has_Unique_Chars().Run();
        }
    }

    public class Array_Q1_01_Is_String_Has_Unique_Chars : IQuestion
    {
        public void Run()
        {
            StringUtility.IsUniqueChars_Run();
        }
    }
}