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
	public void Rotate(int[] nums, int k)
	{		
		int[] rotated = new int[nums.Length];
		k = k % nums.Length;
				
		for (int i = 0; i < nums.Length; i++) 
		{
			int j = (i + k ) % nums.Length;
			rotated[j] = nums[i];
		}
		for(int i = 0; i < nums.Length; i++) 
		{
			nums[i] = rotated[i];
		}
	}
}

#region private::Tests

[Fact] void Test_Xunit() => Assert.True(1 + 1 == 2);

/*
Example 1:

Input: nums = [1,2,3,4,5,6,7], k = 3
Output: [5,6,7,1,2,3,4]
Explanation:
rotate 1 steps to the right: [7,1,2,3,4,5,6]
rotate 2 steps to the right: [6,7,1,2,3,4,5]
rotate 3 steps to the right: [5,6,7,1,2,3,4]
Example 2:

Input: nums = [-1,-100,3,99], k = 2
Output: [3,99,-1,-100]
Explanation: 
rotate 1 steps to the right: [99,-1,-100,3]
rotate 2 steps to the right: [3,99,-1,-100]
 
*/

[Theory]
/**/
[InlineData(new[] { 1, 2, 3, 4, 5, 6, 7 }, 10, new[] { 5, 6, 7, 1, 2, 3, 4 })]
[InlineData(new[] { 1, 2, 3, 4, 5, 6, 7 }, 3, new[] { 5, 6, 7, 1, 2, 3, 4 })]
[InlineData(new[] { -1, -100, 3, 99 }, 2, new[] { 3, 99, -1, -100 })]
[InlineData(new[] { 1, 2 }, 1, new[] { 2, 1 })]
[InlineData(new[] { 1, 2 }, 2, new[] { 1, 2 })]

[InlineData(new[] { 1, 2, 3, 4 }, 2, new[] { 3, 4, 1, 2 })]
void RotateArrayTest(int[] nums, int k, int[] expected)
{
	new Solution().Rotate(nums, k);
	Assert.Equal(expected, nums);
}

#endregion