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
	public int MinCostClimbingStairs(int[] nums)
	{
		if (nums.Length == 1) return nums[0];

		int[] dp = new int[nums.Length + 1];
		dp[nums.Length] = 0;
		dp[nums.Length - 1] = nums[nums.Length - 1];
		for (int i = nums.Length - 2; i >= 0; i--)
		{
			dp[i] = nums[i] + Math.Min(dp[i + 1], dp[i + 2]);
		}

		return Math.Min(dp[0], dp[1]);
	}
}

#region Tests

[Theory]
[InlineData(new[] { 10, 15, 20 }, 15)]
[InlineData(new[] { 1, 100, 1, 1, 1, 100, 1, 1, 100, 1 }, 6)]
[InlineData(new[] { 0, 2, 2, 1 }, 2)]
void Test(int[] nums, int expected)
{
	int result = new Solution().MinCostClimbingStairs(nums);
	Assert.Equal(expected, result);
}

/*

Input:
[0,2,2,1]
Output:
3
Expected:
2

Example 1:
Input: cost = [10,15,20]
Output: 15
Explanation: You will start at index 1.
- Pay 15 and climb two steps to reach the top.
The total cost is 15.

Example 2:
Input: cost = [1,100,1,1,1,100,1,1,100,1]
Output: 6
Explanation: You will start at index 0.
- Pay 1 and climb two steps to reach index 2.
- Pay 1 and climb two steps to reach index 4.
- Pay 1 and climb two steps to reach index 6.
- Pay 1 and climb one step to reach index 7.
- Pay 1 and climb two steps to reach index 9.
- Pay 1 and climb one step to reach the top.
The total cost is 6.
*/

#endregion