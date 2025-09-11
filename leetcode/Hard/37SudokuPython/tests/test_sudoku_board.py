import pytest
from typing import List
from modules.sudoku_board import SudokuBoard

def test_board_setup_smoke_test(): 
    board = SudokuBoard()
    
    # board should have 9 rows and 9 cols
    assert(len(board._board) == 9)
    assert(len(board._board[0]) == 9)
    assert(len(board._board[0][0].possible_values) == 9)

    # set the value of 1st cell...
    board.set_value(0, 0, 3)
    assert(board.get_value(0, 0) == 3)
    assert(board.get_value(0, 1) == 0)

    # cells in the 1st row should have removed 3 as a possible value
    assert((3 not in board._board[0][1].possible_values))
    assert((3 not in board._board[0][8].possible_values))
    
    # cell in the second row in last col should have 3 as a possible value
    assert(3 in board._board[1][8].possible_values)

    # cells in the 1st column should have removed 3 as a possible value
    assert((3 not in board._board[1][0].possible_values))
    assert((3 not in board._board[8][0].possible_values))

    # first cell should have only one possible value: 3
    assert(len(board._board[0][0].possible_values) == 1)
    assert(board._board[0][0].possible_values[0] == 3)

    # all cells in first zone should have removed 3 as a possible value
    assert((3 not in board._board[1][2].possible_values))


def get_easy_board() -> SudokuBoard: 
    values = []
    values.append(["", "9", "", "2", "1", "4", "", "", "6"])
    values.append(["2", "1", "7", "", "", "", "", "", "8"])
    values.append(["", "", "", "8", "", "9", "1", "3", ""])
    values.append(["9", "2", "", "3", "8", "", "", "6", ""])
    values.append(["", "8", "5", "", "", "", "", "2", "9"])
    values.append(["", "7", "", "9", "6", "", "", "", "5"])
    values.append(["7", "", "", "", "5", "1", "2", "", ""])
    values.append(["4", "", "", "", "", "8", "7", "", ""])
    values.append(["1", "", "8", "", "2", "", "6", "", "4"])
    return SudokuBoard.parse(values)    

def test_get_easy_board(): 
    board = get_easy_board()
    assert(board._board[0][1]._value == 9)
    assert(board._board[0][0].possible_values == [3, 5, 8])
    assert(board._board[0][2].possible_values == [3])
    assert(board._board[2][2].possible_values == [4, 6])
    assert(board._board[8][7].possible_values == [5, 9])
    assert(board._board[8][0]._value == 1)
    assert(board._board[2][5]._value == 9)

def test_get_count(): 
    board = get_easy_board()
    # number of hardcoded values from the easy board above
    expected = 38
    assert(board.get_count() == expected)

def test_invalid_row_fails_validation(): 
    board = SudokuBoard()
    # set_value(r, c, v)
    board.set_value(0, 1, 1)
    board.set_value(0, 2, 2)
    board.set_value(0, 3, 3)
    board.set_value(0, 4, 4)
    board.set_value(0, 5, 5)
    board.set_value(0, 6, 1)
    expected = False
    assert(board.validate_region(0, 0, 0, 8) == expected)

def test_valid_row_passes_validation(): 
    board = SudokuBoard()
    # set_value(r, c, v)
    board.set_value(0, 1, 1)
    board.set_value(0, 2, 2)
    board.set_value(0, 3, 3)
    board.set_value(0, 4, 4)
    board.set_value(0, 5, 5)
    board.set_value(0, 6, 6)
    expected = True
    assert(board.validate_region(0, 0, 0, 8) == expected)

@pytest.mark.parametrize("row_number, expected", [
    (1, [0, 9, 0, 2, 1, 4, 0, 0, 6]), 
    (6, [0, 7, 0, 9, 6, 0, 0, 0, 5])
])
def test_get_row_cells(row_number: int, expected: List[int]): 
    board = get_easy_board()
    row = board.get_row_cells(row_number)
    assert(row == expected)

@pytest.mark.parametrize("row_number, expected", [
    (1, [0, 2, 0, 9, 0, 0, 7, 4, 1]), 
    (6, [4, 0, 9, 0, 0, 0, 1, 8, 0])
])
def test_get_col_cells(row_number: int, expected: List[int]): 
    board = get_easy_board()
    row = board.get_col_cells(row_number)
    assert(row == expected)

@pytest.mark.parametrize("zone_number, expected", [
    (1, [0, 9, 0, 2, 1, 7, 0, 0, 0]), 
    (6, [0, 6, 0, 0, 2, 9, 0, 0, 5])
])
def test_get_zone_cells(zone_number: int, expected: List[int]): 
    board = get_easy_board()
    row = board.get_zone_cells(zone_number)
    assert(row == expected)