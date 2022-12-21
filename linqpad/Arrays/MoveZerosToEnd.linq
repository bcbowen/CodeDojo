<Query Kind="Program" />

void Main()
{
	/*
	Example 1:

	Input: nums = [0,1,0,3,12]
	Output: [1,3,12,0,0]
	Example 2:

	Input: nums = [0]
	Output: [0]
	*/
	Test(new[] { 0,1,0,3,12 }, new[] { 1,3,12,0,0 });
	Test(new[] { 0 }, new[] { 0 });
	Test(new[] { 1,2,3 }, new[] { 1,2,3 });
	Test(new[] { 1, 0 }, new[] { 1, 0 });
}

public void Test(int[] nums, int[] expected) 
{

	Console.WriteLine("Original");
	nums.Dump();

	new Solution().MoveZeroes(nums);

	Console.WriteLine("After");
	nums.Dump();

	Console.WriteLine("Expected");
	expected.Dump();
}

public class Solution
{
	public void MoveZeroes(int[] nums)
	{
		int i = 0;
		int j = 0;

		while (i < nums.Length)
		{
			if (nums[i] != 0) 
			{
				nums[j++] = nums[i];
			}
			i++;
		}

		while(j < nums.Length)
		{
			nums[j++] = 0;
		}
	}
}