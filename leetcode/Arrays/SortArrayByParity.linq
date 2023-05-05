<Query Kind="Program" />

void Main()
{
	/*Input: nums = [3,1,2,4]
Output: [2,4,3,1]
Explanation: The outputs [4,2,3,1], [2,4,1,3], and [4,2,1,3] would also be accepted.
Example 2:

Input: nums = [0]
Output: [0]*/
Test(new[] { 3,1,2,4 });
Test(new[] { 3 });
Test(new[] { 3,3, 3, 3 });
Test(new[] { 2, 2, 2, 2 });
Test(new[] { 3,1,2,4 });
Test(new[] { 2 });
Test(new[] { 3,2,4,1 });
}

void Test(int[] nums) 
{
	Console.WriteLine("Original");
	nums.Dump();

	int[] result = new Solution().SortArrayByParity(nums);

	Console.WriteLine("After");
	result.Dump();
}

public class Solution
{
	public int[] SortArrayByParity(int[] nums)
	{
		int[] result = new int[nums.Length];
		int e = 0;
		int o = result.Length - 1;
		foreach(int i in nums)
		{
			if (i % 2 == 0) 
			{
				result[e++] = i;
			} 
			else 
			{
				result[o--] = i;
			}
		}
		return result;
	}
}