namespace LeetCode.Solutions.Easy.P00561_ArrayPartition;

public class Solution
{
    public int ArrayPairSum(int[] nums)
    {
        if (nums.Length == 0) return 0;

        Array.Sort(nums);

        int sum = 0;
        for (int i = 1; i < nums.Length; i += 2)
        {
            sum += nums[i - 1];
        }

        return sum;
    }
}