namespace LeetCode.Solutions.Easy.P00070_ClimbStairs;

public class Solution
{
    public int ClimbStairs(int n)
    {
        if (n == 1) return n;

        int[] results = new int[n + 1];

        int index = 1;
        results[index++] = 1;
        results[index++] = 2;
        while (index <= n)
        {
            results[index] = results[index - 1] + results[index - 2];
            index++;
        }

        return results[n];
    }
}