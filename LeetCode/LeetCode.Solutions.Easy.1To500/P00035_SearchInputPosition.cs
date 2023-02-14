namespace LeetCode.Solutions.Easy.P00035_SearchInputPosition;

public class Solution
{
    public int SearchInsert(int[] nums, int target)
    {
        if (nums.Length == 1) return target > nums[0] ? 1 : 0;
        if (target < nums[0]) return 0;
        if (target > nums[nums.Length - 1]) return nums.Length;

        int i = 0;
        int j = nums.Length - 1;
        while (i < j)
        {
            int index = (i + j) / 2;
            if (nums[index] == target)
            {
                return index;
            }
            else if (nums[index] < target)
            {
                i = index + 1;
            }
            else
            {
                j = index - 1;
            }

        }
        return nums[i] < target ? i + 1 : i;
    }
}