namespace LeetCode.Solutions.Easy;

public class Solution
{
    public int[][] MatrixReshape(int[][] matrix, int r, int c)
    {
        int[] flat = Flatten(matrix);
        if (r * c != flat.Length) return matrix;
        int[][] result = new int[r][];


        int index = 0;
        for (int row = 0; row < r; row++)
        {
            int[] currentRow = new int[c];
            for (int col = 0; col < c; col++)
            {
                currentRow[col] = flat[index++];
            }
            result[row] = currentRow;
        }

        return result;
    }

    internal int[] Flatten(int[][] matrix)
    {
        int[] flat = new int[matrix.Length * matrix[0].Length];
        for (int i = 0; i < matrix.Length; i++)
        {
            for (int j = 0; j < matrix[i].Length; j++)
            {
                int pos = i * matrix[0].Length + j;
                flat[pos] = matrix[i][j];
            }
        }
        return flat;
    }
}
