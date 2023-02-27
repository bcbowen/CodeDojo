<Query Kind="Program" />

void Main()
{
	Test(new[] { 18,43,36,13,7 }, 54);
	Test(new[] { 10, 12, 19, 14 }, -1);
	Test(new[] { 229, 398, 269, 317, 420, 464, 491, 218, 439, 153, 482, 169, 411, 93, 147, 50, 347, 210, 251, 366, 401}, 973);

}

public void Test(int[] nums, int expected)
{
	int result = new Solution().MaximumSum(nums);
	if (result == expected)
	{
		Console.WriteLine("PASS");
	}
	else
	{
		Console.WriteLine($"FAIL: {expected} != {result}");
	}
}

public class Solution
{
	public int MaximumSum(int[] nums)
	{
		Dictionary<int, int[]> pairs = new Dictionary<int, int[]>();

		foreach (int num in nums) 
		{
			int sumDigits = SumDigits(num);
			if(pairs.ContainsKey(sumDigits))
			{
				int temp;
				if (num > pairs[sumDigits][1])
				{
					temp = pairs[sumDigits][1];
					pairs[sumDigits][1] = num;
					if (temp > pairs[sumDigits][0]) 
					{
						pairs[sumDigits][0] = temp;
					}
				}
				else if (num > pairs[sumDigits][0])
				{
					pairs[sumDigits][0] = num;
				}				
			}
			else
			{
				pairs.Add(sumDigits, new [] { num, 0 });
			}
			
		}

		int maxSum = -1;
		foreach (int key in pairs.Keys)
		{
			if (pairs[key][1] > 0) 
			{
				int sum = pairs[key][0] + pairs[key][1]; 
				if (sum > maxSum) maxSum = sum; 
			}
		}
		
		return maxSum;
	}

	private int SumDigits(int val)
	{
		int sum = 0;
		while (val > 0)
		{
			sum += val % 10;
			val /= 10;
		}

		return sum;
	}

}