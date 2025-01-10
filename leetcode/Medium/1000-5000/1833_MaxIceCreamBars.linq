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

/*
   Example 1:
   Input: costs = [1,3,2,4,1], coins = 7
   Output: 4
   Explanation: The boy can buy ice cream bars at indices 0,1,2,4 for a total price of 1 + 3 + 2 + 1 = 7.

   Example 2:
   Input: costs = [10,6,8,7,7,8], coins = 5
   Output: 0
   Explanation: The boy cannot afford any of the ice cream bars.

   Example 3:
   Input: costs = [1,6,3,1,2,5], coins = 20
   Output: 6
   Explanation: The boy can buy all the ice cream bars for a total price of 1 + 6 + 3 + 1 + 2 + 5 = 18.
   */
[Theory]
[InlineData(new[] { 1, 3, 2, 4, 1 }, 7, 4)]
[InlineData(new[] { 10, 6, 8, 7, 7, 8 }, 5, 0)]
[InlineData(new[] { 1, 6, 3, 1, 2, 5 }, 20, 6)]
[InlineData(new[] { 1 }, 1, 1)]
[InlineData(new[] { 2 }, 1, 0)]
public void ReverseWordsTest(int[] costs, int coins, int expected)
{
	int result = new Solution().MaxIceCream(costs, coins);
	Assert.Equal(expected, result);
}

