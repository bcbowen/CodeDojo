using LeetCode.Solutions.P00498_DiagonalTraverse;

namespace Medium;

public class Tests
{
    [TestCase(new[] { 2, 3 }, new[] { 2, 3 })]
    [TestCase(new[] { 1, 2, 4, 7, 5, 3, 6, 8, 9 }, new[] { 1, 2, 3 }, new[] { 4, 5, 6 }, new[] { 7, 8, 9 })]
    [TestCase(new[] { 1, 2, 3, 4 }, new[] { 1, 2 }, new[] { 3, 4 })]
    [TestCase(new[] { 1 }, new[] { 1 })]
    [TestCase(new[] { 1, 2, 5, 9, 6, 3, 4, 7, 10, 13, 14, 11, 8, 12, 15, 16 }, new[] { 1, 2, 3, 4 }, new[] { 5, 6, 7, 8 }, new[] { 9, 10, 11, 12 }, new[] { 13, 14, 15, 16 })]
    [TestCase(new[] { 1, 2, 5, 6, 3, 4, 7, 8 }, new[] { 1, 2, 3, 4 }, new[] { 5, 6, 7, 8 })]
    public void Test(int[] expected, params int[][] mat)
    {
        int[] result = new Solution().FindDiagonalOrder(mat);
        Assert.That(result, Is.EqualTo(expected));

    }



}