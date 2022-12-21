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
	private int _size;
	private int _margin;
	private int _blowupSize;

	public int LargestOverlap(int[][] img1, int[][] img2)
	{
		_size = img1.Length;
		_blowupSize = _size * 3 - 2;
		_margin = (_blowupSize - _size) / 2;
		int maxScore = 0;

		int[][] superSize = BlowUpImage(img1);
		for (int i = 0; i <= _blowupSize - _size; i++)
		{
			for (int j = 0; j <= _blowupSize - _size; j++)
			{
				int score = GetScore(i, j, superSize, img2);
				maxScore = Math.Max(score, maxScore);
			}
		}

		return maxScore;
	}

	private int[][] BlowUpImage(int[][] image)
	{
		int[][] superSize = new int[_blowupSize][];
		for (int i = 0; i < _blowupSize; i++)
		{
			superSize[i] = new int[_blowupSize];
			Array.Fill(superSize[i], 0);
		}

		for (int i = 0; i < _size; i++)
		{
			for (int j = 0; j < _size; j++)
			{
				superSize[i + _margin][j + _margin] = image[i][j];
			}
		}

		return superSize;
	}

	private int GetScore(int windowI, int windowJ, int[][] superSize, int[][] image2)
	{
		int score = 0;
		for (int i = 0; i < _size; i++)
		{
			for (int j = 0; j < _size; j++)
			{
				if (1 == superSize[windowI + i][windowJ + j] && 1 == image2[i][j])
				{
					score++;
				}
			}
		}

		return score;
	}
}

#region private::Tests

[Fact]
void Test_Example1()
{
	int[][] image1 = new int[3][];
	image1[0] = new[] { 1, 1, 0 };
	image1[1] = new[] { 0, 1, 0 };
	image1[2] = new[] { 0, 1, 0 };

	int[][] image2 = new int[3][];
	image2[0] = new[] { 0, 0, 0 };
	image2[1] = new[] { 0, 1, 1 };
	image2[2] = new[] { 0, 0, 1 };

	int expected = 3;
	int result = new Solution().LargestOverlap(image1, image2);
	Assert.Equal(expected, result);
}

[Fact]
void Test_Example2()
{
	int[][] image1 = new int[1][];
	image1[0] = new[] { 1 };

	int[][] image2 = new int[1][];
	image2[0] = new[] { 1 };

	int expected = 1;
	int result = new Solution().LargestOverlap(image1, image2);
	Assert.Equal(expected, result);
}

[Fact]
void Test_Example3()
{
	int[][] image1 = new int[1][];
	image1[0] = new[] { 0 };

	int[][] image2 = new int[1][];
	image2[0] = new[] { 0 };

	int expected = 0;
	int result = new Solution().LargestOverlap(image1, image2);
	Assert.Equal(expected, result);
}

[Fact]
void Test_Example4()
{
	int[][] image1 = new int[5][];
	image1[0] = new[] { 0, 0, 0, 0, 1 };
	image1[1] = new[] { 0, 0, 0, 0, 0 };
	image1[2] = new[] { 0, 0, 0, 0, 0 };
	image1[3] = new[] { 0, 0, 0, 0, 0 };
	image1[4] = new[] { 0, 0, 0, 0, 0 };

	int[][] image2 = new int[5][];
	image2[0] = new[] { 0, 0, 0, 0, 0 };
	image2[1] = new[] { 0, 0, 0, 0, 0 };
	image2[2] = new[] { 0, 0, 0, 0, 0 };
	image2[3] = new[] { 0, 0, 0, 0, 0 };
	image2[4] = new[] { 1, 0, 0, 0, 0 };

	int expected = 1;
	int result = new Solution().LargestOverlap(image1, image2);
	Assert.Equal(expected, result);
}


/*
Ex4: 
Input
[[0,0,0,0,1],[0,0,0,0,0],[0,0,0,0,0],[0,0,0,0,0],[0,0,0,0,0]]
[[0,0,0,0,0],[0,0,0,0,0],[0,0,0,0,0],[0,0,0,0,0],[1,0,0,0,0]]
Output
0
Expected
1

Example 1:
Input: img1 = [[1,1,0],[0,1,0],[0,1,0]], img2 = [[0,0,0],[0,1,1],[0,0,1]]
Output: 3
Explanation: We translate img1 to right by 1 unit and down by 1 unit.

Example 2:
Input: img1 = [[1]], img2 = [[1]]
Output: 1

Example 3:
Input: img1 = [[0]], img2 = [[0]]
Output: 0
*/

#endregion