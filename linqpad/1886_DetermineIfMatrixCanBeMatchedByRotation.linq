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
	public bool FindRotation(int[][] mat, int[][] target)
	{
		if (mat.Length != target.Length) return false;

		if (AreEqual(mat, target)) return true;

		for (int i = 0; i < 4; i++)
		{
			Rotate(target);
			if (AreEqual(mat, target)) return true;
		}
		return false;
	}

	internal bool AreEqual(int[][] mat, int[][] target)
	{
		for (int i = 0; i < mat.Length; i++)
		{
			for(int j = 0; j < mat[i].Length; j++)
			{
				if (mat[i][j] != target[i][j]) 
				{
					return false;
				}
			}
		}
		return true;
	}

	internal void Rotate(int[][] matrix)
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
void Test1() 
{
	/*
	Example 1:
	Input: mat = [[0,1],[1,0]], target = [[1,0],[0,1]]
	Output: true
	Explanation: We can rotate mat 90 degrees clockwise to make mat equal target.
	*/

	int[][] matrix1 = new int[2][];
	matrix1[0] = new[] { 0, 1 };
	matrix1[1] = new[] { 1, 0 };

	int[][] matrix2 = new int[2][];
	matrix2[0] = new[] { 1, 0 };
	matrix2[1] = new[] { 0, 1 };

	bool expected = true;
	bool result = new Solution().FindRotation(matrix1, matrix2);
	Assert.Equal(expected, result);
}

[Fact]
void Test2() 
{
	/*
	Example 2:
	Input: mat = [[0,1],[1,1]], target = [[1,0],[0,1]]
	Output: false
	Explanation: It is impossible to make mat equal to target by rotating mat.
	*/

	int[][] matrix1 = new int[2][];
	matrix1[0] = new[] { 0, 1 };
	matrix1[1] = new[] { 1, 1 };

	int[][] matrix2 = new int[2][];
	matrix2[0] = new[] { 1, 0 };
	matrix2[1] = new[] { 0, 1 };

	bool expected = false;
	bool result = new Solution().FindRotation(matrix1, matrix2);
	Assert.Equal(expected, result);
}

[Fact]
void Test3()
{
	/*
	Example 3:
	Input: mat = [[0,0,0],[0,1,0],[1,1,1]], target = [[1,1,1],[0,1,0],[0,0,0]]
	Output: true
	Explanation: We can rotate mat 90 degrees clockwise two times to make mat equal target.
	*/
	
	int[][] matrix1 = new int[3][];
	matrix1[0] = new[] { 0, 0, 0 };
	matrix1[1] = new[] { 0, 1, 0 };
	matrix1[2] = new[] { 1, 1, 1 };

	int[][] matrix2 = new int[3][];
	matrix2[0] = new[] { 1, 1, 1 };
	matrix2[1] = new[] { 0, 1, 0 };
	matrix2[2] = new[] { 0, 0, 0 };

	bool expected = true;
	bool result = new Solution().FindRotation(matrix1, matrix2);
	Assert.Equal(expected, result);

}
/*





*/

#endregion