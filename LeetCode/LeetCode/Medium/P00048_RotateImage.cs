using LeetCode.Solutions.Medium.P00048_RotateImage;

namespace LeetCode.Tests.Medium.P00048_RotateImage;

[TestFixture]
[Category("Medium")]
public class Tests
{
    [Test]
    public void P00048_RotateImage_ThreeTest()
    {
        int[][] matrix = new int[3][];
        matrix[0] = new[] { 1, 2, 3 };
        matrix[1] = new[] { 4, 5, 6 };
        matrix[2] = new[] { 7, 8, 9 };

        new Solution().Rotate(matrix);
        // Input: matrix = [[1,2,3],[4,5,6],[7,8,9]]
        // Output: [[7,4,1],[8,5,2],[9,6,3]]

        int[] expected = new int[] { 7, 4, 1 };
        Assert.AreEqual(expected, matrix[0]);

        expected = new int[] { 8, 5, 2 };
        Assert.AreEqual(expected, matrix[1]);

        expected = new int[] { 9, 6, 3 };
        Assert.AreEqual(expected, matrix[2]);


    }

    [Test]
    public void P00048_RotateImage_FourTest()
    {
        int[][] matrix = new int[4][];
        matrix[0] = new[] { 5, 1, 9, 11 };
        matrix[1] = new[] { 2, 4, 8, 10 };
        matrix[2] = new[] { 13, 3, 6, 7 };
        matrix[3] = new[] { 15, 14, 12, 16 };

        new Solution().Rotate(matrix);
        // Input: matrix = [[1,2,3],[4,5,6],[7,8,9]]
        // Output: [[7,4,1],[8,5,2],[9,6,3]]

        int[] expected = new int[] { 15, 13, 2, 5 };
        Assert.AreEqual(expected, matrix[0]);

        expected = new int[] { 14, 3, 4, 1 };
        Assert.AreEqual(expected, matrix[1]);

        expected = new int[] { 12, 6, 8, 9 };
        Assert.AreEqual(expected, matrix[2]);

        expected = new int[] { 16, 7, 10, 11 };
        Assert.AreEqual(expected, matrix[3]);
    }
}