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
	public void Rotate(int[][] matrix)
	{
		Transpose(matrix);
		Mirror(matrix);

	}

	internal void Transpose(int[][] matrix)
	{
		int s = matrix.Length;
		for (int y = 0; y < s; y++)
		{
			for (int x = y + 1; x < s; x++)
			{
				int temp = matrix[y][x];
				matrix[y][x] = matrix[x][y];
				matrix[x][y] = temp;
			}
		}
	}

	internal void Mirror(int[][] matrix)
	{
		int s = matrix.Length;
		for (int y = 0; y < s; y++)
		{
			for (int x = 0; x < s / 2; x++)
			{
				int temp = matrix[y][s - 1 - x];
				matrix[y][s - 1 - x] = matrix[y][x];
				matrix[y][x] = temp;
			}

		}
	}
}

#region private::Tests

[Fact]
void ThreeTest()
{
	int[][] matrix = new int[3][];
	matrix[0] = new[] { 1, 2, 3 };
	matrix[1] = new[] { 4, 5, 6 };
	matrix[2] = new[] { 7, 8, 9 };

	new Solution().Rotate(matrix);
	// Input: matrix = [[1,2,3],[4,5,6],[7,8,9]]
	// Output: [[7,4,1],[8,5,2],[9,6,3]]

	int[] expected = new int[] { 7, 4, 1 };
	Assert.Equal(expected, matrix[0]);

	expected = new int[] { 8, 5, 2 };
	Assert.Equal(expected, matrix[1]);

	expected = new int[] { 9, 6, 3 };
	Assert.Equal(expected, matrix[2]);


}

[Fact]
void FourTest()
{
	int[][] matrix = new int[4][];
	matrix[0] = new[] { 5, 1, 9, 11 };
	matrix[1] = new[] { 2, 4, 8, 10 };
	matrix[2] = new[] { 13, 3, 6, 7 };
	matrix[3] = new[] { 15, 14, 12, 16 };

	new Solution().Rotate(matrix);
	// Input: matrix = [[1,2,3],[4,5,6],[7,8,9]]
	// Output: [[7,4,1],[8,5,2],[9,6,3]]

	int[] expected = new int[] { 15, 13, 2, 5 };
	Assert.Equal(expected, matrix[0]);

	expected = new int[] { 14, 3, 4, 1 };
	Assert.Equal(expected, matrix[1]);

	expected = new int[] { 12, 6, 8, 9 };
	Assert.Equal(expected, matrix[2]);

	expected = new int[] { 16, 7, 10, 11 };
	Assert.Equal(expected, matrix[3]);
}


#endregion
