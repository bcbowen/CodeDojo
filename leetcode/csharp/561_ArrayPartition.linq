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
	public int ArrayPairSum(int[] nums)
	{
		if (nums.Length == 0) return 0;
		
		Array.Sort(nums);

		int sum = 0;
		for (int i = 1; i < nums.Length; i += 2) 
		{
			sum += nums[i - 1]; 
		}
		
		return sum;
	}
}

#region private::Tests

[Fact] void Test_Xunit() => Assert.True(1 + 1 == 2);
[Theory]
[InlineData(new[] {1,4,3,2}, 4)]
[InlineData(new[] {6,2,6,5,1,2}, 9)]
void Test(int[] nums, int expected) 
{
	int result = new Solution().ArrayPairSum(nums);
	Assert.Equal(expected, result);
}

/*
Example 1:

Input: nums = [1,4,3,2]
Output: 4
Explanation: All possible pairings (ignoring the ordering of elements) are:
1. (1, 4), (2, 3) -> min(1, 4) + min(2, 3) = 1 + 2 = 3
2. (1, 3), (2, 4) -> min(1, 3) + min(2, 4) = 1 + 2 = 3
3. (1, 2), (3, 4) -> min(1, 2) + min(3, 4) = 1 + 3 = 4
So the maximum possible sum is 4.
Example 2:

Input: nums = [6,2,6,5,1,2]
Output: 9
Explanation: The optimal pairing is (2, 1), (2, 5), (6, 6). min(2, 1) + min(2, 5) + min(6, 6) = 1 + 2 + 6 = 9.
*/
#endregion