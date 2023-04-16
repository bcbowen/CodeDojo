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
	private int _n; 
	HashSet<(int, int)> foundQueens; 
	public IList<IList<string>> SolveNQueens(int n)
	{
		_n = n;
		
		foundQueens = new HashSet<(int, int)>();

		for (int x = 0; x < n; x++) 
		{
			IList<IList<string>> board = InitBoard(n);
		    int queenCount = 0;
			SetQueen(x, 0, board); 
		}
	}

	internal string[][] FindNext(int x, int y, 

	internal IList<IList<string>> InitBoard(int n) 
	{
		string[][] board = new string[n][];
		for (int i = 0; i < n; i++) 
		{
			board[i] = new string[n]; 
			Array.Fill(board[i], "."); 
		}
		return board;
	}

	internal (IList<IList<string>>, bool) SetQueen(int x, int y, IList<IList<string>> board) 
	{
		if (board[y][x] == "x")
		{
			return (board, true);
		}

		board[y][x] = "Q";
		int row, col;
		for (col = 0; col < _n; col++) 
		{
			if (col == x) continue;
			board[y][col] = "x"; 
		}

		for (row = 0; row < _n; row++)
		{
			if (row == y) continue;
			board[row][x] = "x"; 
		}
		
		row = y - 1; 
		col = x - 1;

		while (x >= 0 && y >= 0) 
		{
			board[col][row] = "x"; 
			row--; 
			col--; 
		}

		row = y + 1;
		col = x + 1;

		while (x < _n && y < _n)
		{
			board[col][row] = "x";
			row++;
			col++;
		}

		row = y - 1;
		col = x + 1;

		while (x < _n && y >= 0)
		{
			board[col][row] = "x";
			row--;
			col++;
		}

		row = y + 1;
		col = x - 1;

		while (x >= 0 && y < _n)
		{
			board[col][row] = "x";
			row--;
			col++;
		}
		
		return (board, true);
	}
}

#region private::Tests

[Fact] void Test_Xunit() => Assert.True (1 + 1 == 2);

#endregion