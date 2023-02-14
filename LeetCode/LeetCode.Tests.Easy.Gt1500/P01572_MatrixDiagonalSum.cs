using LeetCode.Solutions.Easy.P01572_MatrixDiagonalSum;

namespace LeetCode.Tests.Easy.P01572_MatrixDiagonalSum;

[TestFixture]
[Category("Easy")]
public partial class Tests
{
    [TestCase(25, new[] { 1, 2, 3 }, new[] { 4, 5, 6 }, new[] { 7, 8, 9 })]
    [TestCase(8, new[] { 1, 1, 1, 1 }, new[] { 1, 1, 1, 1 }, new[] { 1, 1, 1, 1 }, new[] { 1, 1, 1, 1 })]
    [TestCase(5, new[] { 5 })]
    public void Test(int expected, params int[][] mat)
    {
        int result = new Solution().DiagonalSum(mat);
        Assert.That(result, Is.EqualTo(expected));
    }

}