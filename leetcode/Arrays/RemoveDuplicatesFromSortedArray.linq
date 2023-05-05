<Query Kind="Program" />

void Main()
{
	Test(new[] {1,1,2}, 2);
	Test(new[] {0,0,1,1,1,2,2,3,3,4}, 5);
	/*
	Input: nums = [1,1,2]
Output: 2, nums = [1,2,_]

Input: nums = [0,0,1,1,1,2,2,3,3,4]
Output: 5, nums = [0,1,2,3,4,_,_,_,_,_]
	*/
}

public void Test(int[] nums, int expected) 
{
	Console.WriteLine("BEFORE");
	nums.Dump();
	int result = new Solution().RemoveDuplicates(nums);
	if (result == expected)
	{ 
		Console.WriteLine("PASS");
		
	}
	else
	{
		Console.WriteLine($"FAIL {result} != {expected}");
	}
	Console.WriteLine("AFTER");
	nums.Dump();
}

public class Solution
{
	public int RemoveDuplicates(int[] nums)
	{
		int last = nums[0];
		int j = 1;
		for (int i = 1; i < nums.Length; i++)
		{
			if (nums[i] != last)
			{
				last = nums[i];
				nums[j++] = nums[i];
			}
		}
		return j;
	}
}