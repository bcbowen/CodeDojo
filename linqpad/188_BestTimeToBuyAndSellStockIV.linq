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
	private int[] _prices;
	private int[][][] _memo;
	internal int RecurrenceRelation(int i, int k, int holding)
	{
		// base cases
		if (k == 0 || i == _prices.Length) return 0;

		if (_memo[i][k][holding] == 0)
		{
			int doNothing = RecurrenceRelation(i + 1, k, holding);
			int doSomething;

			if (holding == 1)
			{
				// Sell Stock
				doSomething = _prices[i] + RecurrenceRelation(i + 1, k - 1, 0);
			}
			else
			{
				// Buy Stock
				doSomething = -_prices[i] + RecurrenceRelation(i + 1, k, 1);
			}

			// Recurrence relation. Choose the most profitable option.
			_memo[i][k][holding] = Math.Max(doNothing, doSomething);
		}
		return _memo[i][k][holding];
	}

	public int MaxProfit(int k, int[] prices)
	{
		_prices = prices;
		_memo = new int[prices.Length][][];
		for (int i = 0; i < prices.Length; i++)
		{
			_memo[i] = new int[k + 1][];
			for (int j = 0; j <= k; j++)
			{
				_memo[i][j] = new int[2];
			}
		}

		return RecurrenceRelation(0, k, 0);
	}
}

#region private::Tests

[Theory]
[InlineData(2, new[] { 2, 4, 1 }, 2)]
[InlineData(2, new[] { 3, 2, 6, 5, 0, 3 }, 7)]
[InlineData(1, new[] { 1, 2 }, 1)]
void Test(int k, int[] prices, int expected)
{
	int result = new Solution().MaxProfit(k, prices);
	Assert.Equal(expected, result);
}

/*
Example 1:

Input: k = 2, prices = [2,4,1]
Output: 2
Explanation: Buy on day 1 (price = 2) and sell on day 2 (price = 4), profit = 4-2 = 2.
Example 2:

Input: k = 2, prices = [3,2,6,5,0,3]
Output: 7
Explanation: Buy on day 2 (price = 2) and sell on day 3 (price = 6), profit = 6-2 = 4. Then buy on day 5 (price = 0) and sell on day 6 (price = 3), profit = 3-0 = 3.
*/

#endregion