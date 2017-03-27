using System;
using System.Collections;
using System.Text;
using TWL_Algorithms_Samples.BitManipulation;
using TWL_Algorithms_Samples.Char;

namespace TWL_Algorithms_Samples.Arrays.Strings
{
    public class StringUtility
    {
        public string[] OneDTestStrings = new string[] { "abcabcbb", "bbbbb", "pwwkew" };

        public string[][] TwoDTestStrings = new string[][]  {
                new string[]{"apple", "pleap"},
                new string[]{"waterbottle", "erbottlewat"},
                new string[]{"camera", "macera"},
            };

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

        public static void IsUniqueChars_Run()
        {
            foreach (var word in Constants.cArrayIsUniqueCharecters)
            {
                Console.WriteLine(word + ": "
                    + IsUniqueChars_UsingBitTracker(word) + " "
                    + IsUniqueChars_UsingExtraCharecterArray(word)
                   );
                Console.WriteLine("--------------------------------------------------------------");
            }
        }

        public void Compression_Run()
        {
        }

        public void IsAnagram_Run()
        {
            string[][] pairs =
            {
                new string[]{"anagram", "nagrama"},
                new string[]{"anagram", "aaaaaaa"},
                new string[]{ "anagram", "anag"}
            };

            foreach (var pair in pairs)
            {
                var word1 = pair[0];
                var word2 = pair[1];
                var isRotation = IsRotation(word1, word2);
                Console.WriteLine("IsAnagram_UsingArray({0}, {1}): {2}", word1, word2, IsAnagram_UsingArray(word1, word2));

                Console.WriteLine("IsAnagram_UsingHashtable({0}, {1}): {2}", word1, word2, IsAnagram_UsingHashtable(word1, word2));
            }
        }

        public bool IsAnagram_UsingArray(string s, string t)
        {
            if (s.Length != t.Length) return false;
            int n = s.Length;
            int[] counts = new int[26];
            for (int i = 0; i < n; i++)
            {
                counts[s[i] - 'a']++;
                counts[t[i] - 'a']--;
            }
            for (int i = 0; i < 26; i++)
                if (counts[i] != 0) return false;
            return true;
        }

        public bool IsAnagram_UsingHashtable(string s, string t)
        {
            if (s.Length != t.Length) return false;
            int n = s.Length;
            Hashtable hashtable = new Hashtable();
            for (int i = 0; i < n; i++)
            {
                if (hashtable.ContainsKey(s[i]))
                {
                    hashtable[s[i]] = (int)hashtable[s[i]] + 1;
                }
                else
                {
                    hashtable.Add(s[i], 1);
                }

                if (hashtable.ContainsKey(t[i]))
                {
                    hashtable[t[i]] = (int)hashtable[t[i]] - 1;
                }
                else
                {
                    hashtable.Add(t[i], -1);
                }
            }
            foreach (var hashValue in hashtable.Values)
                if ((int)hashValue != 0) return false;
            return true;
        }

        /// <summary>
        /// considering only alphanumeric characters and ignoring cases
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public bool isPalindrome_ConsiderOnlyAlphanumericCharectes(String s)
        {
            if (string.IsNullOrEmpty(s))
            {
                return true;
            }
            int head = 0, tail = s.Length - 1;
            char cHead, cTail;
            while (head <= tail)
            {
                cHead = s.ToCharArray()[head];
                cTail = s.ToCharArray()[tail];
                if (!cHead.isLetterOrDigit())
                {
                    head++;
                }
                else if (!cTail.isLetterOrDigit())
                {
                    tail--;
                }
                else
                {
                    if (cHead.ToLower() != cTail.ToLower())
                    {
                        return false;
                    }
                    head++;
                    tail--;
                }
            }

            return true;
        }

        public void isPalindrome_ConsiderOnlyAlphanumericCharectes_Run()
        {
            string[] testStrings = new string[] { "A man, a plan, a canal: Panama", "race a car" };
            foreach (var testStr in testStrings)
            {
                Console.WriteLine($"{isPalindrome_ConsiderOnlyAlphanumericCharectes(testStr)} string:'{testStr}'");
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

        public int LengthOfLongestSubstring(String s)
        {
            if (s.Length == 0) return 0;
            Hashtable map = new Hashtable();
            int max = 0;
            for (int i = 0, j = 0; i < s.Length; ++i)
            {
                if (map.ContainsKey(s[i]))
                {
                    j = Math.Max(j, i + 1);//(int)map[s[i]]
                }
                else
                {
                    map.Add(s[i], i);
                }
                max = Math.Max(max, i - j + 1);
            }

            // Console.WriteLine($"{string.Join(", ", map.Keys.Cast<object>().Select(x => x.ToString()).ToArray())}");
            return max;
        }

        public void LengthOfLongestSubstring_Run()
        {
            foreach (string str in OneDTestStrings)
            {
                Console.WriteLine($"Input String='{str}' LengthOfLongestSubstring_Run={LengthOfLongestSubstring(str)}");
            }
        }

        public void PrintFrequencyOfCharecters_Run()
        {
            string[] testStrings = { "xyz", "test", "aaabb" };
            // , "◣⚽◢⚡◣⚾⚡◢" -should be used only with Hash table implementation

            foreach (var testString in testStrings)
            {
                //   PrintFrequency_UsingHashtable(testString);
                PrintFrequencyOfCharecters_UsingArray(testString);
            }
        }

        public string Reverse(string str)
        {
            char[] chars = str.ToCharArray();
            int startIndex = 0;
            int endIndex = chars.Length - 1;
            while (startIndex < endIndex)
            {
                chars.Swap(startIndex, endIndex);
                startIndex++;
                endIndex--;
            }
            return String.Concat(chars);
        }

        public void Reverse_Run()
        {
            string revereStringTest = "I am doing good";
            Console.WriteLine($"revereStringTest='{revereStringTest}'");
            Console.WriteLine($"Reversed String='{Reverse(revereStringTest)}'");
            Console.WriteLine($"Reversed Words in String='{ReverseWords(revereStringTest)}'");
        }

        public string ReverseWords(string str)
        {
            string reversedString = Reverse(str);
            StringBuilder reversedWordsString = new StringBuilder();
            foreach (string word in reversedString.Split(' '))
            {
                reversedWordsString.AppendFormat("{0} ", Reverse(word));
            }
            return reversedWordsString.ToString();
        }

        public void Run()
        {
            //IsUniqueChars_Run();
            //IsPermutation_Run();
            //URLEncoding_Run();
            //Compression_Run();
            //new Palindrome_Permutation().Run();
            //IsRotation_Run();
            //isPalindrome_ConsiderOnlyAlphanumericCharectes_Run();
            //Reverse_Run();
            //IsAnagram_Run();
            //PrintFrequency_Run();
            //LengthOfLongestSubstring_Run();
        }

        public string Sort_TEMP(string str)
        {
            // put the characters into an array
            char[] chars = str.ToCharArray();
            ///???
            return chars.ToString();
        }

        public int strStr(String haystack, String needle)
        {
            for (int i = 0; ; i++)
            {
                for (int j = 0; ; j++)
                {
                    if (j == needle.Length) return i;
                    if (i + j == haystack.Length) return -1;
                    if (needle[j] != haystack[i + j]) break;
                }
            }
        }

        public void URLEncoding_Run()
        {
            const string input = "abc d e f";
            string encodedURL = URLEncoding_ReplaceSpaces(input, input.Length);
            Console.WriteLine("{0} -> {1}", input, encodedURL);
        }

        public void Void()
        { }

        /// <summary>
        /// Where bit traker 'checker' will store/set bit for each charecter
        /// and when upon 1&1 it indiacate that charecter already exists.
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        private static bool IsUniqueChars_UsingBitTracker(string str)
        {
            string prefix = "IsUniqueChars_UsingBitTracker: ";
            Console.WriteLine($"{prefix} str={str}");
            if (str.Length > 256)
            {
                return false;
            }
            var checker = 0;
            for (var i = 0; i < str.Length; i++)
            {
                var val = str[i] - 'a';
                Console.WriteLine($"{prefix} str[i]=" + str[i]);
                //Console.WriteLine($"{prefix}  val= (str[i] - 'a') = {str[i] - 'a'} =" + val);
                Console.WriteLine($"{prefix}  checker= {checker} [{AssortedMethods.ToFullBinarystring(checker)}]");
                Console.WriteLine($"{prefix}  (1 << val)=(1 [{AssortedMethods.ToFullBinarystring(1)}] << {val}) = {(1 << val)} [{AssortedMethods.ToFullBinarystring((1 << val))}]");
                Console.WriteLine($"{prefix}  (checker & (1 << val)) > 0 = [{AssortedMethods.ToFullBinarystring(checker)}] & [{AssortedMethods.ToFullBinarystring((1 << val))}] = [{AssortedMethods.ToFullBinarystring((checker & (1 << val)))}] > 0 = " + ((checker & (1 << val)) > 0));
                if ((checker & (1 << val)) > 0)
                {
                    Console.WriteLine($"{prefix} Return False");
                    return false;
                }
                Console.WriteLine($"{prefix}  checker |= (1 << val) =  [{AssortedMethods.ToFullBinarystring(checker | (1 << val))}]" + (checker | (1 << val)));
                checker |= (1 << val);
            }
            return true;
        }

        private static bool IsUniqueChars_UsingExtraCharecterArray(String str)
        {
            string prefix = "IsUniqueChars_UsingExtraCharecterArray: ";

            Console.WriteLine($"{prefix} str={str}");
            if (str.Length > 256)
            {
                return false;
            }
            //charecter tracer checks if charecter processed before
            var charSet = new bool[256];
            for (var i = 0; i < str.Length; i++)
            {
                int val = str[i];
                Console.WriteLine($"{prefix} str[i]=" + str[i]);
                Console.WriteLine($"{prefix} val=" + val);
                Console.WriteLine($"{prefix} charSet[val]=" + charSet[val]);
                //Check if charecter already exist in charSet if yes then return false
                if (charSet[val])
                {
                    return false;
                }
                charSet[val] = true;
            }
            return true;
        }

        private static void PrintFrequencyOfCharecters_UsingArray(string testString)
        {
            Console.WriteLine($"PrintFrequency_UsingArray('{testString}'):");

            char[] str = testString.ToCharArray();

            int[] freq = new int[128];
            for (int i = 0; i < str.Length; i++)
            {
                freq[str[i] - 'a']++;
            }
            for (int i = 0; i < 128; i++)
            {
                if (freq[i] > 0)
                {
                    Console.WriteLine("PrintFrequency_UsingArray:[" + (char)((char)i + 'a') + "] = " + freq[i]);
                }
            }
        }

        //        int atoi(const char* str) {
        //    int sign = 1, base = 0, i = 0;
        //    while (str[i] == ' ') { i++; }
        //    if (str[i] == '-' || str[i] == '+') {
        //        sign = 1 - 2 * (str[i++] == '-');
        //    }
        //    while (str[i] >= '0' && str[i] <= '9') {
        //        if (base >  INT_MAX / 10 || (base == INT_MAX / 10 && str[i] - '0' > 7)) {
        //            if (sign == 1) return INT_MAX;
        //            else return INT_MIN;
        //        }
        //        base  = 10 * base + (str[i++] - '0');
        //    }
        //    return base * sign;
        //}
        private static void PrintFrequencyOfCharecters_UsingHashtable(string testString)
        {
            Console.WriteLine($"PrintFrequency_UsingHashtable('{testString}'):");

            char[] str = testString.ToCharArray();

            Hashtable freq = new Hashtable();
            for (int i = 0; i < str.Length; i++)
            {
                if (freq.ContainsKey(str[i]))
                {
                    freq[str[i]] = (int)freq[str[i]] + 1;
                }
                else
                {
                    freq.Add(str[i], 1);
                }
            }
            foreach (DictionaryEntry dectionaryEntry in freq)
            {
                Console.WriteLine("PrintFrequency_UsingHashtable: [" + dectionaryEntry.Key + "] = " + dectionaryEntry.Value);
            }
        }

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
                    int x = CharExtension.GetCharNumber(c);
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
                    int x = CharExtension.GetCharNumber(c);
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