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
	public int MaxProfit(int[] prices)
	{
		int maxProfit = 0;
		int profit = 0;
		int buy = int.MaxValue;
		int sell = int.MinValue;

		for (int i = 0; i < prices.Length; i++)
		{
			if (prices[i] < buy)
			{
				if (sell > int.MinValue)
				{
					profit = sell - buy;
					if (profit > maxProfit)
					{
						maxProfit = profit;
						sell = int.MinValue;
					}
				}
				buy = prices[i];
			}
			if (prices[i] > sell && prices[i] > buy)
			{
				sell = prices[i];
			}
		}
		profit = 0;
		if (buy < int.MaxValue && sell > int.MinValue)
		{
			profit = sell - buy;
		}
		return Math.Max(profit, maxProfit);
	}

	public int MaxProfit_1(int[] prices)
	{
		int previousBuy = int.MaxValue;
		int previousSell = int.MinValue;
		int previousProfit() => previousBuy < int.MaxValue && previousSell > int.MinValue ? previousSell - previousBuy : 0;
		int buy = int.MaxValue;
		int sell = int.MinValue;
		int profit() => buy < int.MaxValue && sell > int.MinValue ? sell - buy : 0;
		for (int i = 0; i < prices.Length; i++)
		{
			if (prices[i] < buy)
			{
				if (sell > int.MinValue)
				{
					if (profit() > previousProfit())
					{
						previousBuy = buy;
						previousSell = sell;
						sell = int.MinValue;
					}
				}
				buy = prices[i];
			}
			if (prices[i] > sell && prices[i] > buy)
			{
				sell = prices[i];
			}
		}
		return Math.Max(profit(), previousProfit());
	}
}

#region Tests

[Theory]
[InlineData(new[] { 7, 1, 5, 3, 6, 4 }, 5)]
[InlineData(new[] { 7, 6, 4, 3, 1 }, 0)]
[InlineData(new[] { 2, 4, 1 }, 2)]
void Test(int[] prices, int expected)
{
	int result = new Solution().MaxProfit(prices);
	Assert.Equal(expected, result);
}

/*
Input:
[2,4,1]
Output:
0
Expected:
2

Example 1:
Input: prices = [7,1,5,3,6,4]
Output: 5
Explanation: Buy on day 2 (price = 1) and sell on day 5 (price = 6), profit = 6-1 = 5.
Note that buying on day 2 and selling on day 1 is not allowed because you must buy before you sell.

Example 2:
Input: prices = [7,6,4,3,1]
Output: 0
Explanation: In this case, no transactions are done and the max profit = 0.
*/

#endregion