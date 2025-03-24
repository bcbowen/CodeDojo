<Query Kind="Program">
  <Namespace>Xunit</Namespace>
</Query>

#load "xunit"

void Main()
{
	RunTests();  // Call RunTests() or press Alt+Shift+T to initiate testing.
}

public partial class Solution
{
	public int CountOdds(int low, int high)
	{
		if ((low & 1) == 0)
		{
			low++;
		}

		if (low > high) return 0;

		return (high - low) / 2 + 1;
	}
}


[Theory]
[InlineData(3, 7, 3)]
[InlineData(2, 7, 3)]
[InlineData(2, 8, 3)]
[InlineData(3, 8, 3)]
[InlineData(3, 3, 1)]
[InlineData(4, 4, 0)]
[InlineData(1, 7, 4)]
[InlineData(1, 8, 4)]
[InlineData(1, 9, 5)]
[InlineData(2, 10, 4)]
[InlineData(8, 10, 1)]
public void CountOddsTest(int low, int high, int expected)
{
	int result = new Solution().CountOdds(low, high);
	Assert.Equal(expected, result);
}

