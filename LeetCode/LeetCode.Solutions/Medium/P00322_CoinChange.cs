namespace LeetCode.Solutions.Medium.P00322_CoinChange;

public class Solution
{
    public int CoinChange(int[] coins, int amount)
    {
        int[] amounts = new int[amount + 1];
        Array.Fill(amounts, amount + 1);

        amounts[0] = 0;
        for (int i = 1; i <= amount; i++)
        {
            foreach (int coin in coins)
            {
                if (i - coin < 0) continue;
                amounts[i] = Math.Min(amounts[i], amounts[i - coin] + 1);
            }
        }

        return amounts[amount] < amount + 1 ? amounts[amount] : -1;
    }

    public int CoinChangeBad(int[] coins, int amount)
    {
        int coinCount = 0;
        Array.Sort(coins);

        int denominationIndex = coins.Length - 1;
        int denomination = coins[denominationIndex];
        int minDenomination = coins[0];
        while (amount > 0 && minDenomination <= amount)
        {
            while (amount >= denomination)
            {
                amount -= denomination;
                coinCount++;
            }
            denominationIndex--;
            if (denominationIndex < 0)
            {
                break;
            }
            denomination = coins[denominationIndex];
        }

        return amount == 0 ? coinCount : -1;
    }
}