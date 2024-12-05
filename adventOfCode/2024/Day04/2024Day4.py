import pytest
from pathlib import Path
from collections import namedtuple

Direction = namedtuple('Direction', ['y', 'x'])
East = Direction(0, 1)
West = Direction(0, -1)
South = Direction(1, 0)
North = Direction(-1, 0)
NorthEast = Direction(-1, 1)
SouthEast = Direction(1, 1)
NorthWest = Direction(-1, -1)
SouthWest = Direction(1, -1)

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
        grid = [list(line) for line in file.readlines()]

    return grid


def search(direction, grid : list[list[str]], location: tuple[int, int]) -> bool: 

    if direction in (North, NorthWest, NorthEast) and location[0] < 3:
        return False
    
    if direction in (South, SouthWest, SouthEast) and location[0] > len(grid) - 4: 
        return False
    
    if direction in (East, NorthEast, SouthEast) and location[1] > len(grid[0]) - 4: 
        return False
    
    if direction in (West, NorthWest, SouthWest) and location[1] < 3:
        return False

    values = ['M', 'A', 'S']
    y, x = location

    for i in range(len(values)): 
        y += direction.y
        x += direction.x   
        if grid[y][x] != values[i]: 
            return False

    return True


def part1(file_name: str) -> int: 
    grid = load_input(file_name) 
    found = 0
    for row in range(len(grid)): 
        for col in range(len(grid[0])-1): 
            if grid[row][col] == 'X': 
                for direction in [North, NorthEast, East, SouthEast, South, SouthWest, West, NorthWest]:
                    if search(direction, grid, (row, col)): 
                        #print(f"Found one: {row}, {col} {direction}")
                        found += 1

    return found

"""
This should only be called when the current value is 'A'. The fields in the diags have to be 
either 'M' or 'S' and must be different either vertically or horizontally. 

M S                    M M
 A          --or--      A
M S                    S S
etc...
"""
def x_check(grid : list[list[int]], location : tuple[int, int]) -> bool: 
    
    ur = grid[location[0] - 1][location[1] + 1]
    lr = grid[location[0] + 1][location[1] + 1]
    ul = grid[location[0] - 1][location[1] - 1]
    ll = grid[location[0] + 1][location[1] - 1]

    for val in (ur, lr, ul, ll): 
        if not val in ['M', 'S']: 
            return False

    # check vertical 
    if ur != lr and ul != ll: 
        return True

    # check horizontal
    if ur != ul and lr != ll: 
        return True
    
    return False

def part2(file_name: str) -> int: 
    grid = load_input(file_name) 
    found = 0
    for row in range(1, len(grid)-2): 
        for col in range(1, len(grid)-2): 
            if grid[row][col] == 'A' and x_check(grid, (row, col)): 
                found += 1

    return found

"""
0, 4 SE
0, 5 E
1, 4 W
3, 9 S, SW
4, 0 E
4, 6 W, N
5, 0 NE
5, 6 NW
9, 1 NE
9, 3 NW,NE
9, 5 NW, NE, E
9, 9 NW, N
"""
def test1(): 
    file_name = "sample.txt"
    expected = 18
    result = part1(file_name)
    assert(result == expected)


def test2(): 
    file_name = "sample.txt"
    expected = 9
    result = part2(file_name)
    assert(result == expected)

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
    

if __name__ == "__main__": 
    pytest.main([__file__])
    main()
