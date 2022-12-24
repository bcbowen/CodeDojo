namespace LeetCode.Solutions.P00048_RotateImage;

public class Solution
{
    public void Rotate(int[][] matrix)
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