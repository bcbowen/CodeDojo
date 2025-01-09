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
	public int[][] FloodFill(int[][] image, int sr, int sc, int newColor)
	{
		HashSet<(int, int)> visited = new HashSet<(int, int)>();
		Stack<(int, int)> connected = new Stack<(int, int)>();
		connected.Push((sr, sc));
		visited.Add((sr, sc));
		int oldColor = image[sr][sc];
		image[sr][sc] = newColor;
		while (connected.Count > 0)
		{
			(int r, int c) = connected.Pop();
			image[r][c] = newColor;
			CheckNeighbor(r - 1, c, image, newColor, oldColor, visited, connected);
			CheckNeighbor(r, c - 1, image, newColor, oldColor, visited, connected);
			CheckNeighbor(r, c + 1, image, newColor, oldColor, visited, connected);
			CheckNeighbor(r + 1, c, image, newColor, oldColor, visited, connected);
		}

		return image;
	}

	internal void CheckNeighbor(int r, int c, int[][] image, int newColor, int oldColor, HashSet<(int, int)> visited, Stack<(int, int)> connected)
	{
		if (r < 0 || c < 0 || r == image.Length || c == image[0].Length) return;

		int color = image[r][c];
		if (color == oldColor && !visited.Contains((r, c)))
		{
			visited.Add((r, c));
			connected.Push((r, c));
		}
	}
}

#region private::Tests

/// <summary>
/// Input: image = [[1,1,1],[1,1,0],[1,0,1]], sr = 1, sc = 1, color = 2
/// Output: [[2,2,2],[2,2,0],[2,0,1]]
/// Explanation: From the center of the image with position (sr, sc) = (1, 1) (i.e., the red pixel), all pixels connected by a path of the same color as the starting pixel (i.e., the blue pixels) are colored with the new color.
/// Note the bottom corner is not colored 2, because it is not 4-directionally connected to the starting pixel.
/// 
/// </summary>
[Fact]
void Test1()
{
	int[][] image = new[]
	{
		new []{1,1,1},
		new []{1,1,0},
		new []{1,0,1}
	};

	int[][] expected = new[]
	{
		new []{2,2,2},
		new []{2,2,0},
		new []{2,0,1}
	};

	int sr = 1;
	int sc = 1;
	int color = 2;
	int[][] result = new Solution().FloodFill(image, sr, sc, color);
	Assert.Equal(expected, result);
}

/*

Example 2:
Input: image = [[0,0,0],[0,0,0]], sr = 0, sc = 0, color = 0
Output: [[0,0,0],[0,0,0]]
Explanation: The starting pixel is already colored 0, so no changes are made to the image.
*/
#endregion