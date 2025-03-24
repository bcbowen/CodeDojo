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
	public IList<int> SpiralOrder(int[][] matrix)
	{
		List<int> values = new List<int>();

		if (matrix == null || matrix.Length == 0) return values;

		if (matrix.Length == 1)
		{
			values.AddRange(matrix[0]);
			return values;
		}
		int size = matrix.Length * matrix[0].Length;
		
		int xStart = 0;
		int xEnd = matrix[0].Length - 1;
		int yStart = 0;
		int yEnd = matrix.Length - 1;

		while (yStart <= yEnd && xStart <= xEnd)
		{
			for (int x = xStart; x <= xEnd; x++)
			{
				values.Add(matrix[yStart][x]);
			}
			yStart++;
			if (values.Count == size) break;

			for (int y = yStart; y <= yEnd; y++)
			{
				values.Add(matrix[y][xEnd]);
			}
			if (values.Count == size) break;
			xEnd--;

			for (int x = xEnd; x >= xStart; x--)
			{
				values.Add(matrix[yEnd][x]);
			}
			yEnd--;
			if (values.Count == size) break;

			for (int y = yEnd; y >= yStart; y--)
			{
				values.Add(matrix[y][xStart]);
			}
			xStart++;
			if (values.Count == size) break;
		}

		return values;
	}
}

#region private::Tests

[Fact] void Test_Xunit() => Assert.True(1 + 1 == 2);
/*
Input: matrix = [[1,2,3],[4,5,6],[7,8,9]]
Output: [1,2,3,6,9,8,7,4,5]

Input: matrix = [[1,2,3,4],[5,6,7,8],[9,10,11,12]]
Output: [1,2,3,4,8,12,11,10,9,5,6,7]

Input: matrix = [[1,2]]
Output: [1,2]

12
34
56
78

[[3],[2]]
Output
[3,2,2]
Expected
[3,2]


[[1,2,3,4],[5,6,7,8],[9,10,11,12],[13,14,15,16]]
Output
[1,2,3,4,8,12,16,15,14,13,9,5,6,7]
Expected
[1,2,3,4,8,12,16,15,14,13,9,5,6,7,11,10]

1  2  3  4
5  6  7  8
9  10 11 12
13 14 15 16


2  3  4
5  6  7
8  9  10 
11 12 13 
14 15 16

[[2,3,4],[5,6,7],[8,9,10],[11,12,13],[14,15,16]]
Output
[2,3,4,7,10,13,16,15,14,11,8,5,6,9,12,9]
Expected
[2,3,4,7,10,13,16,15,14,11,8,5,6,9,12]


*/
[Theory]
/**/
[InlineData(new[] { 2, 3, 4, 7, 10, 13, 16, 15, 14, 11, 8, 5, 6, 9, 12 }, new[] { 2, 3, 4 }, new[] { 5, 6, 7 }, new[] { 8, 9, 10 }, new[] { 11, 12, 13 }, new[] { 14, 15, 16 })]

[InlineData(new[] { 1,2,3,4,8,12,16,15,14,13,9,5,6,7,11,10 }, new[] { 1, 2, 3, 4 }, new[] { 5, 6, 7, 8 }, new[] { 9, 10, 11, 12 }, new[] { 13, 14, 15, 16 })]
[InlineData(new int[0], new int[0])]
[InlineData(new[] { 1, 2, 3, 6, 9, 8, 7, 4, 5 }, new[] { 1, 2, 3 }, new[] { 4, 5, 6 }, new[] { 7, 8, 9 })]

[InlineData(new[] { 1, 2, 3, 4, 8, 12, 11, 10, 9, 5, 6, 7 }, new[] { 1, 2, 3, 4 }, new[] { 5, 6, 7, 8 }, new[] { 9, 10, 11, 12 })]


[InlineData(new[] { 1, 2 }, new[] { 1, 2 })]
[InlineData(new[] { 1 }, new[] { 1 })]
[InlineData(new[] { 1, 2, 3, 4 }, new[] { 1, 2 }, new[] { 4, 3})]
[InlineData(new[] { 1, 2, 3, 4 }, new[] { 1 }, new[] { 2 }, new[] { 3 }, new[] { 4 })]
[InlineData(new[] { 3, 2 }, new[] { 3 }, new[] { 2 })]
[InlineData(new[] { 1, 2, 3, 4, 8, 7, 6, 5}, new[] { 1, 2, 3, 4 }, new[] { 5, 6, 7, 8 })]
[InlineData(new[] { 1, 2, 4, 6, 8, 7, 5, 3 }, new[] { 1, 2 }, new[] { 3, 4 }, new[] { 5, 6 }, new[] { 7, 8 })]
/**/
void Test(int[] expected, params int[][] matrix)
{
	int[] result = new Solution().SpiralOrder(matrix).ToArray();
	Assert.Equal(expected, result);
}
#endregion