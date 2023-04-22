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
	internal List<List<List<int>>> SudokuBoard;
	
	public void SolveSudoku(char[][] board)
	{
		Solve(board); 
	}

	internal void Solve(char[][] board)
	{
		Initialize(board);

		bool isSolved = false;
		while (!isSolved)
		{
			bool more = false;
			for (int row = 0; row < 9; row++)
			{
				for (int col = 0; col < 9; col++) 
				{
					more = Filter(row, col) || more; 
				}
			}

			if (!more) 
			{
				isSolved = IsFinished();
			}
		}
	}

	internal void Initialize(char[][] board) 
	{
		SudokuBoard = new List<List<List<int>>>();
		for (int i = 0; i < 9; i++)
		{
			SudokuBoard.Add(new List<List<int>>());
			for (int j = 0; j < 9; j++)
			{
				SudokuBoard[i].Add(new List<int>());
				if (board[i][j] != '.')
				{
					SudokuBoard[i][j].Add(int.Parse(board[i][j].ToString()));
				}
				else
				{
					SudokuBoard[i][j].AddRange(Enumerable.Range(1, 9));
				}
			}
		}
		
	}

	/// <summary>
	/// Remove this value from cells in this row, column, and section. 
	/// Returns true if there are still cells that have multiple possibilities.
	/// </summary>
	internal bool Filter(int row, int col)
	{
		if (SudokuBoard[row][col].Count == 0) throw new Exception($"Cell at row {row} column {col} is empty.");
		if (row < 0 || row > 8) throw new ArgumentException($"Invalid row: {row}"); 
		if (col < 0 || col > 8) throw new ArgumentException($"Invalid column: {col}"); 
		
		bool more = false;

		if (SudokuBoard[row][col].Count > 1) 
		{
			more = true;
		}
		else
		{
			int val = SudokuBoard[row][col][0];
			more = FilterColumns(row, val) || more;
			more = FilterRows(col, val) || more;
			more = FilterSection(row, col, val) || more;
		}
		
		return more;
	}

	/// <summary>
	/// Remove this value from cells in this row. 
	/// Returns true if there are still cells in this row that have multiple possibilities
	/// </summary>
	internal bool FilterColumns(int row, int val)
	{
		bool more = false;
		for (int col = 0; col < 9; col++)
		{
			if (SudokuBoard[row][col].Count > 1 && SudokuBoard[row][col].Contains(val)) 
			{
				SudokuBoard[row][col].Remove(val); 
				more = SudokuBoard[row][col].Count > 1 || more;
			}
		}
		return more;
	}

	/// <summary>
	/// Remove this value from cells in this column. 
	/// Returns true if there are still cells in this column that have multiple possibilities
	/// </summary>
	internal bool FilterRows(int col, int val)
	{
		bool more = false;
		for (int row = 0; row < 9; row++)
		{
			if (SudokuBoard[row][col].Count > 1 && SudokuBoard[row][col].Contains(val))
			{
				SudokuBoard[row][col].Remove(val);
				more = SudokuBoard[row][col].Count > 1 || more;
			}
		}
		return more;
	}

	/// <summary>
	/// Remove this value from cells in this section. 
	/// Returns true if there are still cells in this section that have multiple possibilities
	/// </summary>
	internal bool FilterSection(int row, int col, int val) 
	{
		bool more = false;
		int startX = 0;
		while (startX + 3 < col) 
		{
			startX += 3; 
		}

		int startY = 0;
		while(startY + 3 < row) 
		{
			startY += 3; 
		}
		
		int endX = startX + 2; 
		int endY = startY = 2;

		if (endY > 8 || endX > 8) throw new Exception($"Point outside of board limits. {endY}:{endX}"); 

		for (int x = startX; x <= endX; x++)
		{
			for (int y = startY; y <= endY; y++)
			{
				if (SudokuBoard[y][x].Count > 1 && SudokuBoard[y][x].Contains(val))
				{
					SudokuBoard[y][x].Remove(val);
					more = SudokuBoard[y][x].Count > 1 || more;
				}
			}
		}
		return more;
	}

	internal bool IsFinished()
	{
		for(int x = 0; x < 9; x++)
		{
			for (int y = 0; y < 9; y++)
			{
				if (SudokuBoard[y][x].Count > 0) return false;
			}
		}
		
		return true;
	}
}

[Fact]
void InitializeTest() 
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
	
	Solution s = new Solution(); 
	s.Initialize(board); 
	Assert.Equal(9, s.SudokuBoard.Count);
	Assert.Equal(9, s.SudokuBoard[0].Count);
	Assert.Equal(5, s.SudokuBoard[0][0][0]); 
	Assert.Equal(9, s.SudokuBoard[0][2].Count);
	Assert.Equal(9, s.SudokuBoard[0][2][8]);
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