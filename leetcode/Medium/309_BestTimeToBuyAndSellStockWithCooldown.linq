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
	int sold = int.MinValue; 
	int held = int.MinValue; 
	int rest = 0;

	foreach(int price in prices) 
	{
		sold = held + price; 
		held = Math.Max(held, rest - price);
		rest = Math.Max(rest, sold); 
	}
	
	return Math.Max(sold, rest); 
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

[Theory]
[InlineData(new[] { 1, 2, 3, 0, 2 }, 3)]
[InlineData(new[] { 1 }, 0)]
void Test(int[] prices, int expected)
{
	int result = MaxProfit(prices);
	Assert.Equal(expected, result);
}

#endregion