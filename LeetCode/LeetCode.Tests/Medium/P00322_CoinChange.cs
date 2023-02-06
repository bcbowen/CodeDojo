using LeetCode.Solutions.Medium.P00322_CoinChange;

namespace LeetCode.Tests.Medium;

public class Tests
{
    [TestCase(new[] { 1, 2, 5 }, 11, 3)]
    [TestCase(new[] { 2 }, 3, -1)]
    [TestCase(new[] { 1 }, 0, 0)]
    [TestCase(new[] { 186, 419, 83, 408 }, 6249, 20)]
    public void Test(int[] coins, int amount, int expected)
    {
        int result = new Solution().CoinChange(coins, amount);
        Assert.That(result, Is.EqualTo(expected));
    }

}