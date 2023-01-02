namespace LeetCode.Solutions.P00746_MinCostClimbingStairs;

public class Solution
{
    public int MinCostClimbingStairs(int[] nums)
    {
        if (nums.Length == 1) return nums[0];

        int[] dp = new int[nums.Length + 1];
        dp[nums.Length] = 0;
        dp[nums.Length - 1] = nums[nums.Length - 1];
        for (int i = nums.Length - 2; i >= 0; i--)
        {
            dp[i] = nums[i] + Math.Min(dp[i + 1], dp[i + 2]);
        }

        return Math.Min(dp[0], dp[1]);
    }
}