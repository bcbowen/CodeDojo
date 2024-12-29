import pytest
from pathlib import Path
from collections import namedtuple
import copy 

Direction = namedtuple('Direction', ['y', 'x'])
Point = namedtuple('Point', ['y', 'x'])
East = Direction(0, 1)
West = Direction(0, -1)
South = Direction(1, 0)
North = Direction(-1, 0)

def get_input_filepath(file_name: str):
    current_path = Path(__file__).parent
    day = current_path.name
    current_path = current_path.parent
    year = current_path.name

    # traverse up directories to the private files
    private_files_base = current_path.parents[2] / "adventOfCodePrivateFiles"

    input_path = private_files_base / year / day / file_name
    return input_path

def expand_grid(grid : list[list[str]]) -> list[list[str]]:
    new_grid = [] 
    for row in grid: 
        new_row = [] 
        for c in row: 
            if c == '@': 
                new_row.extend(['@', '.'])
            elif c == "O": 
                new_row.extend(['[', ']'])
            else: 
                new_row.extend([c, c])
        new_grid.append(new_row)
    return new_grid

def load_input(file_name : str) -> tuple[list[list[str]], list[str]]:
    path = get_input_filepath(file_name)
    with open(path, "r") as file: 
        lines = file.readlines()
        grid = []
        for index, line in enumerate(lines): 
            if line.strip() == "": 
                break
            grid.append(list(line.strip()))
        index += 1
        moves = [line for line in lines[index:]]

        grid = expand_grid(grid)
        return grid, moves


def load_grid(file_name : str) -> list[list[str]]:
    path = get_input_filepath(file_name)
    with open(path, "r") as file: 
        lines = file.readlines()
        grid = []
        for index, line in enumerate(lines): 
            if line.strip() == "": 
                break
            grid.append(list(line.strip()))
    return grid

def find_robot(grid : list[list[str]]) -> Point: 
    for row in range(len(grid)): 
        for col in range(len(grid[0])):
            if grid[row][col] == "@": 
                #return row, col
                return Point(row, col) 

def get_direction(value : str) -> Direction: 
    match value: 
        case '>': 
            return East
        case '<':
            return West
        case '^':  
            return North
        case 'v':
            return South
    raise Exception(f"Invalid direction: {value}")  

"""

      b2 b3     b1    b2   b1   b2     b2    b1  b1
        b1     b2 b3  b1   b2    b1   b1    b2    b2
"""
def move_box_vertically(grid : list[list[str]], current_location: Point, direction: Direction) -> tuple[Point, list[list[str]]]:
    test_location = Point(current_location.y + direction.y, current_location.x)
    if grid[test_location.y][test_location.x] == ']': 
        b1_right = Point(test_location.y, test_location.x)
        b1_left = Point(test_location.y, test_location.x - 1)
    else: 
        b1_left = Point(test_location.y, test_location.x)
        b1_right = Point(test_location.y, test_location.x + 1)

    test_location = Point(b1_left.y + direction.y, b1_left.x)

    #check for obstacle above or below b1
    if grid[test_location.y][test_location.x] == '#' or grid[test_location.y][test_location.x + 1] == '#':
        return current_location, grid

    # if there is empty space above or below both sides we can move now
    if grid[test_location.y][test_location.x] == '.' and grid[test_location.y][test_location.x + 1] == '.':         
        grid[test_location.y][test_location.x] = '['
        grid[test_location.y][test_location.x + 1] = ']'
        grid[b1_left.y][b1_left.x] = '.'
        grid[b1_right.y][b1_right.x] = '.'
        current_location = Point(current_location.y + direction.y, current_location.x)
        return current_location, grid
    
    # if there is one box directly above or below the current box
    if grid[test_location.y][test_location.x] == '[':
        b2_left = Point(test_location.y, test_location.x)
        b2_right = Point(test_location.y, test_location.x + 1)
        test_location = Point(b2_left.y + direction.y, b2_left.x)
        # we can only move if both spaces above or below b2 are empty, otherwise return unchanged
        if grid[test_location.y][test_location.x] == '.' and grid[test_location.y][test_location.x + 1] == '.':         
            grid[test_location.y][test_location.x] = '['
            grid[test_location.y][test_location.x + 1] = ']'
            grid[b1_left.y][b1_left.x] = '.'
            grid[b1_right.y][b1_right.x] = '.'
            current_location = Point(current_location.y + direction.y, current_location.x)
            
        return current_location, grid

    # if there are two boxes directly above or below the middle of the current box
    if grid[test_location.y][test_location.x] == ']' and grid[test_location.y][test_location.x + 1] == '[':
        b2_left = Point(test_location.y, test_location.x - 1)
        b2_right = Point(test_location.y, test_location.x)
        b3_left = Point(test_location.y, test_location.x + 1)
        b3_right = Point(test_location.y, test_location.x + 2)

        test_location = Point(b2_left.y + direction.y, b2_left.x)
        # we can only move if all spaces above or below b2 and b3 are empty, otherwise return unchanged
        if grid[test_location.y][test_location.x] == '.' \
         and grid[test_location.y][test_location.x + 1] == '.' \
         and grid[test_location.y][test_location.x + 2] == '.' \
         and grid[test_location.y][test_location.x + 3] == '.':       
            grid[test_location.y][test_location.x] = '['
            grid[test_location.y][test_location.x + 1] = ']'
            grid[test_location.y][test_location.x + 2] = '['
            grid[test_location.y][test_location.x + 3] = ']'
            grid[b2_left.y][b2_left.x] = '.'
            grid[b2_right.y][b2_right.x] = '['
            grid[b3_left.y][b3_left.x] = ']'
            grid[b3_right.y][b3_right.x] = '.'
            grid[b1_left.y][b1_left.x] = '.'
            grid[b1_right.y][b1_right.x] = '.'
            current_location = Point(current_location.y + direction.y, current_location.x)
            
        return current_location, grid
    
    # if there is one box halfway above or below the current box
    if grid[test_location.y][test_location.x] == ']':
        b2_left = Point(test_location.y, test_location.x - 1)
        b2_right = Point(test_location.y, test_location.x)
    elif grid[test_location.y][test_location.x + 1] == '[':
        b2_left = Point(test_location.y, test_location.x)
        b2_right = Point(test_location.y, test_location.x + 1)

    test_location = Point(b2_left.y + direction.y, b2_left.x)
    # we can only move if both spaces above b2 are empty, otherwise return unchanged
    if grid[test_location.y][test_location.x] == '.' and grid[test_location.y][test_location.x + 1] == '.':         
        grid[test_location.y][test_location.x] = '['
        grid[test_location.y][test_location.x + 1] = ']'
        grid[b1_left.y][b1_left.x] = '.'
        grid[b1_right.y][b1_right.x] = '.'
        current_location = Point(current_location.y + direction.y, current_location.x)
        
    return current_location, grid

def move_robot(grid : list[list[str]], current_location: Point, direction: Direction) -> tuple[Point, list[list[str]]]:
    next_location = Point(y=current_location.y + direction.y, x=current_location.x + direction.x)
    # If the immediate next cell is a barrier we don't move
    if grid[next_location.y][next_location.x] == "#": 
        return current_location, grid
    # If it's an empty space, we can move without disturbing anything else. 
    elif grid[next_location.y][next_location.x] == ".":
        grid[next_location.y][next_location.x] = "@"
        grid[current_location.y][current_location.x] = "."
        return next_location, grid

    # Boxes to move
    new_grid = copy.deepcopy(grid)
    # if we're moving horizontally we can push up to 2 boxes
    if direction == East or direction == West: 
        # check at end of box (2 spaces) to see if it is a space, obstacle, or another box
        test_location = Point(current_location.y, current_location.x + 3 * direction.x)
        if grid[test_location.y][test_location.x] == '#': 
            # we're blocked, return current grid and location unchanged
            return current_location, grid    
        elif grid[test_location.y][test_location.x] == '.':
            new_grid[test_location.y][test_location.x] = ']'
            test_location = Point(current_location.y, current_location.x + 2 * direction.x)
            new_grid[test_location.y][test_location.x] = '['
            test_location = Point(current_location.y, current_location.x + direction.x)
            new_grid[test_location.y][test_location.x] = '@'
            new_grid[current_location.y][current_location.x] = '.'
        else: 
            # 2 boxes next to each other, we can only move if the next value is empty
            test_location = Point(current_location.y, current_location.x + 5 * direction.x)
            if grid[test_location.y][test_location.x] != '.': 
                return current_location, grid
            # move both boxes
            new_grid[test_location.y][test_location.x] = ']'
            test_location = Point(current_location.y, current_location.x + 4 * direction.x)
            new_grid[test_location.y][test_location.x] = '['
            test_location = Point(current_location.y, current_location.x + 3 * direction.x)
            new_grid[test_location.y][test_location.x] = ']'
            test_location = Point(current_location.y, current_location.x + 2 * direction.x)
            new_grid[test_location.y][test_location.x] = '['
            test_location = Point(current_location.y, current_location.x + direction.x)
            new_grid[test_location.y][test_location.x] = '@'
            new_grid[current_location.y][current_location.x] = '.'
    else: 
        # moving up or down
        test_location = Point(current_location.y, current_location.x + direction.x)
        if grid[test_location.y][test_location.x] == '#': 
            # we're blocked, return current grid and location unchanged
            return current_location, grid    
        elif grid[test_location.y][test_location.x] == '.':
            new_grid[test_location.y][test_location.x] = ']'
            test_location = Point(current_location.y, current_location.x + 2 * direction.x)
            new_grid[test_location.y][test_location.x] = '['
            test_location = Point(current_location.y, current_location.x + direction.x)
            new_grid[test_location.y][test_location.x] = '@'
            new_grid[current_location.y][current_location.x] = '.'
        else: 
            next_location, new_grid = move_box_vertically(grid, current_location, direction)
    
    return next_location, new_grid

def part2(file_name : str) -> int: 
    grid, moves = load_input(file_name)
    current_location = find_robot(grid)
    for line in moves: 
        for move in line.strip(): 
            direction = get_direction(move)
            current_location, grid = move_robot(grid, current_location, direction)

    return get_gps_total(grid)

def main():
    file_name = "input.txt"
    result = part2(file_name)
    print(f"Part 2 result: {result}")

def get_gps_total(grid: list[list[str]]) -> int: 
    gps_score = lambda y, x : y * 100 + x

    total = 0
    for y in range(len(grid)): 
        for x in range(len(grid[0])): 
            if grid[y][x] == "O": 
                total += gps_score(y, x)
    return total

@pytest.mark.parametrize("file_name, expected", [
    ("sample4.txt", 10092), 
    ("sample3.txt", 2028)
])
def test_get_gps_total(file_name: str, expected: int): 
    grid, _ = load_input(file_name)
    result = get_gps_total(grid)
    assert(result == expected)

# larger example, the sum of all boxes' GPS coordinates is 10092. In the smaller example, the sum is 2028.

def test_find_robot(): 
    file_name = "sample1.txt"
    grid, _ = load_input(file_name)
    expected = Point(4, 8)
    result = find_robot(grid)
    assert(result == expected)

def print_grid(grid: list[list[str]]): 
    for row in grid: 
        print(row)

def test_move_robot(): 
    file_name = "part2_move_sample_1.txt"
    grid, moves = load_input(file_name)

    file_name = "part2_move_sample_2.txt"
    expected_grid = load_grid(file_name)
    assert(grid == expected_grid)

    current_location = find_robot(grid)
    move_index = 0
    move = moves[0][move_index] 
    direction = get_direction(move)
    current_location, grid = move_robot(grid, current_location, direction)
    file_name = "part2_move_sample_3.txt"
    expected_grid = load_grid(file_name)
    assert(grid == expected_grid)

    #print_grid(grid)
    #assert(current_location == expected)


def test_load_input(): 
    file_name = "sample1.txt"
    # load grid and moves from original input:
    grid, moves = load_input(file_name)

    # load transformed grid sample: 
    file_name = "sample_2_before.txt"
    expanded_grid = load_grid(file_name)

    assert(grid == expanded_grid)
    assert(len(moves) == 10)

if __name__ == "__main__": 
    pytest.main([__file__])
    #main()

