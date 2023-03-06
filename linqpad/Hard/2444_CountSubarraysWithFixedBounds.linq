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
	public long CountSubarrays(int[] nums, int minK, int maxK) {
		int minIndex = -1; 
		int maxIndex = -1; 
		int leftBound =  -1;

		long result = 0;

		for (int i = 0; i < nums.Length; i++)
		{
			if (nums[i] < minK || nums[i] > maxK) 
			{
				leftBound = i;
			}
			
			if (nums[i] == minK)
			{
				minIndex = i;
			}
			if (nums[i] == maxK)
			{
				maxIndex = i;
			}
			
			result += Math.Max(0, Math.Min(maxIndex,minIndex) - leftBound);
				
		}
		return result;
    }
}

#region private::Tests
/*
Example 1:
Input: nums = [1,3,5,2,7,5], minK = 1, maxK = 5
Output: 2
Explanation: The fixed-bound subarrays are [1,3,5] and [1,3,5,2].

Example 2:
Input: nums = [1,1,1,1], minK = 1, maxK = 1
Output: 10
Explanation: Every subarray of nums is a fixed-bound subarray. There are 10 possible subarrays.

*/

[Theory]
[InlineData(new[] { 1, 3, 5, 2, 7, 5}, 1, 5, 2)]
[InlineData(new[] { 1, 1, 1, 1 }, 1, 1, 10)]
[InlineData(new[] { 35054, 398719, 945315, 945315, 820417, 945315, 35054, 945315, 171832, 945315, 35054, 109750, 790964, 441974, 552913 }, 35054, 945315, 81)]
/**/
void Test(int[] nums, int minK, int maxK, long expected) 
{
	long result = new Solution().CountSubarrays(nums, minK, maxK); 
	Assert.Equal(expected, result);
}

#endregion