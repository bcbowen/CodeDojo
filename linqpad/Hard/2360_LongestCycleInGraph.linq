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
	public int LongestCycle(int[] edges)
	{

	}
}

#region private::Tests

[Theory]
[InlineData(new[] { 3, 3, 4, 2, 3 }, 3)]
[InlineData(new[] { 2, -1, 3, 1 }, 3)]
void Test(int[] edges, int expected)
{
	int result = new Solution().LongestCycle(edges); 
	Assert.Equal(expected, result);
}

#endregion