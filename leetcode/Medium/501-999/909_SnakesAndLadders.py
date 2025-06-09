import math
import pytest
from collections import deque
from typing import List, Tuple

class Solution:

    def snakesAndLadders(self, board: List[List[int]]) -> int:

        q = deque() 
        game_on = True
        # initial rolls (1 - 6) 
        moves = 0
        current = (len(board) - 1, 0)
        while game_on: 
            moves += 1
            for _ in range(6):
                next = Solution.get_next(
        
        
        return moves

    """
    16 15 14 13
    09 10 11 12
    08 07 06 05
    01 02 03 04

    
    07 08 09
    06 05 04
    01 02 03
    
    get_next: for the given space, get the coordinates for the next space. For even rows 
    this will be the space to the right or above the last column in the row. For odd rows 
    this will be the space to the left or above the first column in the row.

    size = l = w
    for odd sizes, even rows go l -> r
    for even sizes, odd rows go l -> r
    """
    @staticmethod
    def get_final(board: List[List[int]]) -> Tuple[int, int]: 
        
        is_even = len(board) % 2 == 0
        # if we're already at the first space we can't move any more, stay put
        if is_even: 
            return (0,0)
        
        return (0, len(board) - 1)
        

    """
    16 15 14 13
    09 10 11 12
    08 07 06 05
    01 02 03 04

    
    07 08 09
    06 05 04
    01 02 03
    
    get_next: for the given space, get the coordinates for the next space. For even rows 
    this will be the space to the right or above the last column in the row. For odd rows 
    this will be the space to the left or above the first column in the row.

    size = l = w
    for odd sizes, even rows go l -> r
    for even sizes, odd rows go l -> r
    """
    @staticmethod
    def get_next(board: List[List[int]], current: Tuple[int, int]) -> Tuple[int, int]: 
        size = len(board)
        is_even = size % 2 == 0

        # if we're already at the first space we can't move any more, stay put
        final = Solution.get_final(board)
        if current == final: 
            return current       
        
        row, col = current

        if is_even: 
            # for even sizes, odd rows go l -> r
            if row % 2 == 1: 
                # ltr
                if col < size - 1: 
                    # room to move in current row
                    return (row, col + 1)
                else: 
                    # this is the end, next row up
                    return (row - 1, size - 1)
            else: 
                # rtl
                if col > 0: 
                    #room to move in current row
                    return (row, col - 1)
                else: 
                    # this is the end, next row up
                    return (row - 1, 0)
        else: 
            # for odd sizes, even rows go l -> r
            if row % 2 == 0: 
                # ltr
                if col < size - 1: 
                    # room to move in current row
                    return (row, col + 1)
                else: 
                    # this is the end, next row up
                    return (row - 1, size - 1)
            else: 
                # rtl
                if col > 0: 
                    #room to move in current row
                    return (row, col - 1)
                else: 
                    # this is the end, next row up
                    return (row - 1, 0)

    """
    Translate space into coordinates
    16 15 14 13
    09 10 11 12
    08 07 06 05
    01 02 03 04
    """
    @staticmethod
    def get_coordinates(board: List[List[int]], space: int) -> tuple[int, int]:
        # The board is square so rows == cols
        side = len(board[0])
        
        row = Solution.get_row(side, space)
        col = Solution.get_col(side, space)
        return (row, col)
    
    @staticmethod
    def get_col(row_size: int, space: int) -> int: 
        if space == 1: 
            return 0
        
        row = Solution.get_row(row_size, space)
        if row % 2 == 1:
            col = row_size - 1 if space % row_size == 0 else space % row_size - 1
        else:
            col = 0 if space % row_size == 0 else row_size - 1 - (space % row_size - 1)
        return col

    @staticmethod
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
@pytest.mark.parametrize("size, jumps, expected", [
    (6, [(3, 1, 35), (3, 4, 13), (5,1,15)], 4),
    (2, [(1, 1, 3)], 1)
])
def test_snakesAndLadders(size: int, jumps: List[Tuple[int, int, int]], expected: int):
    board = generate_board(size, jumps)
    result = Solution().snakesAndLadders(board)
    assert(result == expected)

@pytest.mark.parametrize("size, jumps, space, expected", [
    (6, [(3, 1, 35), (3, 4, 13), (5,1,15)], 1, (5, 0)),
    (6, [(3, 1, 35), (3, 4, 13), (5,1,15)], 8, (4, 4)),
    (6, [(3, 1, 35), (3, 4, 13), (5,1,15)], 28, (1, 3)),
    (6, [(3, 1, 35), (3, 4, 13), (5,1,15)], 36, (0, 0)),
    (2, [(1, 1, 3)], 3, (0, 1)),
    (2, [(1, 1, 3)], 4, (0, 0)),
    (2, [(1, 1, 3)], 1, (1, 0))
])
def test_get_coordinates(size: int, jumps: List[Tuple[int, int, int]], space: int, expected: tuple[int, int]):
    board = generate_board(size, jumps)
    result = Solution().get_coordinates(board, space)
    assert(result == expected)

def generate_board(size: int, jumps: List[Tuple[int, int, int]]) -> List[List[int]]: 
    board = [[-1] * size] * size
    for jump in jumps: 
        row, col, space = jump
        board[row][col] = space

    return board

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

"""
16 15 14 13
09 10 11 12
08 07 06 05
01 02 03 04

These tests assume an empty 4X4 board which will be generated to reduce the complexity of the test params
"""
@pytest.mark.parametrize("current, expected", [
    ((3, 0), (3, 1)),
    ((3, 1), (3, 2)),
    ((3, 2), (3, 3)),
    ((3, 3), (2, 3)),
    ((2, 3), (2, 2)),
    ((2, 2), (2, 1)),
    ((2, 1), (2, 0)),
    ((2, 0), (1, 0)),
    ((1, 3), (0, 3)),
    ((0, 1), (0, 0)), 
    ((0, 0), (0, 0))
])
def test_get_next_even(current: Tuple[int, int], expected: Tuple[int, int]): 
    # generate 4x4 board
    size = 4
    board = generate_board(size, []) #[[-1] * 4] * 4
    result = Solution.get_next(board, current)
    assert(result == expected)

"""
07 08 09
06 05 04
01 02 03

These tests assume an empty 4X4 board which will be generated to reduce the complexity of the test params
"""
@pytest.mark.parametrize("current, expected", [
    ((2, 0), (2, 1)),
    ((2, 1), (2, 2)),
    ((2, 2), (1, 2)),
    ((1, 2), (1, 1)),
    ((1, 1), (1, 0)),
    ((1, 0), (0, 0)),
    ((0, 0), (0, 1)),
    ((0, 1), (0, 2)),
    ((0, 2), (0, 2))
])
def test_get_next_odd(current: Tuple[int, int], expected: Tuple[int, int]): 
    # generate 3x3 board
    size = 3
    board = generate_board(3, []) #[[-1] * 3] * 3
    result = Solution.get_next(board, current)
    assert(result == expected)

@pytest.mark.parametrize("size, expected", [
    (3, (0, 2)),
    (5, (0, 4)),
    (4, (0, 0)),
    (6, (0, 0))
])
def test_get_final(size: int, expected: Tuple[int, int]): 
    # generate 3x3 board
    board = generate_board(size, [])
    result = Solution.get_final(board)
    assert(result == expected)

"""
    6x6: 
    [
        [-1,-1,-1,-1,-1,-1],
        [-1,-1,-1,-1,-1,-1],
        [-1,-1,-1,-1,-1,-1],
        [-1,35,-1,-1,13,-1],
        [-1,-1,-1,-1,-1,-1],
        [-1,15,-1,-1,-1,-1]
    ]

    2x2: 
    [
        [-1,-1],
        [-1,3]
    ]

    4x4 no jumps: 
    [
        [-1,-1,-1,-1],
        [-1,-1,-1,-1],
        [-1,-1,-1,-1],
        [-1,-1,-1,-1]
    ]

    3x3 no jumps: 
    [
        [-1,-1,-1],
        [-1,-1,-1],
        [-1,-1,-1]
    ]
"""
def test_generate_board(size: int, jumps: List[Tuple[int, int, int]]): 
    board = generate_board(size, jumps)
    assert(len(board) == size)
    assert(len(board[0]) == size)
    for jump in jumps: 
        row, col, val = jump
        assert(board[row][col] == val)

if __name__ == "__main__":
    pytest.main([__file__])