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
	public int[] TopKFrequent(int[] nums, int k)
	{
		Dictionary<int, int> counts = new Dictionary<int, int>();
		foreach(int num in nums)
		{
			if (!counts.ContainsKey(num)) 
			{
				counts.Add(num, 0);
			}
			counts[num]++;
		}

		PriorityQueue<int, int> q = new PriorityQueue<int, int>();
		foreach(int key in counts.Keys)
		{
			q.Enqueue(key, -counts[key]);
		}

		int[] result = new int[k];
		for (int i = 0; i < k; i++) 
		{
			result[i] = q.Dequeue();
		}
		return result;
	}
}

#region private::Tests

[Fact] void Test_Xunit() => Assert.True(1 + 1 == 2);
[Theory]
[InlineData(new[] { 1, 1, 1, 2, 2, 3 }, 2, new[] { 1, 2 })]
[InlineData(new[] { 1 }, 1, new[] { 1 })]
void Test(int[] nums, int k, int[] expected)
{
	int[] result = new Solution().TopKFrequent(nums, k);
	Assert.Equal(expected, result);
}

/*
Example 1:

Input: nums = [1,1,1,2,2,3], k = 2
Output: [1,2]
Example 2:

Input: nums = [1], k = 1
Output: [1]
*/
#endregion