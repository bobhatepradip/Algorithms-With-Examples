using System;

namespace TWL_Algorithms_Samples.Arrays.Strings
{
    internal class StringUtility
    {
        public void Run()
        {
            //IsUniqueChars_Test();
            IsPermutation_Test();
        }

        public string Sort(string str)
        {
            // put the characters into an array
            char[] chars = str.ToCharArray();
            ///???
            return chars.ToString();
        }

        public void Void()
        { }

        private void IsPermutation_Test()
        {
            string[][] pairs =             {
                new string[]{"apple", "papel"},
                new string[]{"carrot", "tarroc"},
                new string[]{"hello", "llloh"},
                new string[]{ "lol", "lol" },
               new string[]{ "lol", "LOL" },
               new string[]{ "abc", "def" },
               new string[]{ "xyz", "abcd" }
            };

            foreach (var pair in pairs)
            {
                var word1 = pair[0];
                var word2 = pair[1];
                //var result1 = IsPermutation_UsingSort(word1, word2);
                var result2 = IsPermutation_UsingIdenticalCharecterCount(word1, word2);
                //Console.WriteLine("{0}, {1}: {2} / {3}", word1, word2, result1, result2);
            }
        }

        /// <summary>
        /// Requires additional memory to store identical counts
        /// </summary>
        /// <param name="original"></param>
        /// <param name="valueToTest"></param>
        /// <returns></returns>
        private bool IsPermutation_UsingIdenticalCharecterCount(string original, string valueToTest)
        {
            bool isPermutaion = true;
            if (original.Length != valueToTest.Length)
            {
                Console.WriteLine($"Length of '{original}' does not match with {valueToTest}");
                return false;
            }

            var letters = new int[256];
            var originalAsArray = original.ToCharArray();
            originalAsArray.Print($"'{original}'- original.ToCharArray():");

            foreach (var character in originalAsArray)
            {
                letters[character]++;
                //Console.WriteLine($"character -'{character}'; letters[character]-'{letters[character]}'");
            }

            letters.Print($"'{original}'-");

            var valueToTestAsArray = valueToTest.ToCharArray();
            valueToTestAsArray.Print($"'{valueToTest}'- valueToTest.ToCharArray():");
            foreach (var character in valueToTestAsArray)
            {
                letters[character]--;

                //why it is -1 vs 0 condition?
                if (letters[character] < 0)
                {
                    Console.WriteLine($"character== {character}, letters[character] = {letters[character]} : (letters[character] < 0 ) = {letters[character] < 0}");
                    isPermutaion = false;
                    break;
                }
            }

            Console.WriteLine($" Is '{original}' and {valueToTest} are permutaion-{original.Equals(valueToTest)}");
            Console.WriteLine("===================================================================================");

            return isPermutaion;
        }

        /// <summary>
        /// Requires no additional memory if used proper sorting algorithms (-which does not require additional memory)
        /// </summary>
        /// <param name="original"></param>
        /// <param name="valueToTest"></param>
        /// <returns></returns>
        private bool IsPermutation_UsingSort(string original, string valueToTest)
        {
            if (original.Length != valueToTest.Length)
            {
                Console.WriteLine($"Length of '{original}' does not match with {valueToTest}");
                return false;
            }

            var originalAsArray = original.ToCharArray();

            // Array.Sort Is Default Implementaion.
            // It should be implementted using quick sort see sorting.cs for quick sort exampled
            Array.Sort(originalAsArray);
            Console.WriteLine($"'{original}' after sort {new string(originalAsArray)}");
            original = new string(originalAsArray);

            var valueToTestAsArray = valueToTest.ToCharArray();

            // Array.Sort Is Default Implementaion.
            // It should be implementted using quick sort see sorting.cs for quick sort exampled
            Array.Sort(valueToTestAsArray);
            Console.WriteLine($"'{valueToTest}' after sort {new string(valueToTestAsArray)}");
            valueToTest = new string(valueToTestAsArray);

            Console.WriteLine($" Is '{original}' and {valueToTest} are permutaion-{original.Equals(valueToTest)}");
            Console.WriteLine("===================================================================================");
            return original.Equals(valueToTest);
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

        private void IsUniqueChars_Test()
        {
            foreach (var word in Constants.cArrayIsUniqueCharecters)
            {
                Console.WriteLine(word + ": "
                    + IsUniqueChars(word) + " "
                    + IsUniqueChars_UsingExtraCharecterArray(word));
                Console.WriteLine("--------------------------------------------------------------");
            }
        }

        private bool IsUniqueChars_UsingExtraCharecterArray(String str)
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