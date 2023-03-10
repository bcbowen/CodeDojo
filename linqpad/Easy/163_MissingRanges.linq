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
	public IList<string> FindMissingRanges(int[] nums, int lower, int upper)
	{
		List<string> result = new List<string>();

		if (nums.Length == 0)
		{
			result.Add($"{lower}" + (lower == upper ? "" : $"->{upper}"));
		}
		else
		{
			if (nums[0] > lower)
			{
				result.Add($"{lower}" + (lower == nums[0] - 1 ? "" : $"->{nums[0] - 1}"));
			}
			int i = nums[0];
			foreach (int num in nums)
			{
				if (num > i)
				{
					result.Add($"{i}" + (i == num - 1 ? "" : $"->{num - 1}"));
					i = num;
				}

				i++;
			}
			if (nums[nums.Length - 1] < upper)
			{
				result.Add($"{nums[nums.Length - 1] + 1}" + (nums[nums.Length - 1] + 1 == upper ? "" : $"->{upper}"));
			}
		}
		return result;
	}
}

#region private::Tests

[Theory]
[InlineData(new[] { 0, 1, 3, 50, 75 }, 0, 99, new[] { "2", "4->49", "51->74", "76->99" })]
[InlineData(new int[0], 1, 1, new[] { "1" })]
[InlineData(new int[0], 1, 5, new[] { "1->5" })]
[InlineData(new[] { -1 }, -1, -1, new string[0])]
[InlineData(new[] { 3, 4, 5, 6, 7 }, 1, 7, new string[] { "1->2" })]
[InlineData(new[] { 2, 3, 4, 5, 6, 7 }, 1, 7, new string[] { "1" })]
[InlineData(new[] { 3, 4, 5, 6, 7 }, 3, 9, new string[] { "8->9" })]
[InlineData(new[] { 2, 3, 4, 5, 6, 7 }, 2, 8, new string[] { "8" })]
/**/
void Test(int[] nums, int lower, int upper, string[] expected)
{
	string[] result = new Solution().FindMissingRanges(nums, lower, upper).ToArray();
	Assert.Equal(expected, result);
}

/*
Example 1:
Input: nums = [0,1,3,50,75], lower = 0, upper = 99
Output: ["2","4->49","51->74","76->99"]
Explanation: The ranges are:
[2,2] --> "2"
[4,49] --> "4->49"
[51,74] --> "51->74"
[76,99] --> "76->99"

Example 2:
Input: nums = [-1], lower = -1, upper = -1
Output: []
Explanation: There are no missing ranges since there are no missing numbers.
*/

#endregion