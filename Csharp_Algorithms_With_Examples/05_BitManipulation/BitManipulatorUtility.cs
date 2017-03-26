using System;
using System.Text;
using TWL_Algorithms_Samples.Arrays;

namespace TWL_Algorithms_Samples.BitManipulation
{
    public class BitManipulationUtility
    {
        public void Run()
        {
            //SingleNumber_Run();
            BitOperation_Run();
        }
        public void BitOperation_Run()
        {
            foreach (var i in new[] { 0, 1, 2 })
            {
                foreach (var testOriginalValue in new[] { 1, 2, 3, 4, 5, 6 })
                {
                    Console.WriteLine($"GetBit('{testOriginalValue}', '{i}th'): {HasIthBit(testOriginalValue, i)} ");
                    var testOldValue = testOriginalValue;
                    var testNewValue = SetBit(testOldValue, i);
                    Console.WriteLine($"SetBit('{testOldValue}', '{i}th'): {testNewValue} ");
                    Console.WriteLine($"GetBit('{testNewValue}', '{i}th'): {HasIthBit(testNewValue, i)} ");

                    testOldValue = testNewValue;
                    testNewValue = ClearBit(testOriginalValue, i);
                    Console.WriteLine($"ClearBit('{testOldValue}', '{i}th'): {testNewValue} ");
                    Console.WriteLine($"GetBit('{testNewValue}', '{i}th'): {HasIthBit(testNewValue, i)} ");

                    testNewValue = ClearBitsMSBthroughtI(testOriginalValue, i);
                    Console.WriteLine($"ClearBitsMSBthroughtI('{testOldValue}', '{i}th'): {testNewValue} ");
                    Console.WriteLine($"GetBit('{testNewValue}', '{i}th'): {HasIthBit(testNewValue, i)} ");

                    testNewValue = ClearBitIthrought0(testOriginalValue, i);
                    Console.WriteLine($"ClearBitIthrought0('{testOldValue}', '{i}th'): {testNewValue} ");
                    Console.WriteLine($"GetBit('{testNewValue}', '{i}th'): {HasIthBit(testNewValue, i)} ");
                    Console.WriteLine("-------------------------------=-------------------");
                }
                Console.WriteLine("***********************************************************");
                Console.WriteLine($"UpdateBit(-1, 0, false);: {UpdateBit(-1, 0, false)} ");
                Console.WriteLine("***********************************************************");
                Console.WriteLine($"UpdateBit(-2, 0, true);: {UpdateBit(-2, 0, true)} ");
                Console.WriteLine("***********************************************************");
            }
        }
        public bool HasIthBit(int number, int i)
        {
            return ((number & (1 << i)) != 0);
        }

        public bool GetBit(int number, int i)
        {
            return ((number & (1 << i)) != 0);
        }

        public int ClearBit(int number, int i)
        {
            int mask = ~(1 << i);
            Console.WriteLine($"ClearBit:(number({number})={AssortedMethods.ToFullBinarystring(number, 4)}) " +
                $"& mask({mask})={AssortedMethods.ToFullBinarystring(mask, 4)})={(number & mask)}         " +
                $"mask= ~(1 << {i})=~[{AssortedMethods.ToFullBinarystring(1 << i, 4)}] =[{AssortedMethods.ToFullBinarystring(~(1 << i), 4)}]={mask}");
            return (number & mask);
        }

        public int UpdateBit(int number, int i, bool bitValue)
        {
            int value = bitValue ? 1 : 0;
            int mask = ~(1 << i);
            Console.WriteLine($"ClearBit:(number({number})={AssortedMethods.ToFullBinarystring(number, 4)}) " +
                $"& mask({mask})={AssortedMethods.ToFullBinarystring(mask, 4)})={(number & mask)}         " +
                $"mask= ~(1 << {i})=~[{AssortedMethods.ToFullBinarystring(1 << i, 4)}] =[{AssortedMethods.ToFullBinarystring(~(1 << i), 4)}]={mask}");

            Console.WriteLine($"UpdateBit: ClearBit(number, i)[{AssortedMethods.ToFullBinarystring(ClearBit(number, i), 4)}] | (value[[{AssortedMethods.ToFullBinarystring(value, 4)}]] << 1) = [{AssortedMethods.ToFullBinarystring(value << 1, 4)}]");
            //return (ClearBit(number, i) | (value << 1));
            return (number & mask) | (value << 1);
        }

        public int ClearBitsMSBthroughtI(int number, int i)
        {
            int mask = (1 << i) - 1;
            Console.WriteLine($"ClearBitsMSBthroughtI:(number({number})={AssortedMethods.ToFullBinarystring(number, 4)}) " +
                $"& mask({mask})={AssortedMethods.ToFullBinarystring(mask, 4)})={(number & mask)}          " +
                $"mask= ((1 << i) - 1)=(1 << i) [{AssortedMethods.ToFullBinarystring(1 << i, 4)}]-1 [{AssortedMethods.ToFullBinarystring(-1, 4)}]=[{AssortedMethods.ToFullBinarystring((1 << i) - 1, 4)}]={mask}" +
                $"");
            return (number & mask);
        }

        public int ClearBitIthrought0(int number, int i)
        {
            int mask = -1 << (i + 1);
            Console.WriteLine($"ClearBitIthrought0:(number({number})={AssortedMethods.ToFullBinarystring(number, 4)}) " +
                $"& mask({mask})={AssortedMethods.ToFullBinarystring(mask, 4)})={(number & mask)}          " +
                $"mask= ( -1 << (i + 1))={mask}" +
                $"mask= (-1 << (i + 1))=-1 [{AssortedMethods.ToFullBinarystring(-1, 4)}] << (i + 1) [{AssortedMethods.ToFullBinarystring(i + 1, 4)}]=[{AssortedMethods.ToFullBinarystring(-1 << (i + 1), 4)}]={mask}" +
                $"");
            return (number & mask);
        }

        public int SetBit(int number, int i)
        {
            return (number | (1 << i));
        }

        /// <summary>
        /// Given an array of integers, every element appears twice except for one. Find that single one.
        /// </summary>
        public void SingleNumber_Run()
        {
            foreach (var testArray in ArrayUtility.TwoDArray)
            {
                testArray.Print("Input");
                Console.WriteLine($"SingleNumber: {SingleNumber_UsingXOR(testArray)} ");
            }
        }

        private int SingleNumber_UsingXOR(int[] numbers)
        {
            int result = 0;
            for (int i = 0; i < numbers.Length; i++)
            {
                result ^= numbers[i];
            }
            return result;
        }

        public class Q5_01_Insertion : IQuestion
        {
            public void Run()
            {
                Console.WriteLine(UpdateBits(100, 10, 2, 6));
            }

            private static int UpdateBits(int n, int m, int i, int j)
            {
                /* Create a mask to clear bits i  through j in n */
                /* Example i = 2, j = 4. Result should be 11100011.
                 * For simplicity, we'll use just 8 bits for the example. */

                // Will equal sequence of all 1's
                const int allOnes = ~0;

                // 1's before position j, then 0s. left = 11100000
                var left = allOnes << (j + 1);

                // 1's after position i. right = 00000011
                var right = ((1 << i) - 1);

                // All 1's, except for 0's between i and i. mask 11100011
                var mask = left | right;

                /* Clear bits j through i then put m in there */
                var nCleared = n & mask; // Clear bits j thorugh i.
                var mShifted = m << i; // Move m into correct position.

                return nCleared | mShifted;// OR them, and we're done
            }
        }

        public class Q5_02_Binary_to_String : IQuestion
        {
            public void Run()
            {
                var binaryString = PrintBinary2(.125);
                Console.WriteLine(binaryString);

                for (var i = 0; i < 1000; i++)
                {
                    var num = i / 1000.0;
                    var binary = PrintBinary(num);
                    var binary2 = PrintBinary2(num);

                    if (!binary.Equals("ERROR") || !binary2.Equals("ERROR"))
                    {
                        Console.WriteLine(num + " : " + binary + " " + binary2);
                    }
                }
            }

            private string PrintBinary(double number)
            {
                if (number >= 1 || number <= 0)
                {
                    return "ERROR";
                }

                var binary = new StringBuilder();
                binary.Append(".");

                while (number > 0)
                {
                    /* Setting a limit on length: 32 characters */
                    if (binary.Length > 32)
                    {
                        return "ERROR";
                    }

                    var r = number * 2;

                    if (r >= 1)
                    {
                        binary.Append(1);
                        number = r - 1;
                    }
                    else
                    {
                        binary.Append(0);
                        number = r;
                    }
                }

                return binary.ToString();
            }

            private string PrintBinary2(double number)
            {
                if (number >= 1 || number <= 0)
                {
                    return "ERROR";
                }

                var binary = new StringBuilder();
                var frac = 0.5;
                binary.Append(".");

                while (number > 0)
                {
                    /* Setting a limit on length: 32 characters */
                    if (binary.Length >= 32)
                    {
                        return "ERROR";
                    }
                    if (number >= frac)
                    {
                        binary.Append(1);
                        number -= frac;
                    }
                    else
                    {
                        binary.Append(0);
                    }
                    frac /= 2;
                }

                return binary.ToString();
            }
        }

        public class Q5_04_Next_Number : IQuestion
        {
            public static void BinPrint(int number)
            {
                Console.WriteLine(number + ": " + AssortedMethods.ToFullBinarystring(number));
            }

            public static int CountOnes(int number)
            {
                var count = 0;

                while (number > 0)
                {
                    if ((number & 1) == 1)
                    {
                        count++;
                    }

                    number = number >> 1;
                }

                return count;
            }

            public static int CountZeros(int number)
            {
                return 32 - CountOnes(number);
            }

            public static int GetNext(int number)
            {
                var c = number;
                var c0 = 0;
                var c1 = 0;

                while (((c & 1) == 0) && (c != 0))
                {
                    c0++;
                    c >>= 1;
                }

                while ((c & 1) == 1)
                {
                    c1++;
                    c >>= 1;
                }

                /* If c is 0, then n is a sequence of 1s followed by a sequence of 0s. This is already the biggest
                 * number with c1 ones. Return error.
                 */
                if (c0 + c1 == 31 || c0 + c1 == 0)
                {
                    return -1;
                }

                int pos = c0 + c1; // position of right-most non-trailing zero (where the right most bit is bit 0)

                /* Flip the right-most non-trailing zero (which will be at position pos) */
                number |= (1 << pos); // Flip right-most non-trailing zero

                /* Clear all bits to the right of pos.
                 * Example with pos = 5
                 * (1) Shift 1 over by 5 to create 0..0100000           [ mask = 1 << pos ]
                 * (2) Subtract 1 to get 0..0011111                     [ mask = mask - 1 ]
                 * (3) Flip all the bits by using '~' to get 1..1100000 [ mask = ~mask    ]
                 * (4) AND with n
                 */
                number &= ~((1 << pos) - 1); // Clear all bits to the right of pos

                /* Put (ones-1) 1s on the right by doing the following:
                 * (1) Shift 1 over by (ones-1) spots. If ones = 3, this gets you 0..0100
                 * (2) Subtract one from that to get 0..0011
                 * (3) OR with n
                 */
                number |= (1 << (c1 - 1)) - 1;

                return number;
            }

            public static int GetNextArith(int number)
            {
                var c = number;
                var c0 = 0;
                var c1 = 0;

                while (((c & 1) == 0) && (c != 0))
                {
                    c0++;
                    c >>= 1;
                }

                while ((c & 1) == 1)
                {
                    c1++;
                    c >>= 1;
                }

                /* If c is 0, then n is a sequence of 1s followed by a sequence of 0s. This is already the biggest
                 * number with c1 ones. Return error.
                 */
                if (c0 + c1 == 31 || c0 + c1 == 0)
                {
                    return -1;
                }

                /* Arithmetically:
                 * 2^c0 = 1 << c0
                 * 2^(c1-1) = 1 << (c0 - 1)
                 * next = n + 2^c0 + 2^(c1-1) - 1;
                 */

                return number + (1 << c0) + (1 << (c1 - 1)) - 1;
            }

            public static int GetNextSlow(int number)
            {
                if (!HasValidNext(number))
                {
                    return -1;
                }

                var numOnes = CountOnes(number);
                number++;

                while (CountOnes(number) != numOnes)
                {
                    number++;
                }

                return number;
            }

            public static int GetPrev(int number)
            {
                var temp = number;
                var c0 = 0;
                var c1 = 0;

                while ((temp & 1) == 1)
                {
                    c1++;
                    temp >>= 1;
                }

                /* If temp is 0, then the number is a sequence of 0s followed by a sequence of 1s. This is already
                 * the smallest number with c1 ones. Return -1 for an error.
                 */
                if (temp == 0)
                {
                    return -1;
                }

                while (((temp & 1) == 0) && (temp != 0))
                {
                    c0++;
                    temp >>= 1;
                }

                var p = c0 + c1; // position of right-most non-trailing one (where the right most bit is bit 0)

                /* Flip right-most non-trailing one.
                 * Example: n = 00011100011.
                 * c1 = 2
                 * c0 = 3
                 * pos = 5
                 *
                 * Build up a mask as follows:
                 * (1) ~0 will be a sequence of 1s
                 * (2) shifting left by p + 1 will give you 11.111000000 (six 0s)
                 * (3) ANDing with n will clear the last 6 bits
                 * n is now 00011000000
                 */
                number &= ((~0) << (p + 1)); // clears from bit p onwards (to the right)

                /* Create a sequence of (c1+1) 1s as follows
                 * (1) Shift 1 to the left (c1+1) times. If c1 is 2, this will give you 0..001000
                 * (2) Subtract one from that. This will give you 0..00111
                 */
                var mask = (1 << (c1 + 1)) - 1; // Sequence of (c1+1) ones

                /* Move the ones to be right up next to bit p
                 * Since this is a sequence of (c1+1) ones, and p = c1 + c0, we just need to
                 * shift this over by (c0-1) spots.
                 * If c0 = 3 and c1 = 2, then this will look like 00...0011100
                 *
                 * Then, finally, we OR this with n.
                 */
                number |= mask << (c0 - 1);

                return number;
            }

            public static int GetPrevArith(int number)
            {
                var temp = number;
                var c0 = 0;
                var c1 = 0;

                while (((temp & 1) == 1) && (temp != 0))
                {
                    c1++;
                    temp >>= 1;
                }

                /* If temp is 0, then the number is a sequence of 0s followed by a sequence of 1s. This is already
                 * the smallest number with c1 ones. Return -1 for an error.
                 */
                if (temp == 0)
                {
                    return -1;
                }

                while ((temp & 1) == 0 && (temp != 0))
                {
                    c0++;
                    temp >>= 1;
                }

                /* Arithmetic:
                 * 2^c1 = 1 << c1
                 * 2^(c0 - 1) = 1 << (c0 - 1)
                 */
                return number - (1 << c1) - (1 << (c0 - 1)) + 1;
            }

            public static int GetPrevSlow(int number)
            {
                if (!HasValidPrev(number))
                {
                    return -1;
                }

                var numOnes = CountOnes(number);
                number--;

                while (CountOnes(number) != numOnes)
                {
                    number--;
                }

                return number;
            }

            public static bool HasValidNext(int number)
            {
                if (number == 0)
                {
                    return false;
                }
                var count = 0;

                while ((number & 1) == 0)
                {
                    number >>= 1;
                    count++;
                }

                while ((number & 1) == 1)
                {
                    number >>= 1;
                    count++;
                }

                if (count == 31)
                {
                    return false;
                }

                return true;
            }

            public static bool HasValidPrev(int number)
            {
                while ((number & 1) == 1)
                {
                    number >>= 1;
                }

                if (number == 0)
                {
                    return false;
                }

                return true;
            }

            public void Run()
            {
                // TODO: Fix this (ported from Java but does not seem to function properly)
                for (var i = 0; i < 200; i++)
                {
                    var p1 = GetPrevSlow(i);
                    var p2 = GetPrev(i);
                    var p3 = GetPrevArith(i);

                    var n1 = GetNextSlow(i);
                    var n2 = GetNext(i);
                    var n3 = GetNextArith(i);

                    if (p1 != p2 || p2 != p3 || n1 != n2 || n2 != n3)
                    {
                        BinPrint(i);
                        BinPrint(p1);
                        BinPrint(p2);
                        BinPrint(p3);
                        BinPrint(n1);
                        BinPrint(n2);
                        BinPrint(n3);
                        Console.WriteLine("");
                    }
                }

                Console.WriteLine("Done!");
            }
        }

        public class Q5_06_Conversion : IQuestion
        {
            public static int BitSwapRequired(int number1, int number2)
            {
                var count = 0;

                for (var c = number1 ^ number2; c != 0; c = c >> 1)
                {
                    count += c & 1;
                }

                return count;
            }

            public static int BitSwapRequired2(int number1, int number2)
            {
                var count = 0;

                for (var c = number1 ^ number2; c != 0; c = c & (c - 1))
                {
                    count++;
                }

                return count;
            }

            public void Run()
            {
                var a = 23432;
                var b = 512132;
                Console.WriteLine(a + ": " + AssortedMethods.ToFullBinarystring(a));
                Console.WriteLine(b + ": " + AssortedMethods.ToFullBinarystring(b));

                var nbits = BitSwapRequired(a, b);
                var nbits2 = BitSwapRequired2(a, b);

                Console.WriteLine("Required number of bits: " + nbits + " " + nbits2);
            }
        }

        public class Q5_07_Pairwise_Swap : IQuestion
        {
            public static int SwapOddEvenBits(int x)
            {
                return (int)(((x & 0xaaaaaaaa) >> 1) | ((x & 0x55555555) << 1));
            }

            public void Run()
            {
                var a = 103217;
                Console.WriteLine(a + ": " + AssortedMethods.ToFullBinarystring(a));
                var b = SwapOddEvenBits(a);
                Console.WriteLine(b + ": " + AssortedMethods.ToFullBinarystring(b));
            }
        }

        public class Q5_08_Draw_Line : IQuestion
        {
            public static int ComputeByteNum(int width, int x, int y)
            {
                return (width * y + x) / 8;
            }

            public static void DrawLine(byte[] screen, int width, int x1, int x2, int y)
            {
                var startOffset = x1 % 8;
                var firstFullByte = x1 / 8;

                if (startOffset != 0)
                {
                    firstFullByte++;
                }

                var endOffset = x2 % 8;
                var lastFullByte = x2 / 8;

                if (endOffset != 7)
                {
                    lastFullByte--;
                }

                // Set full bytes
                for (var b = firstFullByte; b <= lastFullByte; b++)
                {
                    screen[(width / 8) * y + b] = (byte)0xFF;
                }

                var startMask = (byte)(0xFF >> startOffset);
                var endMask = (byte)~(0xFF >> (endOffset + 1));

                // Set start and end of line
                if ((x1 / 8) == (x2 / 8))
                {
                    // If x1 and x2 are in the same byte
                    var mask = (byte)(startMask & endMask);
                    screen[(width / 8) * y + (x1 / 8)] |= mask;
                }
                else
                {
                    if (startOffset != 0)
                    {
                        var byteNumber = (width / 8) * y + firstFullByte - 1;
                        screen[byteNumber] |= startMask;
                    }
                    if (endOffset != 7)
                    {
                        var byteNumber = (width / 8) * y + lastFullByte + 1;
                        screen[byteNumber] |= endMask;
                    }
                }
            }

            public static void PrintByte(byte b)
            {
                for (var i = 7; i >= 0; i--)
                {
                    Console.Write((b >> i) & 1);
                }
            }

            public static void PrintScreen(byte[] screen, int width)
            {
                var height = screen.Length * 8 / width;

                for (var r = 0; r < height; r++)
                {
                    for (var c = 0; c < width; c += 8)
                    {
                        var b = screen[ComputeByteNum(width, c, r)];
                        PrintByte(b);
                    }

                    Console.WriteLine("");
                }
            }

            public void Run()
            {
                const int width = 8 * 4;
                const int height = 15;
                var screen = new byte[width * height / 8];
                //screen[1] = 13;

                DrawLine(screen, width, 8, 10, 2);

                PrintScreen(screen, width);
            }
        }
    }
}