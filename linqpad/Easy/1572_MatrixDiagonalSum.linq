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
	public int DiagonalSum(int[][] mat)
	{
		int x1 = 0; 
		int x2 = mat[0].Length - 1;
		int sum = 0;
		foreach(int[] row in mat)
		{
			if (x1 != x2)
			{
				sum += row[x1] + row[x2];
			} 
			else
			{
				sum += row[x1];
			}	
			x1++; 
			x2--;
		}
		return sum;
	}
}

/*
Input: mat = [[1,2,3],
              [4,5,6],
              [7,8,9]]
Output: 25
Explanation: Diagonals sum: 1 + 5 + 9 + 3 + 7 = 25
Notice that element mat[1][1] = 5 is counted only once.

Input: mat = [[1,1,1,1],
              [1,1,1,1],
              [1,1,1,1],
              [1,1,1,1]]
Output: 8


Input: mat = [[5]]
Output: 5

*/
// [InlineData(true, new[] {1, 2}, new[] {2, 3}, new[] {3, 4}, new[] {4, 5}, new[] {5, 6}, new[] {6, 7})]
[Theory]
[InlineData(25, new[] {1,2,3}, new[] {4,5,6}, new[] {7,8,9})]
[InlineData(8, new[] {1,1,1,1}, new[] {1,1,1,1}, new[] {1,1,1,1}, new[] {1,1,1,1})]
[InlineData(5, new[] {5})]
void Tests(int expected, params int[][] mat) 
{
	int result = new Solution().DiagonalSum(mat);
	Assert.Equal(expected, result);
}
