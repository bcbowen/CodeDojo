<Query Kind="Program" />

void Main()
{
	Test(new[] { 1,3,2,1,3,2,2}, new[] {3,1});
	Test(new[] { 1,1}, new[] {1,0});
	Test(new[] {0 }, new[] {0,1});
}

public void Test(int[] nums, int[] expected) 
{
	int[] result = new Solution().NumberOfPairs(nums);
	if (result[0] == expected[0] && result[1] == expected[1]) 
	{
		Console.WriteLine("PASS");
	}
	else
	{
		Console.WriteLine($"FAIL: [{expected[0]},{expected[1]}] != [{result[0]}{result[1]}]");
	}
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