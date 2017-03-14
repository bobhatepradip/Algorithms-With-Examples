using System;
using System.Text;
using TWL_Algorithms_Samples.BitManipulation;

namespace TWL_Algorithms_Samples.Arrays.Strings
{
    internal class StringUtility
    {
        public static bool IsRotation(String s1, String s2)
        {
            var string1Length = s1.Length;

            /* check that s1 and s2 are equal length and not empty */
            if (string1Length == s2.Length && string1Length > 0)
            {
                /* concatenate s1 and s1 within new buffer */
                var s1S1 = s1 + s1;
                return IsSubstring(s1S1, s2);
            }

            return false;
        }

        public static bool IsSubstring(String big, String small)
        {
            return big.IndexOf(small) >= 0;
        }

        public void Compression_Run()
        {
            string[] testStrings = new string[] { "abbccccccde", "abbccccccdeeee" };
            foreach (var original in testStrings)
            {
                var compressed = Compression(original);
                Console.WriteLine("Original  : {0}", original);
                Console.WriteLine("Compressed: {0}", compressed);
            }
        }

        public void IsRotation_Run()
        {
            string[][] pairs =
            {
                new string[]{"apple", "pleap"},
                new string[]{"waterbottle", "erbottlewat"},
                new string[]{"camera", "macera"}
            };

            foreach (var pair in pairs)
            {
                var word1 = pair[0];
                var word2 = pair[1];
                var isRotation = IsRotation(word1, word2);
                Console.WriteLine("{0}, {1}: {2}", word1, word2, isRotation);
            }
        }

        public void Run()
        {
            //IsUniqueChars_Run();
            //IsPermutation_Run();
            //URLEncoding_Run();
            //Compression_Run();
            //new Palindrome_Permutation().Run();
            IsRotation_Run();
        }

        public string Sort(string str)
        {
            // put the characters into an array
            char[] chars = str.ToCharArray();
            ///???
            return chars.ToString();
        }

        public void URLEncoding_Run()
        {
            const string input = "abc d e f";
            string encodedURL = URLEncoding_ReplaceSpaces(input, input.Length);
            Console.WriteLine("{0} -> {1}", input, encodedURL);
        }

        public void Void()
        { }

        private string Compression(string str)
        {
            var size = CompressionCount(str);

            if (size >= str.Length)
            {
                return str;
            }

            var sb = new StringBuilder();
            var last = str[0];
            var count = 1;

            for (var i = 1; i < str.Length; i++)
            {
                if (str[i] == last)
                {
                    count++;
                }
                else
                {
                    sb.Append(last);
                    sb.Append(count);
                    last = str[i];
                    count = 1;
                }
            }
            sb.Append(last);
            sb.Append(count);

            return sb.ToString();
        }

        private int CompressionCount(string str)
        {
            if (string.IsNullOrEmpty(str))
            {
                return 0;
            }

            var last = str[0];
            var size = 0;
            var count = 0;

            for (var i = 1; i < str.Length; i++)
            {
                if (str[i] == last)
                {
                    count++;
                }
                else
                {
                    last = str[i];
                    size += 1 + string.Format("{0}", count).Length;
                    count = 1;
                }
            }

            size += 1 + string.Format("{0}", count).Length;
            Console.WriteLine($"CompressionCount for '{str}({str.Length})' is {size}");
            return size;
        }

        private void IsPermutation_Run()
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

        private void IsUniqueChars_Run()
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

        private char[] URLEncoding_ReplaceSpaces(char[] input, int length)
        {
            var spaceCount = 0;

            // count the number of spaces
            foreach (var character in input)
            {
                if (character == ' ')
                {
                    spaceCount++;
                }
            }

            // calculate new string size
            var outputIndex = length + spaceCount * 2;
            char[] output = new char[outputIndex];
            // copying the characters backwards and inserting %20
            for (var i = length - 1; i >= 0; i--)
            {
                if (input[i] == ' ')
                {
                    output[outputIndex - 1] = '0';
                    output[outputIndex - 2] = '2';
                    output[outputIndex - 3] = '%';
                    outputIndex -= 3;
                }
                else
                {
                    output[outputIndex - 1] = input[i];
                    outputIndex--;
                }
            }

            return output;
        }

        private string URLEncoding_ReplaceSpaces(string input, int length)
        {
            char[] output = URLEncoding_ReplaceSpaces(input.ToCharArray(), length);
            return new string(output);
        }

        public class Palindrome_Permutation : IQuestion
        {
            public static int[] BuildCharFrequencyTable(String phrase)
            {
                int[] table = new int[(int)char.GetNumericValue('z') - (int)char.GetNumericValue('a') + 1];
                foreach (char c in phrase.ToCharArray())
                {
                    int x = CharUtility.GetCharNumber(c);
                    if (x != -1)
                    {
                        table[x]++;
                    }
                }
                return table;
            }

            #region Solution 1

            public static bool CheckMaxOneOdd(int[] table)
            {
                bool foundOdd = false;
                foreach (int count in table)
                {
                    if (count % 2 == 1)
                    {
                        if (foundOdd)
                        {
                            return false;
                        }
                        foundOdd = true;
                    }
                }
                return true;
            }

            public static bool IsPermutationOfPalindrome(String phrase)
            {
                int[] table = BuildCharFrequencyTable(phrase);
                return CheckMaxOneOdd(table);
            }

            #endregion Solution 1

            #region Solution 2

            public static bool IsPermutationOfPalindrome2(String phrase)
            {
                int countOdd = 0;
                int[] table = new int[(int)char.GetNumericValue('z') - (int)char.GetNumericValue('a') + 1];
                foreach (char c in phrase.ToCharArray())
                {
                    int x = CharUtility.GetCharNumber(c);
                    if (x != -1)
                    {
                        table[x]++;

                        if (table[x] % 2 == 1)
                        {
                            countOdd++;
                        }
                        else
                        {
                            countOdd--;
                        }
                    }
                }
                return countOdd <= 1;
            }

            #endregion Solution 2

            #region Solution 3

            /* Toggle the ith bit in the integer. */

            public static bool IsPermutationOfPalindrome3(String phrase)
            {
                int bitVector = BitVector.CreateBitVector(phrase);
                return bitVector == 0 || BitVector.CheckExactlyOneBitSet(bitVector);
            }

            #endregion Solution 3

            public void Run()
            {
                String[] strings = {
                            //"Rats live on no evil star",
                            //"A man, a plan, a canal, panama",
                            //"Lleve",
                            //"Tacotac",
                            //"Tacootac",
                            //"Tacootacz",
                            "12asda"
                };

                foreach (String s in strings)
                {
                    bool a = true;// IsPermutationOfPalindrome(s);
                    bool b = true; //IsPermutationOfPalindrome2(s);
                    bool c = IsPermutationOfPalindrome3(s);
                    Console.WriteLine($"'{s}' IsPermutationOfPalindrome:{a} IsPermutationOfPalindrome2:{b} IsPermutationOfPalindrome3:{c}\n");
                }
            }
        }
    }
}