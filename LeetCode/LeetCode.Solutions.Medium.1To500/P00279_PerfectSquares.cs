namespace LeetCode.Solutions.Medium.P00279_PerfectSquares;

public class Solution
{
    /// <summary>
    /// Not working...revisit
    /// </summary>
    /// <param name="n"></param>
    /// <returns></returns>
    public int NumSquares(int n)
    {
        int[] squares = GetSquares(n);
        Queue<(int, int)> totals = new Queue<(int, int)>();
        bool found = false;
        int count = 1;
        HashSet<int> values= new HashSet<int>();
        foreach (int i in squares) 
        {
            if (i == n) return 1;
            totals.Enqueue((count, i));
        }
        totals.Enqueue((0, 0));
        count++; 
        while (!found) 
        {
            (int c, int v) = totals.Dequeue();
            if (c == 0)
            {
                count++;              
                totals.Enqueue((0, 0));
                continue;
            }
            foreach (int s in squares) 
            {
                int value = v + s;
                if (value == n) 
                {
                    found = true;
                    break;
                }
                if (value < n && !values.Contains(value)) 
                {
                    totals.Enqueue((count, value)); 
                }
            }
            
        }

        return count;
    }

    private int[] GetSquares(int n)
    {
        List<int> squares = new List<int>();
        int root = 1;
        int square = 1;
        while (square <= n)
        {
            squares.Add(square);
            root++;
            square = root * root;
        }

        return squares.ToArray();
    }
}