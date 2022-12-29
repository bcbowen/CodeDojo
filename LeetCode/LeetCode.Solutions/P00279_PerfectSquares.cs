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
        if (n < 2) return 1;

        double root = Math.Sqrt(n);
        if (root % 1 == 0)
        {
            return 1;
        }

        int count = 1;
        root = Math.Floor(root);
        int rootSquared = (int)root * (int)root;

        while (n > rootSquared)
        {
            count++;
            n -= rootSquared;
        }

        count += NumSquares(n);
        return count;
    }
}