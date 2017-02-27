using System;

namespace TWL_Algorithms_Samples.Arrays.Strings
{
    internal class Is_Unique
    {
        public void Run()
        {
            string[] words = { "abcde", "hello", "lol", "apple", "kite", "padle" };

            foreach (var word in words)
            {
                Console.WriteLine(word + ": "
                    + IsUniqueChars(word) + " "
                    + IsUniqueChars2(word));
                Console.WriteLine("--------------------------------------------------------------");
            }
        }

        private bool IsUniqueChars(string str)
        {
            Console.WriteLine("IsUniqueChars: str=" + str);
            if (str.Length > 256)
            {
                return false;
            }
            var checker = 0;
            for (var i = 0; i < str.Length; i++)
            {
                var val = str[i] - 'a';
                Console.WriteLine("IsUniqueChars: str[i]=" + str[i]);
                Console.WriteLine("IsUniqueChars: val=" + val);
                Console.WriteLine("IsUniqueChars: checker=" + checker);
                Console.WriteLine("IsUniqueChars: (1 << val)=" + (1 << val));
                Console.WriteLine("IsUniqueChars: (checker & (1 << val)) > 0=" + ((checker & (1 << val)) > 0));
                if ((checker & (1 << val)) > 0)
                {
                    return false;
                }
                checker |= (1 << val);
                Console.WriteLine("IsUniqueChars: checker |= (1 << val):" + checker);
            }
            return true;
        }

        private bool IsUniqueChars2(String str)
        {
            Console.WriteLine("IsUniqueChars: str=" + str);
            if (str.Length > 256)
            {
                return false;
            }
            //charecter tracer checks if charecter processed before
            var charSet = new bool[256];
            for (var i = 0; i < str.Length; i++)
            {
                int val = str[i];
                Console.WriteLine("IsUniqueChars: str[i]=" + str[i]);
                Console.WriteLine("IsUniqueChars: val=" + val);
                Console.WriteLine("IsUniqueChars: charSet[val]=" + charSet[val]);
                //Check if charecter already exist in charSet if yes then return false
                if (charSet[val])
                {
                    return false;
                }
                charSet[val] = true;
            }
            return true;
        }
    }
}