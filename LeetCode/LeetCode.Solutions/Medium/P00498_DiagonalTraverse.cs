namespace LeetCode.Solutions.Medium;

public class Solution
{
    public int[] FindDiagonalOrder(int[][] matrix)
    {
        if (matrix.Length == 1 && matrix[0].Length == 1)
        {
            return new[] { matrix[0][0] };
        }

        bool climbing = true;
        bool done = false;
        int m = matrix.Length;
        int n = matrix[0].Length;
        int[] values = new int[m * n];

        int x = 0;
        int y = 0;

        int index = 0;
        while (!done)
        {
            values[index++] = matrix[y][x];
            if (climbing)
            {
                if (y == 0)
                {
                    climbing = false;
                    if (x < n - 1)
                    {
                        x++;
                    }
                    else
                    {
                        y++;
                        climbing = false;
                    }
                }
                else
                {
                    if (x < n - 1)
                    {
                        y--;
                        x++;
                    }
                    else
                    {
                        climbing = false;
                        y++;
                    }
                }
            }
            else
            {
                if (x == 0)
                {
                    climbing = true;
                    if (y < m - 1)
                    {
                        y++;
                    }
                    else
                    {
                        x++;
                    }
                }
                else
                {
                    if (y < m - 1)
                    {
                        x--;
                        y++;
                    }
                    else
                    {
                        climbing = true;
                        x++;
                    }

                }
            }

            if (y == m - 1 && x == n - 1)
            {
                done = true;
                values[index] = matrix[y][x];
            }

        }
        return values;
    }
}
