import pytest
import string
from typing import List, Tuple
from pathlib import Path

@staticmethod
def get_input_filepath(file_name: str) -> Path:
        current_path = Path(__file__).parent
        day = current_path.name
        current_path = current_path.parent
        year = current_path.name

        # traverse up directories to the private files
        private_files_base = current_path.parents[2] / "adventOfCodePrivateFiles"

        input_path = private_files_base / year / day / file_name
        return input_path

@staticmethod
def get_input(file_name: str) -> List[List[str]]: 
    path = get_input_filepath(file_name)
    inputs = []
    with open(path, "r") as file: 
        inputs = [[c for c in line] for line in file.readlines()]
    return inputs 


@staticmethod
# start is always at top in the middle
def find_start(board: List[List[str]]) -> Tuple[int, int]: 
    y = 0
    x = len(board[0]) // 2 - 1
    for i in range(3): 
        if board[y][x] == 'S': 
            return (y, x)
        x += 1
    raise(Exception("Start not found... check your logic "))

@staticmethod
def count_splits(board: List[List[str]]) -> int: 
     
    splits = 0
    for row in range(1, len(board)): 
        for col in range(len(board[row])): 
            if board[row][col] == '^': 
                if board[row - 1][col] == '|' and board[row + 1][col - 1] == '|' and board[row + 1][col + 1] == '|': 
                    splits += 1

    return splits      

@staticmethod
def part1(file_name: str) -> int: 
    board = get_input(file_name)
    row, col = find_start(board)
    board[row + 1][col] = '|'
    row += 1
    split_count = 0
    while row < len(board): 
        for col in range(len(board[row])): 
            if board[row][col] == '^' and board[row - 1][col] == '|': 
                split_count += 1
                if row < len(board) - 1:
                    if col > 0: 
                        board[row + 1][col - 1] = '|'
                    if col < len(board[row]) - 1: 
                        board[row + 1][col + 1] = '|' 
            elif board[row - 1][col] == '|': 
                board[row][col] = '|'
        row += 1
    
    #return count_splits(board)
    return split_count

"""
Add 2 hex values together. Ex: '7' + '4' = 'B'
"""
@staticmethod
def combine(val1: str, val2: str) -> str:
    return format(int(val1, 16) + int(val2, 16), 'X')

@staticmethod
def part2(file_name: str) -> int: 

    """ 
    When merging left and right streams
     * If we are at the right edge (no more cols to the right), return '0'
     * If there is a splitter to the right (current row, 2 cols to the right), the val is the value above the splitter
     * if there is not a splitter to the right, and there is a value in the col to the right, it is that value
     * otherwise, '0'
    """
    def get_right_val(row: int, col: int) -> str: 
        right_edge = len(board[row]) - 1
        if col >= right_edge - 1: 
            return '0'
        if row > 1 and right_edge - col  > 2 and board[row][ col + 2] == '^' and board[row - 1][col + 2] in string.hexdigits: 
            return board[row - 1][col + 2]
        if board[row - 1][col + 1] in string.hexdigits: 
            return board[row - 1][col + 1]
        
        return '0'
    
    board = get_input(file_name)
    row, col = find_start(board)
    board[row + 1][col] = '1'
    row += 1
    #split_count = 0
    while row < len(board): 
        for col in range(len(board[row])): 
            if board[row][col] == '^' and board[row - 1][col] in string.hexdigits:
                #split_count += 1
                if row < len(board) - 1:
                    if col > 0 and board[row + 1][col - 1] == '.': 
                        board[row + 1][col - 1] = board[row - 1][col]
                    if col < len(board[row]) - 1 and board[row + 1][col + 1] == '.': 
                        right_val = get_right_val(row, col)
                        left_val = board[row - 1][col]
                        board[row + 1][col + 1] = combine(left_val, right_val)
            elif board[row - 1][col] in string.hexdigits: 
                board[row][col] = board[row - 1][col] 
        row += 1
    
    #return count_splits(board)
    total = 0
    for col in board[-1]: 
        if col != '.': 
            total += int(col, 16)
    return total 


# 1332 too low
def main(): 
    file_name = "input.txt"
    result = part1(file_name)
    print(f"Part 1 result: {result}")

def test_part1(): 
    file_name = "sample.txt"
    result = part1(file_name)
    expected = 21 
    assert(result == expected)

def test_part2(): 
    file_name = "sample.txt"
    result = part2(file_name)
    expected = 40 
    assert(result == expected)

def test_count_splits(): 
    file_name = "sample2.txt"
    board = get_input(file_name)
    expected = 21
    result = count_splits(board)
    assert(expected == result)

def test_find_start(): 
    file_name = "sample.txt"
    board = get_input(file_name)
    result = find_start(board) 
    expected = (0, 7)
    assert(result == expected)

def test_get_input(): 
    file_name = "sample.txt"
    result = get_input(file_name)
    assert(len(result) == 16)
    assert(len(result[0]) == 16)
    assert(result[0][0] == '.')
    assert(result[0][7] == 'S')

@pytest.mark.parametrize("val1, val2, expected", [
    ('1', '2', '3'), 
    ('7', '4', 'B')
])
def test_combine(val1: str, val2: str, expected: str): 
    result = combine(val1, val2)
    assert(expected == result)

if __name__ == "__main__":
    pytest.main([__file__])
    main()