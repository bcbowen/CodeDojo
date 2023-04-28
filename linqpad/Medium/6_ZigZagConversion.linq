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
	public string Convert(string s, int numRows)
	{
		if (numRows == 1) return s;

		char[][] grid = new char[numRows][];
		int i = 0;
		for (i = 0; i < grid.Length; i++) 
		{
			grid[i] = new char[s.Length];
		}

		i = 0;
		int col = 0;
		int row = 0;
		while(i < s.Length)
		{
			for (row = 0; row < grid.Length; row++) 
			{
				grid[row][col] = s[i]; 
				i++; 
				if(i == s.Length) break;
			}
			row--;
			while (i < s.Length && row > 1) 
			{
				row--; 
				col++;
				grid[row][col] = s[i];
				i++;
			}
			col++;
		}

		StringBuilder result = new StringBuilder();
		for (int y = 0; y < grid.Length; y++)
		{
			for (int x = 0; x < grid[0].Length; x++) 
			{
				if (grid[y][x] != '\0') result.Append(grid[y][x]); 
			}
		}
		return result.ToString();
	}
}

/*
Example 1:
Input: s = "PAYPALISHIRING", numRows = 3
Output: "PAHNAPLSIIGYIR"

Example 2:
Input: s = "PAYPALISHIRING", numRows = 4
Output: "PINALSIGYAHRPI"
Explanation:
P     I    N
A   L S  I G
Y A   H R
P     I

Example 3:
Input: s = "A", numRows = 1
Output: "A"
*/

[Theory]
[InlineData("PAYPALISHIRING", 3, "PAHNAPLSIIGYIR")]
[InlineData("PAYPALISHIRING", 4, "PINALSIGYAHRPI")]
[InlineData("A", 1, "A")]
[InlineData("A", 2, "A")]
void Test(string s, int numRows, string expected) 
{
	string result = new Solution().Convert(s, numRows);
	Assert.Equal(expected, result);
}
