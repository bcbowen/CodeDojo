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
	public int FindKthLargest(int[] nums, int k)
	{
		PriorityQueue<int, int> q = new PriorityQueue<int, int>();
		foreach (int num in nums)
		{
			q.Enqueue(num, -num);
		};

		int result = 0;
		for (int i = 0; i < k; i++)
		{
			result = q.Dequeue();
		}

		return result;
	}
}

#region private::Tests

[Fact] void Test_Xunit() => Assert.True(1 + 1 == 2);
/*
Example 1:

Input: nums = [3,2,1,5,6,4], k = 2
Output: 5
Example 2:

Input: nums = [3,2,3,1,2,4,5,5,6], k = 4
Output: 4
*/

[Theory]
[InlineData(new[] { 3, 2, 1, 5, 6, 4 }, 2, 5)]
[InlineData(new[] { 3, 2, 3, 1, 2, 4, 5, 5, 6 }, 4, 4)]
void FindKthLargestTest(int[] nums, int k, int expected)
{
	int result = new Solution().FindKthLargest(nums, k);
	Assert.Equal(expected, result);
}


#endregion