import pytest
from pathlib import Path

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

"""
from collections import namedtuple

# Define a namedtuple to represent the direction
Direction = namedtuple('Direction', ['x', 'y'])

# Declare constants using named tuples
RTL = Direction(0, 1)
LTR = Direction(0, -1)
D = Direction(-1, 0)
U = Direction(1, 0)

# Access the values using named attributes
print(RTL.x, RTL.y)  # Output: 0 1
"""

def part1(file_name: str) -> int: 
    grid = load_input(file_name) 
    found = 0
    for row in range(len(grid)): 
        for col in range(len(row)): 
            if grid[col][row] == 'X': 
                # E

    return found

def part2(file_name: str) -> int: 
    return -1

def test1(): 
    file_name = "sample.txt"
    expected = 18
    result = part1(file_name)
    assert(result == expected)


def test2(): 
    file_name = "sample.txt"
    expected = -1
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
