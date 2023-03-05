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
	public int SingleNumber(int[] nums)
	{
		HashSet<int> seen = new HashSet<int>();
		foreach(int num in nums)
		{
			if (!seen.Contains(num))
			{
				seen.Add(num);
			}
			else 
			{
				seen.Remove(num);
			}
		}
		return seen.First();
	}
}

#region private::Tests

[Theory]
[InlineData(new[] {2,2,1}, 1)]
[InlineData(new[] {4,1,2,1,2}, 4)]
[InlineData(new[] {1}, 1)]
void Test(int[] nums, int expected) 
{
	int result = new Solution().SingleNumber(nums);
	Assert.Equal(expected, result);
}

/*
Example 1:
Input: nums = [2,2,1]
Output: 1

Example 2:
Input: nums = [4,1,2,1,2]
Output: 4

Example 3:
Input: nums = [1]
Output: 1
*/

#endregion