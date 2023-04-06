<Query Kind="Program">
  <Namespace>Xunit</Namespace>
</Query>

#load "xunit"

void Main()
{
	RunTests();  // Call RunTests() or press Alt+Shift+T to initiate testing.
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

[Theory]
[InlineData(14, 6)]
[InlineData(8, 4)]
[InlineData(123, 12)]
public void Test(int num, int expected)
{
	int result = new Solution().NumberOfSteps(num);
	Assert.Equal(expected, result);
}