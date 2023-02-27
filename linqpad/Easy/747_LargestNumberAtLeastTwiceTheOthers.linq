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
	public int DominantIndex(int[] nums)
	{
		int max = int.MinValue;
		int index = 0;
		for(int i = 0; i < nums.Length; i++)
		{
			if (nums[i] > max) 
			{
				max = nums[i]; 
				index = i;
			}
		}
		
		int limit = max / 2;
		foreach(int i in nums) 
		{
			if (i > limit && i < max) return -1;
		}
		
		return index;
	}
}

#region private::Tests

[Fact] void Test_Xunit() => Assert.True(1 + 1 == 2);

[Theory]
[InlineData(new[] {3,6,1,0}, 1)]
[InlineData(new[] {1,2,3,4}, -1)]
void TestDominantIndex(int[] nums, int expected) 
{
	int result = new Solution().DominantIndex(nums);
	Assert.Equal(expected, result);
}
/*
Example 1:

Input: nums = [3,6,1,0]
Output: 1
Explanation: 6 is the largest integer.
For every other number in the array x, 6 is at least twice as big as x.
The index of value 6 is 1, so we return 1.
Example 2:

Input: nums = [1,2,3,4]
Output: -1
Explanation: 4 is less than twice the value of 3, so we return -1.
*/

#endregion