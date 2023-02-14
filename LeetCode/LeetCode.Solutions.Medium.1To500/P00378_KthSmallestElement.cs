namespace LeetCode.Solutions.Medium.P00378_KthSmallestElement;

public class Solution
{
    public int KthSmallest(int[][] matrix, int k)
    {
        int[] flat = Flatten(matrix);
        if (flat.Length == 1) return flat[0];

        Array.Sort(flat);
        return flat[k - 1];
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