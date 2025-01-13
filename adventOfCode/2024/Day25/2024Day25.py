import pytest
from pathlib import Path

def get_input_filepath(file_name: str) -> str:
        current_path = Path(__file__).parent
        day = current_path.name
        current_path = current_path.parent
        year = current_path.name

        # traverse up directories to the private files
        private_files_base = current_path.parents[2] / "adventOfCodePrivateFiles"

        input_path = private_files_base / year / day / file_name
        return input_path

def parse_grid(locks : list[list[int]], keys : list[list[int]], graph : list[list[str]]):
    # keys have top row empty
    if graph[0][0] == '.': 
        key_row = [0] * len(graph[0])
        for col in range(len(graph[0])): 
             for row in range(len(graph)): 
             
                  if graph[row][col] != '.': 
                       key_row[col] = len(graph) - row - 1
                       break
        keys.append(key_row)
    else: 
        lock_row = [0] * len(graph[0])
        for col in range(len(graph[0])): 
             for row in range(len(graph)): 
                  if graph[row][col] == '.': 
                       lock_row[col] = row - 1
                       break
        locks.append(lock_row)



def load_inputs(file_name: str) -> tuple[list[list[int]], list[list[int]]]: 
    locks : list[list[int]] = []
    keys : list[list[int]] = []
    path = get_input_filepath(file_name)
    with open(path, "r") as file:
         lines = file.readlines()
         i = 0
         while i < len(lines):  
            grid = []
            j = i + 7
            while i < j: 
                 grid.append(list(lines[i].strip()))
                 i += 1
            parse_grid(locks, keys, grid)
            i += 1
    return locks, keys

def main(): 
    file_name = "input.txt"
    result = part1(file_name)
    print(f"Part 1: {result}")

def part1(file_name : str) -> int: 
    locks, keys = load_inputs(file_name)

    fit_count = 0
    for lock in locks: 
        for key in keys:
            bad_fit = False 
            for i in range(len(key)): 
                if lock[i] + key[i] > 5: 
                        bad_fit = True
                        break
            if not bad_fit: 
                fit_count += 1
    return fit_count

def test_part1(): 
     file_name = "sample.txt"
     expected = 3
     result = part1(file_name)
     assert(result == expected)

def test_load_inputs(): 
    file_name = "sample.txt"
    locks, keys = load_inputs(file_name)
    assert(len(locks) == 2)
    assert(len(keys) == 3)

if __name__ == "__main__":
    pytest.main([__file__])
    main()