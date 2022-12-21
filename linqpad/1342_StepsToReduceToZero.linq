<Query Kind="Program" />

void Main()
{
	Test(14, 6);
	Test(8, 4);
	Test(123, 12);
}

public void Test(int num, int expected)
{
	int result = new Solution().NumberOfSteps(num);
	if (result == expected)
	{
		Console.WriteLine($"{num} PASS: {expected}");
		
	}
	else
	{
		Console.WriteLine($"{num} FAIL: {expected} != {result}");
	}
}

public class Solution
{
	public int NumberOfSteps(int num)
	{
		int val = num;
		int steps = 0;
		while (val > 0)
		{
			if (val % 2 == 0)
			{
				val /= 2;
			}
			else
			{
				val -= 1;
			}
			steps++;
		}
		
		return steps;
	}
}