namespace LeetCode.Solutions.P01572_MatrixDiagonalSum;

public class Solution
{
    public int DiagonalSum(int[][] mat)
    {
        int x1 = 0;
        int x2 = mat[0].Length - 1;
        int sum = 0;
        foreach (int[] row in mat)
        {
            if (x1 != x2)
            {
                sum += row[x1] + row[x2];
            }
            else
            {
                sum += row[x1];
            }
            x1++;
            x2--;
        }
        return sum;
    }
}
