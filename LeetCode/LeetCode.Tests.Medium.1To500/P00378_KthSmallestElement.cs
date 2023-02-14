using LeetCode.Solutions.Medium.P00378_KthSmallestElement;

namespace LeetCode.Tests.Medium.P00378_KthSmallestElement;

[TestFixture]
[Category("Medium")]
public class Tests
{
    [TestCase(2, 1, new[] { 1, 2 }, new[] { 1, 3 })]
    [TestCase(8, 13, new[] { 1, 5, 9 }, new[] { 10, 11, 13 }, new[] { 12, 13, 15 })]
    [TestCase(1, -5, new[] { -5 })]
    public void Test(int k, int expected, params int[][] matrix)
    {
        int result = new Solution().KthSmallest(matrix, k);
        Assert.That(result, Is.EqualTo(expected));
    }


}