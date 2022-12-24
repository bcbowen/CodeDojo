namespace LeetCode.Solutions.P00054_SpiralMatrix;

public class Solution
{
    public IList<int> SpiralOrder(int[][] matrix)
    {
        List<int> values = new List<int>();

        if (matrix == null || matrix.Length == 0) return values;

        if (matrix.Length == 1)
        {
            values.AddRange(matrix[0]);
            return values;
        }
        int size = matrix.Length * matrix[0].Length;

        int xStart = 0;
        int xEnd = matrix[0].Length - 1;
        int yStart = 0;
        int yEnd = matrix.Length - 1;

        while (yStart <= yEnd && xStart <= xEnd)
        {
            for (int x = xStart; x <= xEnd; x++)
            {
                values.Add(matrix[yStart][x]);
            }
            yStart++;
            if (values.Count == size) break;

            for (int y = yStart; y <= yEnd; y++)
            {
                values.Add(matrix[y][xEnd]);
            }
            if (values.Count == size) break;
            xEnd--;

            for (int x = xEnd; x >= xStart; x--)
            {
                values.Add(matrix[yEnd][x]);
            }
            yEnd--;
            if (values.Count == size) break;

            for (int y = yEnd; y >= yStart; y--)
            {
                values.Add(matrix[y][xStart]);
            }
            xStart++;
            if (values.Count == size) break;
        }

        return values;
    }
}