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

        return grid, moves


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
        case 'V':
            return South
    raise Exception(f"Invalid direction: {value}")  

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
    moves = []
    moves.append(current_location)
    test_location = next_location
    while grid[test_location.y][test_location.x] == "O": 
        moves.append(test_location)
        test_location = Point(test_location.y + direction.y, test_location.x + direction.x)

    # If the boxes are up against an obstacle, we're stuck
    if grid[test_location.y][test_location.x] == "#": 
        return current_location, grid
    
    # looks like we can shift over, unwind the stack and get busy
    while len(moves) > 0: 
        location = moves.pop()
        new_grid[test_location.y][test_location.x] = new_grid[location.y][location.x]
        test_location = location
    new_grid[current_location.y][current_location.x] = '.'

    return next_location, new_grid

def part1(file_name : str) -> int: 
    pass

def main():
    pass

def test_find_robot(): 
    file_name = "sample1.txt"
    grid, _ = load_input(file_name)
    expected = Point(4, 4)
    result = find_robot(grid)
    assert(result == expected)

def print_grid(grid: list[list[str]]): 
    for row in grid: 
        print(row)

@pytest.mark.parametrize("row_in, start_position, end_position, row_out", [
    ("..@..", Point(0, 2), Point(0, 3), "...@."),
    ("..@O.", Point(0, 2), Point(0, 3), "...@O"), 
    ("..@O#", Point(0, 2), Point(0, 2), "..@O#"), 
    ("..@#.", Point(0, 2), Point(0, 2), "..@#."), 
    ("..@OO.", Point(0, 2), Point(0, 3), "...@OO"),
    ("..@O.O", Point(0, 2), Point(0, 3), "...@OO")
])
def test_move_robot2(row_in : str, start_position : Point, end_position : Point, row_out: str): 
    grid_in = []
    grid_in.append(list(row_in))
    grid_out = []
    grid_out.append(list(row_out))

    result_position, result_grid = move_robot(grid_in, start_position, East)
    assert(result_position == end_position)
    assert(result_grid == grid_out)

@pytest.mark.parametrize("moves, expected", [
    ("<<", Point(4, 2)), 
    ("<<<", Point(4, 2)), 
    ("<", Point(4, 3)), 
    ("^^^^", Point(1, 4)),
    ("^^^^^", Point(1, 4)),
    ("^^^", Point(2, 4)),
    (">>>", Point(4, 7)),
    (">>>>", Point(4, 7)),
    (">>>", Point(4, 6)),
    ("VVV", Point(7, 4)),
    ("VVVV", Point(7, 4)),
    ("VV", Point(6, 4))
])
def test_move_robot(moves : str, expected: Point): 
    file_name = "sample1.txt"
    grid, _ = load_input(file_name)
    current_location = find_robot(grid)
    for move in moves: 
        direction = get_direction(move)
        current_location, grid = move_robot(grid, current_location, direction)

    print_grid(grid)
    assert(current_location == expected)

def test_load_input(): 
    file_name = "sample2.txt"
    grid, moves = load_input(file_name)
    assert(len(grid) == 8)
    assert(len(grid[0]) == 8)
    assert(len(moves) == 1)
    assert(len(moves[0]) == 15)

if __name__ == "__main__": 
    pytest.main([__file__])
    main()

