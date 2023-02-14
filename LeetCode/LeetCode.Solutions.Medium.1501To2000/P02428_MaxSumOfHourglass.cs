namespace LeetCode.Solutions.Medium.P02428_MaxSumOfHourglass;

public partial class Solution
{
    public int MaxSum(int[][] grid)
    {
        int maxSum = 0;
        for (int y = 0; y < grid.Length - 2; y++)
        {
            for (int x = 0; x < grid[0].Length - 2; x++)
            {
                maxSum = Math.Max(maxSum, GetHourGlassSum(grid, new[] { x, y }));

            }
        }
        return maxSum;
    }

    internal int GetHourGlassSum(int[][] grid, int[] corner)
    {
        int sum = 0;

        int y = corner[1];
        for (int x = corner[0]; x < corner[0] + 3; x++)
        {
            sum += grid[y][x];
        }
        y++;
        sum += grid[y][corner[0] + 1];
        y++;
        for (int x = corner[0]; x < corner[0] + 3; x++)
        {
            sum += grid[y][x];
        }

        return sum;
    }
}