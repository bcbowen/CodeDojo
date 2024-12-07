import pytest
from pathlib import Path
from collections import namedtuple


Direction = namedtuple('Direction', ['y', 'x'])
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

def load_input(file_name: str) -> list[list[str]]: 
    path = get_input_filepath(file_name)
    with open(path, "r") as file: 
        grid = [list(line.strip()) for line in file.readlines()]

    return grid

def turn(currentDirection : Direction) -> Direction: 
    match currentDirection: 
        case Direction(-1, 0):  # North
            return East
        case Direction(0, 1):  # East
            return South
        case Direction(1, 0):  # South
            return West
        case _:  # Default case
            return North

def find_start(grid : list[list[str]]) -> tuple[int, int]: 
    for row in range(len(grid)): 
        for col in range(len(grid[row])): 
            if grid[row][col] == '^': 
                return row, col
    raise Exception("Start not found in grid!")

def exited( grid : list[list[str]], pos: tuple[int, int]) -> bool: 
    upper_boundary = len(grid)
    if pos[0] < 0 or pos[1] < 0 or pos[0] >= upper_boundary or pos[1] >= upper_boundary: 
        return True
    return False


def part1(file_name: str) -> int: 
    grid = load_input(file_name)
    count = 1
    current_pos = find_start(grid)
    current_direction = North
    seen = 'o'
    block = '#'
    empty = '.'

    while not exited(grid, current_pos): 
        next_pos = tuple(a + b for a, b in zip(current_pos, current_direction)) #current_pos + current_direction
        if exited(grid, next_pos): 
            current_pos = next_pos
            continue
        if grid[next_pos[0]][next_pos[1]] == block: 
            current_direction = turn(current_direction)
            continue        
        current_pos = next_pos
        if grid[current_pos[0]][current_pos[1]] == empty: 
            grid[current_pos[0]][current_pos[1]] = seen
            count += 1
    #for row in grid: 
    #    print(row)            
    return count


def part2(file_name: str): 
    grid = load_input(file_name)
    count = 0
    current_pos = find_start(grid)
    start_pos = current_pos
    current_direction = North
    block = '#'
    empty = '.'
    found = set()

    while not exited(grid, current_pos): 
        next_pos = tuple(a + b for a, b in zip(current_pos, current_direction)) #current_pos + current_direction
        if exited(grid, next_pos): 
            current_pos = next_pos
            continue
        if grid[next_pos[0]][next_pos[1]] == block: 
            current_direction = turn(current_direction)
            continue        
        current_pos = next_pos
        
        grid[current_pos[0]][current_pos[1]] = block
        if test_cycle(grid, start_pos) and not current_pos in found:
            found.add(current_pos) 
            count += 1
        grid[current_pos[0]][current_pos[1]] = empty
    return count


def test_cycle(grid: list[list[str]], start_pos : tuple[int, int]) -> bool: 
    current_direction = North
    current_pos = start_pos
    visited = set()
    checking = True
    block = '#'
    while checking: 
        next_pos = tuple(a + b for a, b in zip(current_pos, current_direction)) #current_pos + current_direction
        if exited(grid, next_pos): 
            checking = False
            continue
        
        if grid[next_pos[0]][next_pos[1]] == block: 
            current_direction = turn(current_direction)
            continue        
        current_pos = next_pos
        if (current_pos, current_direction) in visited:
            return True 
        else: 
            visited.add((current_pos, current_direction))
    return False


def main(): 
    # part 1:
    result = part1("sample.txt")
    print(f"Sample part1: {result}")
    
    result = part1("input.txt")
    print(f"Part1: {result}")
    
    # part 2:
    result = part2("sample.txt")
    print(f"Sample part2: {result}")
    result = part2("input.txt")
    print(f"Part2: {result}")

def test_part1(): 
    file_name = "sample.txt" 
    result = part1(file_name)
    expected = 41
    assert(result == expected)

def test_part2(): 
    file_name = "sample.txt" 
    expected = 6
    result = part2(file_name)
    assert(result == expected)

def test_load(): 
    grid = load_input("sample.txt")
    assert(len(grid) == 10)
    assert(len(grid[0]) == 10)
    assert(grid[0][0] == '.')
    assert(grid[9][6] == '#')

if __name__ == "__main__": 
    pytest.main([__file__])
    main()
