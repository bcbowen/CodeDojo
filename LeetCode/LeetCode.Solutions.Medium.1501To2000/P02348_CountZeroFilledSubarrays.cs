namespace LeetCode.Solutions.Medium.P02348_CountZeroFilledSubarrays;

public class Solution
{
    public long ZeroFilledSubarray(int[] nums)
    {
        int i = 0;
        int j = 0;
        long sum = 0;
        while (i < nums.Length)
        {
            if (nums[i] != 0)
            {
                if (j < i) sum += SumFactor(i - j);
                j = i + 1;
            }
            i++;
        }
        if (j < i) sum += SumFactor(i - j);
        return sum;
    }

    private long SumFactor(int i)
    {
        long sum = 0;
        while (i > 0)
        {
            sum += i--;
        }
        return sum;
    }
}
