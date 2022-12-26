namespace LeetCode.Solutions.P00191_Number1Bits_HammingWeight;

public class Solution
{
    public int HammingWeight(uint n)
    {
        int bitCount = 0;
        uint mask = 1;

        for (int i = 0; i < 32; i++)
        {
            if ((n & mask) == mask) bitCount++;
            mask <<= 1;
        }

        return bitCount;
    }

    public int HammingWeightFirst(uint n)
    {
        int bitCount = 0;
        long mask = (long)Math.Pow(2, 32);

        while (mask > 0)
        {
            if ((n & mask) == mask) bitCount++;
            mask /= 2;
        }

        return bitCount;
    }
}