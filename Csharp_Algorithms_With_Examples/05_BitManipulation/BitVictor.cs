using System;

namespace TWL_Algorithms_Samples.BitManipulation
{
    public static class BitVector
    {
        public static int Toggle(int bitVector, int index)
        {
            if (index < 0) return bitVector;

            int mask = 1 << index;
            if ((bitVector & mask) == 0)
            {
                bitVector |= mask;
            }
            else
            {
                bitVector &= ~mask;
            }
            return bitVector;
        }

        /* Create bit vector for string. For each letter with value i,
         * toggle the ith bit. */

        public static int CreateBitVector(String phrase)
        {
            int bitVector = 0;
            foreach (char c in phrase.ToCharArray())
            {
                int x = CharUtility.GetCharNumber(c);
                bitVector = Toggle(bitVector, x);
            }
            return bitVector;
        }

        /* Check that exactly one bit is set by subtracting one from the
         * integer and ANDing it with the original integer. */

        public static bool CheckExactlyOneBitSet(int bitVector)
        {
            return (bitVector & (bitVector - 1)) == 0;
        }
    }
}