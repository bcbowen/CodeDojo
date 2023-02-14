namespace LeetCode.Solutions.Medium.P01630_ArithmeticSubarrays;

public class Solution
{
    public IList<bool> CheckArithmeticSubarrays(int[] nums, int[] l, int[] r)
    {
        List<bool> result = new List<bool>();
        for (int i = 0; i < l.Length; i++)
        {
            int start = l[i];
            int end = r[i];
            List<int> temp = new List<int>();
            for (int j = start; j < end + 1; j++)
            {
                temp.Add(nums[j]);
            }
            result.Add(CheckIsArithmeticSubarrays(temp));
        }
        return result;
    }

    internal bool CheckIsArithmeticSubarrays(List<int> nums)
    {
        if (nums.Count() < 2) return false;
        nums.Sort();
        int delta = nums[1] - nums[0];
        for (int i = 0; i < nums.Count() - 1; i++)
        {
            if (nums[i + 1] - nums[i] != delta)
                return false;
        }
        return true;
    }

}
