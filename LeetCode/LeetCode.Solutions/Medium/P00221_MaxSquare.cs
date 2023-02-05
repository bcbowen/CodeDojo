namespace LeetCode.Solutions.P00221_MaxSquare;

public class Solution
{
    public int MaximalSquare(char[][] matrix)
    {
        int maxSize = 0;
        // create totals array the same size as matrix and initialize 1st col with copy from matrix
        int[][] totals = new int[matrix.Length][];
        for (int i = 0; i < totals.Length; i++)
        {
            totals[i] = new int[matrix[i].Length];
            int value = int.Parse(matrix[i][0].ToString());
            totals[i][0] = value;
            maxSize = Math.Max(maxSize, value);
        }
        // copy 1st row from matrix to totals
        for (int i = 0; i < totals[0].Length; i++)
        {
            int value = int.Parse(matrix[0][i].ToString());
            totals[0][i] = value;
            maxSize = Math.Max(maxSize, value);
        }

        // fill in totals of cells from second row and column out
        for (int i = 1; i < matrix.Length; i++)
        {
            for (int j = 1; j < matrix[i].Length; j++)
            {
                if (matrix[i][j] == '1')
                {
                    int value = Math.Min(
                        Math.Min(
                            totals[i - 1][j],
                            totals[i - 1][j - 1]
                        ),
                        totals[i][j - 1]
                    ) + 1;
                    totals[i][j] = value;
                    maxSize = Math.Max(maxSize, value);
                }
                else
                {
                    totals[i][j] = 0;
                }
            }
        }

        return maxSize * maxSize;
    }
}