import pytest
from pathlib import Path
from enum import Enum

class Direction(Enum): 
    Up = 1, 
    Down = 2,
    Left = 3, 
    Right = 4
    Invalid = -1


def get_input_filepath(file_name: str): 
    current_path = Path(__file__).parent
    day = current_path.name
    current_path = current_path.parent
    year = current_path.name

    # traverse up directories to the private files 
    private_files_base = current_path.parents[2] / "adventOfCodePrivateFiles"
    
    input_path = private_files_base / year / day / file_name
    return input_path

def load_map(file_name: str) -> list[list[str]]: 
    input_map = []
    path = get_input_filepath(file_name)
    with open(path, "r") as file: 
        input_map = [list(line.strip()) for line in file.readlines()]

    return input_map


"""
| is a vertical pipe connecting north and south.
- is a horizontal pipe connecting east and west.
L is a 90-degree bend connecting north and east.
J is a 90-degree bend connecting north and west.
7 is a 90-degree bend connecting south and west.
F is a 90-degree bend connecting south and east.
. is ground; there is no pipe in this tile.
S is the starting position of the animal;
"""

def get_direction(start: tuple[int, int], end: tuple[int, int]): 
    if start[0] != end[0] and start[1] != end[1]: 
        return Direction.Invalid
    # horizontal move: 
    if start[0] == end[0]:
        return Direction.Right if start[1] < end[1] else Direction.Left

    # vertical move: 
    if start[1] == end[1]: 
        return Direction.Up if start[0] < end[0] else Direction.Down 
    
    return Direction.Invalid
 
def is_valid_move(direction: Direction, value: str) -> bool: 
    if value == '.' or direction == Direction.Invalid: 
        return False
    
    match direction: 
        case Direction.Up: 
            return value in ['|', '7', 'F']
        case Direction.Down: 
            return value in ['|', 'L', 'J']
        case Direction.Right: 
            return value in ['-', 'J', '7']
        case Direction.Left: 
            return value in ['-', 'L', 'F']
        

def map_path(file_name: str) -> int: 
    raw_map = load_map(file_name)
    working_map = copy_map(raw_map)
    max = 0
    visited = []
    moveQ = []
    (x, y) = find_entry_point(working_map)
    distance = 0
    moveQ.append((x, y, distance))
    
    while len(moveQ) > 0: 
        (x, y, distance) = moveQ.pop()
        visited.append((x, y))
        # try left
        if x > 0: 
            x1 = x - 1
            c = working_map[y][x1]
        if is_valid_move(Direction.Left, c):
            moveQ.append(y, x1, distance + 1)

    

def copy_map(input_map: list[list[str]]) -> list[list[str]]: 
    copied = []
    i = 0 
    for row in input_map: 
        copied.append(list()) 
        copied[i] = row.copy()
        i += 1
    return copied

def find_entry_point(input_map: list[list[str]]) -> tuple[int, int]: 
    for row in range(len(input_map)): 
        for col in range(len(input_map[row])): 
            if input_map[row][col] == "S": 
                return (row, col)

    return (-1, -1)



def part1(file_name: str) -> int:
    pass 

def test(): 
    

    pass

"""
case Direction.Up: 
            return value in ['|', '7', 'F']
        case Direction.Down: 
            return value in ['|', 'L', 'J']
        case Direction.Right: 
            return value in ['-', 'J', '7']
        case Direction.Left: 
            return value in ['-', 'L', 'F']
        
"""

@pytest.mark.parametrize("direction, value, expected", {
    (Direction.Up, '|', True), 
    (Direction.Up, '7', True), 
    (Direction.Up, 'F', True),
    (Direction.Up, '.', False),
    (Direction.Up, 'L', False),
    (Direction.Up, 'J', False),
    (Direction.Up, '-', False),

    (Direction.Down, '|', True), 
    (Direction.Down, 'L', True), 
    (Direction.Down, 'J', True),
    (Direction.Down, '.', False),
    (Direction.Down, '7', False),
    (Direction.Down, 'F', False),
    (Direction.Down, '-', False),

    (Direction.Left, '-', True), 
    (Direction.Left, 'L', True), 
    (Direction.Left, 'F', True),
    (Direction.Left, '.', False),
    (Direction.Left, '7', False),
    (Direction.Left, 'J', False),
    (Direction.Left, '|', False),

    (Direction.Right, '-', True), 
    (Direction.Right, '7', True), 
    (Direction.Right, 'J', True),
    (Direction.Right, '.', False),
    (Direction.Right, 'L', False),
    (Direction.Right, 'F', False),
    (Direction.Right, '|', False)
})
def test_is_valid_move(direction: Direction, value: str, expected: bool):
    result = is_valid_move(direction, value)
    assert(expected == result) 


@pytest.mark.parametrize("start, end, expected", [
    ((2, 2), (3, 2), Direction.Up), 
    ((2, 2), (1, 2), Direction.Down),
    ((2, 2), (2, 3), Direction.Right),
    ((2, 2), (2, 1), Direction.Left),
    ((2, 2), (4, 4), Direction.Invalid),
])
def test_get_direction(start: tuple[int, int], end: tuple[int, int], expected: Direction): 
    result = get_direction(start, end)
    assert(expected == result)


@pytest.mark.parametrize("file_name, expected", [
    ("sample.txt", (1, 1)), 
    ("sample2.txt", (2, 0))
])
def test_find_entry_point(file_name: str, expected: tuple[int, int]): 
    test_map = load_map(file_name)
    (row, col) = find_entry_point(test_map)
    assert(expected[0] == row)
    assert(expected[1] == col)

def test_load_map1(): 
    file_name = "sample.txt"
    test_map = load_map(file_name)
    assert(len(test_map) == 5)
    assert(len(test_map[0]) == 5)
    assert(test_map[0][0] == '.')
    assert(test_map[1][1] == 'S')
    assert(test_map[1][2] == '-')
    assert(test_map[1][3] == '7')
    assert(test_map[2][1] == '|')
    assert(test_map[2][2] == '.')
    assert(test_map[2][3] == '|')
    assert(test_map[3][1] == 'L')
    assert(test_map[3][2] == '-')
    assert(test_map[3][3] == 'J')

def test_load_map2(): 
    file_name = "sample2.txt"
    test_map = load_map(file_name)
    assert(len(test_map) == 5)
    assert(len(test_map[0]) == 5)
    assert(test_map[0][0] == '.')
    assert(test_map[0][2] == 'F')
    assert(test_map[1][2] == 'J')
    assert(test_map[2][0] == 'S')
    assert(test_map[4][1] == 'J')

if __name__ == "__main__": 
    pytest.main([__file__])