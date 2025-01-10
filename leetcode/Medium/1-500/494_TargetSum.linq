<Query Kind="Program">
  <Namespace>Xunit</Namespace>
</Query>

#load "xunit"

void Main()
{
	RunTests();  // Call RunTests() or press Alt+Shift+T to initiate testing.
}

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
	public void Calculate(int[] nums, int i, int sum, int target)
	{
		if (i == nums.Length)
		{
			if (sum == target)
			{
				_count++;
			}
		}
		else
		{
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

/*
Example 1:

Input: nums = [1,1,1,1,1], target = 3
Output: 5
Explanation: There are 5 ways to assign symbols to make the sum of nums be target 3.
-1 + 1 + 1 + 1 + 1 = 3
+1 - 1 + 1 + 1 + 1 = 3
+1 + 1 - 1 + 1 + 1 = 3
+1 + 1 + 1 - 1 + 1 = 3
+1 + 1 + 1 + 1 - 1 = 3
Example 2:

Input: nums = [1], target = 1
Output: 1
*/
[Theory]
[InlineData(new[] { 1, 1, 1, 1, 1 }, 3, 5)]
[InlineData(new[] { 1 }, 1, 1)]
public void P00494_TargetSumTest(int[] nums, int target, int expected)
{
	int result = new Solution().FindTargetSumWays(nums, target);
	Assert.Equal(expected, result);
}