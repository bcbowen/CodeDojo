using LeetCode.Solutions.Medium.P00054_SpiralMatrix;

namespace LeetCode.Tests.Medium.P00054_SpiralMatrix;

public class Tests
{
    [Test]
    [TestCase(new[] { 2, 3, 4, 7, 10, 13, 16, 15, 14, 11, 8, 5, 6, 9, 12 }, new[] { 2, 3, 4 }, new[] { 5, 6, 7 }, new[] { 8, 9, 10 }, new[] { 11, 12, 13 }, new[] { 14, 15, 16 })]
    [TestCase(new[] { 1, 2, 3, 4, 8, 12, 16, 15, 14, 13, 9, 5, 6, 7, 11, 10 }, new[] { 1, 2, 3, 4 }, new[] { 5, 6, 7, 8 }, new[] { 9, 10, 11, 12 }, new[] { 13, 14, 15, 16 })]
    [TestCase(new int[0], new int[0])]
    [TestCase(new[] { 1, 2, 3, 6, 9, 8, 7, 4, 5 }, new[] { 1, 2, 3 }, new[] { 4, 5, 6 }, new[] { 7, 8, 9 })]
    [TestCase(new[] { 1, 2, 3, 4, 8, 12, 11, 10, 9, 5, 6, 7 }, new[] { 1, 2, 3, 4 }, new[] { 5, 6, 7, 8 }, new[] { 9, 10, 11, 12 })]
    [TestCase(new[] { 1, 2 }, new[] { 1, 2 })]
    [TestCase(new[] { 1 }, new[] { 1 })]
    [TestCase(new[] { 1, 2, 3, 4 }, new[] { 1, 2 }, new[] { 4, 3 })]
    [TestCase(new[] { 1, 2, 3, 4 }, new[] { 1 }, new[] { 2 }, new[] { 3 }, new[] { 4 })]
    [TestCase(new[] { 3, 2 }, new[] { 3 }, new[] { 2 })]
    [TestCase(new[] { 1, 2, 3, 4, 8, 7, 6, 5 }, new[] { 1, 2, 3, 4 }, new[] { 5, 6, 7, 8 })]
    [TestCase(new[] { 1, 2, 4, 6, 8, 7, 5, 3 }, new[] { 1, 2 }, new[] { 3, 4 }, new[] { 5, 6 }, new[] { 7, 8 })]
    public void Test(int[] expected, params int[][] matrix)
    {
        int[] result = new Solution().SpiralOrder(matrix).ToArray();
        Assert.AreEqual(expected, result);
    }

}