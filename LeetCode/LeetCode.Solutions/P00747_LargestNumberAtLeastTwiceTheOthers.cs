namespace LeetCode.Solutions.P00747_LargestNumberAtLeastTwiceTheOthers;

public class Solution
{
    public int DominantIndex(int[] nums)
    {
        int max = int.MinValue;
        int index = 0;
        for (int i = 0; i < nums.Length; i++)
        {
            if (nums[i] > max)
            {
                max = nums[i];
                index = i;
            }
        }

        int limit = max / 2;
        foreach (int i in nums)
        {
            if (i > limit && i < max) return -1;
        }

        return index;
    }
}