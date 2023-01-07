namespace LeetCode.Solutions.P01833_MaxIceCreamBars;

public class Solution
{
    public int MaxIceCream(int[] costs, int coins)
    {
        Array.Sort(costs);
        int max = 0;
        int i = 0;
        while (coins > 0 && i < costs.Length)
        {
            if (coins < costs[i]) break;
            max++;
            coins -= costs[i];
            i++;
        }

        return max;
    }
}