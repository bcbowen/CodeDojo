import pytest
from typing import List, Tuple
import sys
from pathlib import Path
sys.path.insert(0, str(Path(__file__).resolve().parents[2]))  # repo root
import Modules.aoc_io

@staticmethod
def get_input(file_name: str) -> List[List[str]]: 
    inputs = [[c for c in line.strip()] for line in Modules.aoc_io.read_input(2025, 7, file_name).split('\n')]
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
Empty values (.) are treated as 0
"""
@staticmethod
def combine(val1: str, val2: str) -> str:
    if val1 in ['.', 'S', '^']: 
        val1 = '0'
    if val2 in ['.', 'S', '^']: 
        val2 = '0'
    return format(int(val1, 16) + int(val2, 16), 'X')

@staticmethod
def part2(file_name: str) -> int: 
    board = get_input(file_name)
    row, col = find_start(board)
    board[row + 1][col] = '1'
    row += 1
    for row in range(2, len(board)):     
        for col in range(0, len(board[row])): 
            # If this is a splitter, cells to the left and right will have the value above
            if board[row][col] == '^':                 
                current_col_value = board[row - 1][col]
                # left
                new_val = combine(current_col_value, board[row][col - 1])
                if new_val != '0' and col > 0: 
                    board[row][col - 1] = new_val
                
                # right
                new_val = combine(current_col_value, board[row][col + 1])
                if new_val != '0' and col < len(board[row]): 
                    board[row][col + 1] = new_val
            else: 
                # not a splitter, trickle down
                if board[row - 1][col] != '.': 
                    board[row][col] = combine(board[row][col], board[row - 1][col])

    total = 0
    for col in board[-1]: 
        if col != '.': 
            total += int(col, 16)
    return total 


def main(): 
    file_name = "input.txt"
    result = part1(file_name)
    print(f"Part 1 result: {result}")

    result = part2(file_name)
    print(f"Part 2 result: {result}")

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
    assert(len(result[0]) == 15)
    assert(result[0][0] == '.')
    assert(result[0][7] == 'S')

"""
String values will either be hex digits or dots. Treat dots as 0
"""
@pytest.mark.parametrize("val1, val2, expected", [
    ('1', '2', '3'), 
    ('7', '4', 'B'), 
    ('1', '.', '1'), 
    ('.', '1', '1'), 
    ('.', '.', '0'), 
])
def test_combine(val1: str, val2: str, expected: str): 
    result = combine(val1, val2)
    assert(expected == result)

if __name__ == "__main__":
    pytest.main([__file__])
    main()