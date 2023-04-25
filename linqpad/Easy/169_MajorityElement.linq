<Query Kind="Program">
  <Namespace>Xunit</Namespace>
</Query>

#load "xunit"

void Main()
{
	RunTests();  // Call RunTests() or press Alt+Shift+T to initiate testing.
}

public class Solution {
	public int MajorityElement(int[] nums)
	{
		int maxCount = 0; 
		int maxKey = nums[0]; 
		Dictionary<int, int> counts = new Dictionary<int, int>();
		foreach (int num in nums)
		{
			if (!counts.ContainsKey(num)) 
			{
				counts.Add(num, 0);
			}
			counts[num]++;
			if (counts[num] > maxCount) 
			{
				maxCount = counts[num]; 
				maxKey = num;
			}
		}
		
		return maxKey;
		
	}
}

/*

Example 1:
Input: nums = [3,2,3]
Output: 3

Example 2:
Input: nums = [2,2,1,1,1,2,2]
Output: 2
 

*/

[Theory]
[InlineData(new[] {3,2,3}, 3)]
[InlineData(new[] {2,2,1,1,1,2,2}, 2)]
void Test(int[] nums, int expected) 
{
	int result = new Solution().MajorityElement(nums); 
	Assert.Equal(expected, result);
}