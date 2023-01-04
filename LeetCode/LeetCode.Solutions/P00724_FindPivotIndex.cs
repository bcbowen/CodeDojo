namespace LeetCode.Solutions.P00724_FindPivotIndex;

public class Solution
{
    public int PivotIndex(int[] nums)
    {

        int index = 0;
        int left = 0;
        int right = 0;
        for (int i = 1; i < nums.Length; i++)
        {
            right += nums[i];
        }

        while (index < nums.Length)
        {
            if (left == right)
            {
                return index;
            }
            index++;
            left += nums[index - 1];
            if (index < nums.Length) right -= nums[index];
        }

        return -1;
    }
}
