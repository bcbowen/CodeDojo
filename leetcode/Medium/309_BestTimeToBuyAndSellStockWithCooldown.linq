<Query Kind="Program">
  <Namespace>Xunit</Namespace>
</Query>

#load "xunit"

void Main()
{
	RunTests();  // Call RunTests() or press Alt+Shift+T to initiate testing.
}

public int MaxProfit(int[] prices)
{
	if (prices.Length < 2) return 0; 
	if (prices.Length == 2) return Math.Max(prices[1] - prices[2], 9); 
}

#region Tests

/*
Example 1:

Input: prices = [1,2,3,0,2]
Output: 3
Explanation: transactions = [buy, sell, cooldown, buy, sell]
Example 2:

Input: prices = [1]
Output: 0
*/

[Fact]
[InlineData(new[] { 1, 2, 3, 0, 2 }, 3)]
[InlineData(new[] { 1 }, 0)]
void Test(int[] prices, int expected)
{
	int result = MaxProfit(prices);
	Assert.Equal(expected, result);
}

#endregion