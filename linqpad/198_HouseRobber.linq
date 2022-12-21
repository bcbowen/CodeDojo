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

#region private::Tests

[Theory]
[InlineData(new[] { 1, 2, 3, 1 }, 4)]
[InlineData(new[] { 2, 7, 9, 3, 1 }, 12)]
void Test(int[] nums, int expected)
{
	int result = new Solution().Rob(nums);
	Assert.Equal(expected, result);
}

/*
Example 1:
Input: nums = [1,2,3,1]
Output: 4
Explanation: Rob house 1 (money = 1) and then rob house 3 (money = 3).
Total amount you can rob = 1 + 3 = 4.

Example 2:
Input: nums = [2,7,9,3,1]
Output: 12
Explanation: Rob house 1 (money = 2), rob house 3 (money = 9) and rob house 5 (money = 1).
Total amount you can rob = 2 + 9 + 1 = 12.
*/

#endregion