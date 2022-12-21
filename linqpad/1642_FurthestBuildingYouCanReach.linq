<Query Kind="Program">
  <Namespace>Xunit</Namespace>
</Query>

#load "xunit"

void Main()
{
	RunTests();  // Call RunTests() or press Alt+Shift+T to initiate testing.
}
/*
You are given an integer array heights representing the heights of buildings, some bricks, and some ladders.
You start your journey from building 0 and move to the next building by possibly using bricks or ladders.
While moving from building i to building i+1 (0-indexed),

If the current building's height is greater than or equal to the next building's height, you do not need a ladder or bricks.
If the current building's height is less than the next building's height, you can either use one ladder or (h[i+1] - h[i]) bricks.
Return the furthest building index (0-indexed) you can reach if you use the given ladders and bricks optimally.
*/
public class Solution
{
	public int FurthestBuilding(int[] heights, int bricks, int ladders)
	{
		PriorityQueue<int, int> laddersQueue = new PriorityQueue<int, int>();
		for (int i = 0; i < heights.Length - 1; i++)
		{
			int diff = heights[i + 1] - heights[i];
			if(diff > 0)
			{
				if (ladders > 0) 
				{
					laddersQueue.Enqueue(diff, diff);
					ladders--;
				}
				else if(laddersQueue.Count > 0 && laddersQueue.Peek() < diff) 
				{
					int bricksCount = laddersQueue.Dequeue();
					if (bricksCount <= bricks)
					{
						bricks -= bricksCount; 
						laddersQueue.Enqueue(diff, diff);
					}
					else 
					{
						return i;
					}
				}
				else
				{
					if (bricks >= diff) 
					{
						bricks -= diff;
					}
					else
					{
						return i;
					}
				}
			}
		}
		
		return heights.Length - 1;
	}

	public int FurthestBuildingA(int[] heights, int bricks, int ladders)
	{
		int reached = 0;
		for (int i = 0; i < heights.Length - 1; i++)
		{
			int diff = heights[i + 1] - heights[i];
			if (diff > 0)
			{
				if (diff <= bricks)
				{
					bricks -= diff;
				}
				else if (ladders > 0)
				{
					ladders--;
				}
				else
				{
					break;
				}
			}
			reached++;
		}
		return reached;
	}
}

#region private::Tests

[Fact] void Test_Xunit() => Assert.True(1 + 1 == 2);

[Theory]
/**/
[InlineData(new[] { 4, 2, 7, 6, 9, 14, 12 }, 5, 1, 4)]
[InlineData(new[] { 4, 12, 2, 7, 3, 18, 20, 3, 19 }, 10, 2, 7)]
[InlineData(new[] { 14, 3, 19, 3 }, 17, 0, 3)]

[InlineData(new[] { 1,5,1,2,3,4,10000 }, 4, 1, 5)]
void TestFurthestBuilding(int[] heights, int bricks, int ladders, int expected)
{
	int result = new Solution().FurthestBuilding(heights, bricks, ladders);
	Assert.Equal(expected, result);
}

/*
[1,5,1,2,3,4,10000]
4
1
Output
3
Expected
5

1 -> 5: ladder + 1
5 -> 1: + 1
1 -> 2: 1 b + 1
2 -> 3: 1 b + 1
3 -> 4: 1 b + 1
4 -> 10000: X
5

Example 1:
Input: heights = [4,2,7,6,9,14,12], bricks = 5, ladders = 1
Output: 4
Explanation: Starting at building 0, you can follow these steps:
- Go to building 1 without using ladders nor bricks since 4 >= 2.
- Go to building 2 using 5 bricks. You must use either bricks or ladders because 2 < 7.
- Go to building 3 without using ladders nor bricks since 7 >= 6.
- Go to building 4 using your only ladder. You must use either bricks or ladders because 6 < 9.
It is impossible to go beyond building 4 because you do not have any more bricks or ladders.

Example 2:
Input: heights = [4,12,2,7,3,18,20,3,19], bricks = 10, ladders = 2
Output: 7
Example 3:

Input: heights = [14,3,19,3], bricks = 17, ladders = 0
Output: 3

14 -> 3: + 1
3 -> 19: 16 bricks, + 1
19 -3: + 1
= 3

*/
#endregion