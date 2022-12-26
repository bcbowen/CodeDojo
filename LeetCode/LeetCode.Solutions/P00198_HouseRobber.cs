namespace LeetCode.Solutions.P00198_HouseRobber;

public class Solution
{
    public int Rob(int[] nums)
    {
        if (nums.Length == 1) return nums[0];

        int[] loot = new int[nums.Length];
        loot[0] = nums[0];
        loot[1] = Math.Max(nums[0], nums[1]);

        for (int i = 2; i < nums.Length; i++)
        {
            loot[i] = Math.Max(loot[i - 1], loot[i - 2] + nums[i]);
        }

        return loot[loot.Length - 1];
    }
}