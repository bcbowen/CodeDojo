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
	public void SolveSudoku(char[][] board)
	{
		if (!CheckVerticals(board)) return false;
		if (!CheckHorizontals(board)) return false;
		if (!CheckSquares(board)) return false;
		return true;
	}

	internal void Solve(char[][] board)
	{
		List<List<List<int>>> sudoku = new List<List<List<int>>>();
		for (int i = 0; i < 9; i++)
		{
			sudoku.Add(new List<List<int>>());
			for (int j = 0; j < 9; j++)
			{
				sudoku[i].Add(new List<int>());
				if (board[i][j] != '.')
				{
					sudoku[i][j].Add(int.Parse(board[i][j].ToString()));
				}
				else
				{
					sudoku[i][j].AddRange(Enumerable.Range(1, 9));
				}
			}
		}
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

[Fact]
void Test()
{
	char[][] board =
	{
		new []{'5','3','.','.','7','.','.','.','.'},
		new []{'6','.','.','1','9','5','.','.','.'},
		new []{'.','9','8','.','.','.','.','6','.'},
		new []{'8','.','.','.','6','.','.','.','3'},
		new []{'4','.','.','8','.','3','.','.','1'},
		new []{'7','.','.','.','2','.','.','.','6'},
		new []{'.','6','.','.','.','.','2','8','.'},
		new []{'.','.','.','4','1','9','.','.','5'},
		new []{'.','.','.','.','8','.','.','7','9'}
	};

	char[][] expected =
	{
		new []{'5','3','4','6','7','8','9','1','2'},
		new []{'6','7','2','1','9','5','3','4','8'},
		new []{'1','9','8','3','4','2','5','6','7'},
		new []{'8','5','9','7','6','1','4','2','3'},
		new []{'4','2','6','8','5','3','7','9','1'},
		new []{'7','1','3','9','2','4','8','5','6'},
		new []{'9','6','1','5','3','7','2','8','4'},
		new []{'2','8','7','4','1','9','6','3','5'},
		new []{'3','4','5','2','8','6','1','7','9'}
	};


	new Solution().SolveSudoku(board);
	Assert.Equal(expected, board);
}