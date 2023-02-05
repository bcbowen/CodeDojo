namespace LeetCode.Solutions.Easy;

public class Solution
{
    public bool IsUgly(int n)
    {
        if (n < 1) return false;

        int[] factors = { 2, 3, 5 };

        foreach (int factor in factors)
        {
            while (n % factor == 0)
            {
                n /= factor;
            }
        }

        return n == 1;
    }
}