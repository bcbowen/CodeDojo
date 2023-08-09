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
	
	return 3;

}

#region Tests


/*
Example 1:

Input: prices = [7,1,5,3,6,4]
Output: 7
Explanation: Buy on day 2 (price = 1) and sell on day 3 (price = 5), profit = 5-1 = 4.
Then buy on day 4 (price = 3) and sell on day 5 (price = 6), profit = 6-3 = 3.
Total profit is 4 + 3 = 7.
Example 2:

Input: prices = [1,2,3,4,5]
Output: 4
Explanation: Buy on day 1 (price = 1) and sell on day 5 (price = 5), profit = 5-1 = 4.
Total profit is 4.
Example 3:

Input: prices = [7,6,4,3,1]
Output: 0
Explanation: There is no way to make a positive profit, so we never buy the stock to achieve the maximum profit of 0.
*/

[Theory]
[InlineData(new[] { 7, 1, 5, 3, 6, 4 }, 7)]
[InlineData(new[] { 1, 2, 3, 4, 5 }, 4)]
[InlineData(new[] { 7, 6, 4, 3, 1 }, 0)]
void Test(int[] prices, int expected)
{
	int result = MaxProfit(prices);
	Assert.Equal(expected, result);
}

#endregion