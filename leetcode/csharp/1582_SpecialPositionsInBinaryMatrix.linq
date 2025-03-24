<Query Kind="Program">
  <Namespace>Xunit</Namespace>
</Query>

#load "xunit"

void Main()
{
	RunTests();  // Call RunTests() or press Alt+Shift+T to initiate testing.
}

public int NumSpecial(int[][] mat)
{
	int result = 0; 
	for(int row = 0; row < mat.Length; row++)
	{
		for(int col = 0; col < mat[row].Length; col++) 
		{
			if (IsSpecial(mat, col, row)) result++; 
		}
	}
	
	return result;
}

internal bool IsSpecial(int[][] matrix, int x, int y)
{
	if (matrix[y][x] != 1) return false;
	// check rows
	for (int r = 0; r < matrix.Length; r++)
	{
		if (r == y) continue; 
		if (matrix[r][x] == 1) return false;
	}

	// check cols
	for (int c = 0; c < matrix[y].Length; c++)
	{
		if (c == x) continue;
		if (matrix[y][c] == 1) return false;
	}

	return true;
}

[Theory]
[InlineData(1, new[] {1, 0, 0}, new[] { 0, 0, 1}, new[] {1, 0, 0})]
[InlineData(3, new[] {1, 0, 0}, new[] { 0, 1, 0}, new[] {0, 0, 1})]
[InlineData(1, new[] {0, 0}, new[] { 0, 0}, new[] {1, 0})]
void Test(int expectedResult, params int[][] matrix)
{
	int result = NumSpecial(matrix); 
	Assert.Equal(expectedResult, result); 
}

private int[][] GetTestMatrix()
{
	int[][] matrix = new int[3][];
	matrix[0] = new[] { 1, 0, 0 };
	matrix[1] = new[] { 0, 0, 1 };
	matrix[2] = new[] { 1, 0, 0 };

	return matrix;
}

[Theory]
[InlineData(0, 0, false)]
[InlineData(1, 0, false)]
[InlineData(2, 0, false)]
[InlineData(0, 1, false)]
[InlineData(1, 1, false)]
[InlineData(2, 1, true)]
[InlineData(0, 2, false)]
[InlineData(0, 2, false)]
[InlineData(0, 2, false)]
void IsSpecialTest(int x, int y, bool expected)
{
	int[][] matrix = GetTestMatrix(); 
	bool result = IsSpecial(matrix, x, y); 
	Assert.Equal(expected, result); 
}
