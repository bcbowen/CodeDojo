import pytest 
from typing import List, Tuple

class Solution:
    def numRookCaptures(self, board: List[List[str]]) -> int:
        row, col = self.findRook(board)

        captures = 0

        # up
        for r in range(row - 1, -1, -1): 
            if board[r][col] != '.': 
                if board[r][col] == 'p': 
                    captures += 1
                break
        # down
        for r in range(row + 1, len(board)): 
            if board[r][col] != '.': 
                if board[r][col] == 'p': 
                    captures += 1
                break

        # left
        for c in range(col - 1, -1, -1): 
            if board[row][c] != '.': 
                if board[row][c] == 'p': 
                    captures += 1
                break

        # right
        for c in range(col + 1, len(board[0])): 
            if board[row][c] != '.': 
                if board[row][c] == 'p': 
                    captures += 1
                break

        return captures
    
    def findRook(self, board: List[List[str]]) -> Tuple[int, int]: 
        for row in range(len(board)): 
            for col in range(len(board[row])): 
                if board[row][col] == 'R': 
                    return (row, col)
        raise Exception("Rook not found")

"""
Example 1:
Input: board = [[".",".",".",".",".",".",".","."],[".",".",".","p",".",".",".","."],[".",".",".","R",".",".",".","p"],[".",".",".",".",".",".",".","."],[".",".",".",".",".",".",".","."],[".",".",".","p",".",".",".","."],[".",".",".",".",".",".",".","."],[".",".",".",".",".",".",".","."]]
Output: 3

Explanation:
In this example, the rook is attacking all the pawns.

Example 2:
Input: board = [[".",".",".",".",".",".","."],[".","p","p","p","p","p",".","."],[".","p","p","B","p","p",".","."],[".","p","B","R","B","p",".","."],[".","p","p","B","p","p",".","."],[".","p","p","p","p","p",".","."],[".",".",".",".",".",".",".","."],[".",".",".",".",".",".",".","."]]
Output: 0

Explanation:

The bishops are blocking the rook from attacking any of the pawns.

Example 3:
Input: board = [[".",".",".",".",".",".",".","."],[".",".",".","p",".",".",".","."],[".",".",".","p",".",".",".","."],["p","p",".","R",".","p","B","."],[".",".",".",".",".",".",".","."],[".",".",".","B",".",".",".","."],[".",".",".","p",".",".",".","."],[".",".",".",".",".",".",".","."]]
Output: 3

Explanation:

The rook is attacking the pawns at positions b5, d6, and f5.
"""
@pytest.mark.parametrize("board, expected", [
    ([[".",".",".",".",".",".",".","."],[".",".",".","p",".",".",".","."],[".",".",".","R",".",".",".","p"],[".",".",".",".",".",".",".","."],[".",".",".",".",".",".",".","."],[".",".",".","p",".",".",".","."],[".",".",".",".",".",".",".","."],[".",".",".",".",".",".",".","."]], 3), 
    ([[".",".",".",".",".",".","."],[".","p","p","p","p","p",".","."],[".","p","p","B","p","p",".","."],[".","p","B","R","B","p",".","."],[".","p","p","B","p","p",".","."],[".","p","p","p","p","p",".","."],[".",".",".",".",".",".",".","."],[".",".",".",".",".",".",".","."]], 0), 
    ([[".",".",".",".",".",".",".","."],[".",".",".","p",".",".",".","."],[".",".",".","p",".",".",".","."],["p","p",".","R",".","p","B","."],[".",".",".",".",".",".",".","."],[".",".",".","B",".",".",".","."],[".",".",".","p",".",".",".","."],[".",".",".",".",".",".",".","."]], 3)
])
def test_numRookCaptures(board: List[List[str]], expected: int):
    result = Solution().numRookCaptures(board)
    assert(result == expected)

if __name__ == "__main__":
    pytest.main([__file__]) 