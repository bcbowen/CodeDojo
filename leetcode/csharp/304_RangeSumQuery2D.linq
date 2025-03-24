<Query Kind="Program">
  <Namespace>Xunit</Namespace>
</Query>

#load "xunit"

void Main()
{
	RunTests();  // Call RunTests() or press Alt+Shift+T to initiate testing.
}

public class NumMatrix
{
	private int[][] _matrix;
	public NumMatrix(int[][] matrix)
	{
		_matrix = matrix;
	}

	public int SumRegion(int row1, int col1, int row2, int col2)
	{
		int sum = 0;
		for (int row = row1; row <= row2; row++)
		{
			for (int col = col1; col <= col2; col++) 
			{
				sum += _matrix[row][col]; 
			}
		}
		return sum;
	}
}

#region private::Tests

[Theory]
void Test() 
{
	
}

/*

Input
["NumMatrix", "sumRegion", "sumRegion", "sumRegion"]
[[[[3, 0, 1, 4, 2], [5, 6, 3, 2, 1], [1, 2, 0, 1, 5], [4, 1, 0, 1, 7], [1, 0, 3, 0, 5]]], [2, 1, 4, 3], [1, 1, 2, 2], [1, 2, 2, 4]]
Output
[null, 8, 11, 12]

Explanation
NumMatrix numMatrix = new NumMatrix([[3, 0, 1, 4, 2], [5, 6, 3, 2, 1], [1, 2, 0, 1, 5], [4, 1, 0, 1, 7], [1, 0, 3, 0, 5]]);
numMatrix.sumRegion(2, 1, 4, 3); // return 8 (i.e sum of the red rectangle)
numMatrix.sumRegion(1, 1, 2, 2); // return 11 (i.e sum of the green rectangle)
numMatrix.sumRegion(1, 2, 2, 4); // return 12 (i.e sum of the blue rectangle)

*/

private int[][] GetTestMatrix() 
{
	int[][] matrix = new int[5][];
	int i = 0;
	matrix[i++] = new int[5] {3, 0, 1, 4, 2} ;
	matrix[i++] = new int[5] {5, 6, 3, 2, 1} ;
	matrix[i++] = new int[5] {1, 2, 0, 1, 5} ;
	matrix[i++] = new int[5] {4, 1, 0, 1, 7} ;
	matrix[i++] = new int[5] {1, 0, 3, 0, 5} ;
	
	return matrix; 
	
}

#endregion