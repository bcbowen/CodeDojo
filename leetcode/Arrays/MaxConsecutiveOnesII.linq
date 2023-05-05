<Query Kind="Program" />

void Main()
{
	Test(new[] {1,0,1,1,0}, 4);
	Test(new[] { 1, 0, 1, 1, 0, 1 }, 4);
	Test(new[] {1,1,0,1}, 4);
	Test(new[] {1}, 1);
	/*
	Example 1:

Input: nums = [1,0,1,1,0]
Output: 4
Explanation: Flip the first zero will get the maximum number of consecutive 1s. After flipping, the maximum number of consecutive 1s is 4.
Example 2:

Input: nums = [1,0,1,1,0,1]
Output: 4
	*/
}

void Test(int[] nums, int expected)
{
	int result = new Solution().FindMaxConsecutiveOnes(nums);

	if (expected == result)
	{
		Console.WriteLine("PASS");
	} 
	else
	{
		Console.WriteLine($"FAIL: {expected} {result}");
	}
	
}

public class Solution
{
	public int FindMaxConsecutiveOnes(int[] nums)
	{
		int zerosCount = 0; 
		int left = 0; 
		int right = 0; 
		int maxOnes = 0;
		while(right < nums.Length)
		{
			if (nums[right] == 0) 
			{
				zerosCount++;
			}
			if (zerosCount > 1)
			{
				while(nums[left] != 0) 
				{
					left++;
				}
				left++;
				zerosCount--;
			}
			maxOnes = Math.Max(maxOnes, right - left + 1);
			right++;
		}
	
		return maxOnes;
	}
	
	public int FindMaxConsecutiveOnesFirst(int[] nums)
	{
		List<int> sums = new List<int>();
		int sum = 0;
		foreach (int i in nums)
		{
			if (i == 1)
			{
				sum++;
			}
			else
			{
				sums.Add(sum);
				sum = 0;
			}
		}
		sums.Add(sum);
		int max = 0;
		if (sums.Count == 1)
		{ 
			max = sums[0];
		}
		else
		{
			for (int i = 1; i < sums.Count; i++)
			{
				if (sums[i - 1] + sums[i] + 1 > max) max = sums[i - 1] + sums[i] + 1;
			}
		}
		
		return max;
	}
}
