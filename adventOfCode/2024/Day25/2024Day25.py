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
                       key_row[col] = len(graph) - row
                       break
        keys.append(key_row)
    else: 
        lock_row = [0] * len(graph[0])
        for col in range(len(graph[0])): 
             for row in range(len(graph)): 
                  if graph[row][col] == '.': 
                       lock_row[col] = row
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
    pass

def test_load_inputs(): 
    file_name = "sample.txt"
    locks, keys = load_inputs(file_name)
    assert(len(locks) == 2)
    assert(len(keys) == 3)

if __name__ == "__main__":
    pytest.main([__file__])
    main()