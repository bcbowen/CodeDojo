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
	public int LengthOfLIS(int[] nums)
	{
		int[] answers = new int[nums.Length];
		Array.Fill(answers, 1);
		
		for (int i = 1; i < nums.Length; i++)
		{
			for (int j = 0; j < i; j++)
			{
				if (nums[j] < nums[i])
				{
					answers[i] = Math.Max(answers[i], answers[j] + 1);
				}
			}
		}

		return answers.Max(a => a);
	}
}

#region private::Tests

[Theory]
[InlineData(new[] { 10, 9, 2, 5, 3, 7, 101, 18 }, 4)]
[InlineData(new[] { 0, 1, 0, 3, 2, 3 }, 4)]
[InlineData(new[] { 7, 7, 7, 7, 7, 7, 7 }, 1)]
[InlineData(new[] {1,3,6,7,9,4,10,5,6 }, 6)]
void Test(int[] nums, int expected)
{
	int result = new Solution().LengthOfLIS(nums);
	Assert.Equal(expected, result);
}

/*

Example 1:
Input: nums = [10,9,2,5,3,7,101,18]
Output: 4
Explanation: The longest increasing subsequence is [2,3,7,101], therefore the length is 4.

Example 2:
Input: nums = [0,1,0,3,2,3]
Output: 4

Example 3:
Input: nums = [7,7,7,7,7,7,7]
Output: 1

*/
#endregion