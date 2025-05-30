<Query Kind="Program">
  <Namespace>Xunit</Namespace>
</Query>

#load "xunit"

void Main()
{
	RunTests(); 
}

public class Solution
{
	private int _n; 
	private int _result;
	
	public int TotalNQueens(int n)
	{
		_n = n;
		_result = 0; 

		for (int x = 0; x < n; x++) 
		{
			IList<IList<string>> board = InitBoard(n);	
			board[0][x] = "Q"; 
			FindNext(board, 1); 
		}
		
		return _result;
	}

	internal void FindNext(IList<IList<string>> board, int y)
	{
		if (y == _n) 
		{
			_result++; 
			return;
		}
		
		for (int x = 0; x < _n; x++)
		{
			IList<IList<string>> copy = CopyBoard(board, y - 1);
			copy[y][x] = "Q";
			if (CheckQueen(x, y, copy)) 
			{
				FindNext(copy, y + 1);
			}
		}
	}

	internal IList<IList<string>> CopyBoard(IList<IList<string>> board, int lastRow) 
	{
		IList<IList<string>> copy = InitBoard(_n);
		for(int y = 0; y <= lastRow; y++)
		{
			for (int x = 0; x < _n; x++)
			{
				if (board[y][x] == "Q") 
				{
					copy[y][x] = "Q"; 
					break;
				}
			}
		}
		return copy;
	}

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

	internal bool CheckQueen(int x, int y, IList<IList<string>> board) 
	{
		int row, col;
		col = x;
		// check for Queen in a different row in the same column
		for (row = 0; row < _n; row++)
		{
			if (row == y) continue;
			if (board[row][col] == "Q") return false; 
		}
		
		row = y - 1; 
		col = x - 1;

		// check diag up to left
		while (col >= 0 && row >= 0) 
		{
			if (board[row][col] == "Q") return false; 
			row--; 
			col--; 
		}

		// check diag down to right
		row = y + 1;
		col = x + 1;

		while (col < _n && row < _n)
		{
			if (board[row][col]== "Q") return false;
			row++;
			col++;
		}

		// check diag up to right
		row = y - 1;
		col = x + 1;

		while (col < _n && row >= 0)
		{
			if (board[row][col] == "Q") return false;
			row--;
			col++;
		}

		// check diag down to left
		row = y + 1;
		col = x - 1;

		while (col >= 0 && row < _n)
		{
			if (board[row][col] == "Q") return false;
			row++;
			col--;
		}
		
		// no conflicts 
		return true;
	}
}

[Theory]
[InlineData(1, 1)]
[InlineData(2, 0)]
[InlineData(3, 0)]
[InlineData(4, 2)]
[InlineData(5, 10)]
[InlineData(6, 4)]
[InlineData(7, 40)]
[InlineData(8, 92)]
[InlineData(9, 352)]
[InlineData(10, 724)]
[InlineData(11, 2680)]
void Test(int n, int expected) 
{
	int result = new Solution().TotalNQueens(n); 
	Assert.Equal(expected, result); 
}

