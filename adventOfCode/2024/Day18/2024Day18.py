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

"""
Use BFS to find path through maze
"""
def part1(file_name: str, grid_size: int, bytes: int) -> int: 
    
    grid = init_grid(grid_size)
    points = load_input(file_name)

    for i in range(bytes):
        grid[points[i].y][points[i].x] = '#'
    
    position = Point(0, 0)
    goal = Point(grid_size - 1, grid_size - 1)
    q = []
    seen = []
    count = -1
    q.append((position, 0))
    while len(q) > 0: 
        position, count = q.pop(0)
        if position == goal: 
            break
    
        # north
        next_position = Point(position.x + North.x, position.y + North.y)
        if inbounds(next_position, grid_size) and not next_position in seen and grid[next_position.y][next_position.x] == '.':
            seen.append(next_position)
            q.append((next_position, count + 1))
        
        # east
        next_position = Point(position.x + East.x, position.y + East.y)
        if inbounds(next_position, grid_size) and not next_position in seen and grid[next_position.y][next_position.x] == '.':
            seen.append(next_position)
            q.append((next_position, count + 1))
        
        # south
        next_position = Point(position.x + South.x, position.y + South.y)
        if inbounds(next_position, grid_size) and not next_position in seen and grid[next_position.y][next_position.x] == '.':
            seen.append(next_position)
            q.append((next_position, count + 1))
        
        # west
        next_position = Point(position.x + West.x, position.y + West.y)
        if inbounds(next_position, grid_size) and not next_position in seen and grid[next_position.y][next_position.x] == '.':
            seen.append(next_position)
            q.append((next_position, count + 1))

    return count

""" 
Find all possible paths first, then add additional points until 
they are all blocked. Returns the first point where there is no path
"""
def part2(file_name: str, grid_size: int, start_bytes: int) -> Point: 
    
    def try_step(position: Point, direction: Direction, path: list[Point]): 
        next_position = Point(position.x + direction.x, position.y + direction.y)
        next_step = Step(position, next_position)
        if inbounds(next_position, grid_size) and not next_step.reverse_step() in seen and grid[next_position.y][next_position.x] == '.':
            seen.append(next_step)
            new_path = path.copy()
            new_path.append(next_position)
            q.append((next_position, new_path))

    grid = init_grid(grid_size)
    points = load_input(file_name)
    paths = []
    for i in range(start_bytes):
        grid[points[i].y][points[i].x] = '#'
    
    position = Point(0, 0)
    goal = Point(grid_size - 1, grid_size - 1)
    q = []
    seen = []
    
    q.append((position, [position]))
    while len(q) > 0: 
        position, path = q.pop(0)
        if position == goal: 
            paths.append(path)
    
        try_step(position, North, path)
        try_step(position, East, path)
        try_step(position, South, path)
        try_step(position, West, path)

    # find point where all paths are gone
    for i in range(start_bytes, len(points)):
        point = points[i]
        grid[point.y][point.x] = '#'

def prune_paths(paths: list[list[Point]], position: Point):
    new_list = []
    for path in 

def main(): 
    file_name = "input.txt"
    grid_size = 71
    bytes = 1024
    start_time = datetime.now()
    result = part1(file_name, grid_size, bytes)
    end_time = datetime.now()
    difference = end_time - start_time
    print(f"Part 1 result for {file_name}: {result} in {difference.seconds} seconds")

def test_part1(): 
    file_name = "sample.txt"
    expected = 22
    grid_size = 7
    bytes = 12
    result = part1(file_name, grid_size, bytes)
    assert(result == expected)

if __name__ == "__main__":
    pytest.main([__file__])
    main()
