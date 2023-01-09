namespace LeetCode.Solutions.P00279_PerfectSquares;

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
        int sum = 0;
        int count = 0; 
        for (int i = squares.Length - 1; i > 0; i--)
        {
            while (sum + squares[i] <= n) 
            {
                sum += squares[i];
                count++;
            }
        }

        return count;
    }

    private int[] GetSquares(int n) 
    {
        List<int> squares = new List<int>();
        int root = 1;
        int square = 1;
        while (square < n) 
        {
            squares.Add(square);
            root++;
            square = root * root; 
        }

        return squares.ToArray();
    }
}