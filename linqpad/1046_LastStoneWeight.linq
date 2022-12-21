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
	public int LastStoneWeight(int[] stones)
	{
		PriorityQueue<int, int> queue = new PriorityQueue<int, int>();
		foreach(int stone in stones) 
		{
			queue.Enqueue(stone, -stone);
		}
		while (queue.Count > 1) 
		{
			int x = queue.Dequeue();
			int y = queue.Dequeue();
			if (x > y) 
			{
				queue.Enqueue(x-y, y-x);
			}
		}
		
		return queue.Count > 0 ? queue.Peek() : 0;
	}
}

#region private::Tests

[Fact] void Test_Xunit() => Assert.True(1 + 1 == 2);

[Theory]
[InlineData(new[] { 2, 7, 4, 1, 8, 1 }, 1)]
void TestLastStoneWeight(int[] stones, int expected)
{
	int result = new Solution().LastStoneWeight(stones);
	Assert.Equal(expected, result);
}

/*

You are given an array of integers stones where stones[i] is the weight of the ith stone.

We are playing a game with the stones. On each turn, we choose the heaviest two stones and smash them together. Suppose the heaviest two stones have weights x and y with x <= y. The result of this smash is:

If x == y, both stones are destroyed, and
If x != y, the stone of weight x is destroyed, and the stone of weight y has new weight y - x.
At the end of the game, there is at most one stone left.

Return the weight of the last remaining stone. If there are no stones left, return 0.

Example 1:

Input: stones = [2,7,4,1,8,1]
Output: 1
Explanation: 
We combine 7 and 8 to get 1 so the array converts to [2,4,1,1,1] then,
we combine 2 and 4 to get 2 so the array converts to [2,1,1,1] then,
we combine 2 and 1 to get 1 so the array converts to [1,1,1] then,
we combine 1 and 1 to get 0 so the array converts to [1] then that's the value of the last stone.
Example 2:

Input: stones = [1]
Output: 1
*/
#endregion