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
	public int MaxSum(int[][] grid)
	{
		int maxSum = 0;
		for(int y = 0; y < grid.Length - 2; y++)
		{
			for (int x = 0; x < grid[0].Length -2; x++)
			{
				maxSum = Math.Max(maxSum, GetHourGlassSum(grid, new[] {x, y}));
				
			}
		}
		return maxSum;
	}

	internal int GetHourGlassSum(int[][] grid, int[] corner) 
	{
		int sum = 0;

		int y = corner[1];
		for (int x = corner[0]; x < corner[0] + 3; x++) 
		{
			sum += grid[y][x]; 
		}
		y++; 
		sum += grid[y][corner[0] + 1];
		y++;
		for (int x = corner[0]; x < corner[0] + 3; x++)
		{
			sum += grid[y][x];
		}

		return sum; 
	}
}

#region private::Tests

[Fact] void Test_Xunit() => Assert.True(1 + 1 == 2);

[Theory]
[InlineData(30, new[] {6,2,1,3}, new[] {4,2,1,5},new[] {9,2,8,7},new[] {4,1,2,9})]
[InlineData(35, new[] {1,2,3}, new[] {4,5,6},new[] {7,8,9})]
[InlineData(5095181, new[] {520626,685427,788912,800638,717251,683428}, new[] {23602,608915,697585,957500,154778,209236},new[] {287585,588801,818234,73530,939116,252369})]
public void Test(int expected, params int[][] grid) 
{
	int result = new Solution().MaxSum(grid); 
	Assert.Equal(expected, result);
}

/*
[[520626,685427,788912,800638,717251,683428],
[23602,608915,697585,957500,154778,209236],
[287585,588801,818234,73530,939116,252369]]


Input: grid = [[6,2,1,3],[4,2,1,5],[9,2,8,7],[4,1,2,9]]
Output: 30
Explanation: The cells shown above represent the hourglass with the maximum sum: 6 + 2 + 1 + 2 + 9 + 2 + 8 = 30.

Input: grid = [[1,2,3],[4,5,6],[7,8,9]]
Output: 35
Explanation: There is only one hourglass in the matrix, with the sum: 1 + 2 + 3 + 5 + 7 + 8 + 9 = 35.
*/
#endregion