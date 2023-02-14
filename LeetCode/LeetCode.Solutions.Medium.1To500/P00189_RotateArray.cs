namespace LeetCode.Solutions.Medium.P00189_RotateArray;

public class Solution
{
    public void Rotate(int[] nums, int k)
    {
        int[] rotated = new int[nums.Length];
        k = k % nums.Length;

        for (int i = 0; i < nums.Length; i++)
        {
            int j = (i + k) % nums.Length;
            rotated[j] = nums[i];
        }
        for (int i = 0; i < nums.Length; i++)
        {
            nums[i] = rotated[i];
        }
    }
}