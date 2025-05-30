import pytest
from typing import List

def build_grid(size: int) -> List[List[int]]:
    grid = []
    for i in range(size): 
        grid.append([0] + size)

def main(): 
    val = 325489
    grid_size = find_grid_size(val)
    print(f"grid size: {grid_size}")

def find_grid_size(val: int) -> int: 
    size = 1
    max_val = 1
    while max_val < val: 
        size += 2
        max_val = size**2
    return size

if __name__ == "__main__":
    pytest.main([__file__])
    main()