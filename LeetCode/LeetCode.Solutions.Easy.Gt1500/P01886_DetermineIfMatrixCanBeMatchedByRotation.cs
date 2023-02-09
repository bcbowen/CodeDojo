namespace LeetCode.Solutions.Easy.P01886_DetermineIfMatrixCanBeMatchedByRotation;

public class Solution
{
    public bool FindRotation(int[][] mat, int[][] target)
    {
        if (mat.Length != target.Length) return false;

        if (AreEqual(mat, target)) return true;

        for (int i = 0; i < 4; i++)
        {
            Rotate(target);
            if (AreEqual(mat, target)) return true;
        }
        return false;
    }

    internal bool AreEqual(int[][] mat, int[][] target)
    {
        for (int i = 0; i < mat.Length; i++)
        {
            for (int j = 0; j < mat[i].Length; j++)
            {
                if (mat[i][j] != target[i][j])
                {
                    return false;
                }
            }
        }
        return true;
    }

    internal void Rotate(int[][] matrix)
    {
        Transpose(matrix);
        Mirror(matrix);

    }

    internal void Transpose(int[][] matrix)
    {
        int s = matrix.Length;
        for (int y = 0; y < s; y++)
        {
            for (int x = y + 1; x < s; x++)
            {
                int temp = matrix[y][x];
                matrix[y][x] = matrix[x][y];
                matrix[x][y] = temp;
            }
        }
    }

    internal void Mirror(int[][] matrix)
    {
        int s = matrix.Length;
        for (int y = 0; y < s; y++)
        {
            for (int x = 0; x < s / 2; x++)
            {
                int temp = matrix[y][s - 1 - x];
                matrix[y][s - 1 - x] = matrix[y][x];
                matrix[y][x] = temp;
            }

        }
    }


}
