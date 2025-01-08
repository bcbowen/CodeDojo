import pytest
from pathlib import Path
from dataclasses import dataclass
from collections import namedtuple
from datetime import datetime

Direction = namedtuple('Direction', ['y', 'x'])
East = Direction(0, 1)
West = Direction(0, -1)
South = Direction(1, 0)
North = Direction(-1, 0)

@dataclass
class Point: 
     x: int
     y: int

     
@dataclass
class Step: 
    from_point: Point
    to_point: Point

    def reverse_step(self) -> 'Step': 
        return Step(from_point = self.to_point, to_point = self.from_point)
          

def get_input_filepath(file_name: str) -> str:
        current_path = Path(__file__).parent
        day = current_path.name
        current_path = current_path.parent
        year = current_path.name

        # traverse up directories to the private files
        private_files_base = current_path.parents[2] / "adventOfCodePrivateFiles"

        input_path = private_files_base / year / day / file_name
        return input_path

def load_input(file_name: str) -> list[Point]: 
    path = get_input_filepath(file_name)
    with open(path, "r") as file: 
        points = [
            Point(x=int(coords[0]), y=int(coords[1]))
            for line in file
            if (coords := line.strip().split(",")) and len(coords) == 2
        ]

    return points

def init_grid(size: int) -> list[list[int]]: 
    grid = [['.'] * size for _ in range(size)]
    return grid

def inbounds(position: Point, grid_size: int) -> bool: 
        if position.y < 0: 
            return False
        if position.x < 0: 
            return False
        if position.y >= grid_size: 
            return False
        if position.x >= grid_size: 
            return False
        return True

def populate_grid(grid : list[list[str]], points: list[Point]): 
    for point in points:
        grid[point.y][point.x] = '#'

"""
Use BFS to find path through maze
"""
def part1(file_name: str, grid_size: int, bytes: int) -> int: 
    
    grid = init_grid(grid_size)
    points = load_input(file_name)
    populate_grid(grid, points[0:bytes])
    
    count = find_path(grid)

    return count

def find_path(grid : list[list[str]]) -> int: 
    def try_step(position: Point, direction: Direction, current_count: int): 
        next_position = Point(position.x + direction.x, position.y + direction.y)
        
        if inbounds(next_position, grid_size) and not next_position in seen and grid[next_position.y][next_position.x] == '.':
            seen.append(next_position)
            q.append((next_position, current_count + 1))

    grid_size = len(grid)
    position = Point(0, 0)
    goal = Point(grid_size - 1, grid_size - 1)
    q = []
    seen = []
    count = -1
    found = False
    q.append((position, 0))
    while len(q) > 0: 
        position, count = q.pop(0)
        if position == goal: 
            found = True
            break

        try_step(position, North, count)
        try_step(position, East, count)
        try_step(position, South, count)
        try_step(position, West, count)
        

    return count if found else -1

""" 
Find all possible paths first, then add additional points until 
they are all blocked. Returns the first point where there is no path
"""
def part2(file_name: str, grid_size: int, start_bytes: int) -> Point: 
    
    
    points = load_input(file_name)

    start = 0
    end = len(points) - 1

    while start < end - 1: 
        mid = start + (end - start) // 2
        grid = init_grid(grid_size)
        populate_grid(grid, points[0:mid + 1])
        count = find_path(grid)
        if count > 0: 
            start = mid
        else: 
            end = mid

    if count > 0: 
        mid += 1

    return points[mid]


def main(): 
    file_name = "input.txt"
    grid_size = 71
    bytes = 1024
    start_time = datetime.now()
    result = part1(file_name, grid_size, bytes)
    end_time = datetime.now()
    difference = end_time - start_time
    print(f"Part 1 result for {file_name}: {result} in {difference.seconds} seconds")

    start_time = datetime.now()
    result = part2(file_name, grid_size, bytes)
    end_time = datetime.now()
    difference = end_time - start_time
    print(f"Part 2 result for {file_name}(x, y): {result.x}, {result.y} in {difference.seconds} seconds")

def test_part1(): 
    file_name = "sample.txt"
    expected = 22
    grid_size = 7
    bytes = 12
    result = part1(file_name, grid_size, bytes)
    assert(result == expected)

def test_part2(): 
    file_name = "sample.txt"
    expected = Point(6, 1)
    grid_size = 7
    start_bytes = 12
    result = part2(file_name, grid_size, start_bytes)
    assert(result == expected)

if __name__ == "__main__":
    pytest.main([__file__])
    main()
