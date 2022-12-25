namespace LeetCode.Solutions.P00188_BestTimeToBuyAndSellStockIV;

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