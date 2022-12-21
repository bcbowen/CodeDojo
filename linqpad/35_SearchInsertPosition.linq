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
	public int SearchInsert(int[] nums, int target)
	{
		if (nums.Length == 1) return target > nums[0] ? 1 : 0;
		if (target < nums[0]) return 0;
		if (target > nums[nums.Length - 1]) return nums.Length;

		int i = 0;
		int j = nums.Length - 1;
		while (i < j)
		{
			int index = (i + j) / 2;
			if (nums[index] == target)
			{
				return index;
			}
			else if (nums[index] < target)
			{
				i = index + 1;
			}
			else
			{
				j = index - 1;
			}
			
		}
		return nums[i] < target ? i + 1 : i;
	}
}

#region private::Tests

[Fact] void Test_Xunit() => Assert.True(1 + 1 == 2);

[Theory]
//
/**/
[InlineData(new[] { 1, 3, 5, 6 }, 5, 2)]
[InlineData(new[] { 1, 3, 5, 6 }, 2, 1)]
[InlineData(new[] { 1, 3, 5, 6 }, 7, 4)]
[InlineData(new[] { 2, 3, 5, 6 }, 1, 0)]
[InlineData(new[] { 5 }, 2, 0)]
[InlineData(new[] { 5 }, 7, 1)]
[InlineData(new[] { 1, 3 }, 2, 1)]

[InlineData(new[] { 2,7,8,9,10 }, 9, 3)]
void SearchInsert(int[] nums, int target, int expected)
{
	int result = new Solution().SearchInsert(nums, target);
	Assert.Equal(expected, result);
}

/*
[2,7,8,9,10]
9


Input
[1,3]
2
Output
0
Expected
1

Example 1:

Input: nums = [1,3,5,6], target = 5
Output: 2
Example 2:

Input: nums = [1,3,5,6], target = 2
Output: 1
Example 3:

Input: nums = [1,3,5,6], target = 7
Output: 4
*/


#endregion