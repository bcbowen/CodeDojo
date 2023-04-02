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
	public int PivotIndex(int[] nums)
	{

		int index = 0;
		int left = 0;
		int right = 0;
		for (int i = 1; i < nums.Length; i++)
		{
			right += nums[i];
		}

		while (index < nums.Length)
		{
			if (left == right)
			{
				return index;
			}
			index++;
			left += nums[index - 1];
			if (index < nums.Length) right -= nums[index];
		}

		return -1;
	}
}


[InlineData(new[] { 1, 7, 3, 6, 5, 6 }, 3)]
[InlineData(new[] { 1, 2, 3 }, -1)]
[InlineData(new[] { 2, 1, -1 }, 0)]
[InlineData(new[] { -1, -1, 0, 1, 1, 0 }, 5)]
[Theory]
void PivotIndexTest(int[] values, int expected)
{
	int result = new Solution().PivotIndex(values);
	Assert.Equal(expected, result);
}
/*
Input:
[-1,-1,0,1,1,0]
Output:
-1
Expected:
5


Example 1:

Input: nums = [1,7,3,6,5,6]
Output: 3
Explanation:
The pivot index is 3.
Left sum = nums[0] + nums[1] + nums[2] = 1 + 7 + 3 = 11
Right sum = nums[4] + nums[5] = 5 + 6 = 11
Example 2:

Input: nums = [1,2,3]
Output: -1
Explanation:
There is no index that satisfies the conditions in the problem statement.
Example 3:

Input: nums = [2,1,-1]
Output: 0
Explanation:
The pivot index is 0.
Left sum = 0 (no elements to the left of index 0)
Right sum = nums[1] + nums[2] = 1 + -1 = 0
*/
