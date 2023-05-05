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
	public int[][] MatrixReshape(int[][] matrix, int r, int c)
	{
		int[] flat = Flatten(matrix);
		if (r * c != flat.Length) return matrix;
		int[][] result = new int[r][];


		int index = 0;
		for (int row = 0; row < r; row++) 
		{
			int[] currentRow = new int[c];
			for (int col = 0; col < c; col++) 
			{
				currentRow[col] = flat[index++];
			}
			result[row] = currentRow; 
		}

		return result;
	}

	internal int[] Flatten(int[][] matrix)
	{
		int[] flat = new int[matrix.Length * matrix[0].Length];
		for (int i = 0; i < matrix.Length; i++)
		{
			for (int j = 0; j < matrix[i].Length; j++)
			{
				int pos = i * matrix[0].Length + j;
				flat[pos] = matrix[i][j];
			}
		}
		return flat;
	}
}


/*
Input: mat = [[1,2],[3,4]], r = 1, c = 4
Output: [[1,2,3,4]]

Input: mat = [[1,2],[3,4]], r = 2, c = 4
Output: [[1,2],[3,4]]


[[1,2],[3,4]]
2
4

*/

[Theory]
[InlineData(1, 4, new[] { 1, 2 }, new[] { 3, 4 })]
[InlineData(2, 2, new[] { 1, 2 }, new[] { 3, 4 })]
[InlineData(2, 3, new[] { 1, 2, 3 }, new[] { 4, 5, 6 })]
[InlineData(3, 2, new[] { 1, 2, 3 }, new[] { 4, 5, 6 })]
void ReshapeTestValidData(int r, int c, params int[][] matrix)
{
	int[][] result = new Solution().MatrixReshape(matrix, r, c);
	Assert.Equal(r, result.Length);
	Assert.Equal(c, result[0].Length);
	Console.WriteLine("Result:");
	result.Dump();
	
	Console.WriteLine("Matrix:");
	matrix.Dump();
}

[Theory]
[InlineData(2, 4, new[] { 1, 2 }, new[] { 3, 4 })]
void ReshapeTestInalidData(int r, int c, params int[][] matrix)
{
	int[][] result = new Solution().MatrixReshape(matrix, r, c);
	Assert.Equal(matrix, result);
	Console.WriteLine("Result:");
	result.Dump();

	Console.WriteLine("Matrix:");
	matrix.Dump();
}

[Theory]
[InlineData(new[] { 1, 2 }, new[] { 1 }, new[] { 2 })]
[InlineData(new[] { 1, 2, 3, 4 }, new[] { 1, 2 }, new[] { 3, 4 })]
[InlineData(new[] { 1, 2, 3, 4 }, new[] { 1, 2, 3, 4 })]
[InlineData(new[] { 1, 2, 3, 4, 5, 6 }, new[] { 1, 2, 3 }, new[] { 4, 5, 6 })]
[InlineData(new[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 }, new[] { 1, 2, 3 }, new[] { 4, 5, 6 }, new[] { 7, 8, 9 })]
void FlattenTest(int[] expected, params int[][] matrix)
{
	int[] result = new Solution().Flatten(matrix);
	Assert.Equal(expected, result);
}
