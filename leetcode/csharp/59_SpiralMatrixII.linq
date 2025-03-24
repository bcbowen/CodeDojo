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

	public int[][] GenerateMatrix(int n)
	{
		int[][] matrix = new int[n][];
		int i;
		for (i = 0; i < matrix.Length; i++)
		{
			matrix[i] = new int[n];
		}

		int x = 0; 
		int y = 0;
		int value = 1;
		int maxValue = n * n;
		
		while (value <= maxValue)
		{
			while (x < matrix[y].Length && matrix[y][x] == 0)
			{
				matrix[y][x++] = value++;
			}
			y++;
			x--;

			while (y < matrix.Length && matrix[y][x] == 0)
			{
				matrix[y++][x] = value++;
			}
			x--;
			y--;

			while (x >= 0 && matrix[y][x] == 0)
			{
				matrix[y][x--] = value++;
			}
			y--;
			x++;

			while (y > 0 && matrix[y][x] == 0)
			{
				matrix[y--][x] = value++;
			}
			y++;
			x++;
		}

		return matrix;
	}

	public int[][] GenerateMatrix_First(int n)
	{
		int[][] matrix = new int[n][];
		int i;
		for (i = 0; i < matrix.Length; i++)
		{
			matrix[i] = new int[n];
		}

		int minX = 0;
		int maxX = n - 1;
		int minY = 0;
		int maxY = n - 1;
		int maxI = n * n;

		i = 1;
		while (minX <= maxX && minY <= maxY)
		{
			for (int x = minX; x <= maxX; x++)
			{
				matrix[minY][x] = i++;
			}
			minY++;

			if (i > maxI) break;

			for (int y = minY; y <= maxY; y++)
			{
				matrix[y][maxX] = i++;
			}
			maxX--;

			if (i > maxI) break;

			for (int x = maxX; x >= minX; x--)
			{
				matrix[maxY][x] = i++;
			}
			maxY--;

			if (i > maxI) break;

			for (int y = maxY; y <= minY; y++)
			{
				matrix[y][minX] = i++;
			}
			minX++;
		}

		return matrix;
	}
}

[Theory]
[InlineData(4, new[] { 1, 2, 3, 4 }, new[] { 12, 13, 14, 5 }, new[] { 11, 16, 15, 6 }, new[] { 10, 9, 8, 7 })]
[InlineData(3, new[] { 1, 2, 3 }, new[] { 8, 9, 4 }, new[] { 7, 6, 5 })]
[InlineData(2, new[] { 1, 2 }, new[] { 4, 3 })]
[InlineData(1, new[] { 1 })]
void Test(int n, params int[][] expected)
{
	int[][] result = new Solution().GenerateMatrix(n);
	Assert.Equal(expected, result);

}