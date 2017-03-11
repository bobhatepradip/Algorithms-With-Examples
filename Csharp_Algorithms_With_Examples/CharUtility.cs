namespace TWL_Algorithms_Samples
{
    internal static class CharUtility
    {
        public static int GetCharNumber(char c)
        {
            var a = (int)char.GetNumericValue('a');
            var z = (int)char.GetNumericValue('z');

            var val = (int)char.GetNumericValue(c);
            if (a <= val && val <= z)
            {
                return val - a;
            }
            return -1;
        }
    }
}