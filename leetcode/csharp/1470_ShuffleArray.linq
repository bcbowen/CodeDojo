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
	public int[] Shuffle(int[] nums, int n)
	{
		if (n == 1) return nums;

		int[] result = new int[nums.Length];
		int j = 0;
		for (int i = 0; i < n; i++)
		{
			result[j++] = nums[i];
			result[j++] = nums[i + n];
		}
		return result;
	}
}

[Theory]
[InlineData(new[] { 2, 5, 1, 3, 4, 7 }, 3, new[] { 2, 3, 5, 4, 1, 7 })]
[InlineData(new[] { 1, 2, 3, 4, 4, 3, 2, 1 }, 4, new[] { 1, 4, 2, 3, 3, 2, 4, 1 })]
[InlineData(new[] { 1, 1, 2, 2 }, 2, new[] { 1, 2, 1, 2 })]
public void TestShuffle(int[] nums, int n, int[] expected)
{
	int[] result = new Solution().Shuffle(nums, n);
	Assert.Equal(expected, result);
}

/*
Example 1:
Input: nums = [2,5,1,3,4,7], n = 3
Output: [2,3,5,4,1,7] 
Explanation: Since x1=2, x2=5, x3=1, y1=3, y2=4, y3=7 then the answer is [2,3,5,4,1,7].

Example 2:
Input: nums = [1,2,3,4,4,3,2,1], n = 4
Output: [1,4,2,3,3,2,4,1]

Example 3:
Input: nums = [1,1,2,2], n = 2
Output: [1,2,1,2]

*/