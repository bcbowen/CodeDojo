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

	public int FindLonelyPixel(char[][] picture)
	{
		int[] rTotals = new int[picture.Length]; 
		int[] cTotals = new int[picture[0].Length];
				
		for (int i = 0; i < picture.Length; i++)
		{
			for (int j = 0; j < picture[i].Length; j++)
			{
				if (picture[i][j] == 'B')
				{
					rTotals[i]++; 
					cTotals[j]++; 
				}
			}
		}

		int lonelyPixels = 0;
		for (int i = 0; i < picture.Length; i++)
		{
			for (int j = 0; j < picture[i].Length; j++)
			{
				if (picture[i][j] == 'B')
				{
					if (rTotals[i] == 1 && cTotals[j] == 1) lonelyPixels++;
				}
			}
		}
		
		return lonelyPixels;
	}

	public int FindLonelyPixelWrong(char[][] picture)
	{
		Dictionary<int, int> colCounts = new Dictionary<int, int>();
		Dictionary<int, int> rowCounts = new Dictionary<int, int>();

		for (int i = 0; i < picture.Length; i++)
		{
			for (int j = 0; j < picture[i].Length; j++)
			{
				if (picture[i][j] == 'B')
				{
					if (!colCounts.ContainsKey(i))
					{
						colCounts.Add(i, 0);
					}
					colCounts[i]++;

					if (!rowCounts.ContainsKey(j))
					{
						rowCounts.Add(j, 0);
					}
					rowCounts[j]++;
				}
			}
		}
		return Math.Min(colCounts.Values.Count(v => v == 1), rowCounts.Values.Count(v => v == 1));
	}

}

#region Tests

[Theory]
[InlineData(3, new[] {'W','W','B'}, new[] {'W','B','W'}, new[] {'B','W','W'})]
[InlineData(0, new[] { 'B', 'B', 'B' }, new[] { 'B', 'B', 'W' }, new[] { 'B', 'B', 'B' })]
[InlineData(0, new[] { 'B', 'B', 'B' }, new[] { 'B', 'B', 'W' }, new[] { 'B', 'B', 'B' })]
[InlineData(1, new[]{ 'B' })]
[InlineData(0, new[]{ 'W' })]
[InlineData(1, new[]{ 'W', 'B' })]
[InlineData(0, new[] { 'W', 'B', 'W', 'W' }, new[] { 'W', 'B', 'B', 'W' }, new[] { 'W', 'W', 'W', 'W' })]

void Test(int expected, params char[][] picture) 
{
	int result = new Solution().FindLonelyPixel(picture);
	Assert.Equal(expected, result);
}

/*

[["W","B","W","W"],["W","B","B","W"],["W","W","W","W"]]
Output
1
Expected
0


Input: picture = [["W","W","B"],["W","B","W"],["B","W","W"]]
Output: 3
Explanation: All the three 'B's are black lonely pixels.

Input: picture = [["B","B","B"],["B","B","W"],["B","B","B"]]
Output: 0
*/
#endregion