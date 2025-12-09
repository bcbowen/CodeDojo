import pytest
from typing import List, Tuple
from pathlib import Path

def get_input_filepath(file_name: str) -> Path:
        current_path = Path(__file__).parent
        day = current_path.name
        current_path = current_path.parent
        year = current_path.name

        # traverse up directories to the private files
        private_files_base = current_path.parents[2] / "adventOfCodePrivateFiles"

        input_path = private_files_base / year / day / file_name
        return input_path

def get_input(file_name: str) -> List[List[str]]: 
    path = get_input_filepath(file_name)
    inputs = []
    with open(path, "r") as file: 
        inputs = [[c for c in line] for line in file.readlines()]
    return inputs 


# start is always at top in the middle
def find_start(board: List[List[str]]) -> Tuple[int, int]: 
    y = 0
    x = len(board[0]) // 2 - 1
    for i in range(3): 
        if board[y][x] == 'S': 
            return (y, x)
        x += 1
    raise(Exception("Start not found... check your logic "))

def count_splits(board: List[List[str]]) -> int: 
     
    splits = 0
    for row in range(1, len(board)): 
        for col in range(len(board[row])): 
            if board[row][col] == '^': 
                if board[row - 1][col] == '|' and board[row + 1][col - 1] == '|' and board[row + 1][col + 1] == '|': 
                    splits += 1

    return splits      

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
        row += 1
    
    #return count_splits(board)
    return split_count

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

if __name__ == "__main__":
    pytest.main([__file__])
    main()