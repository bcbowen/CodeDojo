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
	public int FindKthPositive(int[] arr, int k)
	{
		int i = 0;
		int count = 0;
		foreach(int val in arr)
		{
			i++; 
			while(i < val) 
			{
				count++; 
				if (count == k) break;
				i++; 
			}
			if (count == k) break;
		}
		i += k - count; 
		return i;
	}
}

#region private::Tests

[Theory]
[InlineData(new[] {2,3,4,7,11}, 5, 9)]
[InlineData(new[] {1,2,3,4}, 2, 6)]
void Test(int[] nums, int k, int expected) 
{
	int result = new Solution().FindKthPositive(nums, k);
	Assert.Equal(expected, result);
}

/*
Example 1:
Input: arr = [2,3,4,7,11], k = 5
Output: 9
Explanation: The missing positive integers are [1,5,6,8,9,10,12,13,...]. The 5th missing positive integer is 9.

Example 2:
Input: arr = [1,2,3,4], k = 2
Output: 6
Explanation: The missing positive integers are [5,6,7,...]. The 2nd missing positive integer is 6.
*/

#endregion