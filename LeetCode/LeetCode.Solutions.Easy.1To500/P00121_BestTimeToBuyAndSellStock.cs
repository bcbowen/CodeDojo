namespace LeetCode.Solutions.Easy.P00121_BestTimeToBuyAndSellStock;

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