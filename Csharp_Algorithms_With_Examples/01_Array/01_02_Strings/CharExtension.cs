﻿namespace TWL_Algorithms_Samples.Char
{
    internal static class CharExtension
    {
        public static int GetCharNumber(this char charecter)
        {
            var a = (int)char.GetNumericValue('a');
            var z = (int)char.GetNumericValue('z');

            var val = (int)char.GetNumericValue(charecter);
            if (a <= val && val <= z)
            {
                return val - a;
            }
            return -1;
        }

        public static bool isLetterOrDigit(this char c)
        {
            return (c >= 'a' && c <= 'z') ||
                   (c >= 'A' && c <= 'Z') ||
                   (c >= '0' && c <= '9');
        }

        public static char ToLower(this char ch)
        {
            return ch >= 'A' && ch <= 'Z' ? (char)(ch + 'a' - 'A') : ch;
        }

        public static bool IsUpperCase(this char ch)
        {
            return (ch >= 'A' && ch <= 'Z');
        }

        public static bool IsLowerCase(this char ch)
        {
            return (ch >= 'A' && ch <= 'Z');
        }

        public static char ToUpperCase(this char ch)
        {
            //32 = (int)char.GetNumericValue('a') - (int)char.GetNumericValue('A') == (97-65)
            return IsLowerCase(ch) ? (char)((int)char.GetNumericValue(ch) - 32) : ch;
        }

        public static char ToLowerCase(this char ch)
        {
            //32 = (int)char.GetNumericValue('a') - (int)char.GetNumericValue('A') == (97-65)
            return IsUpperCase(ch) ? (char)((int)char.GetNumericValue(ch) + 32) : ch;
        }
    }
}