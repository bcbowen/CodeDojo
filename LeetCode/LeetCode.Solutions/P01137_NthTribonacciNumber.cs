namespace LeetCode.Solutions.P01137_NthTribonacciNumber;

public class Solution
{
    public int Tribonacci(int n)
    {
        if (n < 3) return n < 2 ? n : 1;


        int[] tribs = new int[n + 1];
        tribs[0] = 0;
        tribs[1] = 1;
        tribs[2] = 1;

        for (int i = 3; i < tribs.Length; i++)
        {
            tribs[i] = tribs[i - 3] + tribs[i - 2] + tribs[i - 1];
        }

        return tribs[tribs.Length - 1];
    }
}