import pytest
import hashlib
from collections import deque
#from typing import List, Tuple, Deque

# Up, Down, Left, Right
UP = 0
DOWN = 1
LEFT = 2
RIGHT = 3
directions = [(-2, 0), (2, 0), (0, -2), (0, 2)]
#lock_directions = [(-1, 0), (1, 0), (0, -1), (0, 1)]

"""
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
"""

# current position is in the playable area on the board
def is_inbounds(row: int, col: int) -> bool: 
    if row < 1 or row > 7: 
        return False
    if col < 1 or col > 7: 
        return False
    return True
"""
def is_unlocked(board: List[List[str]], current: Tuple[int, int], next: Tuple[int, int]) -> bool: 
    cy, cx = current
    ny, nx = next

    dy = int((ny - cy) / 2)
    dx = int((nx - cx) / 2)

    return board[cy + dy][cx + dx] == ' '

def unlock(board: List[List[str]], position: Tuple[int, int], direction : int): 
    d = lock_directions[direction]
    unlock_positon = (position[0] + d[0], position[1] + d[1])
    board[unlock_positon[0]][unlock_positon[1]] = ' '

def check_path(board: List[List[str]]) -> bool: 
    destination = (8, 8)
    current = (1, 1)
    seen = set()
    q = deque()
    q.append(current)
    seen.add(current)
    while q: 
        current = q.popleft()
        if current == destination: 
            return True
        current_y, current_x = current
        for d in directions: 
            next_y = current_y + d[0]
            next_x = current_x + d[1]
            if not (next_y, next_x) in seen and is_inbounds(next_y, next_x) and is_unlocked(board, (current_y, current_x), (next_y, next_x)): 
                q.append((next_y, next_x))
                seen.add((next_y, next_x))

    return False



@pytest.mark.parametrize("board, expected", [
    ([
	['#', '#', '#', '#', '#', '#', '#', '#', '#'],
    ['#', 'S', '|', ' ', '|', ' ', '|', ' ', '#'],
    ['#', '-', '#', '-', '#', '-', '#', '-', '#'],
    ['#', ' ', '|', ' ', '|', ' ', '|', ' ', '#'],
    ['#', '-', '#', '-', '#', '-', '#', '-', '#'],
    ['#', ' ', '|', ' ', '|', ' ', '|', ' ', '#'],
    ['#', '-', '#', '-', '#', '-', '#', '-', '#'],
    ['#', ' ', '|', ' ', '|', ' ', '|', ' ', ' '],
    ['#', '#', '#', '#', '#', '#', '#', ' ', 'V']
    ], False), 
    ([
	['#', '#', '#', '#', '#', '#', '#', '#', '#'],
    ['#', 'S', ' ', ' ', '|', ' ', '|', ' ', '#'],
    ['#', '-', '#', ' ', '#', '-', '#', '-', '#'],
    ['#', ' ', '|', ' ', ' ', ' ', '|', ' ', '#'],
    ['#', '-', '#', '-', '#', ' ', '#', '-', '#'],
    ['#', ' ', '|', ' ', '|', ' ', '|', ' ', '#'],
    ['#', '-', '#', '-', '#', ' ', '#', '-', '#'],
    ['#', ' ', '|', ' ', '|', ' ', ' ', ' ', ' '],
    ['#', '#', '#', '#', '#', '#', '#', ' ', 'V']
    ], True), 
    ([
	['#', '#', '#', '#', '#', '#', '#', '#', '#'],
    ['#', 'S', '|', ' ', '|', ' ', '|', ' ', '#'],
    ['#', '-', '#', ' ', '#', '-', '#', '-', '#'],
    ['#', ' ', '|', ' ', ' ', ' ', '|', ' ', '#'],
    ['#', '-', '#', '-', '#', ' ', '#', '-', '#'],
    ['#', ' ', '|', ' ', '|', ' ', '|', ' ', '#'],
    ['#', '-', '#', '-', '#', ' ', '#', '-', '#'],
    ['#', ' ', '|', ' ', '|', ' ', ' ', ' ', ' '],
    ['#', '#', '#', '#', '#', '#', '#', ' ', 'V']
    ], False), 
    ([
	['#', '#', '#', '#', '#', '#', '#', '#', '#'],
    ['#', 'S', '|', ' ', '|', ' ', '|', ' ', '#'],
    ['#', ' ', '#', '-', '#', '-', '#', '-', '#'],
    ['#', ' ', '|', ' ', '|', ' ', '|', ' ', '#'],
    ['#', ' ', '#', '-', '#', '-', '#', '-', '#'],
    ['#', ' ', ' ', ' ', '|', ' ', '|', ' ', '#'],
    ['#', '-', '#', ' ', '#', '-', '#', '-', '#'],
    ['#', ' ', '|', ' ', ' ', ' ', ' ', ' ', ' '],
    ['#', '#', '#', '#', '#', '#', '#', ' ', 'V']
    ], True), 
])
def test_check_path(board: List[List[str]], expected: bool): 
    result = check_path(board)
    assert(result == expected)

@pytest.mark.parametrize("board, current, next, expected", [
    ([
	['#', '#', '#', '#', '#', '#', '#', '#', '#'],
    ['#', 'S', '|', ' ', '|', ' ', '|', ' ', '#'],
    ['#', '-', '#', '-', '#', '-', '#', '-', '#'],
    ['#', ' ', '|', ' ', '|', ' ', '|', ' ', '#'],
    ['#', '-', '#', '-', '#', '-', '#', '-', '#'],
    ['#', ' ', '|', ' ', '|', ' ', '|', ' ', '#'],
    ['#', '-', '#', '-', '#', '-', '#', '-', '#'],
    ['#', ' ', '|', ' ', '|', ' ', '|', ' ', ' '],
    ['#', '#', '#', '#', '#', '#', '#', ' ', 'V']
    ], (5, 3), (3, 3), False), 
    ([
	['#', '#', '#', '#', '#', '#', '#', '#', '#'],
    ['#', 'S', '|', ' ', '|', ' ', '|', ' ', '#'],
    ['#', '-', '#', '-', '#', '-', '#', '-', '#'],
    ['#', ' ', '|', ' ', '|', ' ', '|', ' ', '#'],
    ['#', '-', '#', '-', '#', '-', '#', '-', '#'],
    ['#', ' ', ' ', ' ', '|', ' ', '|', ' ', '#'],
    ['#', '-', '#', '-', '#', '-', '#', '-', '#'],
    ['#', ' ', '|', ' ', '|', ' ', '|', ' ', ' '],
    ['#', '#', '#', '#', '#', '#', '#', ' ', 'V']
    ], (5, 3), (5, 1), True), 
    ([
	['#', '#', '#', '#', '#', '#', '#', '#', '#'],
    ['#', 'S', '|', ' ', '|', ' ', '|', ' ', '#'],
    ['#', '-', '#', '-', '#', '-', '#', '-', '#'],
    ['#', ' ', '|', ' ', '|', ' ', '|', ' ', '#'],
    ['#', '-', '#', ' ', '#', '-', '#', '-', '#'],
    ['#', ' ', '|', ' ', '|', ' ', '|', ' ', '#'],
    ['#', '-', '#', '-', '#', '-', '#', '-', '#'],
    ['#', ' ', '|', ' ', '|', ' ', '|', ' ', ' '],
    ['#', '#', '#', '#', '#', '#', '#', ' ', 'V']
    ], (5, 3), (3, 3), True), 
])
def test_is_unlocked(board: List[List[str]], current: Tuple[int, int], next: Tuple[int, int], expected: bool): 
    result = is_unlocked(board, current, next)
    assert(result == expected)

"""

"""
Board: 
S: start
V: vault
#########
#S| | | #
#-#-#-#-#
# | | | #
#-#-#-#-#
# | | | #
#-#-#-#-#
# | | |  
####### V
"""

# udlr
def get_shortest_path(start_code: str) -> str:
    def is_open(c: str) -> bool: 
        return c.isalpha() and c != 'a'
    
    #board = init_board()
    val = hashlib.md5(start_code.encode()).hexdigest()
    current = (1, 1)
    goal = (7, 7)
    q = deque()
    # only d and r can be unlocked from the initial position
    if val[DOWN].isalpha(): 
        row, col = current[0] + directions[DOWN][0], current[1] + directions[DOWN][1]
        q.append((start_code + "D", (row, col)))

    if val[RIGHT].isalpha(): 
        row, col = current[0] + directions[RIGHT][0], current[1] + directions[RIGHT][1]
        q.append((start_code + "R", (row, col)))

    while q: 
        path, current = q.popleft()
        if current == goal: 
            return path[len(start_code):]
        
        val = hashlib.md5(path.encode()).hexdigest()

        if is_open(val[UP]): 
            row, col = current[0] + directions[UP][0], current[1] + directions[UP][1]
            if is_inbounds(row, col): 
                q.append((path + "U", (row, col)))
            
        if is_open(val[DOWN]): 
            row, col = current[0] + directions[DOWN][0], current[1] + directions[DOWN][1]
            if is_inbounds(row, col): 
                q.append((path + "D", (row, col)))

        if is_open(val[RIGHT]): 
            row, col = current[0] + directions[RIGHT][0], current[1] + directions[RIGHT][1]
            if is_inbounds(row, col): 
                q.append((path + "R", (row, col))) 
    
        if is_open(val[LEFT]): 
            row, col = current[0] + directions[LEFT][0], current[1] + directions[LEFT][1]
            if is_inbounds(row, col): 
                q.append((path + "L", (row, col)))

    return "NOPE"

def main(): 
    start_code = "edjrjqaa"
    result = get_shortest_path(start_code)
    print(f"Part1 result: {result}")

def part1(start_code: str) -> str: 
    result = get_shortest_path(start_code)
    return result


def test_part1(): 
    start_code = "ihgpwlah"
    expected = "DDRRRD"
    result = get_shortest_path(start_code)
    assert(result == expected)

"""
If your passcode were ihgpwlah, the shortest path would be DDRRRD.  
With kglvqrro, the shortest path would be DDUDRLRRUDRD.
With ulqzkmiv, the shortest would be DRURDRUDDLLDLUURRDULRLDUUDDDRR. 
"""
@pytest.mark.parametrize("start_code, expected", [
    ("hijkl", "NOPE"),
    ("ihgpwlah", "DDRRRD"), 
    ("kglvqrro", "DDUDRLRRUDRD"), 
    ("ulqzkmiv", "DRURDRUDDLLDLUURRDULRLDUUDDDRR")
])
def test_get_shortest_path(start_code: str, expected: str): 
    result = get_shortest_path(start_code)
    assert(result == expected)

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

"""
def test_init_board(): 
    board = init_board()
    assert(len(board) == 9)
    assert(len(board[0]) == 9)
    assert(board[0][0] == '#')
    assert(board[1][2] == '|')
    assert(board[1][1] == 'S')
    assert(board[8][8] == 'V')
"""


if __name__ == "__main__": 
    pytest.main([__file__])
    main()