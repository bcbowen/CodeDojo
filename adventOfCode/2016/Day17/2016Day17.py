import pytest
import hashlib
from collections import deque
from typing import List, Tuple

# Up, Down, Left, Right
directions = [(-2, 0), (2, 0), (0, -2), (0, 2)]

def init_board() -> List[List[str]]: 
    board = []
    board.append([c for c in "#########"])
    board.append([c for c in "#S| | | #"])
    board.append([c for c in "#-#-#-#-#"])
    board.append([c for c in "# | | | #"])
    board.append([c for c in "#-#-#-#-#"])
    board.append([c for c in "# | | | #"])
    board.append([c for c in "#-#-#-#-#"])
    board.append([c for c in "# | | |  "])
    board.append([c for c in "####### V"])

    return board


# current position is in the playable area on the board
def is_inbounds(row: int, col: int) -> bool: 
    if row < 1 or row > 7: 
        return False
    if col < 1 or col > 7: 
        return False
    return True

def is_unlocked(board: List[List[str]], current: Tuple[int, int], next: Tuple[int, int]) -> bool: 
    cy, cx = current
    ny, nx = next

    dy = int((ny - cy) / 2)
    dx = int((nx - cx) / 2)

    return board[cy + dy][cx + dx] == ' '

def check_path(board: List[List[str]]) -> bool: 
    destination = (1, 1)
    current = (8, 8)
    seen = ()
    q = deque([current])
    while q: 
        current = q.popleft()
        if current == destination: 
            return True
        current_y, current_x = current
        for d in directions: 
            next_y = current_y + d[0]
            next_x = current_x + d[1]
            if is_inbounds(next_y, next_x): 

    return False



@pytest.mark.parametrize("board, expected", [
    ([
	['#', '#', '#', '#', '#', '#', '#', '#', '#'],
    ['#', 'S', '|', ' ', '|', ' ', '|', ' ', '#'],
    ['#', '-', '#', '-', '#', '-', '#', '-', '#'],
    ['#', ' ', '|', ' ', '|', ' ', '|', ' ', ' '],
    ['#', '-', '#', '-', '#', '-', '#', '-', '#'],
    ['#', ' ', '|', ' ', '|', ' ', '|', ' ', ' '],
    ['#', '-', '#', '-', '#', '-', '#', '-', '#'],
    ['#', ' ', '|', ' ', '|', ' ', '|', ' ', ' '],
    ['#', '#', '#', '#', '#', '#', '#', ' ', 'V']
    ], False), 
])
def test_check_path(board: List[List[str]], expected: bool): 
    result = check_path(board)
    assert(result == expected)


def main(): 
    pass

def part1(): 
    pass


def test_part1(): 
    pass

@pytest.mark.parametrize("row, col, expected", [
    (1, 1, True),
    (7, 7, True), 
    (0, 1, False), 
    (1, 0, False), 
    (8, 7, False), 
    (7, 8, False)
])
def test_is_inbounds(row : int, col: int, expected: bool): 
    result = is_inbounds(row, col)
    assert(result == expected)

def test_init_board(): 
    board = init_board()
    assert(len(board) == 9)
    assert(len(board[0]) == 9)
    assert(board[0][0] == '#')
    assert(board[1][2] == '|')
    assert(board[1][1] == 'S')
    assert(board[8][8] == 'V')

if __name__ == "__main__": 
    pytest.main([__file__])