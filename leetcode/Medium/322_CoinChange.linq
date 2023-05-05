<Query Kind="Program">
  <Namespace>Xunit</Namespace>
</Query>

#load "xunit"

void Main()
{
	RunTests();  // Call RunTests() or press Alt+Shift+T to initiate testing.
}

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


#region private::Tests

[Theory]
[InlineData(new[] { 1, 2, 5 }, 11, 3)]
[InlineData(new[] { 2 }, 3, -1)]
[InlineData(new[] { 1 }, 0, 0)]
[InlineData(new[] { 186, 419, 83, 408 }, 6249, 20)]
void Test(int[] coins, int amount, int expected)
{
	int result = new Solution().CoinChange(coins, amount);
	Assert.Equal(expected, result);
}

/*

Input
[186,419,83,408]
6249
Output
-1
Expected
20

Example 1:
Input: coins = [1,2,5], amount = 11
Output: 3
Explanation: 11 = 5 + 5 + 1

Example 2:
Input: coins = [2], amount = 3
Output: -1

Example 3:
Input: coins = [1], amount = 0
Output: 0
*/

#endregion