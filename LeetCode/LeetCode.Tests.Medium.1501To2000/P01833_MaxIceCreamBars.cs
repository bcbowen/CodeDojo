using LeetCode.Solutions.Medium.P01833_MaxIceCreamBars;

namespace LeetCode.Tests.Medium.P01833_MaxIceCreamBars;

[TestFixture]
[Category("Medium")]
public class Tests
{
    /*
    Example 1:
    Input: costs = [1,3,2,4,1], coins = 7
    Output: 4
    Explanation: The boy can buy ice cream bars at indices 0,1,2,4 for a total price of 1 + 3 + 2 + 1 = 7.
    
    Example 2:
    Input: costs = [10,6,8,7,7,8], coins = 5
    Output: 0
    Explanation: The boy cannot afford any of the ice cream bars.
    
    Example 3:
    Input: costs = [1,6,3,1,2,5], coins = 20
    Output: 6
    Explanation: The boy can buy all the ice cream bars for a total price of 1 + 6 + 3 + 1 + 2 + 5 = 18.
    */
    [TestCase(new[] { 1, 3, 2, 4, 1 }, 7, 4)]
    [TestCase(new[] { 10, 6, 8, 7, 7, 8 }, 5, 0)]
    [TestCase(new[] { 1, 6, 3, 1, 2, 5 }, 20, 6)]
    [TestCase(new[] { 1 }, 1, 1)]
    [TestCase(new[] { 2 }, 1, 0)]
    public void ReverseWordsTest(int[] costs, int coins, int expected)
    {
        int result = new Solution().MaxIceCream(costs, coins);
        Assert.That(result, Is.EqualTo(expected));
    }


}