import pytest
from pathlib import Path

from dataclasses import dataclass
from collections import defaultdict
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

     def __eq__(self, other: 'Point'): 
         return self.x == other.x and self.y == other.y

def get_input_filepath(file_name: str) -> str:
    current_path = Path(__file__).parent
    day = current_path.name
    current_path = current_path.parent
    year = current_path.name

    # traverse up directories to the private files
    private_files_base = current_path.parents[2] / "adventOfCodePrivateFiles"

    input_path = private_files_base / year / day / file_name
    return input_path

def load_grid(file_name : str) -> list[list[str]]: 
    path = get_input_filepath(file_name)
    with open(path, "r") as file: 
        grid = [line.strip() for line in file.readlines()]
    return grid

def find_points(grid: list[list[str]]) -> tuple[Point, Point]:
    start = None
    end = None
    for row in range(len(grid)): 
        for col in range(len(grid[0])):
            
            if grid[row][col] == 'S': 
                start = Point(col, row)
            elif grid[row][col] == 'E': 
                end = Point(col, row)

            if start and end: 
                return (start, end)
             
    return (start, end)    

def is_inbounds(p: Point, grid: list[list[str]]) -> bool: 
        if p.y < 0 or p.y >= len(grid): 
            return False
        if p.x < 0 or p.x >= len(grid[0]): 
            return False
        return True



def get_next(current: Point, direction: Direction, grid: list[list[str]]) -> tuple[Point, Direction]: 
    def get_turns(d : Direction) -> tuple[Direction, Direction]: 
        if d in [East, West]: 
            return North, South
        else: 
            return East, West    
    #def is_seen(next: Point):
    #    exists = any((tup[0].x == next.x and tup[0].y == next.y) for tup in path)
    #    return exists

    def try_direction(d: Direction) -> tuple[bool, Point]: 
        next = Point(current.x + d.x, current.y + d.y)
        #exists = is_seen(next)
        if is_inbounds(next, grid) and grid[next.y][next.x] != '#': 
            return (True, next)
        
        return (False, None)

    # try going current direction
    is_valid, next = try_direction(direction)
    if is_valid: 
        return next, direction
    
    #turn l or r: 
    d1, d2 = get_turns(direction)
    for d in [d1, d2]: 
        is_valid, next = try_direction(d)
        if is_valid: 
            return next, d
        
    raise Exception("Next point not found!")
    
def find_shortcuts(path : tuple[Point, int], grid: list[list[str]]) -> dict[int, int]: 
    def check_shortcut(d: Direction) -> Point: 
        point1 = Point(current.x + d.x, current.y + d.y)
        if is_inbounds(point1, grid) and grid[point1.y][point1.x] == "#": 
            point2 = Point(point1.x + d.x, point1.y + d.y)
            if is_inbounds(point2, grid) and grid[point2.y][point2.x] != "#": 
                return point2
        return None
    
    def calc_savings(shortcut : Point, start_index : int, start_step: int):
        for i in range(start_index, len(path)): 
            point, step = path[i]
            if point.x == shortcut.x and point.y == shortcut.y: 
                diff = step - start_step - 2
                return diff
        return -1

    shortcut_counts = defaultdict(int)
    for i, (current, step) in enumerate(path): 
        # check east
        shortcut = check_shortcut(East)
        if shortcut: 
            savings = calc_savings(shortcut, i, step)
            shortcut_counts[savings] += 1

        shortcut = check_shortcut(South)
        if shortcut: 
            savings = calc_savings(shortcut, i, step)
            shortcut_counts[savings] += 1

        shortcut = check_shortcut(West)
        if shortcut: 
            savings = calc_savings(shortcut, i, step)
            shortcut_counts[savings] += 1

        shortcut = check_shortcut(North)
        if shortcut: 
            savings = calc_savings(shortcut, i, step)
            shortcut_counts[savings] += 1
        
    return shortcut_counts

def part1(file_name : str) -> dict[int, int]:
    path = [] 
    grid = load_grid(file_name)
    start, end = find_points(grid)
    step = 0
    current = start
    direction = East
    path.append((current, step))
    
    while current != end:
        step += 1
        current, direction = get_next(current, direction, grid)
        path.append((current, step))    
    shortcuts = find_shortcuts(path, grid)
    return shortcuts
    
# 398 is too low
def main(): 
    file_name = "input.txt"
    shortcuts = part1(file_name)
    total = 0
    
    for key in shortcuts.keys(): 
        print(f"There are {shortcuts[key]} cheats that save {key}")
        if key >= 100: 
            total += 1
    print("Part1 result: ", total)
    

def test_part1(): 
    file_name = "sample.txt"
    shortcuts = part1(file_name)
    
    for key in shortcuts.keys(): 
        print(f"There are {shortcuts[key]} cheats that save {key}")
    

if __name__ == "__main__":
    pytest.main([__file__])
    main()