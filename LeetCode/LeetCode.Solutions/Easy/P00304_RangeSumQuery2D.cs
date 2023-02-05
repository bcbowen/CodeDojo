namespace LeetCode.Solutions.Easy;

public class NumMatrix
{
    private int[][] _matrix;
    public NumMatrix(int[][] matrix)
    {
        _matrix = matrix;
    }

    /// <summary>
    /// This doesn't work... the original implementation exceeds the time limit... need to refactor
    /// </summary>
    /// <param name="row1"></param>
    /// <param name="col1"></param>
    /// <param name="row2"></param>
    /// <param name="col2"></param>
    /// <returns></returns>
    public int SumRegion(int row1, int col1, int row2, int col2)
    {
        // TODO: Refactor
        int sum = 0;
        for (int row = row1; row <= row2; row++)
        {
            for (int col = col1; col <= col2; col++)
            {
                sum += _matrix[row][col];
            }
        }
        return sum;
    }
}
