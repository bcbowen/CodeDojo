import pytest
from pathlib import Path
from collections import namedtuple

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

def move(grid : list[list[str]], current_location: Point, direction: Direction) -> Point:
    test_location = Point(current_location.y + direction.y, current_location.x + direction.x)
    # If the immediate next cell is a barrier we don't move
    if grid[test_location.y][test_location.x] == "#": 
        return current_location
    # If it's an empty space, we can move without disturbing anything else. 
    elif grid[test_location.y][test_location.x] == ".":
        return test_location

    # Boxes to move
    moves = []
    moves.append(current_location)
    while grid[test_location.y][test_location.x] == "0": 
        moves.append(test_location)
        test_location = Point(test_location.y + direction.y, test_location.x + direction.x)

    # If the boxes are up against an obstacle, we're stuck
    if grid[test_location.y][test_location.x] == "#": 
        return current_location
    
    # looks like we can shift over, unwind the stack and get busy
    while len(moves) > 0: 
        location = moves.pop()
        grid[test_location.y][test_location.x] = grid[location.y][location.x]
        test_location = location

    return test_location

def part1(file_name : str) -> int: 
    pass

def main():
    pass

def test_move(): 
    pass

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

