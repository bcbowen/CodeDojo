namespace LeetCode.Solutions.Medium.P00494_TargetSum;

public class Solution
{
    private int _count = 0;

    private Dictionary<(int, int), int> _cache;

    public Solution() 
    {
        _cache = new Dictionary<(int, int), int>(); 
    }

    public int FindTargetSumWays(int[] nums, int target)
    {
        Calculate(nums, 0, 0, target);
        return _count;
    }
    public void Calculate(int[] nums, int i, int sum, int target) {
        if (i == nums.Length) {
            if (sum == target) {
                _count++;
            }
        } else {
            if (_cache.ContainsKey((i + 1, sum + nums[i])))
            {
                if (_cache[(i + 1, sum + nums[i])] == target)
                {
                    _count++;
                }
            }
            else 
            {
                Calculate(nums, i + 1, sum + nums[i], target);
            }

            if (_cache.ContainsKey((i + 1, sum - nums[i])))
            {
                if (_cache[(i + 1, sum - nums[i])] == target)
                {
                    _count++;
                }
            }
            else
            {
                Calculate(nums, i + 1, sum - nums[i], target);
            }

        }
    }

}