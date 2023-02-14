namespace LeetCode.Solutions.Easy.P02389_LongestSubsequenceWithLimitedSum;

public class Solution
{
    public int[] AnswerQueries(int[] nums, int[] queries)
    {
        int[] result = new int[queries.Length];
        Array.Sort(nums);
        for (int k = 0; k < queries.Length; k++)
        {
            int total = queries[k];
            int count = 0;
            int currentTotal = nums[0];
            int i = 0;
            int j = 0;
            int maxCount = 0;
            while (i < nums.Length)
            {
                if (nums[i] <= total)
                {
                    currentTotal = nums[i];
                    count = 1;
                    j = i;
                    while (currentTotal <= total && j < nums.Length)
                    {
                        j++;
                        if (j < nums.Length)
                        {
                            currentTotal += nums[j];
                            if (currentTotal <= total) count++;
                        }
                    }
                    maxCount = Math.Max(count, maxCount);
                    i++;
                }
                else
                {
                    i++;
                }
            }
            result[k] = maxCount;
        }
        return result;
    }
}
