namespace LeetCode.Solutions.Easy.P01672_RichestCustomerWealth;

public class Solution
{
    public int MaximumWealth(int[][] accounts)
    {
        int max = 0;
        foreach (int[] account in accounts)
        {
            int wealth = 0;
            for (int i = 0; i < account.Length; i++)
            {
                wealth += account[i];
            }
            if (wealth > max)
            {
                max = wealth;
            }
        }
        return max;
    }
}