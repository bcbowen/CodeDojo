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

	internal struct Section
	{
		public Section(int beginRow, int beginColumn, int endRow, int endColumn)
		{
			BeginRow = beginRow; 
			BeginColumn = beginColumn; 
			EndRow = endRow; 
			EndColumn = endColumn; 
		}
		
		public int BeginRow {get; set;} 
		public int EndRow {get; set;} 
		
		public int BeginColumn {get; set;} 
		public int EndColumn {get; set;}

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
			for(int i = 8; i >= 0; i--)
			{
				if (SudokuSections[i].BeginRow <= row && SudokuSections[i].BeginColumn <= col) return SudokuSections[i];
			}

			throw new ArgumentOutOfRangeException($"Section not found for row {row}, col {col}"); 
		}
	}
	
	public void SolveSudoku(char[][] board)
	{
		Solve(board); 
	}

	internal void Solve(char[][] board)
	{
		Initialize(board);

		bool isSolved = false;
		int reps = 0; 
		while (!isSolved && reps < 5)
		{
			Filter(); 

			isSolved = IsFinished();
			 reps++; 
		}
		//Console.Write($"Solved after {reps} reps"); 
		
		
		// update board
		for (int col = 0; col < 9; col++)
		{
			for(int row = 0; row < 9; row++)
			{
				if (SudokuBoard[col][row].Count == 1) 
				{
					board[col][row] = (char)(SudokuBoard[col][row][0] + '0'); 
				}				
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
	internal void Filter()
	{
		FilterColumns();
		FilterRows(); 
		FilterSections();
	}

	/// <summary>
	/// Go col by col and filter out known single values. 
	/// As single values are found, process their associated rows, cols, and sections
	/// </summary>
	internal void FilterColumns()
	{
		for (int col = 0; col < 9; col++)
		{
			List<int> singleValues = new List<int>();
			List<int> multiIndexes = new List<int>(); 
			for (int row = 0; row < 9; row++)
			{
				if (SudokuBoard[row][col].Count > 1)
				{
					multiIndexes.Add(row);
				}
				else
				{
					singleValues.Add(SudokuBoard[row][col][0]);
				}
			}

			// filter out single values from cells with multiple possibilities
			foreach (int row in multiIndexes)
			{
				SudokuBoard[row][col].RemoveAll(l => singleValues.Contains(l));

				// if we are left with a single value, clean up the row, col, and section containing this value
				if (SudokuBoard[row][col].Count == 1) FilterCell(row, col);
			}
		}
	}

	/// <summary>
	/// Go row by row and filter out known single values. 
	/// As single values are found, process their associated rows, cols, and sections
	/// </summary>
	internal void FilterRows()
	{
		for (int row = 0; row < 9; row++)
		{
			List<int> singleValues = new List<int>();
			List<int> multiIndexes = new List<int>(); 
			for (int col = 0; col < 9; col++)
			{
				if (SudokuBoard[row][col].Count > 1) 
				{
					multiIndexes.Add(col);
				}
				else 
				{
					singleValues.Add(SudokuBoard[row][col][0]); 
				}
			}

			// filter out single values from cells with multiple possibilities
			foreach(int col in multiIndexes) 
			{
				SudokuBoard[row][col].RemoveAll(l => singleValues.Contains(l)); 
				
				// if we are left with a single value, clean up the row, col, and section containing this value
				if (SudokuBoard[row][col].Count == 1) FilterCell(row, col); 
			}
		}
		
	}

	/// <summary>
	/// When single value is found for cell, eliminate this value for all other cells in 
	/// row, column, section. Called recursively as additional values are found.
	/// </summary>
	internal void FilterCell(int row, int col)
	{
		// get val from cell 
		int val = SudokuBoard[row][col][0];

		// remove value from columns in same row
		for (int x = 0; x < 9; x++)
		{
			if (SudokuBoard[row][x].Count > 1 && SudokuBoard[row][x].Contains(val))
			{
				SudokuBoard[row][x].Remove(val);
				
				if (SudokuBoard[row][x].Count == 1) FilterCell(row, x);
			}
		}

		// remove value from rows in same col
		for (int y = 0; y < 9; y++)
		{
			if (SudokuBoard[y][col].Count > 1 && SudokuBoard[y][col].Contains(val))
			{
				SudokuBoard[y][col].Remove(val);
				if (SudokuBoard[y][col].Count == 1) FilterCell(y,col);
			}
		}

		// remove value from same section
		Section section = Section.GetSection(row, col);
		for (int x = section.BeginColumn; x <= section.EndColumn; x++)
		{
			for (int y = section.BeginRow; y <= section.EndRow; y++)
			{
				if (SudokuBoard[y][x].Count > 1 && SudokuBoard[y][x].Contains(val))
				{
					SudokuBoard[y][x].Remove(val);
					if (SudokuBoard[y][x].Count == 1) FilterCell(y,x);
				}
			}
		}
	}

	/// <summary>
	/// Check each section and filter cells that have been found.
	/// </summary>
	internal void FilterSections()
	{
		foreach(Section section in Section.SudokuSections)
		{
			List<int> singleValues = new List<int>();
			List<(int, int)> multiIndexes = new List<(int, int)>();
			
			for (int row = section.BeginRow; row <= section.EndRow; row++)
			{
				
				for (int col = section.BeginColumn; col <= section.EndColumn; col++)
				{
					if (SudokuBoard[row][col].Count > 1)
					{
						multiIndexes.Add((row, col));
					}
					else
					{
						singleValues.Add(SudokuBoard[row][col][0]);
					}
				}				
			}
			// filter out single values from cells with multiple possibilities
			foreach ((int y, int x) in multiIndexes)
			{
				SudokuBoard[y][x].RemoveAll(l => singleValues.Contains(l));

				// if we are left with a single value, clean up the row, col, and section containing this value
				if (SudokuBoard[y][x].Count == 1) FilterCell(y, x);
			}
		}
	}

	internal bool IsFinished()
	{
		for(int x = 0; x < 9; x++)
		{
			for (int y = 0; y < 9; y++)
			{
				if (SudokuBoard[y][x].Count > 1) return false;
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

[Fact]
void SectionInitializerTests() 
{
	Assert.NotNull(Solution.Section.SudokuSections); 
	Assert.Equal(9, Solution.Section.SudokuSections.Length); 
	// first section
	Assert.Equal(0, Solution.Section.SudokuSections[0].BeginRow);
	Assert.Equal(0, Solution.Section.SudokuSections[0].BeginColumn);
	Assert.Equal(2, Solution.Section.SudokuSections[0].EndRow);
	Assert.Equal(2, Solution.Section.SudokuSections[0].EndColumn);
	// fifth (middle) section
	Assert.Equal(3, Solution.Section.SudokuSections[4].BeginRow);
	Assert.Equal(3, Solution.Section.SudokuSections[4].BeginColumn);
	Assert.Equal(5, Solution.Section.SudokuSections[4].EndRow);
	Assert.Equal(5, Solution.Section.SudokuSections[4].EndColumn);

	// last section
	Assert.Equal(6, Solution.Section.SudokuSections[8].BeginRow);
	Assert.Equal(6, Solution.Section.SudokuSections[8].BeginColumn);
	Assert.Equal(8, Solution.Section.SudokuSections[8].EndRow);
	Assert.Equal(8, Solution.Section.SudokuSections[8].EndColumn);

	// sixth section (c1 r3)
	Assert.Equal(6, Solution.Section.SudokuSections[6].BeginRow);
	Assert.Equal(0, Solution.Section.SudokuSections[6].BeginColumn);
	Assert.Equal(8, Solution.Section.SudokuSections[6].EndRow);
	Assert.Equal(2, Solution.Section.SudokuSections[6].EndColumn);
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
	Solution.Section section = Solution.Section.GetSection(row, col);
	Assert.Equal(expectedBeginRow, section.BeginRow); 
	Assert.Equal(expectedBeginCol, section.BeginColumn);
}

[Fact]
void FilterRowTest() 
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
	s.FilterRows();
	List<int> expected = new List<int> {1, 2, 4, 6, 8, 9}; 
	Assert.Equal(expected, s.SudokuBoard[0][2]); 
	expected = new List<int> {1, 2, 3, 4, 5, 6}; 
	Assert.Equal(expected, s.SudokuBoard[8][0]); 
}

[Fact]
void FilterColumnTest()
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
	s.FilterColumns();
	List<int> expected = new List<int> { 1, 2, 3, 9 };
	Assert.Equal(expected, s.SudokuBoard[2][0]);
	expected = new List<int> { 3, 4, 5 };
	Assert.Equal(expected, s.SudokuBoard[2][4]);
}

[Fact]
void FilterSectionsTest()
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
	s.FilterSections();
	List<int> expected = new List<int> { 1, 2, 4, 7 };
	Assert.Equal(expected, s.SudokuBoard[2][0]);
	expected = new List<int> { 1, 3, 4, 6 };
	Assert.Equal(expected, s.SudokuBoard[6][8]);
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