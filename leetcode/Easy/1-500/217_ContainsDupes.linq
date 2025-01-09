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
	public bool ContainsDuplicate(int[] nums)
	{
		HashSet<int> seen = new HashSet<int>();
		foreach (int i in nums)
		{
			if (seen.Contains(i)) return true;
			seen.Add(i);
		}

		return false;
	}
}

#region private::Tests


/*
Example 1:

Input: nums = [1,2,3,1]
Output: true
Example 2:

Input: nums = [1,2,3,4]
Output: false
Example 3:

Input: nums = [1,1,1,3,3,4,3,2,4,2]
Output: true
*/

[Theory]
[InlineData(new[] { 1, 2, 3, 1 }, true)]
[InlineData(new[] { 1, 2, 3, 4 }, false)]
[InlineData(new[] { 1, 1, 1, 3, 3, 4, 3, 2, 4, 2 }, true)]
void TestContainsDupes(int[] nums, bool expected)
{
	bool result = new Solution().ContainsDuplicate(nums);
}

#endregion