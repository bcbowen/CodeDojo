<Query Kind="Program">
  <Namespace>Xunit</Namespace>
</Query>

#load "xunit"

void Main()
{
	RunTests();  // Call RunTests() or press Alt+Shift+T to initiate testing.
}

[Theory]
[InlineData(new[] { 1, 3, 2, 1, 3, 2, 2 }, new[] { 3, 1 })]
[InlineData(new[] { 1, 1 }, new[] { 1, 0 })]
[InlineData(new[] { 0 }, new[] { 0, 1 })]
public void Test(int[] nums, int[] expected)
{
	int[] result = new Solution().NumberOfPairs(nums);
	Assert.Equal(expected, result);
}
public class Solution
{
	public int[] NumberOfPairs(int[] nums)
	{
		int[] result = new int[2];

		Dictionary<int, int> valueCounts = new Dictionary<int, int>();
		foreach(int num in nums)
		{
			if (valueCounts.ContainsKey(num)) 
			{
				valueCounts[num]++; 
			}
			else 
			{
				valueCounts.Add(num, 1);
			}
		}
		
		int singles = 0;
		int pairs = 0;
		foreach(int key in valueCounts.Keys) 
		{
			singles += valueCounts[key] % 2;
			pairs += valueCounts[key] / 2; 
		}
		result[0] = pairs; 
		result[1] = singles;
		return result;
	}
}

