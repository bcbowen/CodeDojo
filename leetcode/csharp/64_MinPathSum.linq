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
	/// <summary>
	/// DP: create a grid with accumulated path lengths
	/// * start with first row and column 
	/// * each interior length is min [top plus current | left + current]
	/// </summary>
	public int MinPathSum(int[][] grid) 
	{
		int[][] pathGrid = new int[grid.Length][];
		for (int i = 0; i < grid.Length; i++) 
		{
			pathGrid[i] = new int[grid[i].Length];
		}
		
		// initialize upper left corner with first cost
		pathGrid[0][0] = grid[0][0];
		
		// populate first row with accumulated lengths
		for (int i = 1; i < pathGrid[0].Length; i++)
		{
			pathGrid[0][i] = pathGrid[0][i - 1] + grid[0][i]; 
		}
		
		// populate first col with accumulated lengths
		for (int i = 1; i < grid.Length; i++)
		{
			pathGrid[i][0] = pathGrid[i - 1][0] + grid[i][0]; 
		}
		
		// for each interior cell, value is current grid value plus the min of the cells to the top or left
		for (int col = 1; col < grid.Length; col++)
		{
			for (int row = 1; row < grid[col].Length; row++) 
			{
				pathGrid[col][row] = grid[col][row] + Math.Min(pathGrid[col - 1][row], pathGrid[col][row - 1]);
			}
		}
		
		return pathGrid[pathGrid.Length - 1][pathGrid[0].Length - 1]; 
	}
	
	/// <summary>This gives the correct answer but is too slow with big inputs like BigTest
	/// Uses BFS to build all paths
	/// </summary>
	public int MinPathSum_1(int[][] grid)
	{
		int minCost = int.MaxValue;
		int targetY = grid.Length - 1; 
		int targetX = grid[0].Length - 1;
		Queue<(int, int, int)> traversal = new Queue<(int, int, int)>();
		traversal.Enqueue((0, 0, 0));
		HashSet<(int, int)> processedCells = new HashSet<(int, int)>();
		while (traversal.Count > 0) 
		{
			(int total, int x, int y) = traversal.Dequeue();
			total += grid[y][x]; 
			if (x == targetX && y == targetY) 
			{
				minCost = Math.Min(minCost, total); 
			}

			if (y < grid.Length - 1 && total < minCost) 
			{
				traversal.Enqueue((total, x, y + 1)); 
				processedCells.Add((x, y + 1));
			}

			if (x < grid[0].Length - 1 && total < minCost)
			{
				traversal.Enqueue((total, x + 1, y)); 
				processedCells.Add((x + 1, y));
			}
		}
		return minCost;
	}
}

/*
Input: grid = [[1,3,1],[1,5,1],[4,2,1]]
Output: 7
Explanation: Because the path 1 → 3 → 1 → 1 → 1 minimizes the sum.

Example 2:
Input: grid = [[1,2,3],[4,5,6]]
Output: 12
*/

[Theory]
[InlineData(7, new[] { 1, 3, 1 }, new[] { 1, 5, 1 }, new[] { 4, 2, 1 })]
[InlineData(12, new[] { 1, 2, 3 }, new[] { 4, 5, 6 })]
void Test(int expected, params int[][] grid)
{
	int result = new Solution().MinPathSum(grid);
	Assert.Equal(expected, result);
}

[Fact]
void BigTest() 
{
	/*
	[[7,1,3,5,8,9,9,2,1,9,0,8,3,1,6,6,9,5],
[9,5,9,4,0,4,8,8,9,5,7,3,6,6,6,9,1,6],
[8,2,9,1,3,1,9,7,2,5,3,1,2,4,8,2,8,8],
[6,7,9,8,4,8,3,0,4,0,9,6,6,0,0,5,1,4],
[7,1,3,1,8,8,3,1,2,1,5,0,2,1,9,1,1,4],
[9,5,4,3,5,6,1,3,6,4,9,7,0,8,0,3,9,9],
[1,4,2,5,8,7,7,0,0,7,1,2,1,2,7,7,7,4],
[3,9,7,9,5,8,9,5,6,9,8,8,0,1,4,2,8,2],
[1,5,2,2,2,5,6,3,9,3,1,7,9,6,8,6,8,3],
[5,7,8,3,8,8,3,9,9,8,1,9,2,5,4,7,7,7],
[2,3,2,4,8,5,1,7,2,9,5,2,4,2,9,2,8,7],
[0,1,6,1,1,0,0,6,5,4,3,4,3,7,9,6,1,9]]
	*/
	int[][] grid = new int[][]
	{
		new [] {7,1,3,5,8,9,9,2,1,9,0,8,3,1,6,6,9,5}, 
		new [] {9,5,9,4,0,4,8,8,9,5,7,3,6,6,6,9,1,6}, 
		new [] {8,2,9,1,3,1,9,7,2,5,3,1,2,4,8,2,8,8}, 
		new [] {6,7,9,8,4,8,3,0,4,0,9,6,6,0,0,5,1,4}, 
		new [] {7,1,3,1,8,8,3,1,2,1,5,0,2,1,9,1,1,4}, 
		new [] {9,5,4,3,5,6,1,3,6,4,9,7,0,8,0,3,9,9}, 
		new [] {1,4,2,5,8,7,7,0,0,7,1,2,1,2,7,7,7,4}, 
		new [] {3,9,7,9,5,8,9,5,6,9,8,8,0,1,4,2,8,2}, 
		new [] {1,5,2,2,2,5,6,3,9,3,1,7,9,6,8,6,8,3}, 
		new [] {5,7,8,3,8,8,3,9,9,8,1,9,2,5,4,7,7,7}, 
		new [] {2,3,2,4,8,5,1,7,2,9,5,2,4,2,9,2,8,7}, 
		new [] {0,1,6,1,1,0,0,6,5,4,3,4,3,7,9,6,1,9}, 
	};	
	int result = new Solution().MinPathSum(grid);
	int expected = 85; 
	Assert.Equal(expected, result);
}

