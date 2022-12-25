using LeetCode.Solutions.P00119_PascalsTriangleII;

namespace LeetCode.Tests.P00119_PascalsTriangleII;

public class Tests
{
    [Test]
    [TestCase(0, new[] { 1 })]
    [TestCase(1, new[] { 1, 1 })]
    [TestCase(2, new[] { 1, 2, 1 })]
    [TestCase(3, new[] { 1, 3, 3, 1 })]
    [TestCase(4, new[] { 1, 4, 6, 4, 1 })]
    [TestCase(5, new[] { 1, 5, 10, 10, 5, 1 })]
    public void Test(int numRows, int[] expected)
    {
        IList<int> result = new Solution().Generate(numRows);
        Assert.AreEqual(expected, result.ToArray());
    }

}