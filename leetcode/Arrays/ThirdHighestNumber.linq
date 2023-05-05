<Query Kind="Program" />

void Main()
{
	/*
	Input: nums = [3,2,1]
Output: 1
Explanation:
The first distinct maximum is 3.
The second distinct maximum is 2.
The third distinct maximum is 1.
Example 2:

Input: nums = [1,2]
Output: 2
Explanation:
The first distinct maximum is 2.
The second distinct maximum is 1.
The third distinct maximum does not exist, so the maximum (2) is returned instead.
Example 3:

Input: nums = [2,2,3,1]
Output: 1
Explanation:
The first distinct maximum is 3.
The second distinct maximum is 2 (both 2's are counted together since they have the same value).
The third distinct maximum is 1.
	*/
	Test(new[] {3, 2, 1}, 1);
	Test(new[] {1, 2}, 2);
	Test(new[] {2,2,3,1}, 1);
	Test(new[] {1,2,-2147483648}, -2147483648);
}

public void Test(int[] nums, int expected) 
{
	int result = new Solution().ThirdMax(nums);
	if (expected == result) 
	{
		Console.WriteLine("PASS");
	}
	else
	{
		Console.WriteLine($"FAIL {expected} {result}");
	}
	
}

public class Solution
{
	public int ThirdMax(int[] nums)
	{
		int? a = null;
		int? b = null;
		int? c = null;

		foreach (int num in nums)
		{
			if (!c.HasValue || num > c.Value)
			{
				if (!b.HasValue || num > b.Value)
				{
					if (!a.HasValue || num > a.Value)
					{
						c = b;
						b = a;
						a = num;
					}
					else if (num < a)
					{
						c = b;
						b = num;
					}
				}
				else if (num < b)
				{
					c = num;
				}
			}
		}
		
		return c.HasValue ? c.Value : a.Value;
	}
}
