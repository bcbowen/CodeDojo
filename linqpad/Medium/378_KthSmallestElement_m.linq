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
	public int KthSmallest(int[][] matrix, int k)
	{
		int[] flat = Flatten(matrix);
		if (flat.Length == 1) return flat[0];

		Array.Sort(flat);
		return flat[k - 1];
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

#region private::Tests

/*
Example 1:

Input: matrix = [[1,5,9],[10,11,13],[12,13,15]], k = 8
Output: 13
Explanation: The elements in the matrix are [1,5,9,10,11,12,13,13,15], and the 8th smallest number is 13
Example 2:

Input: matrix = [[-5]], k = 1
Output: -5

[[1,2],[1,3]]
k: 2
output: 1

*/
[Theory]
[InlineData(2, 1, new[] { 1, 2 }, new[] { 1, 3 })]
[InlineData(8, 13, new[] { 1, 5, 9 }, new[] { 10, 11, 13 }, new[] { 12, 13, 15 })]
[InlineData(1, -5, new[] { -5 })]
void Test(int k, int expected, params int[][] matrix)
{
	int result = new Solution().KthSmallest(matrix, k);
	Assert.Equal(expected, result);
}

[Fact] void Test_Xunit() => Assert.True(1 + 1 == 2);

#endregion