import pytest
import hashlib
from collections import deque

UP = 0
DOWN = 1
LEFT = 2
RIGHT = 3
directions = [(-2, 0), (2, 0), (0, -2), (0, 2)]

# current position is in the playable area on the board
def is_inbounds(row: int, col: int) -> bool: 
    if row < 1 or row > 7: 
        return False
    if col < 1 or col > 7: 
        return False
    return True

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


# udlr
def get_longest_path_len(start_code: str) -> int:
    def is_open(c: str) -> bool: 
        return c.isalpha() and c != 'a'
    
    #board = init_board()
    val = hashlib.md5(start_code.encode()).hexdigest()
    current = (1, 1)
    goal = (7, 7)
    q = deque()
    max_path_len = -1
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
            max_path_len = max(max_path_len, len(path[len(start_code):]))
            continue
        
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

    return max_path_len

def main(): 
    start_code = "edjrjqaa"
    result1 = get_shortest_path(start_code)
    print(f"Part1 result: {result1}")

    result2 = get_longest_path_len(start_code)
    print(f"Part2 result: {result2}")

def part1(start_code: str) -> str: 
    result = get_shortest_path(start_code)
    return result

def part2(start_code: str) -> int: 
    result = get_longest_path_len(start_code)
    return result

def test_part1(): 
    start_code = "ihgpwlah"
    expected = "DDRRRD"
    result = part1(start_code)
    assert(result == expected)

def test_part2(): 
    start_code = "ihgpwlah"
    expected = 370
    result = part2(start_code)
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

"""
If your passcode were ihgpwlah, the longest path would take 370 steps.
With kglvqrro, the longest path would be 492 steps long.
With ulqzkmiv, the longest path would be 830 steps long.
"""
@pytest.mark.parametrize("start_code, expected", [
    ("hijkl", -1),
    ("ihgpwlah", 370), 
    ("kglvqrro", 492), 
    ("ulqzkmiv", 830)
])
def test_get_longest_path_len(start_code: str, expected: str): 
    result = get_longest_path_len(start_code)
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

if __name__ == "__main__": 
    pytest.main([__file__])
    main()