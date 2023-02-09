namespace LeetCode.Solutions.Easy.P00976_LargestPerimeterTriangle;

public class Solution
{
    public int LargestPerimeter(int[] nums)
    {
        if (nums == null || nums.Length < 3) return 0;
        int p = 0;
        Array.Sort(nums);
        int i = nums.Length - 1;
        while (i > 1)
        {
            int a = nums[i - 2];
            int b = nums[i - 1];
            int c = nums[i];
            if (a + b > c)
            {
                p = a + b + c;
                break;
            }
            i--;
        }
        return p;
    }
}
