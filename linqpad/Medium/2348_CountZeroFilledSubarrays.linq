<Query Kind="Program">
  <Namespace>Xunit</Namespace>
</Query>

#load "xunit"

void Main()
{
	RunTests();  // Call RunTests() or press Alt+Shift+T to initiate testing.
	/*
	
Input: nums = [1,3,0,0,2,0,0,4]
Output: 6
Explanation: 
There are 4 occurrences of [0] as a subarray.
There are 2 occurrences of [0,0] as a subarray.
There is no occurrence of a subarray with a size more than 2 filled with 0. Therefore, we return 6.
Example 2:

Input: nums = [0,0,0,2,0,0]
Output: 9
Explanation:
There are 5 occurrences of [0] as a subarray.
There are 3 occurrences of [0,0] as a subarray.
There is 1 occurrence of [0,0,0] as a subarray.
There is no occurrence of a subarray with a size more than 3 filled with 0. Therefore, we return 9.
Example 3:

Input: nums = [2,10,2019]
Output: 0
Explanation: There is no subarray filled with 0. Therefore, we return 0.
	*/
}


public class Solution
{
	public long ZeroFilledSubarray(int[] nums)
	{
		int i = 0;
		int j = 0;
		long sum = 0;
		while (i < nums.Length)
		{
			if (nums[i] != 0)
			{
				if (j < i) sum += SumFactor(i - j);
				j = i + 1;
			}
			i++;
		}
		if (j < i) sum += SumFactor(i - j);
		return sum;
	}

	private long SumFactor(int i)
	{
		long sum = 0;
		while (i > 0)
		{
			sum += i--;
		}
		return sum;
	}
}

[Theory]
[InlineData(new[] { 1, 3, 0, 0, 2, 0, 0, 4 }, 6)]
[InlineData(new[] { 0, 0, 0, 2, 0, 0 }, 9)]
[InlineData(new[] { 2, 10, 2019 }, 0)]
public void Test(int[] nums, long expected)
{
	long result = new Solution().ZeroFilledSubarray(nums);
	Assert.Equal(expected, result);
}

[Fact]
public void HugeTest()
{
	int[] nums = new int[100_000];
	long expected = 5000050000;
	long result = new Solution().ZeroFilledSubarray(nums);
	Assert.Equal(expected, result);
}
