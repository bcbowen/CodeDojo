using LeetCode.Solutions.P00221_MaxSquare;

namespace Medium;

public class Tests
{
    [TestCase(4, new[] { '1', '0', '1', '0', '0' }, new[] { '1', '0', '1', '1', '1' }, new[] { '1', '1', '1', '1', '1' }, new[] { '1', '0', '0', '1', '0' })]
    [TestCase(1, new[] { '0', '1' }, new[] { '1', '0' })]
    [TestCase(0, new[] { '0' })]
    [TestCase(1, new[] { '1' })]
    [TestCase(1, new[] { '0' }, new[] { '1' })]
    [TestCase(9, new[] { '0', '1', '1', '1', '0' }, new[] { '1', '1', '1', '1', '1' }, new[] { '0', '1', '1', '1', '1' }, new[] { '0', '1', '1', '1', '1' }, new[] { '0', '0', '1', '1', '1' })]
    public void Test(int expected, params char[][] matrix)
    {
        int result = new Solution().MaximalSquare(matrix);
        Assert.AreEqual(expected, result);
    }


}