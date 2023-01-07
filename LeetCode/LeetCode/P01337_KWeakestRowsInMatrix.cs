using LeetCode.Solutions.P01337_KWeakestRowsInMatrix;

namespace LeetCode.Tests.P01337_KWeakestRowsInMatrix;

public class Tests
{
    [TestCase(3, new[] { 2, 0, 3 }, new[] { 1, 1, 0, 0, 0 }, new[] { 1, 1, 1, 1, 0 }, new[] { 1, 0, 0, 0, 0 }, new[] { 1, 1, 0, 0, 0 }, new[] { 1, 1, 1, 1, 1 })]
    [TestCase(1, new[] { 2 }, new[] { 1, 1, 1, 1, 1, 1 }, new[] { 1, 1, 1, 1, 1, 1 }, new[] { 1, 1, 1, 1, 1 })]
    public void TestWeakestRows(int k, int[] expected, params int[][] matrix)
    {
        int[] result = new Solution().KWeakestRows(matrix, k);
        Assert.That(result, Is.EqualTo(expected));
    }

}