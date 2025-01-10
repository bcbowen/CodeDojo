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
	public bool IsValidSudoku(char[][] board)
	{
		if (!CheckVerticals(board)) return false;
		if (!CheckHorizontals(board)) return false;
		if (!CheckSquares(board)) return false;
		return true;
	}

	internal bool CheckVerticals(char[][] board)
	{
		bool[] values = new bool[10];
		for (int x = 0; x < 9; x++)
		{
			values = new bool[10];
			for (int y = 0; y < 9; y++)
			{
				int value;
				if (int.TryParse(board[y][x].ToString(), out value))
				{
					if (values[value]) return false;
					values[value] = true;
				}
			}
		}
		return true;
	}

	internal bool CheckHorizontals(char[][] board)
	{
		bool[] values = new bool[10];
		for (int y = 0; y < 9; y++)
		{
			values = new bool[10];
			for (int x = 0; x < 9; x++)
			{
				int value;
				if (int.TryParse(board[y][x].ToString(), out value))
				{
					if (values[value]) return false;
					values[value] = true;
				}
			}
		}
		return true;
	}

	internal bool CheckSquares(char[][] board)
	{
		int[][] squares = new[] {
			new [] {0, 0, 2, 2},
			new []{0, 3, 2, 5},
			new []{0, 6, 2, 8},
			new []{3, 0, 5, 2},
			new []{3, 3, 5, 5},
			new []{3, 6, 5, 8 },
			new []{6, 0, 8, 2},
			new []{6, 3, 8, 5},
			new []{6, 6, 8, 8},
		};

		for (int i = 0; i < 9; i++)
		{
			bool[] values = new bool[10];
			for (int y = squares[i][0]; y <= squares[i][2]; y++)
			{
				for (int x = squares[i][1]; x <= squares[i][3]; x++)
				{
					int value;
					if (int.TryParse(board[y][x].ToString(), out value))
					{
						if (values[value]) return false;
						values[value] = true;
					}
				}
			}
		}

		return true;
	}
}

/*
Input: board = 
[['5','3','.','.','7','.','.','.','.']
,['6','.','.','1','9','5','.','.','.']
,['.','9','8','.','.','.','.','6','.']
,['8','.','.','.','6','.','.','.','3']
,['4','.','.','8','.','3','.','.','1']
,['7','.','.','.','2','.','.','.','6']
,['.','6','.','.','.','.','2','8','.']
,['.','.','.','4','1','9','.','.','5']
,['.','.','.','.','8','.','.','7','9']]
Output: true
Example 2:

Input: board = 
[['8','3','.','.','7','.','.','.','.']
,['6','.','.','1','9','5','.','.','.']
,['.','9','8','.','.','.','.','6','.']
,['8','.','.','.','6','.','.','.','3']
,['4','.','.','8','.','3','.','.','1']
,['7','.','.','.','2','.','.','.','6']
,['.','6','.','.','.','.','2','8','.']
,['.','.','.','4','1','9','.','.','5']
,['.','.','.','.','8','.','.','7','9']]
Output: false
Explanation: Same as Example 1, except with the 5 in the top left corner being modified to 8. Since there are two 8's in the top left 3x3 sub-box, it is invalid.
*/

// good: 
[Theory]
[InlineData(true,
new[] { '5', '3', '.', '.', '7', '.', '.', '.', '.' },
new[] { '6', '.', '.', '1', '9', '5', '.', '.', '.' },
new[] { '.', '9', '8', '.', '.', '.', '.', '6', '.' },
new[] { '8', '.', '.', '.', '6', '.', '.', '.', '3' },
new[] { '4', '.', '.', '8', '.', '3', '.', '.', '1' },
new[] { '7', '.', '.', '.', '2', '.', '.', '.', '6' },
new[] { '.', '6', '.', '.', '.', '.', '2', '8', '.' },
new[] { '.', '.', '.', '4', '1', '9', '.', '.', '5' },
new[] { '.', '.', '.', '.', '8', '.', '.', '7', '9' }
)]

// vert
[InlineData(false,
new[] { '8', '3', '.', '.', '7', '.', '.', '.', '.' },
new[] { '6', '.', '.', '1', '9', '5', '.', '.', '.' },
new[] { '.', '9', '8', '.', '.', '.', '.', '6', '.' },
new[] { '8', '.', '.', '.', '6', '.', '.', '.', '3' },
new[] { '4', '.', '.', '8', '.', '3', '.', '.', '1' },
new[] { '7', '.', '.', '.', '2', '.', '.', '.', '6' },
new[] { '.', '6', '.', '.', '.', '.', '2', '8', '.' },
new[] { '.', '.', '.', '4', '1', '9', '.', '.', '5' },
new[] { '.', '.', '.', '.', '8', '.', '.', '7', '9' }
)]

// horizontal
[InlineData(false,
new[] { '5', '3', '.', '.', '7', '.', '5', '.', '.' },
new[] { '6', '.', '.', '1', '9', '5', '.', '.', '.' },
new[] { '.', '9', '8', '.', '.', '.', '.', '6', '.' },
new[] { '8', '.', '.', '.', '6', '.', '.', '.', '3' },
new[] { '4', '.', '.', '8', '.', '3', '.', '.', '1' },
new[] { '7', '.', '.', '.', '2', '.', '.', '.', '6' },
new[] { '.', '6', '.', '.', '.', '.', '2', '8', '.' },
new[] { '.', '.', '.', '4', '1', '9', '.', '.', '5' },
new[] { '.', '.', '.', '.', '8', '.', '.', '7', '9' }
)]

// Square 9
[InlineData(false,
new[] { '5', '3', '.', '.', '7', '.', '.', '.', '.' },
new[] { '6', '.', '.', '1', '9', '5', '.', '.', '.' },
new[] { '.', '9', '8', '.', '.', '.', '.', '6', '.' },
new[] { '8', '.', '.', '.', '6', '.', '.', '.', '3' },
new[] { '4', '.', '.', '8', '.', '3', '.', '.', '1' },
new[] { '7', '.', '.', '.', '2', '.', '.', '.', '6' },
new[] { '.', '6', '.', '.', '.', '.', '2', '8', '.' },
new[] { '.', '.', '.', '4', '1', '9', '.', '2', '5' },
new[] { '.', '.', '.', '.', '8', '.', '.', '7', '9' }
)]

// Square 3

[InlineData(false,
new[] { '.', '.', '.', '.', '5', '.', '.', '1', '.' },
new[] { '.', '4', '.', '3', '.', '.', '.', '.', '.' },
new[] { '.', '.', '.', '.', '.', '3', '.', '.', '1' },
new[] { '8', '.', '.', '.', '.', '.', '.', '2', '.' },
new[] { '.', '.', '2', '.', '7', '.', '.', '.', '.' },
new[] { '.', '1', '5', '.', '.', '.', '.', '.', '.' },
new[] { '.', '.', '.', '.', '.', '2', '.', '.', '.' },
new[] { '.', '2', '.', '9', '.', '.', '.', '.', '.' },
new[] { '.', '.', '4', '.', '.', '.', '.', '.', '.' }
)]

void Test(bool expected, params char[][] board)
{
	bool result = new Solution().IsValidSudoku(board);
	Assert.Equal(expected, result);
}