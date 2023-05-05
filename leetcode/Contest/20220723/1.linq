<Query Kind="Program" />

void Main()
{
	/*
	Input: ranks = [13,2,3,1,9], suits = ["a","a","a","a","a"]
Output: "Flush"
Explanation: The hand with all the cards consists of 5 cards with the same suit, so we have a "Flush".
Example 2:

Input: ranks = [4,4,2,4,4], suits = ["d","a","a","b","c"]
Output: "Three of a Kind"
Explanation: The hand with the first, second, and fourth card consists of 3 cards with the same rank, so we have a "Three of a Kind".
Note that we could also make a "Pair" hand but "Three of a Kind" is a better hand.
Also note that other cards could be used to make the "Three of a Kind" hand.
Example 3:

Input: ranks = [10,10,2,12,9], suits = ["a","b","c","a","d"]
Output: "Pair"
Explanation: The hand with the first and second card consists of 2 cards with the same rank, so we have a "Pair".
Note that we cannot make a "Flush" or a "Three of a Kind".

"Flush": Five cards of the same suit.
"Three of a Kind": Three cards of the same rank.
"Pair": Two cards of the same rank.
"High Card": Any single card.

	*/
	Test(new[] { 13,2,3,1,9 }, new[] {'a','a','a','a','a'}, "Flush");
	Test(new[] { 4,4,2,4,4}, new[] {'d','a','a','b','c'}, "Three of a Kind");
	Test(new[] {10,10,2,12,9 }, new[] {'d','a','a','b','c'}, "Pair");
}

public void Test( int[] ranks, char[] suits, string expected) 
{
	string result = new Solution().BestHand(ranks, suits);

	Console.WriteLine($"{expected} {result}");
}

public class Solution
{
	public string BestHand(int[] ranks, char[] suits)
	{
		int maxCount = 0;
		if (suits.All(s => s == suits[0])) return "Flush";

		Dictionary<int, int> counts = new Dictionary<int, int>();

		foreach (int rank in ranks)
		{
			if (counts.ContainsKey(rank))
			{
				counts[rank]++;

			}
			else
			{
				counts.Add(rank, 1);
			}
			if (counts[rank] > maxCount) maxCount = counts[rank];
		}

		if (maxCount >= 3) return "Three of a Kind";
		if (maxCount == 2)  return "Pair"; 
		return "High Card";
			
		
		
	}

	
}