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
	public int Search(int[] nums, int target)
	{
		int index = -1; 
		int start = 0;
		int end = nums.Length - 1;
		while(start < end) 
		{
			int mid = start + (end - start) / 2;
			if (nums[mid] == target)
			{
				return mid;
			}
			if (nums[mid] > target) 
			{
				end = mid - 1;
			}
			else 
			{
				start = mid + 1;
			}
		}
		if (nums[start] == target) index = start;
		return index;
	}
}

#region private::Tests

/*
Example 1:
Input: nums = [-1,0,3,5,9,12], target = 9
Output: 4
Explanation: 9 exists in nums and its index is 4

Example 2:
Input: nums = [-1,0,3,5,9,12], target = 2
Output: -1
Explanation: 2 does not exist in nums so return -1
*/

[Theory]
[InlineData(new[] {-1,0,3,5,9,12}, 9, 4)]
[InlineData(new[] {-1,0,3,5,9,12}, 2, -1)]
void Test(int[] nums, int target, int expected) 
{
	int result = new Solution().Search(nums, target); 
	Assert.Equal(expected, result); 
}

#endregion