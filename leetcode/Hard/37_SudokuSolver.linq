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
		SudokuSolver solver = new SudokuSolver();
		SudokuBoard sudokuBoard = SudokuBoard.Create(board);
		solver.Solve(sudokuBoard);
		board = solver.Board.ToCharArray();
	}
}

internal struct Section
{
	public Section(int beginRow, int beginColumn, int endRow, int endColumn)
	{
		BeginRow = beginRow;
		BeginColumn = beginColumn;
		EndRow = endRow;
		EndColumn = endColumn;
	}

	public int BeginRow { get; set; }
	public int EndRow { get; set; }

	public int BeginColumn { get; set; }
	public int EndColumn { get; set; }

	private static Section[] _sudokuSections = null;
	public static Section[] SudokuSections
	{
		get
		{
			if (_sudokuSections == null)
			{
				_sudokuSections = new Section[9];
				int i = 0;
				for (int row = 0; row < 7; row += 3)
				{
					for (int col = 0; col < 7; col += 3)
					{
						Section section = new Section(row, col, row + 2, col + 2);
						_sudokuSections[i++] = section;
					}
				}
			}

			return _sudokuSections;
		}
	}

	public static Section GetSection(int row, int col)
	{
		for (int i = 8; i >= 0; i--)
		{
			if (SudokuSections[i].BeginRow <= row && SudokuSections[i].BeginColumn <= col) return SudokuSections[i];
		}

		throw new ArgumentOutOfRangeException($"Section not found for row {row}, col {col}");
	}
}

internal class SudokuCell : ICloneable
{
	public SudokuCell()
	{
		PossibleValues = new List<int>();
	}

	public int Value { get; set; }
	public List<int> PossibleValues { get; set; }

	public bool Contains(int value)
	{
		return PossibleValues.Contains(value);
	}

	public bool Remove(int value)
	{
		return PossibleValues.Remove(value);
	}

	public int RemoveRange(List<int> values)
	{
		return PossibleValues.RemoveAll(value => values.Contains(value));
	}

	public object Clone() 
	{
		SudokuCell cloned = new SudokuCell();
		cloned.Value = Value;
		foreach(int possibleValue in PossibleValues)
		{
			cloned.PossibleValues.Add(possibleValue); 
		}
		return cloned;
	}

}

internal class SudokuBoard : ICloneable
{
	public SudokuBoard()
	{
		Board = new List<List<UserQuery.SudokuCell>>();
	}
	public List<List<SudokuCell>> Board { get; set; }

	public static SudokuBoard Create(char[][] board)
	{
		SudokuBoard sudokuBoard = new SudokuBoard();

		for (int i = 0; i < 9; i++)
		{
			sudokuBoard.Board.Add(new List<SudokuCell>());
			for (int j = 0; j < 9; j++)
			{
				sudokuBoard.Board[i].Add(new SudokuCell());
				if (board[i][j] != '.')
				{
					sudokuBoard.Board[i][j].Value = int.Parse(board[i][j].ToString());
				}
				else
				{
					sudokuBoard.Board[i][j].PossibleValues.AddRange(Enumerable.Range(1, 9));
				}
			}
		}

		return sudokuBoard;
	}

	/// <summary>
	/// When single value is found for cell, eliminate this value for all other cells in 
	/// row, column, section. Called recursively as additional values are found.
	/// </summary>
	internal void FilterCell(int row, int col)
	{
		// get val from cell 
		int val = Board[row][col].Value;

		// remove value from columns in same row
		for (int x = 0; x < 9; x++)
		{
			if (Board[row][x].Contains(val))
			{
				Board[row][x].Remove(val);

				if (Board[row][x].PossibleValues.Count == 1)
				{
					Board[row][x].Value = Board[row][x].PossibleValues[0];
					FilterCell(row, x);
				}
			}
		}

		// remove value from rows in same col
		for (int y = 0; y < 9; y++)
		{
			if (Board[y][col].Contains(val))
			{
				Board[y][col].Remove(val);
				if (Board[y][col].PossibleValues.Count == 1)
				{
					Board[y][col].Value = Board[y][col].PossibleValues[0];
					FilterCell(y, col);
				}
			}
		}

		// remove value from same section
		Section section = Section.GetSection(row, col);
		for (int x = section.BeginColumn; x <= section.EndColumn; x++)
		{
			for (int y = section.BeginRow; y <= section.EndRow; y++)
			{
				if (Board[y][x].Contains(val))
				{
					Board[y][x].Remove(val);
					if (Board[y][x].PossibleValues.Count == 1)
					{
						Board[y][x].Value = Board[y][x].PossibleValues[0];
						FilterCell(y, x);
					}
				}
			}
		}
	}

	/// <summary>
	/// Remove this value from cells in this row, column, and section. 
	/// Returns true if there are still cells that have multiple possibilities.
	/// </summary>
	internal void Filter()
	{
		// Filter Rows
		for (int row = 0; row < 9; row++)
		{
			FilterRange(0, 8, row, row);
		}

		// Filter Columns
		for (int col = 0; col < 9; col++)
		{
			FilterRange(col, col, 0, 8);
		}
		// Filter Sections
		for (int i = 0; i < 9; i++)
		{
			Section section = Section.SudokuSections[i];
			FilterRange(section.BeginColumn, section.EndColumn, section.BeginRow, section.EndRow);
		}
	}

	internal void FilterRange(int beginX, int endX, int beginY, int endY)
	{
		List<int> singleValues = new List<int>();
		List<(int, int)> multiIndexCells = new List<(int, int)>();
		for (int y = beginY; y <= endY; y++)
		{
			for (int x = beginX; x <= endX; x++)
			{
				if (Board[y][x].Value < 1)
				{
					multiIndexCells.Add((y, x));
				}
				else
				{
					singleValues.Add(Board[y][x].Value);
				}
			}
		}

		// filter out single values from cells with multiple possibilities
		foreach ((int row, int col) in multiIndexCells)
		{
			Board[row][col].PossibleValues.RemoveAll(l => singleValues.Contains(l));

			// if we are left with a single value, clean up the row, col, and section containing this value
			if (Board[row][col].PossibleValues.Count == 1)
			{
				Board[row][col].Value = Board[row][col].PossibleValues[0];
				FilterCell(row, col);
			}
		}

	}

	/// <summary>
	/// Check for values that can only be one of the cells in a row, col, or section 
	/// Ex: in a row, one cell has possible values 1, 3, 6, and no other cell in that row can be 6, we know this cell is 6 and we can eliminate the other possibilities
	/// </summary>
	internal void Eliminate()
	{
		// check each row
		for (int row = 0; row < 9; row++)
		{
			EliminateRange(0, 8, row, row);
		}
		// check each col
		for (int col = 0; col < 9; col++)
		{
			EliminateRange(col, col, 0, 8);
		}

		// check each section
		for (int i = 0; i < 9; i++)
		{
			Section section = Section.SudokuSections[i];
			EliminateRange(section.BeginColumn, section.EndColumn, section.BeginRow, section.EndRow);
		}
	}

	internal void EliminateRange(int beginX, int endX, int beginY, int endY)
	{
		// index corresponds to value 1-9, bool indicates if the Value is known
		bool[] values = new bool[10];

		// index corresponds to value, possible cells are cells in the range that could be this value
		List<List<(int, int)>> possibleCells = new List<List<(int, int)>>();

		for (int i = 0; i <= 9; i++)
		{
			possibleCells.Add(new List<(int, int)>());
		}

		for (int row = beginY; row <= endY; row++)
		{
			for (int col = beginX; col <= endX; col++)
			{
				if (Board[row][col].Value > 0)
				{
					values[Board[row][col].Value] = true;
				}
				else
				{
					foreach (int val in Board[row][col].PossibleValues)
					{
						possibleCells[val].Add((row, col));
					}
				}
			}
		}


		for (int i = 0; i < possibleCells.Count; i++)
		{
			if (possibleCells[i].Count == 1)
			{
				(int y, int x) = possibleCells[i][0];
				Board[y][x].PossibleValues.Clear();
				Board[y][x].PossibleValues.Add(i);
				Board[y][x].Value = i;
				FilterCell(y, x);
			}
		}
	}

	public bool CheckSudokuBoard()
	{
		bool result = true;
		// vertical 
		for (int col = 0; col < 9; col++)
		{
			result = result && CheckRegion(col, col, 0, 8);
			if (!result) break;
		}

		if (result)
		{
			for (int row = 0; row < 9; row++)
			{
				result = result && CheckRegion(0, 8, row, row);
				if (!result) break;
			}
		}

		if (result)
		{
			for (int i = 0; i < 9; i++)
			{
				Section section = Section.SudokuSections[i];
				result = result && CheckRegion(section.BeginColumn, section.EndColumn, section.BeginRow, section.EndRow);
				if (!result) break;
			}
		}

		return result;
	}

	internal bool CheckRegion(int beginX, int endX, int beginY, int endY)
	{
		bool[] values;
		for (int x = beginX; x <= endX; x++)
		{
			values = new bool[10];
			for (int y = beginY; y <= endY; y++)
			{
				if (Board[y][x].Value == 0 || values[Board[y][x].Value]) return false;
				values[Board[y][x].Value] = true;
			}
		}
		return true;
	}

	public char[][] ToCharArray()
	{
		char[][] board = new char[9][];
		for (int i = 0; i < 9; i++)
		{
			board[i] = new char[9];
		}

		// update board
		for (int col = 0; col < 9; col++)
		{
			for (int row = 0; row < 9; row++)
			{
				if (Board[col][row].Value > 0)
				{
					board[col][row] = (char)(Board[col][row].Value + '0');
				}
				else
				{
					board[col][row] = '.';
				}
			}
		}

		return board;
	}

	public object Clone() 
	{
		SudokuBoard cloned = new SudokuBoard();
		foreach(List<SudokuCell> row in Board)
		{
			List<SudokuCell> clonedRow = new List<SudokuCell>();
			foreach (SudokuCell cell in row) 
			{
				clonedRow.Add(cell); 
			}
			cloned.Board.Add(clonedRow); 
		}
		
		return cloned;
	}
}

internal class SudokuSolver
{
	public SudokuBoard Board;

	public void Solve(SudokuBoard board)
	{
		Board = board;

		bool isSolved = false;
	
		Board.Filter();
		isSolved = Board.CheckSudokuBoard();

		if (!isSolved) Board.Eliminate();

		isSolved = Board.CheckSudokuBoard();
	
		//Console.Write($"Solved after {reps} reps"); 
	}

	

	/// <summary>
	/// Find a cell with the minumum possible values (most likely 2) and test each possibility with the cascading effects. One choice will be right and we'll keep that, 
	/// we discard bad choices. 
	/// 
	/// 
	/// TODO: We need to move filter, eliminate, and this one to the board object. We don't want them to belong to the solver since at this point the solver 
	/// needs to work with mutliple possible boards. 
	/// </summary>
	internal void PickAndGrin()
	{
		Stack<SudokuBoard> boardStack = new Stack<SudokuBoard>();
		(int y, int x) minCell; 
		int minCount; 
		while(!Board.CheckSudokuBoard()) 
		{
			minCount = 11; 
			minCell = (0, 0); 
			// find candidate with min possible values
			for(int y = 0; y < 9; y++)
			{
				List<SudokuCell> row = Board.Board[y]; 
				for (int x = 0; x < 9; x++)
				{
					SudokuCell cell = row[x];
					if (cell.PossibleValues.Count < minCount) 
					{
						minCell = (y, x); 
					}
				}
			}

			foreach(int val in Board.Board[minCell.y][minCell.x].PossibleValues) 
			{
				SudokuBoard newBoard = Board.Clone() as SudokuBoard;
				newBoard.Board[minCell.y][minCell.x].Value = val;
				newBoard.FilterCell(minCell.y, minCell.x); 
				boardStack.Push(newBoard); 
			}
		}
	}

}



public class SudokuTests
{
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

		SudokuSolver ss = new SudokuSolver();
		ss.Board = SudokuBoard.Create(board);
		Assert.Equal(9, ss.Board.Board.Count());
		Assert.Equal(9, ss.Board.Board[0].Count());
		Assert.Equal(5, ss.Board.Board[0][0].Value);
		Assert.Equal(8, ss.Board.Board[8][4].Value);
	}

	[Fact]
	void SolveTest1()
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


		Solution s = new Solution();
		s.SolveSudoku(board);
		Assert.Equal(expected, board);
		SudokuBoard sb = SudokuBoard.Create(board);
		Assert.True(sb.CheckSudokuBoard());
	}

	[Fact]
	void SolveTest2()
	{
		char[][] board =
		{
		new []{'.','.','9','7','4','8','.','.','.'},
		new []{'7','.','.','.','.','.','.','.','.'},
		new []{'.','2','.','1','.','9','.','.','.'},
		new []{'.','.','7','.','.','.','2','4','.'},
		new []{'.','6','4','.','1','.','5','9','.'},
		new []{'.','9','8','.','.','.','3','.','.'},
		new []{'.','.','.','8','.','3','.','2','.'},
		new []{'.','.','.','.','.','.','.','.','6'},
		new []{'.','.','.','2','7','5','9','.','.'}
	};

		Solution s = new Solution();
		s.SolveSudoku(board);
		SudokuBoard sb = SudokuBoard.Create(board);
		Assert.True(sb.CheckSudokuBoard());
	}

	/*

	new []{".",".","9","7","4","8",".",".","."},
	new []{"7",".",".",".",".",".",".",".","."},
	new []{".","2",".","1",".","9",".",".","."},
	new []{".",".","7",".",".",".","2","4","."},
	new []{".","6","4",".","1",".","5","9","."},
	new []{".","9","8",".",".",".","3",".","."},
	new []{".",".",".","8",".","3",".","2","."},
	new []{".",".",".",".",".",".",".",".","6"},
	new []{".",".",".","2","7","5","9",".","."}
	*/

	[Fact]
	void SectionInitializerTests()
	{
		Assert.NotNull(Section.SudokuSections);
		Assert.Equal(9, Section.SudokuSections.Length);
		// first section
		Assert.Equal(0, Section.SudokuSections[0].BeginRow);
		Assert.Equal(0, Section.SudokuSections[0].BeginColumn);
		Assert.Equal(2, Section.SudokuSections[0].EndRow);
		Assert.Equal(2, Section.SudokuSections[0].EndColumn);
		// fifth (middle) section
		Assert.Equal(3, Section.SudokuSections[4].BeginRow);
		Assert.Equal(3, Section.SudokuSections[4].BeginColumn);
		Assert.Equal(5, Section.SudokuSections[4].EndRow);
		Assert.Equal(5, Section.SudokuSections[4].EndColumn);

		// last section
		Assert.Equal(6, Section.SudokuSections[8].BeginRow);
		Assert.Equal(6, Section.SudokuSections[8].BeginColumn);
		Assert.Equal(8, Section.SudokuSections[8].EndRow);
		Assert.Equal(8, Section.SudokuSections[8].EndColumn);

		// sixth section (c1 r3)
		Assert.Equal(6, Section.SudokuSections[6].BeginRow);
		Assert.Equal(0, Section.SudokuSections[6].BeginColumn);
		Assert.Equal(8, Section.SudokuSections[6].EndRow);
		Assert.Equal(2, Section.SudokuSections[6].EndColumn);
	}

	[Theory]
	[InlineData(2, 1, 0, 0)]
	[InlineData(0, 0, 0, 0)]
	[InlineData(0, 5, 0, 3)]
	[InlineData(0, 3, 0, 3)]
	[InlineData(1, 7, 0, 6)]
	[InlineData(0, 6, 0, 6)]

	[InlineData(4, 1, 3, 0)]
	[InlineData(3, 0, 3, 0)]
	[InlineData(5, 5, 3, 3)]
	[InlineData(3, 3, 3, 3)]
	[InlineData(3, 4, 3, 3)]
	[InlineData(3, 3, 3, 3)]

	[InlineData(7, 1, 6, 0)]
	[InlineData(6, 0, 6, 0)]
	[InlineData(7, 5, 6, 3)]
	[InlineData(6, 3, 6, 3)]
	[InlineData(8, 6, 6, 6)]
	[InlineData(6, 6, 6, 6)]


	void GetSectionTest(int row, int col, int expectedBeginRow, int expectedBeginCol)
	{
		Section section = Section.GetSection(row, col);
		Assert.Equal(expectedBeginRow, section.BeginRow);
		Assert.Equal(expectedBeginCol, section.BeginColumn);
	}

	/// <summary>Start with initial board and run filter, which will run filter by row, column, and section</summary>
	[Fact]
	void FilterTest()
	{
		char[][] board =
		{
		new []{'.','.','9','7','4','8','.','.','.'},
		new []{'7','.','.','.','.','.','.','.','.'},
		new []{'.','2','.','1','.','9','.','.','.'},
		new []{'.','.','7','.','.','.','2','4','.'},
		new []{'.','6','4','.','1','.','5','9','.'},
		new []{'.','9','8','.','.','.','3','.','.'},
		new []{'.','.','.','8','.','3','.','2','.'},
		new []{'.','.','.','.','.','.','.','.','6'},
		new []{'.','.','.','2','7','5','9','.','.'}
	};
		SudokuSolver ss = new SudokuSolver();
		ss.Board = SudokuBoard.Create(board);
		ss.Filter();
		List<int> expected = new List<int> { 1, 3, 5 };
		Assert.Equal(expected, ss.Board.Board[0][1].PossibleValues);
		expected = new List<int> { 3, 5, 7, 8 };
		Assert.Equal(expected, ss.Board.Board[2][7].PossibleValues);
	}

	/*
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
	*/

	[Fact]
	void ValidateValidBoardTest()
	{
		char[][] board =
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

		SudokuSolver ss = new SudokuSolver();
		ss.Board = SudokuBoard.Create(board);
		Assert.True(ss.Board.CheckSudokuBoard());
	}

	[Fact]
	void ValidateInvalidBoardTest()
	{
		// first row 2 fives
		char[][] board =
		{
		new []{'5','5','4','6','7','8','9','1','2'},
		new []{'6','7','2','1','9','5','3','4','8'},
		new []{'1','9','8','3','4','2','5','6','7'},
		new []{'8','5','9','7','6','1','4','2','3'},
		new []{'4','2','6','8','5','3','7','9','1'},
		new []{'7','1','3','9','2','4','8','5','6'},
		new []{'9','6','1','5','3','7','2','8','4'},
		new []{'2','8','7','4','1','9','6','3','5'},
		new []{'3','4','5','2','8','6','1','7','9'}
	};

		SudokuSolver ss = new SudokuSolver();
		ss.Board = SudokuBoard.Create(board);
		Assert.False(ss.Board.CheckSudokuBoard());
	}
}


