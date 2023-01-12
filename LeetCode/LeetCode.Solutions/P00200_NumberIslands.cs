namespace LeetCode.Solutions.P00200_NumberIslands;

public class Solution
{
    private char[][] _grid;
    public int NumIslands(char[][] grid)
    {
        _grid = grid;
        int count = 0;
        for (int m = 0; m < _grid.Length; m++) 
        {
            for (int n = 0; n < _grid[0].Length; n++) 
            {
                if (_grid[m][n] == '1') 
                {
                    count++;
                    Bfs(m, n);
                }
            }
        }

        return count;
    }

    private void Bfs(int m, int n) 
    {
        Queue<(int, int)> q = new Queue<(int, int)> ();
        q.Enqueue((m, n));
        
        while (q.Count > 0) 
        { 
            (m, n) = q.Dequeue();
            if (m < _grid.Length - 1 && _grid[m + 1][n] == '1') 
            {
                q.Enqueue((m + 1, n));
                _grid[m + 1][n] = '0';
            }
            if (m > 0 && _grid[m - 1][n] == '1')
            {
                q.Enqueue((m - 1, n));
                _grid[m - 1][n] = '0';
            }
            if (n < _grid[0].Length - 1 && _grid[m][n + 1] == '1') 
            {
                q.Enqueue((m, n + 1));
                _grid[m][n + 1] = '0';
            }
            if (n > 0 && _grid[m][n - 1] == '1')
            {
                q.Enqueue((m, n - 1));
                _grid[m][n - 1] = '0';
            }
        }
    }
}