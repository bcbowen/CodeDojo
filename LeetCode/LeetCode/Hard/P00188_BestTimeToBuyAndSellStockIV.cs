using LeetCode.Solutions.Hard.P00188_BestTimeToBuyAndSellStockIV;

namespace LeetCode.Tests.Hard.P00188_BestTimeToBuyAndSellStockIV;

[TestFixture]
[Category("Hard")]
public class Tests
{
    [Test]
    [TestCase(2, new[] { 2, 4, 1 }, 2)]
    [TestCase(2, new[] { 3, 2, 6, 5, 0, 3 }, 7)]
    [TestCase(1, new[] { 1, 2 }, 1)]
    public void Test(int k, int[] prices, int expected)
    {
        int result = new Solution().MaxProfit(k, prices);
        Assert.AreEqual(expected, result);
    }

}