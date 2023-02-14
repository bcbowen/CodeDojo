namespace LeetCode.Solutions.Medium.P00300_LongestIncreasingSubsequence;

public class Solution
{
    public int LengthOfLIS(int[] nums)
    {
        int[] answers = new int[nums.Length];
        Array.Fill(answers, 1);

        for (int i = 1; i < nums.Length; i++)
        {
            for (int j = 0; j < i; j++)
            {
                if (nums[j] < nums[i])
                {
                    answers[i] = Math.Max(answers[i], answers[j] + 1);
                }
            }
        }

        return answers.Max(a => a);
    }
}