namespace LeetCode.Solutions.Easy.P00066_PlusOne;

public class Solution
{
    public int[] PlusOne(int[] digits)
    {
        bool carry = true;

        for (int i = digits.Length - 1; i >= 0; i--)
        {
            if (carry)
            {
                if (digits[i] == 9)
                {
                    digits[i] = 0;
                }
                else
                {
                    digits[i]++;
                    carry = false;
                }
            }
            if (!carry) break;
        }
        if (carry)
        {
            int[] digits2 = new int[digits.Length + 1];
            digits2[0] = 1;
            for (int i = 1; i < digits2.Length; i++)
            {
                digits2[i] = digits[i - 1];
            }
            return digits2;
        }
        else
        {
            return digits;
        }

    }
}