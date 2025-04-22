import pytest
from collections import deque
from pathlib import Path
from typing import List

"""
If the binary value has an even number of 1's return ., otherwise return #
"""
def calc_space_value(x: int, y: int, init_value: int) -> str:
    binary_value = bin(x**2 + 3 * x + 2 * x * y + y + y**2 + init_value)
    return '.' if binary_value.count('1') % 2 == 0 else '#'

def init_grid(init_value: int) -> List[List[int]]: 
    grid = [['-' for _ in range(init_value)] for _ in range(init_value) ]
    for row in range(len(grid)): 
        for col in range(len(grid[0])): 
            grid[row][col] = calc_space_value(col, row, init_value)
    return grid

"""
    We assume grid is square (rows = cols)
"""
def is_inbounds(location: tuple[int, int], len: int) -> bool: 
    x, y = location
    if x < 0 or x >= len: 
        return False
    if y < 0 or y >= len: 
        return False
    
    return True

def find_path_len(grid: List[List[str]], start_point: tuple[int, int], end_point: tuple[int, int]) -> int: 
    # N E S W
    # (X, Y)
    directions = [(0, -1), (1, 0), (0, 1), (-1, 0)]
    seen = set()
    seen.add(start_point)
    steps = -1
    queue = deque([(start_point, 0)])

    while queue: 
        current, step = queue.popleft()
        
        seen.add(current)
        if current == end_point: 
            steps = step
            break
        x, y = current
        for dx, dy in directions: 
            next = (x + dx, y + dy)
            if is_inbounds(next, len(grid)) and grid[next[1]][next[0]] == '.' and not next in seen: 
                queue.append((next, step + 1))

    if steps == -1:
        raise Exception("We exhausted the loop before reaching the goal. We're fucked!")
    
    #print(grid)
    return steps

"""
Count distinct locations (x, y) we can reach in 50 steps
"""
def count_locations(grid: List[List[str]], start_point: tuple[int, int]) -> int: 
    # N E S W
    # (X, Y)
    directions = [(0, -1), (1, 0), (0, 1), (-1, 0)]
    step_limit = 50
    seen = set()
    seen.add(start_point)
    queue = deque([(start_point, 0)])

    while queue: 
        current, step = queue.popleft()
        seen.add(current)
        x, y = current
        for dx, dy in directions: 
            next = (x + dx, y + dy)
            if step < step_limit and is_inbounds(next, len(grid)) and grid[next[1]][next[0]] == '.' and not next in seen: 
                queue.append((next, step + 1))

    return len(seen)

def part1(grid: List[List[str]], start_point: tuple[int, int], end_point: tuple[int, int]) -> int: 
    return find_path_len(grid, start_point, end_point)

def part2(grid: List[List[str]], start_point: tuple[int, int]) -> int: 
    return count_locations(grid, start_point)
    

def main(): 
    init_value = 1350 
    start_point = (1, 1)
    end_point = (31, 39)
    grid = init_grid(init_value)
    result = part1(grid, start_point, end_point)
    print(f"Part 1 result: {result}")

    result = part2(grid, start_point)
    print(f"Part 2 result: {result}")

def test_part1(): 
    start_point = (1, 1)
    end_point = (7, 4)
    init_value = 10 
    grid = init_grid(init_value)
    expected = 11
    result = part1(grid, start_point, end_point)
    assert(result == expected)

if __name__ == "__main__":
    pytest.main([__file__])
    main()