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
	internal enum Trend
	{
		Unknown,
		Increasing,
		Decreasing
	}

	public bool IsMonotonic(int[] nums)
	{
		if (nums == null || nums.Length == 0) return false;
		Trend trend = Trend.Unknown;
		int last = nums[0];
		for (int i = 1; i < nums.Length; i++)
		{
			switch (trend)
			{
				case Trend.Unknown:
					if (nums[i] < last)
					{
						trend = Trend.Decreasing;
					}
					else if (nums[i] > last)
					{
						trend = Trend.Increasing;
					}
					break;
				case Trend.Decreasing:
					if (nums[i] > last)
					{
						return false;
					}
					break;
				case Trend.Increasing:
					if (nums[i] < last)
					{
						return false;
					}
					break;
			}
			last = nums[i];
		}
		return true;
	}
}

#region private::Tests

[Theory]
[InlineData(new[] { 1, 2, 2, 3 }, true)]
[InlineData(new[] { 6, 5, 4, 4 }, true)]
[InlineData(new[] { 1, 3, 2 }, false)]
[InlineData(new[] { 6, 6, 6 }, true)]
void Test(int[] nums, bool expected)
{
	bool result = new Solution().IsMonotonic(nums);
	Assert.Equal(expected, result);
}
/*
Example 1:
Input: nums = [1,2,2,3]
Output: true

Example 2:
Input: nums = [6,5,4,4]
Output: true

Example 3:
Input: nums = [1,3,2]
Output: false


*/
#endregion