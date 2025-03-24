<Query Kind="Program">
  <Namespace>Xunit</Namespace>
</Query>

#load "xunit"

void Main()
{
	RunTests();  // Call RunTests() or press Alt+Shift+T to initiate testing.
}

public int MaximumGap(int[] nums)
{
	if (nums == null || nums.Length < 2) return 0; 
	Array.Sort(nums);
	int max = 0;
	int diff = 0; 
	for (int i = 1; i < nums.Length; i++) 
	{
		diff = nums[i] - nums[i - 1]; 
		max = Math.Max(diff, max); 
	}
	return max; 
}

#region private::Tests

/*
Example 1:

Input: nums = [3,6,9,1]
Output: 3
Explanation: The sorted form of the array is [1,3,6,9], either (3,6) or (6,9) has the maximum difference 3.
Example 2:

Input: nums = [10]
Output: 0
Explanation: The array contains less than 2 elements, therefore return 0.
 
*/

[Theory]
[InlineData(new[] { 3, 6, 9, 1 }, 3)]
[InlineData(new[] { 10 }, 0)]
[InlineData(new[] { 1, 10000000}, 9999999)]
void Test(int[] nums, int expected)
{
	int result = MaximumGap(nums);
	Assert.Equal(expected, result);
}

#endregion