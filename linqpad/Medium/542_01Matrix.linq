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
	public int[][] UpdateMatrix(int[][] mat)
	{
		int[][] result = new int[mat.Length][];
		for (int i = 0; i < mat.Length; i++)
		{
			result[i] = new int[mat[i].Length];
			Array.Fill(result[i], 10000);
		}

		for (int r = 0; r < mat.Length; r++)
		{
			for (int c = 0; c < mat[r].Length; c++)
			{
				if (mat[r][c] == 0)
				{
					result[r][c] = 0;
				}
				else
				{
					if (r > 0)
					{
						result[r][c] = Math.Min(result[r][c], result[r - 1][c] + 1);
					}
					if (c > 0)
					{
						result[r][c] = Math.Min(result[r][c], result[r][c - 1] + 1);
					}
				}
			}

		}

		for (int r = mat.Length - 1; r >= 0; r--)
		{
			for (int c = mat[r].Length - 1; c >= 0; c--)
			{
				if (r < mat.Length - 1)
				{
					result[r][c] = Math.Min(result[r][c], result[r + 1][c] + 1);
				}
				if (c < mat[r].Length - 1)
				{
					result[r][c] = Math.Min(result[r][c], result[r][c + 1] + 1);
				}
			}
		}

		return result;
	}
}

#region private::Tests

/// <summary>
/// Input: mat = [[0,0,0],[0,1,0],[0,0,0]]
/// Output: [[0,0,0],[0,1,0],[0,0,0]]
/// </summary>
[Fact]
void Test1()
{
	int[][] matrix = new int[3][];
	matrix[0] = new[] { 0, 0, 0 };
	matrix[1] = new[] { 0, 1, 0 };
	matrix[2] = new[] { 0, 0, 0 };

	int[][] expected = new int[3][];
	expected[0] = new[] { 0, 0, 0 };
	expected[1] = new[] { 0, 1, 0 };
	expected[2] = new[] { 0, 0, 0 };
	
	int[][] result = new Solution().UpdateMatrix(matrix);
	Assert.Equal(expected, result);
}


/// <summary>
/// Input: mat = [[0,0,0],[0,1,0],[1,1,1]]
/// Output: [[0,0,0],[0,1,0],[1,2,1]]
/// </summary>
[Fact]
void Test2()
{
	int[][] matrix = new int[3][];
	matrix[0] = new[] { 0, 0, 0 };
	matrix[1] = new[] { 0, 1, 0 };
	matrix[2] = new[] { 1, 1, 1 };

	int[][] expected = new int[3][];
	expected[0] = new[] { 0, 0, 0 };
	expected[1] = new[] { 0, 1, 0 };
	expected[2] = new[] { 1, 2, 1 };

	int[][] result = new Solution().UpdateMatrix(matrix);
	Assert.Equal(expected, result);
}


#endregion