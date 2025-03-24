<Query Kind="Program">
  <Namespace>Xunit</Namespace>
</Query>

#load "xunit"

void Main()
{
	RunTests();
}

class Solution 
{
	private int[,] _board;

	private void ClearBoard() 
	{
		for (int row = 0; row < _board.GetLength(0); row++)
			for (int col = 0; col < _board.GetLength(1); col++)
				_board[row,col] = '.'; 
	}
	
	public int TotalNQueens(int n)
	{
		_board = new int[n, n];
		int count = 0; 
		for (int col = 0; col < n; col++)
		{
			ClearBoard(); 
			int row = 0; 
			PlaceQueen(row, col); 
			bool backTrack = false;
			for (row = 1; row < n; row++)
			{
				bool placed = false; 
				for (int col2 = 0; col2 <= n; col2++)
				{
					if (IsNotUnderAttack(row, col2))
					{
						PlaceQueen(row, col2);
						placed = true;
					}
					if (placed) break;
				}
				if (!placed) 
				{
					backTrack = true; 
					break; 
				}
			}
			if (!backTrack) count++; 
		}
		return count; 
	}

	bool IsNotUnderAttack(int row, int col) 
	{
		return _board[row, col] != 'X'; 
	}

	void PlaceQueen(int row, int col) 
	{
		_board[row, col] = 'Q';
		// mark rest of column 
		int y, x;
		for (y = row + 1; y < _board.GetLength(0); y++) 
		{
			_board[y, row] = 'X'; 
		}
		// check diags going down only since that is where we'll place future queens
		//  left to lower right
		
		x = col + 1;
		y = row + 1;
		while(x < _board.GetLength(1) && y < _board.GetLength(0)) 
		{
			_board[y,x] = 'X'; 
			x++; 
			y++; 
		}
		
		// diag lower left to upper right
		x = col - 1;
		y = row + 1;
		while(x >= 0 && y < _board.GetLength(0)) 
		{
			_board[y,x] = 'X'; 
			x--; 
			y++; 
		}
	}

	void RemoveQueen(int row, int col) 
	{
		
	}
	
}


/*
   (1). Overall, we iterate over each row in the board, i.e. once we reach the last row of the board, we should have explored all the 
   possible solutions.

        (2). At each iteration (we are located at certain row), we then further iterate over each column of the board, along the 
		current row. At this second iteration, we then can explore the possibility of placing a queen on a particular cell.

        (3). Before, we place a queen on the cell with index of (row, col), we need to check if this cell is under the attacking zone of the
		queens that have been placed on the board before. Let us assume there is a function called is_not_under_attack(row, col) that 
		can do the check.

        (4). Once the check passes, we then can proceed to place a queen. Along with the placement, one should also mark out the 
		attacking zone of this newly-placed queen. Let us assume there is another function called 
		place_queen(row, col) that can help us to do so.

        (5). As an important behaviour of backtracking, we should be able to abandon our previous decision at the moment we decide to 
		move on to the next candidate. Let us assume there is a function called 
		remove_queen(row, col) that can help us to revert the decision along with the changes in step (4). 
*/

// You can define other methods, fields, classes and namespaces here

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

[Fact]
void Test4() 
{
	int n = 4; 
	int expected = 2; 
	int result = new Solution().TotalNQueens(n);
	Assert.Equal(expected, result); 
}