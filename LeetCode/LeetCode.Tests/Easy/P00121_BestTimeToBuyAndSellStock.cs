using LeetCode.Solutions.Easy.P00121_BestTimeToBuyAndSellStock;

namespace LeetCode.Tests.Easy.P00121_BestTimeToBuyAndSellStock;

public class Tests
{
    [Test]
    [TestCase(new[] { 7, 1, 5, 3, 6, 4 }, 5)]
    [TestCase(new[] { 7, 6, 4, 3, 1 }, 0)]
    [TestCase(new[] { 2, 4, 1 }, 2)]
    public void Test(int[] prices, int expected)
    {
        int result = new Solution().MaxProfit(prices);
        Assert.AreEqual(expected, result);
    }

}