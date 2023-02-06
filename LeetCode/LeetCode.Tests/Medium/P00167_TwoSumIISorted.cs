using LeetCode.Solutions.Medium.P00167_TwoSumIISorted;

namespace LeetCode.Tests.Medium.P00167_TwoSumIISorted;

public class Tests
{
    [Test]
    [TestCase(new[] { 2, 7, 11, 15 }, 9, new[] { 1, 2 })]
    [TestCase(new[] { 2, 3, 4 }, 6, new[] { 1, 3 })]
    [TestCase(new[] { -1, 0 }, -1, new[] { 1, 2 })]
    public void TwoSumTest(int[] numbers, int target, int[] expected)
    {
        int[] result = new Solution().TwoSum(numbers, target);
        Assert.AreEqual(expected, result);
    }

}