using LeetCode.Solutions.P01886_DetermineIfMatrixCanBeMatchedByRotation;

namespace LeetCode.Tests.P01886_DetermineIfMatrixCanBeMatchedByRotation;

public class Tests
{
    [Test]
    public void Test1()
    {
        /*
        Example 1:
        Input: mat = [[0,1],[1,0]], target = [[1,0],[0,1]]
        Output: true
        Explanation: We can rotate mat 90 degrees clockwise to make mat equal target.
        */

        int[][] matrix1 = new int[2][];
        matrix1[0] = new[] { 0, 1 };
        matrix1[1] = new[] { 1, 0 };

        int[][] matrix2 = new int[2][];
        matrix2[0] = new[] { 1, 0 };
        matrix2[1] = new[] { 0, 1 };

        bool expected = true;
        bool result = new Solution().FindRotation(matrix1, matrix2);
        Assert.AreEqual(expected, result);
    }

    [Test]
    public void Test2()
    {
        /*
        Example 2:
        Input: mat = [[0,1],[1,1]], target = [[1,0],[0,1]]
        Output: false
        Explanation: It is impossible to make mat equal to target by rotating mat.
        */

        int[][] matrix1 = new int[2][];
        matrix1[0] = new[] { 0, 1 };
        matrix1[1] = new[] { 1, 1 };

        int[][] matrix2 = new int[2][];
        matrix2[0] = new[] { 1, 0 };
        matrix2[1] = new[] { 0, 1 };

        bool expected = false;
        bool result = new Solution().FindRotation(matrix1, matrix2);
        Assert.AreEqual(expected, result);
    }

    [Test]
    public void Test3()
    {
        /*
        Example 3:
        Input: mat = [[0,0,0],[0,1,0],[1,1,1]], target = [[1,1,1],[0,1,0],[0,0,0]]
        Output: true
        Explanation: We can rotate mat 90 degrees clockwise two times to make mat equal target.
        */

        int[][] matrix1 = new int[3][];
        matrix1[0] = new[] { 0, 0, 0 };
        matrix1[1] = new[] { 0, 1, 0 };
        matrix1[2] = new[] { 1, 1, 1 };

        int[][] matrix2 = new int[3][];
        matrix2[0] = new[] { 1, 1, 1 };
        matrix2[1] = new[] { 0, 1, 0 };
        matrix2[2] = new[] { 0, 0, 0 };

        bool expected = true;
        bool result = new Solution().FindRotation(matrix1, matrix2);
        Assert.AreEqual(expected, result);

    }


}