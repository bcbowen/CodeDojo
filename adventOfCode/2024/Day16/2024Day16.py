import pytest
from pathlib import Path
from collections import namedtuple
from dataclasses import dataclass
import heapq

Direction = namedtuple('Direction', ['y', 'x'])
Point = namedtuple('Point', ['y', 'x'])
East = Direction(0, 1)
West = Direction(0, -1)
South = Direction(1, 0)
North = Direction(-1, 0)

@dataclass(order=True)
class Position: 
    cost: int
    location: Point
    orientation: Direction
    

def get_input_filepath(file_name: str) -> str:
    current_path = Path(__file__).parent
    day = current_path.name
    current_path = current_path.parent
    year = current_path.name

    # traverse up directories to the private files
    private_files_base = current_path.parents[2] / "adventOfCodePrivateFiles"

    input_path = private_files_base / year / day / file_name
    return input_path

def load_inputs(file_name : str) -> list[list[str]]: 
    path = get_input_filepath(file_name)
    with open(path, "r") as file: 
        return [list(line.strip()) for line in file.readlines()]

def find_start_position(grid: list[list[str]]) -> Point: 
    for row in range(len(grid)): 
        for col in range(len(grid[0])): 
            if grid[row][col] == 'S': 
                return Point(row, col)
    raise Exception("Start point not found")

"""
    Get directions 90 degrees from the current direction i.e. (turning left or right)
"""
def get_turning_directions(direction : Direction) -> list[Direction]:
    if direction in [East, West]: 
        return [North, South]
    else: 
        return [East, West]
        

def part1(file_name: str) -> int: 
    min_cost = float("inf")
    grid = load_inputs(file_name)
    seen = set()
    location = find_start_position(grid)
    position_q = []
    heapq.heapify(position_q)
    position = Position(0, location, East)
    heapq.heappush(position_q, position)
    #seen.add(location)
    while len(position_q) > 0: 
        current_position = heapq.heappop(position_q)
        if grid[current_position.location.y][current_position.location.x] == 'E': 
            min_cost = min(min_cost, current_position.cost)
        else: 
            # check current direction
            next_location = Point(current_position.location.y + current_position.orientation.y, current_position.location.x + current_position.orientation.x)
            edge = ((current_position.location.y, current_position.location.x), (next_location.y, next_location.x))
            
            if not edge in seen and grid[next_location.y][next_location.x] != '#': 
                seen.add(edge)
                position = Position(current_position.cost + 1, next_location, current_position.orientation)
                heapq.heappush(position_q, position)
            
            turns = get_turning_directions(current_position.orientation)
            for orientation in turns: 
                next_location = Point(current_position.location.y + orientation.y, current_position.location.x + orientation.x)
                edge = ((current_position.location.y, current_position.location.x), (next_location.y, next_location.x))
                if not next_location in seen and grid[next_location.y][next_location.x] != '#': 
                    seen.add(edge)
                    position = Position(current_position.cost + 1000, next_location, orientation)
                    heapq.heappush(position_q, position)

    return min_cost


def main(): 
    file_name = "input.txt"
    result = part1(file_name) 
    print(f"Part 1 for {file_name}: {result}")


@pytest.mark.parametrize("file_name, expected", [
    ("sample1.txt", 7036), 
    ("sample2.txt", 11048)
])
def test_part1(file_name: str, expected: int): 
    result = part1(file_name)
    assert(result == expected)

def test_find_start_position(): 
    file_name = "sample1.txt"
    grid = load_inputs(file_name)
    expected = Point(13, 1)
    result = find_start_position(grid)
    assert(result == expected)

def test_load_inputs(): 
    grid = load_inputs("sample1.txt")
    assert(len(grid) == 15)

if __name__ == "__main__": 
    pytest.main([__file__])
    #main()