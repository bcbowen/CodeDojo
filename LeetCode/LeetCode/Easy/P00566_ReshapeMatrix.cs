using LeetCode.Solutions.P00566_ReshapeMatrix;

namespace LeetCode.Tests.Easy;

public class Tests
{
    [TestCase(1, 4, new[] { 1, 2 }, new[] { 3, 4 })]
    [TestCase(2, 2, new[] { 1, 2 }, new[] { 3, 4 })]
    [TestCase(2, 3, new[] { 1, 2, 3 }, new[] { 4, 5, 6 })]
    [TestCase(3, 2, new[] { 1, 2, 3 }, new[] { 4, 5, 6 })]
    public void ReshapeTestValidData(int r, int c, params int[][] matrix)
    {
        int[][] result = new Solution().MatrixReshape(matrix, r, c);
        Assert.AreEqual(r, result.Length);
        Assert.AreEqual(c, result[0].Length);
    }

    [Theory]
    [TestCase(2, 4, new[] { 1, 2 }, new[] { 3, 4 })]
    public void ReshapeTestInalidData(int r, int c, params int[][] matrix)
    {
        int[][] result = new Solution().MatrixReshape(matrix, r, c);
        Assert.AreEqual(matrix, result);
    }


    [TestCase(new[] { 1, 2 }, new[] { 1 }, new[] { 2 })]
    [TestCase(new[] { 1, 2, 3, 4 }, new[] { 1, 2 }, new[] { 3, 4 })]
    [TestCase(new[] { 1, 2, 3, 4 }, new[] { 1, 2, 3, 4 })]
    [TestCase(new[] { 1, 2, 3, 4, 5, 6 }, new[] { 1, 2, 3 }, new[] { 4, 5, 6 })]
    [TestCase(new[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 }, new[] { 1, 2, 3 }, new[] { 4, 5, 6 }, new[] { 7, 8, 9 })]
    public void FlattenTest(int[] expected, params int[][] matrix)
    {
        int[] result = new Solution().Flatten(matrix);
        Assert.AreEqual(expected, result);
    }


}