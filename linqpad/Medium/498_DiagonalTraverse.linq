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
	public int[] FindDiagonalOrder(int[][] matrix)
	{
		if (matrix.Length == 1 && matrix[0].Length == 1)
		{
			return new[] {matrix[0][0]};
		}
		
		bool climbing = true;
		bool done = false;
		int m = matrix.Length;
		int n = matrix[0].Length;
		int[] values = new int[m * n];

		int x = 0;
		int y = 0;
		
		int index = 0;
		while (!done)
		{
			values[index++] = matrix[y][x];
			if (climbing)
			{
				if (y == 0 )
				{
					climbing = false;
					if (x < n - 1)
					{ 
						x++;
					}
					else 
					{
						y++;
						climbing = false;
					}
				}
				else
				{
					if (x < n - 1)
					{
						y--; 
						x++;
					}
					else 
					{
						climbing = false; 
						y++;
					}
				}
			}
			else
			{
				if (x == 0)
				{
					climbing = true;
					if (y < m - 1) 
					{
						y++;
					}
					else
					{
						x++;
					}
				}
				else
				{
					if (y < m -1) 
					{
						x--;
						y++;
					}  
					else
					{
						climbing = true;
						x++;
					}
					 
				}
			}
			
			if (y == m -1 && x == n - 1) 
			{
				done = true;	
				values[index] = matrix[y][x];
			}
			
		}
		return values;
	}
}

#region private::Tests

[Fact] void Test_Xunit() => Assert.True(1 + 1 == 2);

/*
Input: mat = [[1,2,3],[4,5,6],[7,8,9]]
Output: [1,2,4,7,5,3,6,8,9]

Input: mat = [[1,2],[3,4]]
Output: [1,2,3,4]

[[2,3]]
Output
[2]
Expected
[2,3]
*/

[Theory]
[InlineData(new[] { 2, 3 }, new[] { 2, 3 })]
[InlineData(new[] { 1, 2, 4, 7, 5, 3, 6, 8, 9 }, new[] { 1, 2, 3 }, new[] { 4, 5, 6 }, new[] { 7, 8, 9 })]
[InlineData(new[] { 1, 2, 3, 4 }, new[] { 1, 2 }, new[] { 3, 4 })]
[InlineData(new[] { 1 }, new[] { 1 })]
[InlineData(new[] { 1, 2, 5, 9, 6, 3, 4, 7, 10, 13, 14, 11, 8, 12, 15, 16 }, new[] { 1, 2, 3, 4 }, new[] { 5, 6, 7, 8 }, new[] { 9, 10, 11, 12 }, new[] { 13, 14, 15, 16 })]
[InlineData(new[] { 1, 2, 5, 6, 3, 4, 7, 8 }, new[] { 1, 2, 3, 4 }, new[] { 5, 6, 7, 8 })]
void Test(int[] expected, params int[][] mat)
{
	int[] result = new Solution().FindDiagonalOrder(mat);
	Assert.Equal(expected, result);

}

#endregion