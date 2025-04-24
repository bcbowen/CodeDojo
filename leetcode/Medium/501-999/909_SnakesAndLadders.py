import math
import pytest
from typing import List

class Solution:
    def snakesAndLadders(self, board: List[List[int]]) -> int:

        def move():
            pass
        pass

    """
    Translate space into coordinates
    16 15 14 13
    09 10 11 12
    08 07 06 05
    01 02 03 04
    """
    def get_coordinates(board: List[List[int]], space: int) -> tuple[int, int]:
        # The board is square so rows == cols
        side = len(board[0])
        
        row = Solution.get_row(side, space)
        col = Solution.get_col(side, space)
        return (row, col)
    
    def get_col(row_size: int, space: int) -> int: 
        if space == 1: 
            return 0
        
        row = Solution.get_row(row_size, space)
        if row % 2 == 1:
            col = (space - 1) % row_size
        else:
            col = row_size - (space % row_size) 
        return col


    def get_row(row_size: int, space: int) -> int:
        row = row_size - math.ceil(space / row_size)
        return row 

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

@pytest.mark.parametrize("board, space, expected", [
    ([
        [-1,-1,-1,-1,-1,-1],
        [-1,-1,-1,-1,-1,-1],
        [-1,-1,-1,-1,-1,-1],
        [-1,35,-1,-1,13,-1],
        [-1,-1,-1,-1,-1,-1],
        [-1,15,-1,-1,-1,-1]
    ], 1, (5, 0)),
    ([
        [-1,-1,-1,-1,-1,-1],
        [-1,-1,-1,-1,-1,-1],
        [-1,-1,-1,-1,-1,-1],
        [-1,35,-1,-1,13,-1],
        [-1,-1,-1,-1,-1,-1],
        [-1,15,-1,-1,-1,-1]
    ], 8, (4, 4)),
    ([
        [-1,-1,-1,-1,-1,-1],
        [-1,-1,-1,-1,-1,-1],
        [-1,-1,-1,-1,-1,-1],
        [-1,35,-1,-1,13,-1],
        [-1,-1,-1,-1,-1,-1],
        [-1,15,-1,-1,-1,-1]
    ], 28, (1, 3)),
    ([
        [-1,-1,-1,-1,-1,-1],
        [-1,-1,-1,-1,-1,-1],
        [-1,-1,-1,-1,-1,-1],
        [-1,35,-1,-1,13,-1],
        [-1,-1,-1,-1,-1,-1],
        [-1,15,-1,-1,-1,-1]
    ], 36, (0, 0)),
    ([
        [-1,-1],
        [-1,3]
    ], 3, (0, 1)),
    ([
        [-1,-1],
        [-1,3]
    ], 4, (0, 0)),
    ([
        [-1,-1],
        [-1,3]
    ], 1, (1, 0))
])
def test_get_coordinates(board : List[List[int]], space: int, expected: tuple[int, int]):
    result = Solution.get_coordinates(board, space)
    assert(result == expected)

"""
    16 15 14 13
    09 10 11 12
    08 07 06 05
    01 02 03 04
"""
@pytest.mark.parametrize("row_size, space, expected", [
    (4, 1, 0),
    (4, 2, 1),
    (4, 3, 2),
    (4, 4, 3),
    (4, 8, 0),
    (4, 10, 1),
    (4, 14, 2),
    (4, 12, 3), 
])
def test_get_col(row_size: int, space: int, expected: int): 
    result = Solution.get_col(row_size, space)
    assert(result == expected)

"""
    16 15 14 13
    09 10 11 12
    08 07 06 05
    01 02 03 04
"""
@pytest.mark.parametrize("row_size, space, expected", [
    (4, 1, 3),
    (4, 8, 2),
    (4, 9, 1),
    (4, 16, 0),
    (4, 2, 3),
    (4, 6, 2),
    (4, 12, 1),
    (4, 14, 0), 
])
def test_get_row(row_size: int, space: int, expected: int): 
    result = Solution.get_row(row_size, space)
    assert(result == expected)


if __name__ == "__main__":
    pytest.main([__file__])