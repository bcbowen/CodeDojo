import pytest
from typing import List 

class Solution:
    def snakesAndLadders(self, board: List[List[int]]) -> int:
        pass

"""
Example 1:
Input: board = [
                [-1,-1,-1,-1,-1,-1],
                [-1,-1,-1,-1,-1,-1],
                [-1,-1,-1,-1,-1,-1],
                [-1,35,-1,-1,13,-1],
                [-1,-1,-1,-1,-1,-1],
                [-1,15,-1,-1,-1,-1]
            ]
Output: 4
Explanation: 
In the beginning, you start at square 1 (at row 5, column 0).
You decide to move to square 2 and must take the ladder to square 15.
You then decide to move to square 17 and must take the snake to square 13.
You then decide to move to square 14 and must take the ladder to square 35.
You then decide to move to square 36, ending the game.
This is the lowest possible number of moves to reach the last square, so return 4.

Example 2:
Input: board = [
                [-1,-1],
                [-1,3]
            ]
Output: 1
"""
@pytest.mark.parametrize("board, expected", [
    ([
        [-1,-1,-1,-1,-1,-1],
        [-1,-1,-1,-1,-1,-1],
        [-1,-1,-1,-1,-1,-1],
        [-1,35,-1,-1,13,-1],
        [-1,-1,-1,-1,-1,-1],
        [-1,15,-1,-1,-1,-1]
    ], 4), 
    ([
        [-1,-1],
        [-1,3]
    ], 1)
])
def test_snakesAndLadders(board: List[List[int]], expected: int):
    result = Solution().snakesAndLadders(board)
    assert(result == expected)

if __name__ == "__main__": 
    pytest.main([__file__])